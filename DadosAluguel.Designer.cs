namespace ImoveisPrecoDesktopApp
{
    partial class DadosAluguel
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
            valorAluguelInput = new TextBox();
            label2 = new Label();
            taxaIntermediacaoInput = new NumericUpDown();
            taxaAdminInput = new NumericUpDown();
            label3 = new Label();
            impostoInput = new NumericUpDown();
            label4 = new Label();
            saveBtn = new Button();
            fecharBtn = new Button();
            contabilizarAluguelBtn = new Button();
            rendaLiquidaBtn = new Button();
            rendaLiquidaInput = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)taxaIntermediacaoInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)taxaAdminInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)impostoInput).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 19);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "Valor Aluguel:";
            // 
            // valorAluguelInput
            // 
            valorAluguelInput.Location = new Point(21, 37);
            valorAluguelInput.Name = "valorAluguelInput";
            valorAluguelInput.Size = new Size(120, 23);
            valorAluguelInput.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 72);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 2;
            label2.Text = "Taxa intermediação:";
            // 
            // taxaIntermediacaoInput
            // 
            taxaIntermediacaoInput.Location = new Point(21, 90);
            taxaIntermediacaoInput.Name = "taxaIntermediacaoInput";
            taxaIntermediacaoInput.Size = new Size(120, 23);
            taxaIntermediacaoInput.TabIndex = 3;
            // 
            // taxaAdminInput
            // 
            taxaAdminInput.Location = new Point(21, 147);
            taxaAdminInput.Name = "taxaAdminInput";
            taxaAdminInput.Size = new Size(120, 23);
            taxaAdminInput.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 129);
            label3.Name = "label3";
            label3.Size = new Size(111, 15);
            label3.TabIndex = 4;
            label3.Text = "Taxa administração:";
            // 
            // impostoInput
            // 
            impostoInput.Location = new Point(21, 205);
            impostoInput.Name = "impostoInput";
            impostoInput.Size = new Size(120, 23);
            impostoInput.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 187);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 6;
            label4.Text = "Imposto de renda:";
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(171, 91);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(156, 51);
            saveBtn.TabIndex = 8;
            saveBtn.Text = "SALVAR";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // fecharBtn
            // 
            fecharBtn.Location = new Point(171, 237);
            fecharBtn.Name = "fecharBtn";
            fecharBtn.Size = new Size(156, 51);
            fecharBtn.TabIndex = 9;
            fecharBtn.Text = "FECHAR";
            fecharBtn.UseVisualStyleBackColor = true;
            fecharBtn.Click += fecharBtn_Click;
            // 
            // contabilizarAluguelBtn
            // 
            contabilizarAluguelBtn.Location = new Point(171, 165);
            contabilizarAluguelBtn.Name = "contabilizarAluguelBtn";
            contabilizarAluguelBtn.Size = new Size(156, 51);
            contabilizarAluguelBtn.TabIndex = 10;
            contabilizarAluguelBtn.Text = "CONTABILIZAR RECEITAS DE ALUGUEL";
            contabilizarAluguelBtn.UseVisualStyleBackColor = true;
            contabilizarAluguelBtn.Click += contabilizarAluguelBtn_Click;
            // 
            // rendaLiquidaBtn
            // 
            rendaLiquidaBtn.Location = new Point(171, 19);
            rendaLiquidaBtn.Name = "rendaLiquidaBtn";
            rendaLiquidaBtn.Size = new Size(156, 51);
            rendaLiquidaBtn.TabIndex = 11;
            rendaLiquidaBtn.Text = "CALCULAR RENDA LÍQUIDA";
            rendaLiquidaBtn.UseVisualStyleBackColor = true;
            rendaLiquidaBtn.Click += rendaLiquidaBtn_Click;
            // 
            // rendaLiquidaInput
            // 
            rendaLiquidaInput.Location = new Point(21, 265);
            rendaLiquidaInput.Name = "rendaLiquidaInput";
            rendaLiquidaInput.Size = new Size(120, 23);
            rendaLiquidaInput.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 247);
            label5.Name = "label5";
            label5.Size = new Size(123, 15);
            label5.TabIndex = 12;
            label5.Text = "Renda líquida mensal:";
            // 
            // DadosAluguel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 311);
            Controls.Add(rendaLiquidaInput);
            Controls.Add(label5);
            Controls.Add(rendaLiquidaBtn);
            Controls.Add(contabilizarAluguelBtn);
            Controls.Add(fecharBtn);
            Controls.Add(saveBtn);
            Controls.Add(impostoInput);
            Controls.Add(label4);
            Controls.Add(taxaAdminInput);
            Controls.Add(label3);
            Controls.Add(taxaIntermediacaoInput);
            Controls.Add(label2);
            Controls.Add(valorAluguelInput);
            Controls.Add(label1);
            Name = "DadosAluguel";
            Text = "DadosAluguel";
            ((System.ComponentModel.ISupportInitialize)taxaIntermediacaoInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)taxaAdminInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)impostoInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox valorAluguelInput;
        private Label label2;
        private NumericUpDown taxaIntermediacaoInput;
        private NumericUpDown taxaAdminInput;
        private Label label3;
        private NumericUpDown impostoInput;
        private Label label4;
        private Button saveBtn;
        private Button fecharBtn;
        private Button contabilizarAluguelBtn;
        private Button rendaLiquidaBtn;
        private TextBox rendaLiquidaInput;
        private Label label5;
    }
}