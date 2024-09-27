
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
        [Description("Manutenção")]
        MANUTENCAO,

        [Description("Imposto")]
        IMPOSTO,

        [Description("Entrada de financiamento")]
        ENTRADA_FINANCIAMENTO,

        [Description("Parcela de financiamento")]
        PARCELA_FINANCIAMENTO,

        [Description("Serviço de despachante")]
        DESPACHANTE,

        [Description("Serviços cartorários e notariais")]
        CARTORIO,

        [Description("Projeto (arquitetônico, interior, paisagismo)")]
        PROJETO,

        [Description("Móveis planejados")]
        MOBILIA_FIXA,

        [Description("Despesas gerais")]
        DESPESAS_GERAIS,

        [Description("Outros")]
        OUTROS,

        [Description("Amortização de financiamento")]
        AMORTIZACAO_FINANCIAMENTO,
    }
}