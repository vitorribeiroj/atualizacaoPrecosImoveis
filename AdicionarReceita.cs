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
    public partial class AdicionarReceita : Form
    {
        public int IdImovel { get; set; }
        public bool Alteracoes { get; set; } = false;
        public event Action OnFormClosingEvent;

        public AdicionarReceita(int idImovel)
        {
            InitializeComponent();
            LoadReceitaTipoComboBox();
            IdImovel = idImovel;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (Alteracoes)
            {
                OnFormClosingEvent?.Invoke();
            }
        }

        private void addReceitaBtn_Click(object sender, EventArgs e)
        {
            Receita receita = new Receita();

            receita.Descricao = descricaoInput.Text;
            receita.DataRecebimento = dataRecebimentoPicker.Value.Date;

            double valor = 0;
            double.TryParse(valorInput.Text, out valor);
            receita.Valor = valor;

            string classificacao = receitaTipoComboBox.Text;
            ReceitaTipo? tipo = null;

            try
            {
                tipo = EnumExtensions.GetEnumByDescription<ReceitaTipo>(classificacao);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            receita.Tipo = tipo.Value;

            receita.ImovelId = IdImovel;

            SvcReceitas.AdicionarReceita(receita);

            Alteracoes = true;

            MessageBox.Show("Receita adicionada com sucesso!");

            LimparCampos();
        }

        private void LoadReceitaTipoComboBox()
        {
            receitaTipoComboBox.Items.Insert(0,"Selecione o tipo de receita...");

            var listaTipos = Enum.GetValues(typeof(ReceitaTipo))
                                 .Cast<ReceitaTipo>()
                                 .Select(i => i.GetDescription())
                                 .ToList();

            listaTipos.Sort();            

            foreach (var tipo in listaTipos)
            {
                if(tipo != ReceitaTipo.OUTROS.GetDescription())
                    receitaTipoComboBox.Items.Add(tipo);
            }

            receitaTipoComboBox.Items.Add(ReceitaTipo.OUTROS.GetDescription());

            receitaTipoComboBox.SelectedIndex = 0;
        }       

        private void LimparCampos()
        {
            descricaoInput.Clear();
            valorInput.Value = 0;
            receitaTipoComboBox.SelectedIndex = 0;            
            dataRecebimentoPicker.Value = DateTime.Today;
        }

        private void cleanFieldsBtn_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void SortComboBoxItems(ComboBox comboBox)
        {
            // Criar uma lista para armazenar os itens do ComboBox
            List<string> items = new List<string>();

            // Adicionar itens à lista
            foreach (var item in comboBox.Items)
            {
                items.Add(item.ToString());
            }

            // Ordenar a lista
            items.Sort();

            // Limpar os itens atuais do ComboBox
            comboBox.Items.Clear();

            // Adicionar os itens ordenados ao ComboBox
            foreach (var item in items)
            {
                comboBox.Items.Add(item);
            }
        }


    }
}
