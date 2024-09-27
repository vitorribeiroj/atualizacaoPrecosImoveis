using ImoveisPrecoDesktopApp.Models;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.Services
{
    internal static class SvcFinanciamento
    {
        private static string connectionString = db.DB.ConnectionStringImoveisDB;

        
        public static void BuscarFinanciamentoPorImovel(int idImovel)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    SELECT * FROM financiamento WHERE idImovel = @idImovel", conn);

                command.Parameters.AddWithValue("@idImovel", idImovel);

                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);                    

                    if(dataTable.Rows.Count > 0)
                    {                        
                        var row = dataTable.Rows[0];

                        //Financiamento financiamento = new Financiamento();
                        Financiamento.ExisteFinanciamentoCadastrado = true;
                        Financiamento.IdFinanciamento = int.Parse(row["id"].ToString());
                        Financiamento.ValorImovel = double.Parse(row["valorImovel"].ToString());
                        Financiamento.ValorEntrada = double.Parse(row["entrada"].ToString());
                        Financiamento.ValorFinanciado = double.Parse(row["valorFinanciado"].ToString());
                        Financiamento.Prazo = int.Parse(row["prazo"].ToString());
                        Financiamento.SistemaAmortizacao = (SistemaAmortizacao)Enum
                                                           .Parse(typeof(SistemaAmortizacao), row["sistemaAmortizacao"].ToString());
                        Financiamento.TaxaAnualJuros = double.Parse(row["taxaAnualJuros"].ToString());
                        Financiamento.TaxaAdministracao = double.Parse(row["taxaAdministracao"].ToString());
                        Financiamento.ValorSeguro = double.Parse(row["valorSeguro"].ToString());
                        Financiamento.DataFinanciamento = DateTime.Parse(row["dataFinanciamento"].ToString());
                        Financiamento.IdImovel = int.Parse(row["idImovel"].ToString());
                        Financiamento.ParcelasFinanciamento = JsonConvert.DeserializeObject<Dictionary<int, ParcelaFinanciamento>>(row["parcelas"].ToString());
                        Financiamento.Amortizacoes = JsonConvert.DeserializeObject<Dictionary<string, Amortizacao>>(row["amortizacoes"].ToString());

                        ContarNumeroParcelasFinanciamentoPagas();
                        CalcularSaldoRestante();


                        //return financiamento;
                    }

                    //return null;
                }
            }
        }
                
        public static void CadastrarFinanciamento()
        {
            SvcCorrecaoMonetaria.BuscarHistoricoTR(Financiamento.DataFinanciamento);

            CalcularParcelas();
            CalcularSaldoRestante();

            string parcelasJson = JsonConvert.SerializeObject(Financiamento.ParcelasFinanciamento);

            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    INSERT INTO financiamento (valorImovel, entrada, valorFinanciado, prazo, sistemaAmortizacao,
                                               taxaAnualJuros, taxaAdministracao, valorSeguro, dataFinanciamento, idImovel, parcelas)
                    VALUES (@valorImovel, @entrada, @valorFinanciado, @prazo, @sistemaAmortizacao, @taxaAnualJuros,
                            @taxaAdministracao, @valorSeguro, @dataFinanciamento, @idImovel, @parcelas)", conn);

                command.Parameters.AddWithValue("@valorImovel", Financiamento.ValorImovel);
                command.Parameters.AddWithValue("@entrada", Financiamento.ValorEntrada);
                command.Parameters.AddWithValue("@valorFinanciado", Financiamento.ValorFinanciado);
                command.Parameters.AddWithValue("@prazo", Financiamento.Prazo);
                command.Parameters.AddWithValue("@sistemaAmortizacao", Financiamento.SistemaAmortizacao.ToString());
                command.Parameters.AddWithValue("@taxaAnualJuros", Financiamento.TaxaAnualJuros);
                command.Parameters.AddWithValue("@taxaAdministracao", Financiamento.TaxaAdministracao);
                command.Parameters.AddWithValue("@valorSeguro", Financiamento.ValorSeguro);
                command.Parameters.AddWithValue("@dataFinanciamento", Financiamento.DataFinanciamento.ToShortDateString());
                command.Parameters.AddWithValue("@idImovel", Financiamento.IdImovel);
                command.Parameters.AddWithValue("@parcelas", parcelasJson);

                command.ExecuteNonQuery();
            }
        }
                
        private static void CalcularParcelas()
        {           
            if(Financiamento.SistemaAmortizacao == SistemaAmortizacao.SAC)
            {
                var saldoFinanciamento = Financiamento.ValorFinanciado;

                var jurosMensais = Math.Pow((1 + Financiamento.TaxaAnualJuros / 100), 1.0 / 12.0) - 1;

                //var indicesCorrecao = SvcCorrecaoMonetaria.BuscarHistoricoTR(Financiamento.DataFinanciamento);

                for (int i = 0; i < Financiamento.Prazo; i++)
                {
                    ParcelaFinanciamento parcela = new ParcelaFinanciamento();

                    parcela.NumeroParcela = i + 1;

                    parcela.DataVencimento = Financiamento.DataFinanciamento.AddMonths(i + 1);

                    //double indiceCorrecao = 0;

                    SvcCorrecaoMonetaria.indicesCorrecao.TryGetValue(Financiamento.DataFinanciamento.AddMonths(i), out double indiceCorrecao);

                    parcela.CorrecaoMonetaria = saldoFinanciamento * indiceCorrecao / 100;

                    saldoFinanciamento += parcela.CorrecaoMonetaria;

                    parcela.ValorAmortizacao = saldoFinanciamento / (Financiamento.Prazo - i);
                    parcela.ValorJuros = saldoFinanciamento * jurosMensais;
                    parcela.ValorTaxaAdministracao = Financiamento.TaxaAdministracao;
                    parcela.ValorSeguro = Financiamento.ValorSeguro;

                    Financiamento.ParcelasFinanciamento.Add((i + 1), parcela);

                    saldoFinanciamento -= parcela.ValorAmortizacao;
                }
            }
        }
                
        private static void CalcularSaldoRestante()
        {
            var saldo = Financiamento.ValorFinanciado;

            foreach(var parcela in Financiamento.ParcelasFinanciamento.Values)
            {
                if (parcela.FoiPaga)
                {
                    saldo += (parcela.CorrecaoMonetaria - parcela.ValorAmortizacao);
                }
            }
            if(Financiamento.Amortizacoes is not null)
            {
                saldo -= Financiamento.Amortizacoes.Values.Sum(valor => valor.Valor);
            }

            Financiamento.SaldoRestante = saldo;            
        }

        public static void AmortizarFinanciamento()
        {
            string amortizacoesJson = JsonConvert.SerializeObject(Financiamento.Amortizacoes);               

            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    UPDATE financiamento
                    SET amortizacoes = @amortizacoes                        
                    WHERE idImovel=@idImovel;", conn);

                command.Parameters.AddWithValue("@amortizacoes", amortizacoesJson);
                command.Parameters.AddWithValue("@idImovel", Financiamento.IdImovel);

                command.ExecuteNonQuery();
            }

            CalcularSaldoRestante();
            RecalcularParcelas();
            AtualizarParcelas();
        }

        //public static void AtualizarParcelas()        {
            
        //    string parcelas = JsonConvert.SerializeObject(Financiamento.ParcelasFinanciamento);

        //    SQLitePCL.Batteries.Init();

        //    using (SqliteConnection conn = new SqliteConnection(connectionString))
        //    {
        //        conn.Open();

        //        var command = new SqliteCommand(@"
        //            UPDATE financiamento
        //            SET parcelas = @parcelas                                                
        //            WHERE idImovel=@idImovel;", conn);

        //        command.Parameters.AddWithValue("@parcelas", parcelas);                
        //        command.Parameters.AddWithValue("@idImovel", Financiamento.IdImovel);

        //        command.ExecuteNonQuery();
        //    }
        //}

        private static void ContarNumeroParcelasFinanciamentoPagas()
        {
            Financiamento.NumeroParcelasPagas = 0;

            foreach (var parcela in Financiamento.ParcelasFinanciamento.Values)
            {
                if (parcela.FoiPaga)
                {
                    Financiamento.NumeroParcelasPagas++;
                }
            }            
        }

        public static void AtualizarParcelas()
        {
            string parcelas = JsonConvert.SerializeObject(Financiamento.ParcelasFinanciamento);

            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    UPDATE financiamento
                    SET parcelas = @parcelas                        
                    WHERE idImovel=@idImovel;", conn);

                command.Parameters.AddWithValue("@parcelas", parcelas);
                command.Parameters.AddWithValue("@idImovel", Financiamento.IdImovel);

                command.ExecuteNonQuery();
            }

            //AtualizarParcelas();
            CalcularSaldoRestante();
        }

        //public static void AlterarStatusParcela()
        //{
        //    string parcelas = JsonConvert.SerializeObject(Financiamento.ParcelasFinanciamento);

        //    SQLitePCL.Batteries.Init();

        //    using (SqliteConnection conn = new SqliteConnection(connectionString))
        //    {
        //        conn.Open();

        //        var command = new SqliteCommand(@"
        //            UPDATE financiamento
        //            SET parcelas = @parcelas                        
        //            WHERE idImovel=@idImovel;", conn);

        //        command.Parameters.AddWithValue("@parcelas", parcelas);
        //        command.Parameters.AddWithValue("@idImovel", Financiamento.IdImovel);

        //        command.ExecuteNonQuery();
        //    }

        //    //AtualizarParcelas();
        //    CalcularSaldoRestante();
        //}

        public static void RecalcularParcelas()
        {
            if (Financiamento.SistemaAmortizacao == SistemaAmortizacao.SAC)
            {
                var saldoFinanciamento = Financiamento.SaldoRestante;

                var jurosMensais = Math.Pow((1 + Financiamento.TaxaAnualJuros / 100), 1.0 / 12.0) - 1;

                //Dictionary<DateTime, double> indicesCorrecao = SvcCorrecaoMonetaria.BuscarHistoricoTR(Financiamento.DataFinanciamento);

                for (int i = Financiamento.NumeroParcelasPagas; i < Financiamento.Prazo; i++)
                {
                    ParcelaFinanciamento parcela = new ParcelaFinanciamento();

                    parcela.NumeroParcela = i + 1;

                    parcela.DataVencimento = Financiamento.DataFinanciamento.AddMonths(i + 1);

                    //double indiceCorrecao = 0;

                    SvcCorrecaoMonetaria.indicesCorrecao.TryGetValue(Financiamento.DataFinanciamento.AddMonths(i), out double indiceCorrecao);

                    parcela.CorrecaoMonetaria = saldoFinanciamento * indiceCorrecao / 100;

                    saldoFinanciamento += parcela.CorrecaoMonetaria;

                    parcela.ValorAmortizacao = saldoFinanciamento / (Financiamento.Prazo - i);
                    parcela.ValorJuros = saldoFinanciamento * jurosMensais;
                    parcela.ValorTaxaAdministracao = Financiamento.TaxaAdministracao;
                    parcela.ValorSeguro = Financiamento.ValorSeguro;

                    Financiamento.ParcelasFinanciamento[i + 1] = parcela;

                    //Financiamento.ParcelasFinanciamento.Add((i + 1), parcela);

                    saldoFinanciamento -= parcela.ValorAmortizacao;
                }
            }
        }

        public static void DeletarFinanciamento()
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    DELETE FROM financiamento WHERE idImovel = @idImovel", conn);

                command.Parameters.AddWithValue("@idImovel", Financiamento.IdImovel);

                command.ExecuteNonQuery();
            }
        }
        
    }

}

