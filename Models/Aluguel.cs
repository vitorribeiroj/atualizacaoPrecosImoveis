using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.Models
{
    public class Aluguel
    {
        public int Id { get; set; }
        public double Valor { get; set; }        
        public double TaxaIntermediacao { get; set; }
        public double TaxaAdministracao { get; set; }
        public double ImpostoDeRenda { get; set; }
        public int IdImovel { get; set; }

        public double ValorLiquido { 
            get 
            {
                return (12 * Valor * (1 - TaxaAdministracao / 100) - (Valor * TaxaIntermediacao / 100))
                                    * (1 - ImpostoDeRenda / 100) / 12;
            }
        }
    }
}
