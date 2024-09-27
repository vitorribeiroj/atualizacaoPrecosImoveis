namespace ImoveisPrecoDesktopApp
{
    partial class DadosFinanciamento
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
            dataFinanciamentoInput = new DateTimePicker();
            label3 = new Label();
            prazoInput = new NumericUpDown();
            seguroInput = new TextBox();
            taxaAdminInput = new TextBox();
            label9 = new Label();
            jurosInput = new NumericUpDown();
            label8 = new Label();
            label1 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            valorFinanciadoInput = new TextBox();
            label4 = new Label();
            entradaInput = new TextBox();
            valorImovelInput = new TextBox();
            label2 = new Label();
            label10 = new Label();
            parcelasGridView = new DataGridView();
            label11 = new Label();
            saldoFinanciamentoInput = new TextBox();
            label12 = new Label();
            pagamentosTotaisInput = new TextBox();
            label13 = new Label();
            parcelasPagasInput = new TextBox();
            label14 = new Label();
            label16 = new Label();
            parcelasRestantesInput = new TextBox();
            label15 = new Label();
            sistemaAmortizacaoInput = new TextBox();
            fecharBtn = new Button();
            amortizarBtn = new Button();
            exportarParcelasBtn = new Button();
            registrarPgtoParcelaBtn = new Button();
            deletarFinanciamentoBtn = new Button();
            label17 = new Label();
            reverterPgtoBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)prazoInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jurosInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)parcelasGridView).BeginInit();
            SuspendLayout();
            // 
            // dataFinanciamentoInput
            // 
            dataFinanciamentoInput.Format = DateTimePickerFormat.Custom;
            dataFinanciamentoInput.Location = new Point(330, 168);
            dataFinanciamentoInput.Name = "dataFinanciamentoInput";
            dataFinanciamentoInput.Size = new Size(130, 23);
            dataFinanciamentoInput.TabIndex = 126;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 150);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 117;
            label3.Text = "Data do financiamento";
            // 
            // prazoInput
            // 
            prazoInput.Location = new Point(24, 113);
            prazoInput.Maximum = new decimal(new int[] { 420, 0, 0, 0 });
            prazoInput.Name = "prazoInput";
            prazoInput.Size = new Size(130, 23);
            prazoInput.TabIndex = 121;
            // 
            // seguroInput
            // 
            seguroInput.Location = new Point(177, 168);
            seguroInput.Name = "seguroInput";
            seguroInput.Size = new Size(130, 23);
            seguroInput.TabIndex = 125;
            // 
            // taxaAdminInput
            // 
            taxaAdminInput.Location = new Point(23, 168);
            taxaAdminInput.Name = "taxaAdminInput";
            taxaAdminInput.Size = new Size(130, 23);
            taxaAdminInput.TabIndex = 124;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(331, 94);
            label9.Name = "label9";
            label9.Size = new Size(117, 15);
            label9.TabIndex = 116;
            label9.Text = "Taxa de juros (% a.a.)";
            // 
            // jurosInput
            // 
            jurosInput.DecimalPlaces = 4;
            jurosInput.Location = new Point(331, 112);
            jurosInput.Name = "jurosInput";
            jurosInput.Size = new Size(130, 23);
            jurosInput.TabIndex = 123;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(177, 150);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 115;
            label8.Text = "Seguro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 150);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 114;
            label1.Text = "Taxa de Administração";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(178, 94);
            label7.Name = "label7";
            label7.Size = new Size(134, 15);
            label7.TabIndex = 113;
            label7.Text = "Sistema de Amortização";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 94);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 112;
            label6.Text = "Prazo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(331, 43);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 111;
            label5.Text = "Valor financiado";
            // 
            // valorFinanciadoInput
            // 
            valorFinanciadoInput.Location = new Point(331, 61);
            valorFinanciadoInput.Name = "valorFinanciadoInput";
            valorFinanciadoInput.Size = new Size(130, 23);
            valorFinanciadoInput.TabIndex = 120;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(178, 43);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 110;
            label4.Text = "Entrada";
            // 
            // entradaInput
            // 
            entradaInput.Location = new Point(178, 61);
            entradaInput.Name = "entradaInput";
            entradaInput.Size = new Size(130, 23);
            entradaInput.TabIndex = 119;
            // 
            // valorImovelInput
            // 
            valorImovelInput.Location = new Point(24, 61);
            valorImovelInput.Name = "valorImovelInput";
            valorImovelInput.Size = new Size(130, 23);
            valorImovelInput.TabIndex = 118;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 43);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 109;
            label2.Text = "Valor do Imóvel";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(24, 18);
            label10.Name = "label10";
            label10.Size = new Size(94, 15);
            label10.TabIndex = 127;
            label10.Text = "DADOS GERAIS";
            // 
            // parcelasGridView
            // 
            parcelasGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            parcelasGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            parcelasGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            parcelasGridView.Location = new Point(23, 316);
            parcelasGridView.Name = "parcelasGridView";
            parcelasGridView.RowTemplate.Height = 25;
            parcelasGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            parcelasGridView.Size = new Size(583, 208);
            parcelasGridView.TabIndex = 128;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(23, 213);
            label11.Name = "label11";
            label11.Size = new Size(153, 15);
            label11.TabIndex = 129;
            label11.Text = "DETALHES AMORTIZAÇÃO";
            // 
            // saldoFinanciamentoInput
            // 
            saldoFinanciamentoInput.Location = new Point(23, 254);
            saldoFinanciamentoInput.Name = "saldoFinanciamentoInput";
            saldoFinanciamentoInput.Size = new Size(130, 23);
            saldoFinanciamentoInput.TabIndex = 131;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(23, 236);
            label12.Name = "label12";
            label12.Size = new Size(36, 15);
            label12.TabIndex = 130;
            label12.Text = "Saldo";
            // 
            // pagamentosTotaisInput
            // 
            pagamentosTotaisInput.Location = new Point(177, 254);
            pagamentosTotaisInput.Name = "pagamentosTotaisInput";
            pagamentosTotaisInput.Size = new Size(129, 23);
            pagamentosTotaisInput.TabIndex = 133;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(177, 236);
            label13.Name = "label13";
            label13.Size = new Size(105, 15);
            label13.TabIndex = 132;
            label13.Text = "Pagamentos totais";
            // 
            // parcelasPagasInput
            // 
            parcelasPagasInput.Location = new Point(328, 254);
            parcelasPagasInput.Name = "parcelasPagasInput";
            parcelasPagasInput.Size = new Size(130, 23);
            parcelasPagasInput.TabIndex = 135;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(328, 236);
            label14.Name = "label14";
            label14.Size = new Size(101, 15);
            label14.TabIndex = 134;
            label14.Text = "Nº parcelas pagas";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(23, 298);
            label16.Name = "label16";
            label16.Size = new Size(168, 15);
            label16.TabIndex = 138;
            label16.Text = "PARCELAS - DETALHAMENTO";
            // 
            // parcelasRestantesInput
            // 
            parcelasRestantesInput.Location = new Point(476, 254);
            parcelasRestantesInput.Name = "parcelasRestantesInput";
            parcelasRestantesInput.Size = new Size(130, 23);
            parcelasRestantesInput.TabIndex = 137;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(476, 236);
            label15.Name = "label15";
            label15.Size = new Size(124, 15);
            label15.TabIndex = 136;
            label15.Text = "Parcelas restantes (R$)";
            // 
            // sistemaAmortizacaoInput
            // 
            sistemaAmortizacaoInput.Location = new Point(177, 113);
            sistemaAmortizacaoInput.Name = "sistemaAmortizacaoInput";
            sistemaAmortizacaoInput.Size = new Size(130, 23);
            sistemaAmortizacaoInput.TabIndex = 139;
            // 
            // fecharBtn
            // 
            fecharBtn.Location = new Point(226, 589);
            fecharBtn.Name = "fecharBtn";
            fecharBtn.Size = new Size(167, 47);
            fecharBtn.TabIndex = 140;
            fecharBtn.Text = "FECHAR";
            fecharBtn.UseVisualStyleBackColor = true;
            fecharBtn.Click += fecharBtn_Click;
            // 
            // amortizarBtn
            // 
            amortizarBtn.Location = new Point(408, 536);
            amortizarBtn.Name = "amortizarBtn";
            amortizarBtn.Size = new Size(167, 47);
            amortizarBtn.TabIndex = 141;
            amortizarBtn.Text = "AMORTIZAÇÃO";
            amortizarBtn.UseVisualStyleBackColor = true;
            amortizarBtn.Click += amortizarBtn_Click;
            // 
            // exportarParcelasBtn
            // 
            exportarParcelasBtn.Location = new Point(44, 589);
            exportarParcelasBtn.Name = "exportarParcelasBtn";
            exportarParcelasBtn.Size = new Size(167, 47);
            exportarParcelasBtn.TabIndex = 142;
            exportarParcelasBtn.Text = "EXPORTAR";
            exportarParcelasBtn.UseVisualStyleBackColor = true;
            exportarParcelasBtn.Click += exportarParcelasBtn_Click;
            // 
            // registrarPgtoParcelaBtn
            // 
            registrarPgtoParcelaBtn.Location = new Point(44, 536);
            registrarPgtoParcelaBtn.Name = "registrarPgtoParcelaBtn";
            registrarPgtoParcelaBtn.Size = new Size(167, 47);
            registrarPgtoParcelaBtn.TabIndex = 143;
            registrarPgtoParcelaBtn.Text = "REGISTRAR PAGAMENTO";
            registrarPgtoParcelaBtn.UseVisualStyleBackColor = true;
            registrarPgtoParcelaBtn.Click += registrarPgtoParcelaBtn_Click;
            // 
            // deletarFinanciamentoBtn
            // 
            deletarFinanciamentoBtn.BackColor = Color.FromArgb(192, 0, 0);
            deletarFinanciamentoBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            deletarFinanciamentoBtn.ForeColor = Color.White;
            deletarFinanciamentoBtn.Location = new Point(408, 589);
            deletarFinanciamentoBtn.Name = "deletarFinanciamentoBtn";
            deletarFinanciamentoBtn.Size = new Size(167, 47);
            deletarFinanciamentoBtn.TabIndex = 144;
            deletarFinanciamentoBtn.Text = "DELETAR FINANCIAMENTO";
            deletarFinanciamentoBtn.UseVisualStyleBackColor = false;
            deletarFinanciamentoBtn.Click += deletarFinanciamentoBtn_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.Transparent;
            label17.Location = new Point(24, 642);
            label17.Name = "label17";
            label17.Size = new Size(223, 15);
            label17.TabIndex = 145;
            label17.Text = "ESPAÇO ----------------------------------";
            // 
            // reverterPgtoBtn
            // 
            reverterPgtoBtn.Location = new Point(226, 536);
            reverterPgtoBtn.Name = "reverterPgtoBtn";
            reverterPgtoBtn.Size = new Size(167, 47);
            reverterPgtoBtn.TabIndex = 146;
            reverterPgtoBtn.Text = "REVERTER PAGAMENTO";
            reverterPgtoBtn.UseVisualStyleBackColor = true;
            reverterPgtoBtn.Click += reverterPgtoBtn_Click;
            // 
            // DadosFinanciamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(633, 657);
            Controls.Add(reverterPgtoBtn);
            Controls.Add(label17);
            Controls.Add(deletarFinanciamentoBtn);
            Controls.Add(registrarPgtoParcelaBtn);
            Controls.Add(exportarParcelasBtn);
            Controls.Add(amortizarBtn);
            Controls.Add(fecharBtn);
            Controls.Add(sistemaAmortizacaoInput);
            Controls.Add(label16);
            Controls.Add(parcelasRestantesInput);
            Controls.Add(label15);
            Controls.Add(parcelasPagasInput);
            Controls.Add(label14);
            Controls.Add(pagamentosTotaisInput);
            Controls.Add(label13);
            Controls.Add(saldoFinanciamentoInput);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(parcelasGridView);
            Controls.Add(label10);
            Controls.Add(dataFinanciamentoInput);
            Controls.Add(label3);
            Controls.Add(prazoInput);
            Controls.Add(seguroInput);
            Controls.Add(taxaAdminInput);
            Controls.Add(label9);
            Controls.Add(jurosInput);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(valorFinanciadoInput);
            Controls.Add(label4);
            Controls.Add(entradaInput);
            Controls.Add(valorImovelInput);
            Controls.Add(label2);
            Name = "DadosFinanciamento";
            Text = "DadosFinanciamento";
            ((System.ComponentModel.ISupportInitialize)prazoInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)jurosInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)parcelasGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dataFinanciamentoInput;
        private Label label3;
        private NumericUpDown prazoInput;
        private TextBox seguroInput;
        private TextBox taxaAdminInput;
        private Label label9;
        private NumericUpDown jurosInput;
        private Label label8;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox valorFinanciadoInput;
        private Label label4;
        private TextBox entradaInput;
        private TextBox valorImovelInput;
        private Label label2;
        private Label label10;
        private DataGridView parcelasGridView;
        private Label label11;
        private TextBox saldoFinanciamentoInput;
        private Label label12;
        private TextBox pagamentosTotaisInput;
        private Label label13;
        private TextBox parcelasPagasInput;
        private Label label14;
        private Label label16;
        private TextBox parcelasRestantesInput;
        private Label label15;
        private TextBox sistemaAmortizacaoInput;
        private Button fecharBtn;
        private Button amortizarBtn;
        private Button exportarParcelasBtn;
        private Button registrarPgtoParcelaBtn;
        private Button deletarFinanciamentoBtn;
        private Label label17;
        private Button reverterPgtoBtn;
    }
}