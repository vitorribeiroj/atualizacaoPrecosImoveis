using ImoveisPrecoDesktopApp.Models;
using ImoveisPrecoDesktopApp.Services;
using Microsoft.VisualBasic;
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
    public partial class consultarImoveisWindow : Form
    {
        //public PaginaPrincipal PaginaPrincipal { get; set; }
        public event Action OnFormClosingEvent;
        

        public consultarImoveisWindow()
        {
            InitializeComponent();            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            OnFormClosingEvent?.Invoke();
        }

        private void voltarPaginaInicialBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void consultarImoveisWindow_Load(object sender, EventArgs e)
        {
            var listaEstados = Enum.GetValues(typeof(EstadosFederativos))
                                   .Cast<object>()
                                   .ToArray();

            estadoComboBox.Items.Add("");

            estadoComboBox.Items.AddRange(listaEstados);

            listaImoveisGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void limparFiltrosBtn_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            idImovelTextBox.Clear();
            apelidoImovelTextBox.Clear();
            logradouroTextBox.Clear();
            numeroTextBox.Clear();
            complementoTextBox.Clear();
            bairroTextBox.Clear();
            cepTextBox.Clear();
            cidadeTextBox.Clear();
            estadoComboBox.SelectedIndex = 0;
            listaImoveisGridView.DataSource = null;
        }


        private void consultarImovelSelecionadoBtn_Click(object sender, EventArgs e)
        {
            if (listaImoveisGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecione um imóvel para consulta individual");
            }
            else
            {
                var registro = listaImoveisGridView.SelectedRows[0];

                try
                {
                    int idImovelSelecionado = int.Parse(registro.Cells["id"].Value.ToString());

                    var janelaConsultaIndividual = new JanelaConsultaIndividual(idImovelSelecionado);

                    janelaConsultaIndividual.ShowDialog();

                    //janelaConsultaIndividual.OnFormClosingEvent += this.ShowDialog;

                    //this.Hide();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro na consulta\n\n"+ex.StackTrace);
                }
            }    
            
        }

        private void consultarImoveisBtn_Click(object sender, EventArgs e)
        {
            listaImoveisGridView.DataSource = null;

            DataTable imoveis = null;

            //listaImoveisGridView.DataSource = imoveis;
            bool clausulaLike = false;

            var idImovel = ("id", idImovelTextBox.Text, clausulaLike = false);
            var apelido = ("apelido", apelidoImovelTextBox.Text, clausulaLike = true);
            var logradouro = ("logradouro", logradouroTextBox.Text, clausulaLike = true);
            var numero = ("numero", numeroTextBox.Text, clausulaLike = false);
            var complemento = ("complemento", complementoTextBox.Text, clausulaLike = true);
            var bairro = ("bairro", bairroTextBox.Text, clausulaLike = true);
            var cep = ("cep", cepTextBox.Text, clausulaLike = false);
            var cidade = ("cidade", cidadeTextBox.Text, clausulaLike = true);
            var estado = ("estado", estadoComboBox.Text, clausulaLike = false);

            List<(string, string, bool)> filtros = new List<(string, string, bool)>() { };

            filtros.Add(idImovel);
            filtros.Add(apelido);
            filtros.Add(logradouro);
            filtros.Add(numero);
            filtros.Add(complemento);
            filtros.Add(bairro);
            filtros.Add(cep);
            filtros.Add(cidade);
            filtros.Add(estado);

            List<string> atributosClasulasWHERE = new List<string>() { };
            var numeroFiltros = 0;

            foreach (var filtro in filtros)
            {
                if (filtro.Item2 != "")
                {
                    var clausula = "";

                    if (filtro.Item3)
                    {
                        clausula = $"LOWER({filtro.Item1}) LIKE LOWER('%{filtro.Item2}%')";
                    }
                    else
                    {
                        clausula = $"LOWER({filtro.Item1}) = LOWER({filtro.Item2})";
                    }
                    atributosClasulasWHERE.Add(clausula);
                    numeroFiltros++;
                }
            }

            if (numeroFiltros != 0)
            {
                imoveis = SvcImoveis.ListarImoveisFiltrados(atributosClasulasWHERE);

                if (imoveis?.Rows.Count > 0)
                {
                    listaImoveisGridView.DataSource = imoveis;

                    CustomizarImoveisGridView();
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado com os parâmetros informados");
                }
            }
        }

        private void listarTodosImoveisBtn_Click(object sender, EventArgs e)
        {
            var imoveis = SvcImoveis.ListarTodosOsImoveis();

            listaImoveisGridView.DataSource = imoveis;

            CustomizarImoveisGridView();
        }

        private void CustomizarImoveisGridView()
        {
            listaImoveisGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn coluna in listaImoveisGridView.Columns)
            {
                if (coluna.Name == "id" | coluna.Name == "caminho_foto")
                {
                    coluna.Visible = false;
                }

                switch (coluna.Name)
                {
                    case "apelido":
                        coluna.HeaderText = "Apelido";
                        break;
                    case "logradouro":
                        coluna.HeaderText = "Logradouro";
                        break;
                    case "numero":
                        coluna.HeaderText = "Número";
                        break;
                    case "complemento":
                        coluna.HeaderText = "Complemento";
                        break;
                    case "bairro":
                        coluna.HeaderText = "Bairro";
                        break;
                    case "cidade":
                        coluna.HeaderText = "Cidade";
                        break;
                    case "estado":
                        coluna.HeaderText = "Estado";
                        break;
                    case "cep":
                        coluna.HeaderText = "CEP";
                        break;
                }
            }
        }

    }
}
