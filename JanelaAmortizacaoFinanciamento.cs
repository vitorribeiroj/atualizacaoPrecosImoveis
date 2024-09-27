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
using System.Xml.Linq;

namespace ImoveisPrecoDesktopApp
{
    public partial class JanelaAmortizacaoFinanciamento : Form
    {
        public event Action OnFormClosingEvent;

        bool HouveAlteracoes = false;

        public JanelaAmortizacaoFinanciamento()
        {
            InitializeComponent();

            LoadMeioAmortizacaoComboBox();

            ConfigureDataGridView();

            CarregarAmortizacoesGridView();
        }

        private void CarregarAmortizacoesGridView()
        {
            if (Financiamento.Amortizacoes is not null)
            {
                var amortizacoes = Financiamento.Amortizacoes.Select(a => new
                {
                    Id = a.Key,
                    Valor = a.Value.Valor,
                    MeioAmortizacao = a.Value.MeioDeAmortizacao,
                    DataAmortizacao = a.Value.DataAmortizacao

                }).ToList();

                amortizacoesGridView.DataSource = amortizacoes;
            }
        }

        private void ConfigureDataGridView()
        {
            amortizacoesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            amortizacoesGridView.AutoGenerateColumns = false; // Desativa a geração automática de colunas

            // Adicionar coluna para a chave do dicionário
            amortizacoesGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id", // Nome da propriedade para a chave do dicionário
                Width = 30,
                Visible = false

            });

