using ImoveisPrecoDesktopApp.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.Services
{
    internal static class SvcDespesas
    {

        private static string connectionString = db.DB.ConnectionStringImoveisDB;

        public static void AdicionarDespesa(DespesaViewModel despesaViewModel)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    INSERT INTO despesas (descricao, classificacao, valor, data_pagamento, dedutivel_IR, id_imovel)
                    VALUES (@descricao, @classificacao, @valor, @data_pagamento, @dedutivel_IR, @id_imovel)", conn);

                command.Parameters.AddWithValue("@descricao", despesaViewModel.Descricao);
                command.Parameters.AddWithValue("@classificacao", despesaViewModel.Tipo);
                command.Parameters.AddWithValue("@valor", despesaViewModel.Valor);
                command.Parameters.AddWithValue("@data_pagamento", despesaViewModel.DataPagamento);
                command.Parameters.AddWithValue("@dedutivel_IR", despesaViewModel.DedutivelIR);
                command.Parameters.AddWithValue("@id_imovel", despesaViewModel.ImovelId);

                command.ExecuteNonQuery();
            }            
        }

        public static DataTable CarregarDespesasPorImovel(int id_imovel)
        { 
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    SELECT * FROM despesas WHERE id_imovel = @id_imovel", conn);

                command.Parameters.AddWithValue("@id_imovel", id_imovel);

                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);                    

                    return Utils.ConvertColumnToDateTime(dataTable, "data_pagamento");
                }
            }
        }

        public static DataTable CarregarDespesaPorId(int idDespesa)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    SELECT * FROM despesas WHERE id = @idDespesa", conn);

                command.Parameters.AddWithValue("@idDespesa", idDespesa);

                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return Utils.ConvertColumnToDateTime(dataTable, "data_pagamento");
                }
            }
        }

        public static void ExcluirDespesa(int idDespesa)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();               

                var command = new SqliteCommand(@"
                    DELETE FROM despesas WHERE id = @idDespesa", conn);

                command.Parameters.AddWithValue("@idDespesa", idDespesa);

                command.ExecuteNonQuery();
            }            
        }

        public static void ExcluirDespesaDeFinanciamento(DespesaViewModel despesa)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    DELETE FROM despesas
                    WHERE classificacao = @classificacao
                          
                          AND data_pagamento = @data_pagamento
                          AND id_imovel = @id_imovel", conn);

                command.Parameters.AddWithValue("@classificacao", despesa.Tipo);
                //command.Parameters.AddWithValue("@valor", despesa.Valor);
                command.Parameters.AddWithValue("@data_pagamento", despesa.DataPagamento);
                command.Parameters.AddWithValue("@id_imovel", despesa.ImovelId);

                command.ExecuteNonQuery();
            }
        }

        public static void ExcluirDespesaDeAmortizacao(DespesaViewModel despesa)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    DELETE FROM despesas
                    WHERE classificacao = @classificacao
                          AND valor = @valor
                          AND data_pagamento = @data_pagamento
                          AND id_imovel = @id_imovel", conn);

                command.Parameters.AddWithValue("@classificacao", despesa.Tipo);
                command.Parameters.AddWithValue("@valor", despesa.Valor);
                command.Parameters.AddWithValue("@data_pagamento", despesa.DataPagamento);
                command.Parameters.AddWithValue("@id_imovel", despesa.ImovelId);

                command.ExecuteNonQuery();
            }
        }

        public static void EditarDespesa(DespesaViewModel despesa)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    UPDATE despesas
                    SET descricao = @descricao,
                        classificacao = @classificacao,
                        valor = @valor,
                        data_pagamento = @data_pagamento,
                        dedutivel_IR = @dedutivel_IR
                    WHERE id=@idDespesa;", conn);

                command.Parameters.AddWithValue("@idDespesa", despesa.Id);
                command.Parameters.AddWithValue("@descricao", despesa.Descricao);
                command.Parameters.AddWithValue("@classificacao", despesa.Tipo);
                command.Parameters.AddWithValue("@valor", despesa.Valor);
                command.Parameters.AddWithValue("@data_pagamento", despesa.DataPagamento);
                command.Parameters.AddWithValue("@dedutivel_IR", despesa.DedutivelIR);

                command.ExecuteNonQuery();
            }

        }

    }
}
