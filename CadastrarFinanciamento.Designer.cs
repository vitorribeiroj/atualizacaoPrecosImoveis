namespace ImoveisPrecoDesktopApp
{
    partial class CadastrarFinanciamento
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
            valorImovelInput = new TextBox();
            label2 = new Label();
            entradaInput = new TextBox();
            label4 = new Label();
            label5 = new Label();
            valorFinanciadoInput = new TextBox();
            label6 = new Label();
            label7 = new Label();
            sistemaAmortizacaoComboBox = new ComboBox();
            label1 = new Label();
            label8 = new Label();
            jurosInput = new NumericUpDown();
            label9 = new Label();
            taxaAdminInput = new TextBox();
            seguroInput = new TextBox();
            prazoInput = new NumericUpDown();
            salvarBtn = new Button();
            label3 = new Label();
            dataFinanciamentoInput = new DateTimePicker();
            cancelarBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)jurosInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prazoInput).BeginInit();
            SuspendLayout();
            // 
            // valorImovelInput
            // 
            valorImovelInput.Location = new Point(12, 31);
            valorImovelInput.Name = "valorImovelInput";
            valorImovelInput.Size = new Size(130, 23);
            valorImovelInput.TabIndex = 100;
            
            
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 13);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 44;
            label2.Text = "Valor do Imóvel";
            // 
            // entradaInput
            // 
            entradaInput.Location = new Point(166, 31);
            entradaInput.Name = "entradaInput";
            entradaInput.Size = new Size(130, 23);
            entradaInput.TabIndex = 101;
            
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(166, 13);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 49;
            label4.Text = "Entrada";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(319, 13);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 51;
            label5.Text = "Valor financiado";
            // 
            // valorFinanciadoInput
            // 
            valorFinanciadoInput.Location = new Point(319, 31);
            valorFinanciadoInput.Name = "valorFinanciadoInput";
            valorFinanciadoInput.Size = new Size(130, 23);
            valorFinanciadoInput.TabIndex = 102;
            
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 70);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 53;
            label6.Text = "Prazo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(166, 70);
            label7.Name = "label7";
            label7.Size = new Size(134, 15);
            label7.TabIndex = 55;
            label7.Text = "Sistema de Amortização";
            // 
            // sistemaAmortizacaoComboBox
            // 
            sistemaAmortizacaoComboBox.BackColor = Color.White;
            sistemaAmortizacaoComboBox.FormattingEnabled = true;
            sistemaAmortizacaoComboBox.Location = new Point(166, 88);
            sistemaAmortizacaoComboBox.Name = "sistemaAmortizacaoComboBox";
            sistemaAmortizacaoComboBox.Size = new Size(130, 23);
            sistemaAmortizacaoComboBox.TabIndex = 104;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 131);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 57;
            label1.Text = "Taxa de Administração";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(166, 131);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 58;
            label8.Text = "Seguro";
            // 
            // jurosInput
            // 
            jurosInput.DecimalPlaces = 4;
            jurosInput.Location = new Point(319, 88);
            jurosInput.Name = "jurosInput";
            jurosInput.Size = new Size(130, 23);
            jurosInput.TabIndex = 105;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(319, 70);
            label9.Name = "label9";
            label9.Size = new Size(117, 15);
            label9.TabIndex = 60;
            label9.Text = "Taxa de juros (% a.a.)";
            // 
            // taxaAdminInput
            // 
            taxaAdminInput.Location = new Point(12, 149);
            taxaAdminInput.Name = "taxaAdminInput";
            taxaAdminInput.Size = new Size(130, 23);
            taxaAdminInput.TabIndex = 106;
            
            // 
            // seguroInput
            // 
            seguroInput.Location = new Point(166, 149);
            seguroInput.Name = "seguroInput";
            seguroInput.Size = new Size(130, 23);
            seguroInput.TabIndex = 107;
            
            // 
            // prazoInput
            // 
            prazoInput.Location = new Point(12, 89);
            prazoInput.Maximum = new decimal(new int[] { 420, 0, 0, 0 });
            prazoInput.Name = "prazoInput";
            prazoInput.Size = new Size(130, 23);
            prazoInput.TabIndex = 103;
            // 
            // salvarBtn
            // 
            salvarBtn.Location = new Point(166, 200);
            salvarBtn.Name = "salvarBtn";
            salvarBtn.Size = new Size(130, 46);
            salvarBtn.TabIndex = 111;
            salvarBtn.Text = "SALVAR";
            salvarBtn.UseVisualStyleBackColor = true;
            salvarBtn.Click += salvarBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(319, 131);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 65;
            label3.Text = "Data do financiamento";
            // 
            // dataFinanciamentoInput
            // 
            dataFinanciamentoInput.Format = DateTimePickerFormat.Custom;
            dataFinanciamentoInput.Location = new Point(319, 149);
            dataFinanciamentoInput.Name = "dataFinanciamentoInput";
            dataFinanciamentoInput.Size = new Size(130, 23);
            dataFinanciamentoInput.TabIndex = 108;
            // 
            // cancelarBtn
            // 
            cancelarBtn.Location = new Point(12, 200);
            cancelarBtn.Name = "cancelarBtn";
            cancelarBtn.Size = new Size(130, 46);
            cancelarBtn.TabIndex = 110;
            cancelarBtn.Text = "CANCELAR";
            cancelarBtn.UseVisualStyleBackColor = true;
            cancelarBtn.Click += cancelarBtn_Click;
            // 
            // CadastrarFinanciamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 269);
            Controls.Add(cancelarBtn);
            Controls.Add(dataFinanciamentoInput);
            Controls.Add(label3);
            Controls.Add(salvarBtn);
            Controls.Add(prazoInput);
            Controls.Add(seguroInput);
            Controls.Add(taxaAdminInput);
            Controls.Add(label9);
            Controls.Add(jurosInput);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(sistemaAmortizacaoComboBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(valorFinanciadoInput);
            Controls.Add(label4);
            Controls.Add(entradaInput);
            Controls.Add(valorImovelInput);
            Controls.Add(label2);
            Name = "CadastrarFinanciamento";
            Text = "DadosFinanciamentocs";
            ((System.ComponentModel.ISupportInitialize)jurosInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)prazoInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox valorImovelInput;
        private Label label2;
        private TextBox entradaInput;
        private Label label4;
        private Label label5;
        private TextBox valorFinanciadoInput;
        private Label label6;
        private Label label7;
        private ComboBox sistemaAmortizacaoComboBox;
        private Label label1;
        private Label label8;
        private NumericUpDown jurosInput;
        private Label label9;
        private TextBox taxaAdminInput;
        private TextBox seguroInput;
        private NumericUpDown prazoInput;
        private Button salvarBtn;
        private Label label3;
        private DateTimePicker dataFinanciamentoInput;
        private Button cancelarBtn;

        
    }
}