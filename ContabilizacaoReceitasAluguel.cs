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
    public partial class ContabilizacaoReceitasAluguel : Form
    {
        public Aluguel Aluguel { get; set; }
        public List<Receita> ReceitasAluguel { get; set;} = new List<Receita>();

        public ContabilizacaoReceitasAluguel(Aluguel aluguel)
        {
            InitializeComponent();
            Aluguel = aluguel;
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contabilizarBtn_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = dataInicioInput.Value.Date;
            DateTime dataFim = dataFimInput.Value.Date;
            DateTime dataRef = dataInicio;

            double correcao = (double)correcaoInput.Value/100;

            double correcaoAcumulada = 1;

            int contador = 1;

            while(dataRef <= dataFim)
            {
                if(contador >= 12 && contador % 12 == 0)
                {
                    correcaoAcumulada = correcaoAcumulada * (1 + correcao);
                }

                var receita = new Receita();
                receita.Descricao = "Aluguel mensal";
                receita.Tipo = ReceitaTipo.ALUGUEL;
                receita.DataRecebimento = dataRef;
                receita.Valor = Aluguel.ValorLiquido*correcaoAcumulada;
                receita.ImovelId = Aluguel.IdImovel;

                ReceitasAluguel.Add(receita);

                dataRef = dataRef.AddMonths(1);

                contador++;
            }

            SvcReceitas.AdicionarReceitas(ReceitasAluguel, Aluguel.IdImovel);

            MessageBox.Show("Receitas com aluguel contabilizadas!");
        }
    }
}
