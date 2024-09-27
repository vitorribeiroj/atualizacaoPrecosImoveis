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
    public partial class EditarDadosImovel : Form
    {
        public Imovel Imovel { get; set; }
        public bool Alteracoes { get; set; } = false;
        public event Action OnFormClosingEvent;

        public EditarDadosImovel(Imovel imovel)
        {
            InitializeComponent();
            Imovel = imovel;
            CarregarJanela();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);


            OnFormClosingEvent?.Invoke();

        }
        
        private void CarregarJanela()
        {
            if (Imovel is not null)
            {
                var listaEstados = Enum.GetValues(typeof(EstadosFederativos))
                                   .Cast<object>()
                                   .ToArray();

                estadoComboBox.Items.AddRange(listaEstados);

                apelidoImovelTextBox.Text = Imovel.Apelido;
                logradouroTextBox.Text = Imovel.Logradouro;
                numeroTextBox.Text = Imovel.Numero;
                complementoTextBox.Text = Imovel.Complemento;
                bairroTextBox.Text = Imovel.Bairro;
                cidadeTextBox.Text = Imovel.Cidade;
                estadoComboBox.SelectedItem = Enum.Parse(typeof(EstadosFederativos), Imovel.Estado);
                cepTextBox.Text = Imovel.Cep;
                fotoPerfilImovel.Image = Image.FromFile(Imovel.FotoPath);
            }
        }

        private void cancelaBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void alterarFotoBtn_Click(object sender, EventArgs e)
        {
            // Cria uma instância do OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Configura o OpenFileDialog para aceitar apenas arquivos com extensões específicas
            openFileDialog.Title = "Selecione um arquivo de imagem";
            openFileDialog.Filter = "Imagens (*.gif;*.jpeg;*.jpg;*.bmp;*.png)|*.gif;*.jpeg;*.jpg;*.bmp;*.png";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // Exibe a caixa de diálogo e verifica se o usuário clicou em "OK"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {                
                Imovel.FotoPath = openFileDialog.FileName;           

                fotoPerfilImovel.Image = Image.FromFile(Imovel.FotoPath);
            }
        }

        private void confirmaBtn_Click(object sender, EventArgs e)
        {
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
                    Imovel.Apelido = apelidoImovelTextBox.Text;
                    Imovel.Logradouro = logradouroTextBox.Text;
                    Imovel.Numero = numeroTextBox.Text;
                    Imovel.Complemento = complementoTextBox.Text;
                    Imovel.Bairro = bairroTextBox.Text;
                    Imovel.Cidade = cidadeTextBox.Text;
                    Imovel.Estado = estadoComboBox.Text;
                    Imovel.Cep = cepTextBox.Text;

                    SvcImoveis.EditarImovel(Imovel);

                    Alteracoes = true;                    

                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Não foi possível editar os dados do imóvel");
                }
            }
        }
    }
}
