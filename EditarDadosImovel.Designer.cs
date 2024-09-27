namespace ImoveisPrecoDesktopApp
{
    partial class EditarDadosImovel
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
            cepTextBox = new TextBox();
            label11 = new Label();
            estadoComboBox = new ComboBox();
            cidadeTextBox = new TextBox();
            bairroTextBox = new TextBox();
            complementoTextBox = new TextBox();
            numeroTextBox = new TextBox();
            logradouroTextBox = new TextBox();
            apelidoImovelTextBox = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            fotoPerfilImovel = new PictureBox();
            alterarFotoBtn = new Button();
            confirmaBtn = new Button();
            cancelaBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)fotoPerfilImovel).BeginInit();
            SuspendLayout();
            // 
            // cepTextBox
            // 
            cepTextBox.Location = new Point(353, 235);
            cepTextBox.Name = "cepTextBox";
            cepTextBox.Size = new Size(203, 23);
            cepTextBox.TabIndex = 42;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(353, 218);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 41;
            label11.Text = "CEP";
            // 
            // estadoComboBox
            // 
            estadoComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(496, 289);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(60, 23);
            estadoComboBox.TabIndex = 40;
            // 
            // cidadeTextBox
            // 
            cidadeTextBox.Location = new Point(15, 289);
            cidadeTextBox.Name = "cidadeTextBox";
            cidadeTextBox.Size = new Size(460, 23);
            cidadeTextBox.TabIndex = 39;
            // 
            // bairroTextBox
            // 
            bairroTextBox.Location = new Point(15, 235);
            bairroTextBox.Name = "bairroTextBox";
            bairroTextBox.Size = new Size(322, 23);
            bairroTextBox.TabIndex = 38;
            // 
            // complementoTextBox
            // 
            complementoTextBox.Location = new Point(353, 179);
            complementoTextBox.Name = "complementoTextBox";
            complementoTextBox.Size = new Size(203, 23);
            complementoTextBox.TabIndex = 37;
            // 
            // numeroTextBox
            // 
            numeroTextBox.Location = new Point(286, 179);
            numeroTextBox.Name = "numeroTextBox";
            numeroTextBox.Size = new Size(50, 23);
            numeroTextBox.TabIndex = 36;
            // 
            // logradouroTextBox
            // 
            logradouroTextBox.Location = new Point(286, 126);
            logradouroTextBox.Name = "logradouroTextBox";
            logradouroTextBox.Size = new Size(270, 23);
            logradouroTextBox.TabIndex = 35;
            // 
            // apelidoImovelTextBox
            // 
            apelidoImovelTextBox.Location = new Point(286, 77);
            apelidoImovelTextBox.Name = "apelidoImovelTextBox";
            apelidoImovelTextBox.Size = new Size(270, 23);
            apelidoImovelTextBox.TabIndex = 34;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(496, 271);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 33;
            label9.Text = "Estado";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 271);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 32;
            label8.Text = "Cidade";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 218);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 31;
            label7.Text = "Bairro";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(353, 161);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 30;
            label6.Text = "Complemento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(286, 161);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 29;
            label5.Text = "Número";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(286, 108);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 28;
            label4.Text = "Logradouro";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 59);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 27;
            label3.Text = "Apelido do imóvel";
            // 
            // fotoPerfilImovel
            // 
            fotoPerfilImovel.Image = Properties.Resources.fachada;
            fotoPerfilImovel.Location = new Point(15, 12);
            fotoPerfilImovel.Name = "fotoPerfilImovel";
            fotoPerfilImovel.Size = new Size(250, 190);
            fotoPerfilImovel.SizeMode = PictureBoxSizeMode.StretchImage;
            fotoPerfilImovel.TabIndex = 43;
            fotoPerfilImovel.TabStop = false;
            // 
            // alterarFotoBtn
            // 
            alterarFotoBtn.Location = new Point(286, 12);
            alterarFotoBtn.Name = "alterarFotoBtn";
            alterarFotoBtn.Size = new Size(121, 35);
            alterarFotoBtn.TabIndex = 44;
            alterarFotoBtn.Text = "ALTERAR FOTO";
            alterarFotoBtn.UseVisualStyleBackColor = true;
            alterarFotoBtn.Click += alterarFotoBtn_Click;
            // 
            // confirmaBtn
            // 
            confirmaBtn.Location = new Point(206, 338);
            confirmaBtn.Name = "confirmaBtn";
            confirmaBtn.Size = new Size(175, 35);
            confirmaBtn.TabIndex = 45;
            confirmaBtn.Text = "CONFIRMAR EDIÇÃO";
            confirmaBtn.UseVisualStyleBackColor = true;
            confirmaBtn.Click += confirmaBtn_Click;
            // 
            // cancelaBtn
            // 
            cancelaBtn.Location = new Point(15, 338);
            cancelaBtn.Name = "cancelaBtn";
            cancelaBtn.Size = new Size(175, 35);
            cancelaBtn.TabIndex = 46;
            cancelaBtn.Text = "CANCELAR";
            cancelaBtn.UseVisualStyleBackColor = true;
            cancelaBtn.Click += cancelaBtn_Click;
            // 
            // EditarDadosImovel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 392);
            Controls.Add(cancelaBtn);
            Controls.Add(confirmaBtn);
            Controls.Add(alterarFotoBtn);
            Controls.Add(fotoPerfilImovel);
            Controls.Add(cepTextBox);
            Controls.Add(label11);
            Controls.Add(estadoComboBox);
            Controls.Add(cidadeTextBox);
            Controls.Add(bairroTextBox);
            Controls.Add(complementoTextBox);
            Controls.Add(numeroTextBox);
            Controls.Add(logradouroTextBox);
            Controls.Add(apelidoImovelTextBox);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Name = "EditarDadosImovel";
            Text = "EditarDadosImovel";
            ((System.ComponentModel.ISupportInitialize)fotoPerfilImovel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox cepTextBox;
        private Label label11;
        private ComboBox estadoComboBox;
        private TextBox cidadeTextBox;
        private TextBox bairroTextBox;
        private TextBox complementoTextBox;
        private TextBox numeroTextBox;
        private TextBox logradouroTextBox;
        private TextBox apelidoImovelTextBox;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private PictureBox fotoPerfilImovel;
        private Button alterarFotoBtn;
        private Button confirmaBtn;
        private Button cancelaBtn;
    }
}