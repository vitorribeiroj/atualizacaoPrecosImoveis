using ImoveisPrecoDesktopApp.Services;
using System.Globalization;

namespace ImoveisPrecoDesktopApp
{
    public partial class PaginaPrincipal : Form
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void ConsultarImovelBtn_Click(object sender, EventArgs e)
        {
            var consultarImoveisWin = new consultarImoveisWindow();
            consultarImoveisWin.OnFormClosingEvent += VoltarParaJanelaAnterior;
            //this.Hide();
            consultarImoveisWin.ShowDialog();
        }

        private void VoltarParaJanelaAnterior()
        {
            this.Show();
        }

        private void CadastrarImovelBtn_Click(object sender, EventArgs e)
        {
            

           
        }
    }
}