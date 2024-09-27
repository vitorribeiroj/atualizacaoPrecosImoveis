namespace ImoveisPrecoDesktopApp
{
    partial class consultarImoveisWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            idImovelTextBox = new TextBox();
            apelidoImovelTextBox = new TextBox();
            logradouroTextBox = new TextBox();
            numeroTextBox = new TextBox();
            complementoTextBox = new TextBox();
            bairroTextBox = new TextBox();
            cidadeTextBox = new TextBox();
            estadoComboBox = new ComboBox();
            consultarImoveisBtn = new Button();
            limparFiltrosBtn = new Button();
            listaImoveisGridView = new DataGridView();
            label10 = new Label();
            voltarPaginaInicialBtn = new Button();
            consultarImovelSelecionadoBtn = new Button();
            listarTodosImoveisBtn = new Button();
            cepTextBox = new TextBox();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)listaImoveisGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(15, 9);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Filtros:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 44);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 1;
            label2.Text = "Código do imóvel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(134, 44);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 2;
            label3.Text = "Apelido do imóvel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 92);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 3;
            label4.Text = "Logradouro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(299, 92);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 4;
            label5.Text = "Número";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(366, 92);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 5;
            label6.Text = "Complemento";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 143);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 6;
            label7.Text = "Bairro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 193);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 7;
            label8.Text = "Cidade";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(299, 193);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 8;
            label9.Text = "Estado";
            // 
            // idImovelTextBox
            // 
            idImovelTextBox.Location = new Point(15, 62);
            idImovelTextBox.Name = "idImovelTextBox";
            idImovelTextBox.Size = new Size(100, 23);
            idImovelTextBox.TabIndex = 9;
            // 
            // apelidoImovelTextBox
            // 
            apelidoImovelTextBox.Location = new Point(131, 62);
            apelidoImovelTextBox.Name = "apelidoImovelTextBox";
            apelidoImovelTextBox.Size = new Size(319, 23);
            apelidoImovelTextBox.TabIndex = 10;
            // 
            // logradouroTextBox
            // 
            logradouroTextBox.Location = new Point(15, 110);
            logradouroTextBox.Name = "logradouroTextBox";
            logradouroTextBox.Size = new Size(270, 23);
            logradouroTextBox.TabIndex = 11;
            // 
            // numeroTextBox
            // 
            numeroTextBox.Location = new Point(299, 110);
            numeroTextBox.Name = "numeroTextBox";
            numeroTextBox.Size = new Size(50, 23);
            numeroTextBox.TabIndex = 12;
            // 
            // complementoTextBox
            // 
            complementoTextBox.Location = new Point(366, 110);
            complementoTextBox.Name = "complementoTextBox";
            complementoTextBox.Size = new Size(83, 23);
            complementoTextBox.TabIndex = 13;
            // 
            // bairroTextBox
            // 
            bairroTextBox.Location = new Point(15, 160);
            bairroTextBox.Name = "bairroTextBox";
            bairroTextBox.Size = new Size(270, 23);
            bairroTextBox.TabIndex = 14;
            // 
            // cidadeTextBox
            // 
            cidadeTextBox.Location = new Point(15, 211);
            cidadeTextBox.Name = "cidadeTextBox";
            cidadeTextBox.Size = new Size(270, 23);
            cidadeTextBox.TabIndex = 15;
            // 
            // estadoComboBox
            // 
            estadoComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(299, 211);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(60, 23);
            estadoComboBox.TabIndex = 17;
            // 
            // consultarImoveisBtn
            // 
            consultarImoveisBtn.Location = new Point(484, 110);
            consultarImoveisBtn.Name = "consultarImoveisBtn";
            consultarImoveisBtn.Size = new Size(148, 40);
            consultarImoveisBtn.TabIndex = 18;
            consultarImoveisBtn.Text = "FILTRAR";
            consultarImoveisBtn.UseVisualStyleBackColor = true;
            consultarImoveisBtn.Click += consultarImoveisBtn_Click;
            // 
            // limparFiltrosBtn
            // 
            limparFiltrosBtn.Location = new Point(484, 160);
            limparFiltrosBtn.Name = "limparFiltrosBtn";
            limparFiltrosBtn.Size = new Size(148, 40);
            limparFiltrosBtn.TabIndex = 19;
            limparFiltrosBtn.Text = "LIMPAR FILTROS";
            limparFiltrosBtn.UseVisualStyleBackColor = true;
            limparFiltrosBtn.Click += limparFiltrosBtn_Click;
            // 
            // listaImoveisGridView
            // 
            listaImoveisGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listaImoveisGridView.Cursor = Cursors.Hand;
            listaImoveisGridView.Location = new Point(15, 292);
            listaImoveisGridView.Name = "listaImoveisGridView";
            listaImoveisGridView.RowTemplate.Height = 25;
            listaImoveisGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listaImoveisGridView.Size = new Size(620, 180);
            listaImoveisGridView.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(15, 259);
            label10.Name = "label10";
            label10.Size = new Size(116, 20);
            label10.TabIndex = 21;
            label10.Text = "Lista de imóves:";
            // 
            // voltarPaginaInicialBtn
            // 
            voltarPaginaInicialBtn.Location = new Point(15, 488);
            voltarPaginaInicialBtn.Name = "voltarPaginaInicialBtn";
            voltarPaginaInicialBtn.Size = new Size(140, 40);
            voltarPaginaInicialBtn.TabIndex = 22;
            voltarPaginaInicialBtn.Text = "VOLTAR";
            voltarPaginaInicialBtn.UseVisualStyleBackColor = true;
            voltarPaginaInicialBtn.Click += voltarPaginaInicialBtn_Click;
            // 
            // consultarImovelSelecionadoBtn
            // 
            consultarImovelSelecionadoBtn.Location = new Point(421, 488);
            consultarImovelSelecionadoBtn.Name = "consultarImovelSelecionadoBtn";
            consultarImovelSelecionadoBtn.Size = new Size(220, 40);
            consultarImovelSelecionadoBtn.TabIndex = 23;
            consultarImovelSelecionadoBtn.Text = "CONSULTAR IMÓVEL SELECIONADO";
            consultarImovelSelecionadoBtn.UseVisualStyleBackColor = true;
            consultarImovelSelecionadoBtn.Click += consultarImovelSelecionadoBtn_Click;
            // 
            // listarTodosImoveisBtn
            // 
            listarTodosImoveisBtn.Location = new Point(484, 62);
            listarTodosImoveisBtn.Name = "listarTodosImoveisBtn";
            listarTodosImoveisBtn.Size = new Size(148, 40);
            listarTodosImoveisBtn.TabIndex = 24;
            listarTodosImoveisBtn.Text = "LISTAR TODOS";
            listarTodosImoveisBtn.UseVisualStyleBackColor = true;
            listarTodosImoveisBtn.Click += listarTodosImoveisBtn_Click;
            // 
            // cepTextBox
            // 
            cepTextBox.Location = new Point(299, 160);
            cepTextBox.Name = "cepTextBox";
            cepTextBox.Size = new Size(150, 23);
            cepTextBox.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(299, 143);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 25;
            label11.Text = "CEP";
            // 
            // consultarImoveisWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 548);
            Controls.Add(cepTextBox);
            Controls.Add(label11);
            Controls.Add(listarTodosImoveisBtn);
            Controls.Add(consultarImovelSelecionadoBtn);
            Controls.Add(voltarPaginaInicialBtn);
            Controls.Add(label10);
            Controls.Add(listaImoveisGridView);
            Controls.Add(limparFiltrosBtn);
            Controls.Add(consultarImoveisBtn);
            Controls.Add(estadoComboBox);
            Controls.Add(cidadeTextBox);
            Controls.Add(bairroTextBox);
            Controls.Add(complementoTextBox);
            Controls.Add(numeroTextBox);
            Controls.Add(logradouroTextBox);
            Controls.Add(apelidoImovelTextBox);
            Controls.Add(idImovelTextBox);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "consultarImoveisWindow";
            StartPosition = FormStartPosition.Manual;
            Text = "ConsultarImoveis";
            Load += consultarImoveisWindow_Load;
            ((System.ComponentModel.ISupportInitialize)listaImoveisGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox idImovelTextBox;
        private TextBox apelidoImovelTextBox;
        private TextBox logradouroTextBox;
        private TextBox numeroTextBox;
        private TextBox complementoTextBox;
        private TextBox bairroTextBox;
        private TextBox cidadeTextBox;
        private ComboBox estadoComboBox;
        private Button consultarImoveisBtn;
        private Button limparFiltrosBtn;
        private DataGridView listaImoveisGridView;
        private Label label10;
        private Button voltarPaginaInicialBtn;
        private Button consultarImovelSelecionadoBtn;
        private Button listarTodosImoveisBtn;
        private TextBox cepTextBox;
        private Label label11;
    }
}