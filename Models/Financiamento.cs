using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.Models
{
    public static class Financiamento
    {
        public static bool ExisteFinanciamentoCadastrado { get; set; } = false;
        public static int IdFinanciamento { get; set; }
        public static double ValorImovel { get; set; }
        public static double ValorEntrada { get; set; }
        public static double ValorFinanciado { get; set; }
        public static int Prazo { get; set; }
        public static SistemaAmortizacao SistemaAmortizacao { get; set; }
        public static double TaxaAnualJuros { get; set; }
        public static double TaxaAdministracao { get; set; }
        public static double ValorSeguro { get; set; }
        public static DateTime DataFinanciamento { get; set; }
        public static int IdImovel { get; set; }
        public static Dictionary<int, ParcelaFinanciamento> ParcelasFinanciamento { get; set; } = new Dictionary<int, ParcelaFinanciamento> { };
        public static double SaldoRestante { get; set; }
        public static int NumeroParcelasPagas { get; set; } = 0;
        public static Dictionary<string, Amortizacao> Amortizacoes { get; set; } = new Dictionary<string, Amortizacao> { };
        public static double PagamentoAcumulado
        {
            get
            {
                double soma = 0;

                for(int i = 1; i <= NumeroParcelasPagas; i++)
                {
                    soma += ParcelasFinanciamento[i].ValorParcela;
                }

                return soma;
            }
        }

        //public override string ToString()
        //{
        //    return $"Financiamento #{IdFinanciamento}\n" +
        //           $"Valor imóvel: {ValorImovel}\n" +
        //           $"Valor entrada: {ValorEntrada}\n" +
        //           $"Prazo: {Prazo} meses"
        //           ;
        //}

        public static void ResetarFinanciamento()
        {
            ExisteFinanciamentoCadastrado = false;
            ValorImovel = 0;
            ValorEntrada = 0;
            ValorFinanciado = 0;
            SaldoRestante = 0;
            NumeroParcelasPagas = 0;
            ParcelasFinanciamento = new Dictionary<int, ParcelaFinanciamento> { };
            Amortizacoes = new Dictionary<string, Amortizacao> { };

        }
    }


    public enum SistemaAmortizacao
    {
        SAC,
        PRICE
    }   


}
