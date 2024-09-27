using ImoveisPrecoDesktopApp.Models;
using ImoveisPrecoDesktopApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImoveisPrecoDesktopApp
{
    public partial class EditarDespesa : Form
    {
        public DespesaViewModel DespesaEmEdicao { get; set; }
        public bool Alteracoes { get; set; } = false;
        public event Action OnFormClosingEvent;

        public EditarDespesa(DespesaViewModel despesa)
        {
            InitializeComponent();
            DespesaEmEdicao = despesa;
            CarregarDespesa();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (Alteracoes)
            {
                OnFormClosingEvent?.Invoke();
            }
        }

        private void LoadDespesaTipoComboBox()
        {
            var listaTipos = Enum.GetValues(typeof(DespesaTipo))
                                 .Cast<DespesaTipo>()
                                 .Select(i => i.GetDescription())
                                 .ToList();

            listaTipos.Sort();

            foreach (var tipo in listaTipos)
            {
                if(tipo != DespesaTipo.OUTROS.GetDescription())
                    despesaTipoComboBox.Items.Add(tipo);
            }

            despesaTipoComboBox.Items.Add(DespesaTipo.OUTROS.GetDescription());
        }

        private void CancelarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void confirmarEdicaoBtn_Click(object sender, EventArgs e)
        {
            //if (dataPagamentoPicker.Value.Date > DateTime.Today)
            //{
            //    MessageBox.Show("A data do pagamento não pode ser maior que a data atual");
            //}
            //else
            //{


                DialogResult result = MessageBox.Show(
                "Confirmar a edição?", // Mensagem
                "Confirmação", // Título da caixa de mensagem
                MessageBoxButtons.YesNo, // Botões exibidos
                MessageBoxIcon.Question // Ícone exibido
                );

                // Verificar a resposta do usuário
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DespesaEmEdicao.Descricao = descricaoInput.Text;

                        DespesaEmEdicao.Tipo = EnumExtensions
                                                .GetEnumByDescription<DespesaTipo>(despesaTipoComboBox.SelectedItem.ToString())
                                                .ToString();

                        DespesaEmEdicao.Valor = (double)valorInput.Value;

                        DespesaEmEdicao.DataPagamento = dataPagamentoPicker.Value.ToShortDateString();
                        //DespesaEmEdicao.DataPagamento = dataPagamentoPicker.Value.Date;

                        if (IR_dedutivel_SIM_btn.Checked)
                        {
                            DespesaEmEdicao.DedutivelIR = "S";
                        }
                        else
                        {
                            DespesaEmEdicao.DedutivelIR = "N";
                        }

                        SvcDespesas.EditarDespesa(DespesaEmEdicao);

                        Alteracoes = true;

                        MessageBox.Show("Sucesso!");

                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível editar a despesa");
                    }
                //}
            }
        }

        private void CarregarDespesa()
        {
            descricaoInput.Text = DespesaEmEdicao.Descricao;

            LoadDespesaTipoComboBox();

            DespesaTipo tipo = (DespesaTipo)Enum.Parse(typeof(DespesaTipo), DespesaEmEdicao.Tipo);

            despesaTipoComboBox.SelectedItem = EnumExtensions.GetDescription(tipo);

            valorInput.Value = (decimal)DespesaEmEdicao.Valor;

            dataPagamentoPicker.Value = DateTime.Parse(DespesaEmEdicao.DataPagamento);
            // dataPagamentoPicker.Value = DespesaEmEdicao.DataPagamento.Date;

            if (DespesaEmEdicao.DedutivelIR == "S")
            {
                IR_dedutivel_SIM_btn.Checked = true;
            }
            else if (DespesaEmEdicao.DedutivelIR == "N")
            {
                IR_dedutivel_NAO_btn.Checked = true;
            }
        }
    }
}
