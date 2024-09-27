namespace ImoveisPrecoDesktopApp.Models
{
    public class Receita
    {
     
        public int Id { get; set; }
        
        public string Descricao { get; set; }
        
        public double Valor { get; set; }
        
        public ReceitaTipo Tipo { get; set; }
        
        public DateTime DataRecebimento { get; set; }
        
        public int ImovelId { get; set; }
       
    }

    public enum ReceitaTipo
    {
        [Description("Aluguel")]
        ALUGUEL,

        [Description("Venda")]
        VENDA,

        [Description("Outros")]
        OUTROS
    }
}