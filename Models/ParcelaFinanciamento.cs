using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.Models
{
    public class ParcelaFinanciamento
    {
        public int NumeroParcela { get; set; }
        public double ValorAmortizacao { get; set; }
        public double ValorJuros { get; set; }
        public double CorrecaoMonetaria { get; set; }
        public double IndiceCorrecao { get; set; }
        public double ValorTaxaAdministracao { get; set; }
        public double ValorSeguro { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool FoiPaga { get; set; } = false;

        public double ValorParcela
        {
            get
            {
                return ValorAmortizacao + ValorJuros + ValorTaxaAdministracao + ValorSeguro;
            }
        }
    }
}
