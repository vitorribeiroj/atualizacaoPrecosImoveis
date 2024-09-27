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
    public partial class DadosAluguel : Form
    {
        public Aluguel Aluguel { get; set; }
        bool ExisteAluguelCadastrado = false;
        public int IdImovel { get; set; }
        public bool HouveAlteracaoReceitas { get; set; } = false;
        public event Action OnFormClosingEvent;

        private CultureInfo CultureInfo = new CultureInfo("pt-BR");

        public DadosAluguel(int idImovel)
        {
            InitializeComponent();

            IdImovel = idImovel;

            Aluguel = BuscarCadastroDeAluguel();

            AtualizarTela();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (HouveAlteracaoReceitas)
            {
                OnFormClosingEvent?.Invoke();
            }
        }

        private void AtualizarTela()
        {
            if (ExisteAluguelCadastrado)
            {
                valorAluguelInput.Text = Aluguel.Valor.ToString("C2");
                taxaIntermediacaoInput.Value = (decimal)Aluguel.TaxaIntermediacao;
                taxaAdminInput.Value = (decimal)Aluguel.TaxaAdministracao;
                impostoInput.Value = (decimal)Aluguel.ImpostoDeRenda;
            }
        }

        public Aluguel BuscarCadastroDeAluguel()
        {
            var consulta = SvcAluguel.BuscarAluguelPorImovel(IdImovel);
            if (consulta.Rows.Count > 0)
            {
                var registro = consulta.Rows[0];

                Aluguel aluguel = new Aluguel();

                aluguel.Id = int.Parse(registro["id"].ToString());
                aluguel.Valor = double.Parse(registro["valor"].ToString());
                aluguel.TaxaIntermediacao = double.Parse(registro["taxaIntermediacao"].ToString());
                aluguel.TaxaAdministracao = double.Parse(registro["taxaAdministracao"].ToString());
                aluguel.ImpostoDeRenda = double.Parse(registro["impostoDeRenda"].ToString());
                aluguel.IdImovel = int.Parse(registro["idImovel"].ToString());

                ExisteAluguelCadastrado = true;

                return aluguel;
            }
            else
            {
                return new Aluguel();
            }
        }

        private void contabilizarAluguelBtn_Click(object sender, EventArgs e)
        {
            Aluguel aluguelPreenchido = new Aluguel();
            aluguelPreenchido.Valor = double.Parse(valorAluguelInput.Text, NumberStyles.Currency, CultureInfo);
            aluguelPreenchido.TaxaIntermediacao = (double)taxaIntermediacaoInput.Value;
            aluguelPreenchido.TaxaAdministracao = (double)taxaAdminInput.Value;
            aluguelPreenchido.ImpostoDeRenda = (double)impostoInput.Value;
            aluguelPreenchido.IdImovel = IdImovel;

            bool saoIguais = CompararCamposAluguel(Aluguel, aluguelPreenchido);

            try
            {
                if (!ExisteAluguelCadastrado || !saoIguais)
                {
                    DialogResult result = MessageBox.Show(
                        "Gostaria de salvar os dados do aluguel?", // Mensagem
                        "Confirmação", // Título da caixa de mensagem
                        MessageBoxButtons.YesNo, // Botões exibidos
                        MessageBoxIcon.Question // Ícone exibido
                        );

                    if (result == DialogResult.Yes)
                    {
                        if (!ExisteAluguelCadastrado)
                        {
                            SvcAluguel.AdicionarAluguel(aluguelPreenchido);
                            ExisteAluguelCadastrado = true;
                        }
                        else
                        {
                            SvcAluguel.AtualizarAluguel(aluguelPreenchido);
                        }

                        Aluguel = BuscarCadastroDeAluguel();
                    }
                }

                ContabilizacaoReceitasAluguel contabilizacao = new ContabilizacaoReceitasAluguel(aluguelPreenchido);
                contabilizacao.ShowDialog();

                HouveAlteracaoReceitas = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + $"\n\n{ex.StackTrace}");
            }
        }

        private bool CompararCamposAluguel(Aluguel aluguel, Aluguel aluguelPreenchido)
        {
            if (aluguel.Valor == aluguelPreenchido.Valor
                && aluguel.TaxaIntermediacao == aluguelPreenchido.TaxaIntermediacao
                && aluguel.TaxaAdministracao == aluguelPreenchido.TaxaAdministracao
                && aluguel.ImpostoDeRenda == aluguelPreenchido.ImpostoDeRenda)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (ExisteAluguelCadastrado)
            {
                try
                {
                    Aluguel.Valor = double.Parse(valorAluguelInput.Text, NumberStyles.Currency, CultureInfo);
                    Aluguel.TaxaIntermediacao = (double)taxaIntermediacaoInput.Value;
                    Aluguel.TaxaAdministracao = (double)taxaAdminInput.Value;
                    Aluguel.ImpostoDeRenda = (double)impostoInput.Value;

                    SvcAluguel.AtualizarAluguel(Aluguel);

                    MessageBox.Show("Aluguel atualizado!");
                }
                catch
                {
                    MessageBox.Show("Algum dado informado é inválido");
                }
            }
            else
            {
                try
                {
                    Aluguel.Valor = double.Parse(valorAluguelInput.Text, NumberStyles.Currency, CultureInfo);
                    Aluguel.TaxaIntermediacao = (double)taxaIntermediacaoInput.Value;
                    Aluguel.TaxaAdministracao = (double)taxaAdminInput.Value;
                    Aluguel.ImpostoDeRenda = (double)impostoInput.Value;
                    Aluguel.IdImovel = IdImovel;

                    SvcAluguel.AdicionarAluguel(Aluguel);

                    MessageBox.Show("Aluguel salvo!");

                    //Aluguel = BuscarCadastroDeAluguel();

                    ExisteAluguelCadastrado = true;
                }
                catch
                {
                    MessageBox.Show("Algum dado informado é inválido");
                }
            }
        }

        private void rendaLiquidaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var valorAluguel = double.Parse(valorAluguelInput.Text, NumberStyles.Currency, CultureInfo);
                var taxaIntermediacao = (double)taxaIntermediacaoInput.Value;
                var taxaAdministracao = (double)taxaAdminInput.Value;
                var impostoDeRenda = (double)impostoInput.Value;

                var rendaLiquida = (12 * valorAluguel * (1 - taxaAdministracao / 100) - (valorAluguel * taxaIntermediacao / 100))
                                    * (1 - impostoDeRenda/100) / 12;

                rendaLiquidaInput.Text = rendaLiquida.ToString("C2", CultureInfo);
            }
            catch
            {
                MessageBox.Show("Algum dado inserido é inválido");
            }
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
