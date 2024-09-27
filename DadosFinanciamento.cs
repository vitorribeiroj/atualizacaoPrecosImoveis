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

namespace ImoveisPrecoDesktopApp
{
    public partial class DadosFinanciamento : Form
    {
        private CultureInfo CultureInfo = new CultureInfo("pt-BR");
        public event Action OnFormClosingEvent;
        bool HouveAlteracao = false;

        public DadosFinanciamento()
        {
            InitializeComponent();

            SvcCorrecaoMonetaria.BuscarHistoricoTR(Financiamento.DataFinanciamento);

            CarregarFinanciamento();

            CarregarParcelasGridView();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (HouveAlteracao)
            {
                OnFormClosingEvent?.Invoke();
            }
        }


        private void CarregarFinanciamento()
        {
            valorImovelInput.Text = Financiamento.ValorImovel.ToString("C2", CultureInfo);
            entradaInput.Text = Financiamento.ValorEntrada.ToString("C2", CultureInfo);
            valorFinanciadoInput.Text = Financiamento.ValorFinanciado.ToString("C2", CultureInfo);
            prazoInput.Value = Financiamento.Prazo;
            sistemaAmortizacaoInput.Text = Financiamento.SistemaAmortizacao.ToString();
            jurosInput.Value = (decimal)Financiamento.TaxaAnualJuros;
            taxaAdminInput.Text = Financiamento.TaxaAdministracao.ToString("C2", CultureInfo);
            seguroInput.Text = Financiamento.ValorSeguro.ToString("C2", CultureInfo);
            dataFinanciamentoInput.Text = Financiamento.DataFinanciamento.ToShortDateString();
            saldoFinanciamentoInput.Text = Financiamento.SaldoRestante.ToString("C2", CultureInfo);
            parcelasPagasInput.Text = Financiamento.NumeroParcelasPagas.ToString();

            double pagamentosTotais = 0;
            for (int i = 1; i <= Financiamento.NumeroParcelasPagas; i++)
            {
                pagamentosTotais += Financiamento.ParcelasFinanciamento[i].ValorParcela;
            }
            pagamentosTotaisInput.Text = pagamentosTotais.ToString("C2", CultureInfo);

            double parcelasRestantes = 0;
            for (int i = Financiamento.NumeroParcelasPagas + 1; i < Financiamento.Prazo; i++)
            {
                parcelasRestantes += Financiamento.ParcelasFinanciamento[i].ValorParcela;
            }
            parcelasRestantesInput.Text = parcelasRestantes.ToString("C2", CultureInfo);
        }

        private void CarregarParcelasGridView()
        {
            //parcelasGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var listaParcelas = Financiamento.ParcelasFinanciamento.Select(p => new ParcelaViewModel
            {
                NumeroParcela = p.Key,
                ValorParcela = p.Value.ValorParcela.ToString("C2", CultureInfo),
                ValorAmortizacao = p.Value.ValorAmortizacao.ToString("C2", CultureInfo),
                ValorJuros = p.Value.ValorJuros.ToString("C2", CultureInfo),
                CorrecaoMonetaria = p.Value.CorrecaoMonetaria.ToString("C2", CultureInfo),
                ValorTaxaAdministracao = p.Value.ValorTaxaAdministracao.ToString("C2", CultureInfo),
                ValorSeguro = p.Value.ValorSeguro.ToString("C2", CultureInfo),
                DataVencimento = p.Value.DataVencimento,
                FoiPaga = p.Value.FoiPaga ? "PAGO" : "Pendente"
            }).ToList();

            parcelasGridView.DataSource = listaParcelas;

            parcelasGridView.Columns["NumeroParcela"].HeaderText = "Número da Parcela";
            parcelasGridView.Columns["ValorParcela"].HeaderText = "Valor da Parcela";
            parcelasGridView.Columns["ValorAmortizacao"].HeaderText = "Valor da Amortização";
            parcelasGridView.Columns["ValorJuros"].HeaderText = "Valor dos Juros";
            parcelasGridView.Columns["CorrecaoMonetaria"].HeaderText = "Valor da Correção Monetária";
            parcelasGridView.Columns["ValorTaxaAdministracao"].HeaderText = "Valor da Taxa de Administração";
            parcelasGridView.Columns["ValorSeguro"].HeaderText = "Valor do Seguro";
            parcelasGridView.Columns["DataVencimento"].HeaderText = "Data de Vencimento";
            parcelasGridView.Columns["FoiPaga"].HeaderText = "Pagamento";

        }

