using ImoveisPrecoDesktopApp.Models;
using ImoveisPrecoDesktopApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImoveisPrecoDesktopApp
{
    public partial class JanelaConsultaIndividual : Form
    {
        public DataTable despesasDataTable { get; set; }
        public DataTable receitasDataTable { get; set; }
        public int IdImovel { get; set; }
        public Imovel Imovel { get; set; } = null;
        //public Financiamento Financiamento { get; set; }
        //public event Action OnFormClosingEvent;
        private CultureInfo CultureInfo = new CultureInfo("pt-BR");
        private System.Windows.Forms.ToolTip toolTipCorretagem = new System.Windows.Forms.ToolTip();

        public JanelaConsultaIndividual(int idImovel)
        {
            InitializeComponent();

            panel.AutoScroll = true;
            panel.Dock = DockStyle.Fill;

            panel.Controls.Add(apelidoDisplay);
            panel.Controls.Add(enderecoLabel);
            panel.Controls.Add(logradouroLabel);
            panel.Controls.Add(logradouroDisplay);
            panel.Controls.Add(numeroLabel);
            panel.Controls.Add(numeroDisplay);
            panel.Controls.Add(complementoLabel);
            panel.Controls.Add(complementoDisplay);
            panel.Controls.Add(bairroLabel);
            panel.Controls.Add(bairroDisplay);
            panel.Controls.Add(cidadeLabel);
            panel.Controls.Add(cidadeDisplay);
            panel.Controls.Add(estadoDisplay);
            panel.Controls.Add(estadoLabel);
            panel.Controls.Add(cepLabel);
            panel.Controls.Add(cepDisplay);
            panel.Controls.Add(editarEnderecoBtn);
            panel.Controls.Add(pictureBox1);
            panel.Controls.Add(valorAtualizadoDisplay);
            panel.Controls.Add(valorImovelAtualizadoLabel);
            panel.Controls.Add(saldoFinanciamentoLabel);
            panel.Controls.Add(saldoFinanciamentoInput);
            panel.Controls.Add(dataRefLabel);
            panel.Controls.Add(dataRefPicker);
            panel.Controls.Add(taxaJurosLabel);
            panel.Controls.Add(taxaJurosDisplay);
            panel.Controls.Add(atualizarValorBtn);
            panel.Controls.Add(addDespesaBtn);

            panel.Controls.Add(editDespesaBtn);
            panel.Controls.Add(excluirDespesaBtn);
            panel.Controls.Add(despesasGridViewLabel);
            panel.Controls.Add(despesasGridView);
            panel.Controls.Add(receitasGridViewLabel);
            panel.Controls.Add(receitasGridView);
            panel.Controls.Add(addReceitaBtn);

            panel.Controls.Add(editReceitaBtn);
            panel.Controls.Add(excluirReceitaBtn);

            IdImovel = idImovel;

            CarregarJanela();
        }


        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    base.OnFormClosing(e);

        //    OnFormClosingEvent?.Invoke();
        //}

        private void CarregarJanela()
        {
            CarregarDadosImovel();

            ConfigurarToolTip();

            despesasDataTable = SvcDespesas.CarregarDespesasPorImovel(IdImovel);

            receitasDataTable = SvcReceitas.CarregarReceitasPorImovel(IdImovel);

            CarregarDadosFinanciamento();

            CarregarDespesasGridView();

            CarregarReceitasGridView();

            AtualizarPrecoVenda();

        }

        private void ConfigurarToolTip()
        {
            // Define as propriedades do ToolTip (opcional)
            toolTipCorretagem.AutoPopDelay = 5000; // Tempo em milissegundos que o tooltip ficará visível
            toolTipCorretagem.InitialDelay = 0; // Tempo em milissegundos antes do tooltip aparecer
            toolTipCorretagem.ReshowDelay = 200;   // Tempo em milissegundos para o tooltip reaparecer se o mouse estiver sobre o controle
            toolTipCorretagem.ShowAlways = true;   // Exibir o tooltip mesmo se o formulário estiver desativado
        }

        private void AtualizarDespesasDataSource()
        {
            despesasDataTable = SvcDespesas.CarregarDespesasPorImovel(IdImovel);

            AtualizarPrecoVenda();
        }

        private void CarregarDadosImovel()
        {
            Imovel = SvcImoveis.CarregarImovel(IdImovel);

            if (Imovel is not null)
            {
                apelidoDisplay.Text = Imovel.Apelido;
                logradouroDisplay.Text = Imovel.Logradouro;
                numeroDisplay.Text = Imovel.Numero;
                complementoDisplay.Text = Imovel.Complemento;
                bairroDisplay.Text = Imovel.Bairro;
                cidadeDisplay.Text = Imovel.Cidade;
                estadoDisplay.Text = Imovel.Estado;
                cepDisplay.Text = Imovel.Cep;
                pictureBox1.Image = Image.FromFile(Imovel.FotoPath);
            }
        }

        private void CarregarDadosFinanciamento()
        {
            SvcFinanciamento.BuscarFinanciamentoPorImovel(IdImovel);

            saldoFinanciamentoInput.Text = 0.0.ToString("C2", CultureInfo);

            if (Financiamento.ExisteFinanciamentoCadastrado) saldoFinanciamentoInput.Text = Financiamento.SaldoRestante.ToString("C2", CultureInfo);
        }

        private void CarregarDespesasGridView()
        {
            var dataTableClone = despesasDataTable.Copy();

            despesasGridView.DataSource = dataTableClone;

            double total = 0;
            double dedutiveis = 0;

            foreach (DataRow row in dataTableClone.Rows)
            {
                total += double.Parse(row["valor"].ToString());

                if (row["dedutivel_IR"].ToString() == "S")
                {
                    dedutiveis += double.Parse(row["valor"].ToString());
                    row["dedutivel_IR"] = "Sim";
                }
                else
                {
                    row["dedutivel_IR"] = "Não";
                }

                //DespesaTipo classificacao = ((DespesaTipo)Enum.Parse(typeof(DespesaTipo), row["classificacao"].ToString())).GetDescription();
                row["classificacao"] = ((DespesaTipo)Enum.Parse(typeof(DespesaTipo), row["classificacao"].ToString())).GetDescription();
            }

            despesasTotaisLabel.Text = $"Total: {total.ToString("C2", CultureInfo)}";

            despesasDedutiveisDisplay.Text = $"Despesas dedutíveis: {dedutiveis.ToString("C2", CultureInfo)}";

            CustomizarDespesasGridView();            
        }

        private void CustomizarDespesasGridView()
        {
            despesasGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            despesasGridView.Columns["valor"].DefaultCellStyle.Format = "F2";


            foreach (DataGridViewColumn coluna in despesasGridView.Columns)
            {
                if (coluna.Name == "id" | coluna.Name == "id_imovel")
                {
                    coluna.Visible = false;
                }

                switch (coluna.Name)
                {
                    case "descricao":
                        coluna.HeaderText = "Descrição";
                        break;
                    case "classificacao":
                        coluna.HeaderText = "Classificação";
                        break;
                    case "valor":
                        coluna.HeaderText = "Valor (R$)";
                        //coluna.DefaultCellStyle.Format = "C2";                        
                        break;
                    case "data_pagamento":
                        coluna.HeaderText = "Data do pagamento";
                        break;
                    case "dedutivel_IR":
                        coluna.HeaderText = "Dedutível do IR?";
                        break;
                }
            }
        }

        private void atualizarValorBtn_Click(object sender, EventArgs e)
        {
            AtualizarPrecoVenda();

        }

        private void addDespesaBtn_Click(object sender, EventArgs e)
        {
            var janelaAdicionarDespesa = new AdicionarDespesaWindow(IdImovel);

            janelaAdicionarDespesa.OnFormClosingEvent += AtualizarDespesasDataSource;
            janelaAdicionarDespesa.OnFormClosingEvent += CarregarDespesasGridView;

            janelaAdicionarDespesa.ShowDialog();
        }

        private void excluirDespesaBtn_Click(object sender, EventArgs e)
        {
            var despesasSelecionadas = despesasGridView.SelectedRows;

            if (despesasSelecionadas.Count <= 0)
            {
                MessageBox.Show("Selecione ao menos uma despesa para excluir");
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

                    foreach (DataGridViewRow despesa in despesasSelecionadas)
                    {
                        SvcDespesas.ExcluirDespesa(int.Parse(despesa.Cells["id"].Value.ToString()));
                    }

                    MessageBox.Show("Despesa(s) excluída(s)!");
                }

                AtualizarDespesasDataSource();

                CarregarDespesasGridView();
            }


        }

        private void editDespesaBtn_Click(object sender, EventArgs e)
        {
            var despesasSelecionadas = despesasGridView.SelectedRows;

            if (despesasSelecionadas.Count < 1)
            {
                MessageBox.Show("Selecione uma despesa para editar");
            }
            else if (despesasSelecionadas.Count > 1)
            {
                MessageBox.Show("Selecione apenas uma despesa para editar");
            }
            else
            {
                try
                {
                    DataGridViewRow selecao = despesasSelecionadas[0];

                    DespesaViewModel despesa = new DespesaViewModel();

                    despesa.Id = int.Parse(selecao.Cells["id"].Value.ToString());

                    var despesaDataTable = SvcDespesas.CarregarDespesaPorId(despesa.Id);

                    despesa.Descricao = despesaDataTable.Rows[0]["descricao"].ToString();
                    despesa.Tipo = despesaDataTable.Rows[0]["classificacao"].ToString();
                    despesa.Valor = double.Parse(despesaDataTable.Rows[0]["valor"].ToString());
                    despesa.DataPagamento = despesaDataTable.Rows[0]["data_pagamento"].ToString();
                    //despesa.DataPagamento = DateTime.Parse(despesaDataTable.Rows[0]["data_pagamento"].ToString()).Date;
                    despesa.DedutivelIR = despesaDataTable.Rows[0]["dedutivel_IR"].ToString();

                    var janelaEdicaoDespesa = new EditarDespesa(despesa);

                    janelaEdicaoDespesa.OnFormClosingEvent += AtualizarDespesasDataSource;
                    janelaEdicaoDespesa.OnFormClosingEvent += CarregarDespesasGridView;

                    janelaEdicaoDespesa.ShowDialog();

                }
                catch
                {
                    MessageBox.Show("Não foi possível editar o registro selecionado");
                }
            }
        }

        private void editarEnderecoBtn_Click(object sender, EventArgs e)
        {
            EditarDadosImovel janelaEdicaoDadosImovel = new EditarDadosImovel(Imovel);
            janelaEdicaoDadosImovel.OnFormClosingEvent += CarregarJanela;
            janelaEdicaoDadosImovel.OnFormClosingEvent += MostrarJanela;
            this.Hide();
            janelaEdicaoDadosImovel.ShowDialog();
        }

        private void MostrarJanela()
        {
            this.Show();
        }

        private void dadosFinanciamentoBtn_Click(object sender, EventArgs e)
        {
            //var financiamento = SvcFinanciamento.BuscarFinanciamentoPorImovel(IdImovel);
            //if (Financiamento is null)
            if (!(Financiamento.ExisteFinanciamentoCadastrado))
            {
                DialogResult result = MessageBox.Show(
                "Esse imóvel não possui financiamento cadastrado. Deseja cadastrar?", // Mensagem
                "Financiamento", // Título da caixa de mensagem
                MessageBoxButtons.YesNo, // Botões exibidos
                MessageBoxIcon.Question // Ícone exibido
                );

                // Verificar a resposta do usuário
                if (result == DialogResult.Yes)
                {
                    CadastrarFinanciamento janelaCadastroFinanciamento = new CadastrarFinanciamento(IdImovel);
                    janelaCadastroFinanciamento.OnFormClosingEvent += CarregarDadosFinanciamento;
                    janelaCadastroFinanciamento.ShowDialog();
                }
            }
            else
            {
                //DadosFinanciamento janelaDadosFinanciamento = new DadosFinanciamento(Financiamento);
                DadosFinanciamento janelaDadosFinanciamento = new DadosFinanciamento();
                //janelaDadosFinanciamento.OnFormClosingEvent += CarregarDadosFinanciamento;
                janelaDadosFinanciamento.OnFormClosingEvent += CarregarJanela;
                janelaDadosFinanciamento.ShowDialog();
            }



        }

        private void excluirReceitaBtn_Click(object sender, EventArgs e)
        {
            var receitasSelecionadas = receitasGridView.SelectedRows;

            if (receitasSelecionadas.Count <= 0)
            {
                MessageBox.Show("Selecione ao menos uma receita para excluir");
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

                    foreach (DataGridViewRow receita in receitasSelecionadas)
                    {
                        SvcReceitas.ExcluirReceita(int.Parse(receita.Cells["id"].Value.ToString()));
                    }

                    MessageBox.Show("Receita(s) excluída(s)!");
                }

                AtualizarReceitasDataSource();

                CarregarReceitasGridView();
            }
        }

        private void CarregarReceitasGridView()
        {
            DataTable dataTableClone = receitasDataTable.Copy();

            receitasGridView.DataSource = dataTableClone;

            double total = 0;

            foreach (DataRow row in dataTableClone.Rows)
            {
                total += double.Parse(row["valor"].ToString());
            }

            totalReceitasLabel.Text = $"Total: {total.ToString("C2", CultureInfo)}";

            CustomizarReceitasGridView();
        }

        private void CustomizarReceitasGridView()
        {
            receitasGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn coluna in receitasGridView.Columns)
            {
                if (coluna.Name == "id" | coluna.Name == "id_imovel")
                {
                    coluna.Visible = false;
                }

                switch (coluna.Name)
                {
                    case "descricao":
                        coluna.HeaderText = "Descrição";
                        break;
                    case "classificacao":
                        coluna.HeaderText = "Classificação";
                        break;
                    case "valor":
                        coluna.HeaderText = "Valor (R$)";
                        coluna.DefaultCellStyle.Format = "F2";
                        break;
                    case "data_recebimento":
                        coluna.HeaderText = "Data do recebimento";
                        break;
                }
            }
        }

        private void AtualizarReceitasDataSource()
        {
            receitasDataTable = SvcReceitas.CarregarReceitasPorImovel(IdImovel);

            AtualizarPrecoVenda();
        }

        private void addReceitaBtn_Click(object sender, EventArgs e)
        {
            var janelaAdicionarReceita = new AdicionarReceita(IdImovel);

            janelaAdicionarReceita.OnFormClosingEvent += AtualizarReceitasDataSource;
            janelaAdicionarReceita.OnFormClosingEvent += CarregarReceitasGridView;

            janelaAdicionarReceita.ShowDialog();
        }

        private void dadosAluguelBtn_Click(object sender, EventArgs e)
        {
            DadosAluguel janelaDadosAluguel = new DadosAluguel(IdImovel);
            janelaDadosAluguel.OnFormClosingEvent += AtualizarReceitasGridView;
            janelaDadosAluguel.ShowDialog();
        }

        private void AtualizarReceitasGridView()
        {
            AtualizarReceitasDataSource();
            CarregarReceitasGridView();
        }

        private void ordenarColunaData(object sender, DataGridViewSortCompareEventArgs e)
        {


            if (/*colunaData == "data_pagamento" || */e.Column.Name == "Data do pagamento")
            {
                DateTime date1, date2;

                // Tenta converter os valores das células para DateTime
                bool validDate1 = DateTime.TryParseExact(e.CellValue1.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date1);
                bool validDate2 = DateTime.TryParseExact(e.CellValue2.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date2);

                if (validDate1 && validDate2)
                {
                    // Compara as datas
                    e.SortResult = date1.CompareTo(date2);
                }
                else
                {
                    // Caso as datas não sejam válidas, compara como string
                    e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
                }

                e.Handled = true; // Indica que o evento foi tratado
            }
        }


        private void TaxaCorretagemInput_ValueChanged(object sender, EventArgs e)
        {
            AtualizarPrecoVenda();
        }

        private void TaxaJurosDisplay_ValueChanged(object sender, EventArgs e)
        {
            AtualizarPrecoVenda();
        }

        private void DataRefPicker_ValueChanged(object sender, EventArgs e)
        {
            AtualizarPrecoVenda();
        }

        private void AtualizarToolTipCorretagem()
        {
            decimal valorCorretagem = 0;

            if (precoVendaRecomendadoInput.Text.Length > 0)
            {
                string valorLimpo = precoVendaRecomendadoInput.Text
                                    .Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "") // Remove símbolo da moeda
                                    .Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, "") // Remove separadores de milhares
                                    .Trim();

                valorCorretagem = decimal.Parse(valorLimpo) * taxaCorretagemInput.Value / 100;
            }

            // Configura o tooltip para um Label
            toolTipCorretagem.SetToolTip(taxaCorretagemLabel, $"Valor da corretagem: {valorCorretagem.ToString("C2", CultureInfo)}");
            toolTipCorretagem.SetToolTip(taxaCorretagemInput, $"Valor da corretagem: {valorCorretagem.ToString("C2", CultureInfo)}");
        }

        private void AtualizarPrecoVenda()
        {
            try
            {
                List<(double valorDesp, DespesaTipo tipo, DateTime dataPagamento, bool dedutivelIR)> listaDespesas = new List<(double valorDesp, DespesaTipo tipo, DateTime dataPagamento, bool dedutivelIR)> { };
                List<(double valorReceita, DateTime dataRecebimento)> listaReceitas = new List<(double valorReceita, DateTime dataRecebimento)> { };

                double totalDespesasAtualizadas = 0;
                double totalDespesasDedutiveisIR = 0;

                double totalReceitasAtualizadas = 0;

                double taxaJuros = double.Parse(taxaJurosDisplay.Text) / 100;
                double taxaJurosFGTS = 0.05;

                double taxaCorretagem = double.Parse(taxaCorretagemInput.Text) / 100;

                DateTime dataReferencia = dataRefPicker.Value.Date;

                foreach (DataRow row in despesasDataTable.Rows)
                {
                    var valorDespesa = double.Parse(row["valor"].ToString(), NumberStyles.Any, CultureInfo);
                    DespesaTipo tipo = (DespesaTipo)Enum.Parse(typeof(DespesaTipo), row["classificacao"].ToString());
                    //DespesaTipo tipo = EnumExtensions.GetEnumByDescription<DespesaTipo>(row["classificacao"].ToString());

                    DateTime dataPgto = DateTime.Parse(row["data_pagamento"].ToString());
                    bool dedutivel = row["dedutivel_IR"].ToString() == "S" ? true : false;

                    listaDespesas.Add((valorDespesa, tipo, dataPgto, dedutivel));
                }

                //AGREGA PARCELAS FUTURAS À SIMULAÇÃO
                if (dataReferencia > DateTime.Today)
                {
                    foreach (var parcela in Financiamento.ParcelasFinanciamento.Values)
                    {
                        if (parcela.DataVencimento < dataReferencia && parcela.DataVencimento > DateTime.Today)
                        {
                            listaDespesas.Add((parcela.ValorParcela, DespesaTipo.PARCELA_FINANCIAMENTO, parcela.DataVencimento, true));
                        }
                    }
                }

                foreach (var tupla in listaDespesas)
                {
                    if (tupla.dataPagamento < dataReferencia)
                    {
                        TimeSpan diferencaDatas = dataReferencia.Subtract(tupla.dataPagamento);

                        double diferencaDias = diferencaDatas.Days;

                        double indiceAcumulado = Math.Pow((1 + taxaJuros), (diferencaDias / 365.0));

                        double indiceCorrecaoFGTS = Math.Pow((1 + taxaJurosFGTS), (diferencaDias / 365.0));

                        if (tupla.tipo == DespesaTipo.AMORTIZACAO_FINANCIAMENTO)
                        {
                            totalDespesasAtualizadas += tupla.valorDesp * indiceCorrecaoFGTS;
                        }
                        else
                        {
                            totalDespesasAtualizadas += tupla.valorDesp * indiceAcumulado;
                        }

                        if (tupla.dedutivelIR)
                        {
                            totalDespesasDedutiveisIR += tupla.valorDesp;
                        }
                    }
                }

                //if (Financiamento is not null)
                if (Financiamento.ValorFinanciado > 0)
                {
                    if(dataReferencia > DateTime.Today)
                    {
                        double valorMedioAmortizacao = Financiamento.ValorFinanciado / Financiamento.Prazo;

                        double amortizacoesFuturas = Utils.CalcularDiferencaMeses(DateTime.Today, dataReferencia)
                                                     * valorMedioAmortizacao;

                        totalDespesasAtualizadas += (Financiamento.SaldoRestante - amortizacoesFuturas);
                        totalDespesasDedutiveisIR += (Financiamento.SaldoRestante - amortizacoesFuturas);
                    }
                    else
                    {
                        totalDespesasAtualizadas += Financiamento.SaldoRestante;
                        totalDespesasDedutiveisIR += Financiamento.SaldoRestante;
                    } 
                }

                foreach (DataRow row in receitasDataTable.Rows)
                {
                    var valorReceita = double.Parse(row["valor"].ToString(), NumberStyles.Any, CultureInfo);
                    DateTime dataRecebimento = DateTime.Parse(row["data_recebimento"].ToString());
                    listaReceitas.Add((valorReceita, dataRecebimento));
                }

                foreach (var tupla in listaReceitas)
                {
                    if (tupla.dataRecebimento <= dataReferencia)
                    {
                        TimeSpan diferencaDatas = dataReferencia.Subtract(tupla.dataRecebimento);

                        double diferencaDias = diferencaDatas.Days;

                        double indiceAcumulado = Math.Pow((1 + taxaJuros), (diferencaDias / 365.0));

                        totalReceitasAtualizadas += tupla.valorReceita * indiceAcumulado;
                    }
                }

                valorAtualizadoDisplay.Text = (totalDespesasAtualizadas - totalReceitasAtualizadas).ToString("C2", CultureInfo);

                double precoVenda = ((totalDespesasAtualizadas - totalReceitasAtualizadas) - totalDespesasDedutiveisIR * Utils.AliquotaGanhoCapitalIR) /
                                    (1.0 - Utils.AliquotaGanhoCapitalIR + taxaCorretagem * Utils.AliquotaGanhoCapitalIR - taxaCorretagem);

                precoVendaRecomendadoInput.Text = precoVenda.ToString("C2", CultureInfo);

                AtualizarToolTipCorretagem();

                double baseDeCalculoIR = precoVenda * (1 - taxaCorretagem) - totalDespesasDedutiveisIR;

                AtualizarImpostoDeRenda(baseDeCalculoIR);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Algum valor informado é inválido \n{ex.StackTrace}");
            }
        }

        private void AtualizarImpostoDeRenda(double baseDeCalculo)
        {
            displayImpostoRenda.Text = (baseDeCalculo * Utils.AliquotaGanhoCapitalIR).ToString("C2", CultureInfo);
        }

        private void editReceitaBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
