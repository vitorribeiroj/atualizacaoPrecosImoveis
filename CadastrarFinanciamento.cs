using ImoveisPrecoDesktopApp.Models;
using ImoveisPrecoDesktopApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImoveisPrecoDesktopApp
{
    public partial class CadastrarFinanciamento : Form
    {
        public int IdImovel { get; set; }
        public event Action OnFormClosingEvent;
        public bool FinanciamentoCadastrado { get; set; } = false;


        public CadastrarFinanciamento(int idImovel)
        {
            InitializeComponent();

            InicializarAmortizacaoComboBox();

            IdImovel = idImovel;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (FinanciamentoCadastrado)
            {
                OnFormClosingEvent?.Invoke();
            }
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InicializarAmortizacaoComboBox()
        {
            var listaSistemas = Enum.GetValues(typeof(SistemaAmortizacao))
                                   .Cast<object>()
                                   .ToArray();

            sistemaAmortizacaoComboBox.Items.Add("");

            sistemaAmortizacaoComboBox.Items.AddRange(listaSistemas);
        }

        private void salvarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Financiamento financiamento = new Financiamento();

                Financiamento.ValorImovel = double.Parse(valorImovelInput.Text);
                Financiamento.ValorEntrada = double.Parse(entradaInput.Text);
                Financiamento.ValorFinanciado = double.Parse(valorFinanciadoInput.Text);
                Financiamento.Prazo = int.Parse(prazoInput.Text);
                Financiamento.SistemaAmortizacao = (SistemaAmortizacao)Enum.Parse(typeof(SistemaAmortizacao), sistemaAmortizacaoComboBox.Text);
                Financiamento.TaxaAnualJuros = double.Parse(jurosInput.Text);
                Financiamento.TaxaAdministracao = double.Parse(taxaAdminInput.Text);
                Financiamento.ValorSeguro = double.Parse(seguroInput.Text);
                Financiamento.DataFinanciamento = DateTime.Parse(dataFinanciamentoInput.Text);
                Financiamento.IdImovel = IdImovel;

                //SvcFinanciamento.CalcularParcelas();
                //SvcFinanciamento.CadastrarFinanciamento(financiamento);
                SvcFinanciamento.CadastrarFinanciamento();

                FinanciamentoCadastrado = true;

                MessageBox.Show("Financiamento cadastrado com sucesso!");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        

    }
}