        private void exportarParcelasBtn_Click(object sender, EventArgs e)
        {
            SvcExportarArquivos.ExportarArquivoCsvExcel(parcelasGridView);
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void amortizarBtn_Click(object sender, EventArgs e)
        {
            JanelaAmortizacaoFinanciamento janelaAmortizacaoFinanciamento = new JanelaAmortizacaoFinanciamento();
            
            //janelaAmortizacaoFinanciamento.OnFormClosingEvent += MostrarJanela;
            janelaAmortizacaoFinanciamento.OnFormClosingEvent += CarregarFinanciamento;
            janelaAmortizacaoFinanciamento.OnFormClosingEvent += CarregarParcelasGridView;
            janelaAmortizacaoFinanciamento.OnFormClosingEvent += RegistrarAlteracao;
            janelaAmortizacaoFinanciamento.ShowDialog();
            //this.Hide();
        }

        //private void MostrarJanela()
        //{
        //    this.Show();
        //}

        private void RegistrarAlteracao()
        {
            HouveAlteracao = true;
        }

        private void registrarPgtoParcelaBtn_Click(object sender, EventArgs e)
        {
            var parcelasSelecionadas = parcelasGridView.SelectedRows;

            if (parcelasSelecionadas.Count == 0)
            {
                MessageBox.Show("Selecione uma parcela para registrar o pagamento");
            }
            else if (parcelasSelecionadas.Count > 1)
            {
                MessageBox.Show("Selecione uma parcela por vez");
            }
            else
            {
                var parcela = parcelasSelecionadas[0];

                int chave = int.Parse(parcela.Cells["NumeroParcela"].Value.ToString());

                if (Financiamento.ParcelasFinanciamento.ContainsKey(chave))
                {
                    if (Financiamento.ParcelasFinanciamento[chave].FoiPaga)
                    {
                        MessageBox.Show("A parcela selecionada já foi paga");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                        "Confirma o pagamento?", // Mensagem
                        "Confirmação", // Título da caixa de mensagem
                        MessageBoxButtons.YesNo, // Botões exibidos
                        MessageBoxIcon.Question // Ícone exibido
                        );

                        // Verificar a resposta do usuário
                        if (result == DialogResult.Yes)
                        {
                            Financiamento.ParcelasFinanciamento[chave].FoiPaga = true;

                            SvcFinanciamento.AtualizarParcelas();

                            ConfirmarContabilizacaoAutomaticaNasDespesas(Financiamento.ParcelasFinanciamento[chave]);

                            MessageBox.Show("Pagamento registrado!");

                            CarregarFinanciamento();
                            CarregarParcelasGridView();

                            HouveAlteracao = true;
                        }
                    }

                }
            }

        }

        private void ConfirmarContabilizacaoAutomaticaNasDespesas(ParcelaFinanciamento parcela)
        {
            DialogResult result = MessageBox.Show(
                        "Deseja registrar o pagamento da parcela nas despesas?", // Mensagem
                        "Confirmação", // Título da caixa de mensagem
                        MessageBoxButtons.YesNo, // Botões exibidos
                        MessageBoxIcon.Question // Ícone exibido
                        );

            if (result == DialogResult.Yes)
            {
                DespesaViewModel despesa = new DespesaViewModel();

                despesa.Descricao = $"Parcela do financiamento #{parcela.NumeroParcela}";
                despesa.DataPagamento = parcela.DataVencimento.ToShortDateString();
                //despesa.DataPagamento = parcela.DataVencimento;
                despesa.Tipo = DespesaTipo.PARCELA_FINANCIAMENTO.ToString();
                despesa.DedutivelIR = "S";
                despesa.Valor = parcela.ValorParcela;
                despesa.ImovelId = Financiamento.IdImovel;

                SvcDespesas.AdicionarDespesa(despesa);
            }
        }

        private void deletarFinanciamentoBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                        "Deseja realmente excluir o financiamento cadastrado?", // Mensagem
                        "Confirmação", // Título da caixa de mensagem
                        MessageBoxButtons.YesNo, // Botões exibidos
                        MessageBoxIcon.Question // Ícone exibido
                        );

            // Verificar a resposta do usuário
            if (result == DialogResult.Yes)
            {
                SvcFinanciamento.DeletarFinanciamento();
                Financiamento.ResetarFinanciamento();
                HouveAlteracao = true;
                this.Close();
            }
        }



        private void reverterPgtoBtn_Click(object sender, EventArgs e)
        {
            var parcelasSelecionadas = parcelasGridView.SelectedRows;

            if (parcelasSelecionadas.Count == 0)
            {
                MessageBox.Show("Selecione uma parcela para revisar o status do pagamento");
            }
            else if (parcelasSelecionadas.Count > 1)
            {
                MessageBox.Show("Selecione uma parcela por vez");
            }
            else
            {
                var parcela = parcelasSelecionadas[0];

                int chave = int.Parse(parcela.Cells["NumeroParcela"].Value.ToString());

                if (Financiamento.ParcelasFinanciamento.ContainsKey(chave))
                {
                    if (!Financiamento.ParcelasFinanciamento[chave].FoiPaga)
                    {
                        MessageBox.Show("A parcela selecionada consta como pendente de pagamento");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                        "Confirmar o status pendente?", // Mensagem
                        "Confirmação", // Título da caixa de mensagem
                        MessageBoxButtons.YesNo, // Botões exibidos
                        MessageBoxIcon.Question // Ícone exibido
                        );

                        // Verificar a resposta do usuário
                        if (result == DialogResult.Yes)
                        {
                            Financiamento.ParcelasFinanciamento[chave].FoiPaga = false;
                            Financiamento.NumeroParcelasPagas--;

                            SvcFinanciamento.AtualizarParcelas();

                            DespesaViewModel despesa = new DespesaViewModel();
                            despesa.Tipo = DespesaTipo.PARCELA_FINANCIAMENTO.ToString();
                            despesa.Valor = Financiamento.ParcelasFinanciamento[chave].ValorParcela;
                            despesa.DataPagamento = Financiamento.ParcelasFinanciamento[chave].DataVencimento.ToShortDateString();
                            //despesa.DataPagamento = Financiamento.ParcelasFinanciamento[chave].DataVencimento.Date;
                            despesa.ImovelId = Financiamento.IdImovel;

                            SvcDespesas.ExcluirDespesaDeFinanciamento(despesa);

                            MessageBox.Show("Pagamento devolvido!");

                            CarregarFinanciamento();
                            CarregarParcelasGridView();

                            HouveAlteracao = true;
                        }
                    }

                }
            }
        }
    }
}

