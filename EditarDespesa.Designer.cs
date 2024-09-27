namespace ImoveisPrecoDesktopApp
{
    partial class EditarDespesa
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
            valorInput = new NumericUpDown();
            confirmarEdicaoBtn = new Button();
            label6 = new Label();
            label5 = new Label();
            IR_dedutivel_NAO_btn = new RadioButton();
            IR_dedutivel_SIM_btn = new RadioButton();
            dataPagamentoPicker = new DateTimePicker();
            despesaTipoComboBox = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            descricaoInput = new TextBox();
            label2 = new Label();
            CancelarBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)valorInput).BeginInit();
            SuspendLayout();
            // 
            // valorInput
            // 
            valorInput.DecimalPlaces = 2;
            valorInput.Location = new Point(22, 154);
            valorInput.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            valorInput.Name = "valorInput";
            valorInput.Size = new Size(140, 23);
            valorInput.TabIndex = 26;
            // 
            // confirmarEdicaoBtn
            // 
            confirmarEdicaoBtn.Location = new Point(17, 263);
            confirmarEdicaoBtn.Name = "confirmarEdicaoBtn";
            confirmarEdicaoBtn.Size = new Size(130, 50);
            confirmarEdicaoBtn.TabIndex = 25;
            confirmarEdicaoBtn.Text = "CONFIRMAR";
            confirmarEdicaoBtn.UseVisualStyleBackColor = true;
            confirmarEdicaoBtn.Click += confirmarEdicaoBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(195, 136);
            label6.Name = "label6";
            label6.Size = new Size(112, 15);
            label6.TabIndex = 24;
            label6.Text = "Data do pagamento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 195);
            label5.Name = "label5";
            label5.Size = new Size(173, 15);
            label5.TabIndex = 23;
            label5.Text = "Dedutível do Imposto de Renda";
            // 
            // IR_dedutivel_NAO_btn
            // 
            IR_dedutivel_NAO_btn.AutoSize = true;
            IR_dedutivel_NAO_btn.Location = new Point(73, 222);
            IR_dedutivel_NAO_btn.Name = "IR_dedutivel_NAO_btn";
            IR_dedutivel_NAO_btn.Size = new Size(51, 19);
            IR_dedutivel_NAO_btn.TabIndex = 22;
            IR_dedutivel_NAO_btn.Text = "NÃO";
            IR_dedutivel_NAO_btn.UseVisualStyleBackColor = true;
            // 
            // IR_dedutivel_SIM_btn
            // 
            IR_dedutivel_SIM_btn.AutoSize = true;
            IR_dedutivel_SIM_btn.Location = new Point(22, 222);
            IR_dedutivel_SIM_btn.Name = "IR_dedutivel_SIM_btn";
            IR_dedutivel_SIM_btn.Size = new Size(45, 19);
            IR_dedutivel_SIM_btn.TabIndex = 21;
            IR_dedutivel_SIM_btn.Text = "SIM";
            IR_dedutivel_SIM_btn.UseVisualStyleBackColor = true;
            // 
            // dataPagamentoPicker
            // 
            dataPagamentoPicker.Format = DateTimePickerFormat.Custom;
            dataPagamentoPicker.Location = new Point(195, 154);
            dataPagamentoPicker.Name = "dataPagamentoPicker";
            dataPagamentoPicker.Size = new Size(112, 23);
            dataPagamentoPicker.TabIndex = 20;
            // 
            // despesaTipoComboBox
            // 
            despesaTipoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            despesaTipoComboBox.FormattingEnabled = true;
            despesaTipoComboBox.Location = new Point(22, 96);
            despesaTipoComboBox.Name = "despesaTipoComboBox";
            despesaTipoComboBox.Size = new Size(286, 23);
            despesaTipoComboBox.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 136);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 18;
            label4.Text = "Valor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 78);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 17;
            label3.Text = "Classificação";
            // 
            // descricaoInput
            // 
            descricaoInput.Location = new Point(22, 36);
            descricaoInput.Name = "descricaoInput";
            descricaoInput.Size = new Size(286, 23);
            descricaoInput.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 18);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 15;
            label2.Text = "Descrição";
            // 
            // CancelarBtn
            // 
            CancelarBtn.Location = new Point(178, 263);
            CancelarBtn.Name = "CancelarBtn";
            CancelarBtn.Size = new Size(130, 50);
            CancelarBtn.TabIndex = 27;
            CancelarBtn.Text = "CANCELAR";
            CancelarBtn.UseVisualStyleBackColor = true;
            CancelarBtn.Click += CancelarBtn_Click;
            // 
            // EditarDespesa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 330);
            Controls.Add(CancelarBtn);
            Controls.Add(valorInput);
            Controls.Add(confirmarEdicaoBtn);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(IR_dedutivel_NAO_btn);
            Controls.Add(IR_dedutivel_SIM_btn);
            Controls.Add(dataPagamentoPicker);
            Controls.Add(despesaTipoComboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(descricaoInput);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "EditarDespesa";
            Text = "EditarDespesa";
            ((System.ComponentModel.ISupportInitialize)valorInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown valorInput;
        private Button confirmarEdicaoBtn;
        private Label label6;
        private Label label5;
        private RadioButton IR_dedutivel_NAO_btn;
        private RadioButton IR_dedutivel_SIM_btn;
        private DateTimePicker dataPagamentoPicker;
        private ComboBox despesaTipoComboBox;
        private Label label4;
        private Label label3;
        private TextBox descricaoInput;
        private Label label2;
        private Button CancelarBtn;
    }
}