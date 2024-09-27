using ImoveisPrecoDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources.Extensions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using ImoveisPrecoDesktopApp.Services;

namespace ImoveisPrecoDesktopApp
{
    public partial class AdicionarDespesaWindow : Form
    {
        public int idImovel { get; set; }
        public bool Alteracoes { get; set; } = false;
        public event Action OnFormClosingEvent;

        public AdicionarDespesaWindow(int idImovel)
        {
            InitializeComponent();
            this.idImovel = idImovel;
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (Alteracoes)
            {
                OnFormClosingEvent?.Invoke();
            }            
        }     
       
        private void AdicionarDespesa_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.tituloLabel.Text = $"Despesa relativa ao imóvel #{idImovel}";            
            LoadDespesaTipoComboBox();
        }

        private void LoadDespesaTipoComboBox()
        {
            despesaTipoComboBox.Items.Insert(0,"Selecione o tipo de despesa...");

            var listaTipos = Enum.GetValues(typeof(DespesaTipo))
                                 .Cast<DespesaTipo>()
                                 .ToList()
                                 .Select(i => i.GetDescription())
                                 .ToList();            

            listaTipos.Sort();

            foreach (var tipo in listaTipos)
            {
                if(tipo != DespesaTipo.OUTROS.GetDescription())
                    despesaTipoComboBox.Items.Add(tipo);
            }

            despesaTipoComboBox.Items.Add(DespesaTipo.OUTROS.GetDescription());           

            despesaTipoComboBox.SelectedIndex = 0;
        }

        private void addDespesaBtn_Click(object sender, EventArgs e)
        {
            //if (dataPagamentoPicker.Value.Date > DateTime.Today)
            //{
            //    MessageBox.Show("A data do pagamento não pode ser maior que a data atual");
            //}
            //else
            //{
                DespesaViewModel despesa = new DespesaViewModel();

                despesa.Descricao = descricaoInput.Text;
                despesa.DataPagamento = dataPagamentoPicker.Value.ToShortDateString();
                //despesa.DataPagamento = dataPagamentoPicker.Value.Date;
                double valor = 0;
                double.TryParse(valorInput.Text, out valor);
                despesa.Valor = valor;

                if (IR_dedutivel_SIM_btn.Checked)
                {
                    despesa.DedutivelIR = "S";
                }

                string classificacao = despesaTipoComboBox.Text;
                DespesaTipo? tipo = null;

                try
                {
                    tipo = EnumExtensions.GetEnumByDescription<DespesaTipo>(classificacao);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                despesa.Tipo = tipo.Value.ToString();

                despesa.ImovelId = idImovel;

                SvcDespesas.AdicionarDespesa(despesa);

                Alteracoes = true;

                MessageBox.Show("Despesa adicionada com sucesso!");

                LimparCampos();
            //}

        }

        private void LimparCampos()
        {
            descricaoInput.Clear();
            valorInput.Value = 0;
            despesaTipoComboBox.SelectedIndex = 0;
            IR_dedutivel_NAO_btn.Checked = false;
            IR_dedutivel_SIM_btn.Checked = false;
            dataPagamentoPicker.Value = DateTime.Today;
        }

        private void cleanFieldsBtn_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
              
    }
}
