
using System.ComponentModel;

namespace ImoveisPrecoDesktopApp.Models
{
    public class Despesa
    {        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DespesaTipo Tipo { get; set; }
        public DateTime DataPagamento { get; set; }
        public string DedutivelIR { get; set; } = "N";
        public int ImovelId { get; set; }        
    }

    public enum DespesaTipo
    {
        [Description("Manuten��o")]
        MANUTENCAO,

        [Description("Imposto")]
        IMPOSTO,

        [Description("Entrada de financiamento")]
        ENTRADA_FINANCIAMENTO,

        [Description("Parcela de financiamento")]
        PARCELA_FINANCIAMENTO,

        [Description("Servi�o de despachante")]
        DESPACHANTE,

        [Description("Servi�os cartor�rios e notariais")]
        CARTORIO,

        [Description("Projeto (arquitet�nico, interior, paisagismo)")]
        PROJETO,

        [Description("M�veis planejados")]
        MOBILIA_FIXA,

        [Description("Despesas gerais")]
        DESPESAS_GERAIS,

        [Description("Outros")]
        OUTROS,

        [Description("Amortiza��o de financiamento")]
        AMORTIZACAO_FINANCIAMENTO,
    }
}