            // Adicionar coluna para o atributo 1 do objeto MyData
            amortizacoesGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Valor",
                HeaderText = "Valor da amortização",
                DataPropertyName = "Valor", // Nome da propriedade para o atributo 1
                Width = 100
            });

            // Adicionar coluna para o atributo 2 do objeto MyData
            amortizacoesGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MeioAmortizacao",
                HeaderText = "Meio de amortizacao",
                DataPropertyName = "MeioAmortizacao", // Nome da propriedade para o atributo 2
                Width = 100
            });

            // Adicionar coluna para o atributo 3 do objeto MyData
            amortizacoesGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataAmortizacao",
                HeaderText = "Data",
                DataPropertyName = "DataAmortizacao", // Nome da propriedade para o atributo 3
                Width = 100
            });
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (HouveAlteracoes)
            {
                OnFormClosingEvent?.Invoke();
            }            
        }

        //protected void OnFormClosingSemAlteracoes(FormClosingEventArgs e)
        //{
        //    base.OnFormClosing(e);

        //    if (!HouveAlteracoes)
        //    {
        //        OnFormClosingEvent?.Invoke();
        //    }
        //}


        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool fgtsNaoPodeSerUtilizado = false;

                var valorAmortizacao = double.Parse(valorAmortizacaoInput.Text);

                var meioAmortizacao = EnumExtensions
                                        .GetEnumByDescription<MeioDeAmortizacao>(meioAmortizacaoComboBox.Text)
                                        .ToString();

                DateTime dataAmortizacao = dataAmortizacaoInput.Value.Date;

                if (Financiamento.Amortizacoes is null)
                {
                    Financiamento.Amortizacoes = new Dictionary<string, Amortizacao> { };
                }

                foreach (var amortizacao in Financiamento.Amortizacoes)
                {
                    if (amortizacao.Value.MeioDeAmortizacao == MeioDeAmortizacao.FGTS.ToString()
                        && dataAmortizacaoInput.Value.Date < amortizacao.Value.DataAmortizacao.Date.AddYears(3))
                    {
                        fgtsNaoPodeSerUtilizado = true;
                    }

                }

                if (fgtsNaoPodeSerUtilizado && meioAmortizacao == MeioDeAmortizacao.FGTS.ToString())
                {
                    MessageBox.Show("FGTS não pode ser utilizado, pois já existe amortização com FGTS no período de 3 anos");
                }
                else
                {
                    Amortizacao amortizacao = new Amortizacao(valorAmortizacao, meioAmortizacao, dataAmortizacao);

                    Financiamento.Amortizacoes.Add(Utils.GenerateUniqueKey(), amortizacao);

                    SvcFinanciamento.AmortizarFinanciamento();

                    ConfirmarContabilizacaoAutomaticaNasDespesas(amortizacao);

                    MessageBox.Show("Amortização feita");

                    HouveAlteracoes = true;

                    CarregarAmortizacoesGridView();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algum valor é inválido!\n\n" + ex.StackTrace);
            }
        }

        private void LoadMeioAmortizacaoComboBox()
        {
            meioAmortizacaoComboBox.Items.Add("Selecione o meio de amortização...");

            var listaTipos = Enum.GetValues(typeof(MeioDeAmortizacao))
                                 .Cast<MeioDeAmortizacao>();

            foreach (var tipo in listaTipos)
            {
                string meio = tipo.GetDescription();
                meioAmortizacaoComboBox.Items.Add(meio);
            }

            meioAmortizacaoComboBox.SelectedIndex = 0;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void excluirBtn_Click(object sender, EventArgs e)
        {
            var amortizacoesSelecionadas = amortizacoesGridView.SelectedRows;

            if (amortizacoesSelecionadas.Count <= 0)
            {
                MessageBox.Show("Selecione ao menos uma amortização para excluir");
            }
            else
            {
                DialogResult result = MessageBox.Show(
               "Confirma a exclusão?", // Mensagem
               "Confirmação", // Título da caixa de mensagem
               MessageBoxButtons.YesNo, // Botões exibidos
               MessageBoxIcon.Question // Ícone exibido
               );

                // Verificar a resposta do usuário
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow amortizacao in amortizacoesSelecionadas)
                    {
                        var chave = amortizacao.Cells["Id"].Value.ToString();

                        if (Financiamento.Amortizacoes.ContainsKey(chave))
                        {
                            DespesaViewModel despesa = new DespesaViewModel();
                            despesa.Tipo = DespesaTipo.AMORTIZACAO_FINANCIAMENTO.ToString();
                            despesa.Valor = Financiamento.Amortizacoes[chave].Valor;
                            despesa.DataPagamento = Financiamento.Amortizacoes[chave].DataAmortizacao.ToShortDateString();
                            //despesa.DataPagamento = Financiamento.Amortizacoes[chave].DataAmortizacao.Date;
                            despesa.ImovelId = Financiamento.IdImovel;

                            SvcDespesas.ExcluirDespesaDeFinanciamento(despesa);

                            Financiamento.Amortizacoes.Remove(chave);
                            HouveAlteracoes = true;
                        }


                        //SvcFinanciamento.ExcluirAmortizacao(int.Parse(amortizacao.Cells["Id"].Value.ToString()));
                    }
                    if (HouveAlteracoes)
                    {
                        MessageBox.Show("Registros excluído(s)!");
                        SvcFinanciamento.AmortizarFinanciamento();
                        CarregarAmortizacoesGridView();
                    }



                }
            }
        }

        private void ConfirmarContabilizacaoAutomaticaNasDespesas(Amortizacao amortizacao)
        {
            DialogResult result = MessageBox.Show(
                        "Deseja registrar a amortização nas despesas?", // Mensagem
                        "Confirmação", // Título da caixa de mensagem
                        MessageBoxButtons.YesNo, // Botões exibidos
                        MessageBoxIcon.Question // Ícone exibido
                        );

            if (result == DialogResult.Yes)
            {
                DespesaViewModel despesa = new DespesaViewModel();

                string UsoFGTS = amortizacao.MeioDeAmortizacao == MeioDeAmortizacao.FGTS.ToString() ?
                                    " utilizando saldo de FGTS" : "";                

                despesa.Descricao = $"Amortização de financiamento" + UsoFGTS;
                despesa.DataPagamento = amortizacao.DataAmortizacao.ToShortDateString();
                //despesa.DataPagamento = amortizacao.DataAmortizacao.Date;
                despesa.Tipo = DespesaTipo.AMORTIZACAO_FINANCIAMENTO.ToString();
                despesa.DedutivelIR = "S";
                despesa.Valor = amortizacao.Valor;
                despesa.ImovelId = Financiamento.IdImovel;

                SvcDespesas.AdicionarDespesa(despesa);
            }
        }


    }
}
