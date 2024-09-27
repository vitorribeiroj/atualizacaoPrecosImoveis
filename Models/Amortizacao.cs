using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.Models
{
    public class Amortizacao
    {
        public double Valor { get; set; }
        public string MeioDeAmortizacao { get; set; }
        public DateTime DataAmortizacao { get; set; }

        public Amortizacao(double valor, string meioDeAmortizacao, DateTime dataAmortizacao)
        {
            Valor = valor;
            MeioDeAmortizacao = meioDeAmortizacao;
            DataAmortizacao = dataAmortizacao;
        }
    }

    public enum MeioDeAmortizacao
    {
        [Description("FGTS")]
        FGTS,

        [Description("Débito comum")]
        DEBITO_COMUM
    }
}
