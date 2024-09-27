using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.Models
{
    public class DespesaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }        
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public string DataPagamento { get; set; }
        public string DedutivelIR { get; set; } = "N";
        public int ImovelId { get; set; }


    }
}
