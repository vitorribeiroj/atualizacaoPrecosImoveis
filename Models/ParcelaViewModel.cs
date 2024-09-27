using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.Models
{
    public class ParcelaViewModel
    {
        public int NumeroParcela { get; set; }
        public string ValorParcela { get; set; }
        public string ValorAmortizacao { get; set; }
        public string ValorJuros { get; set; }
        public string CorrecaoMonetaria { get; set; }        
        public string ValorTaxaAdministracao { get; set; }
        public string ValorSeguro { get; set; }
        public DateTime DataVencimento { get; set; }
        public string FoiPaga { get; set; }
    }
}
