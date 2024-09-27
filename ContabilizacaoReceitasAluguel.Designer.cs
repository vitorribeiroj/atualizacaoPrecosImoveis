namespace ImoveisPrecoDesktopApp
{
    partial class ContabilizacaoReceitasAluguel
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
            dataInicioInput = new DateTimePicker();
            dataFimInput = new DateTimePicker();
            dataInicio = new Label();
            label1 = new Label();
            correcaoInput = new NumericUpDown();
            label2 = new Label();
            contabilizarBtn = new Button();
            fecharBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)correcaoInput).BeginInit();
            SuspendLayout();
            // 
            // dataInicioInput
            // 
            dataInicioInput.Format = DateTimePickerFormat.Custom;
            dataInicioInput.Location = new Point(12, 35);
            dataInicioInput.Name = "dataInicioInput";
            dataInicioInput.Size = new Size(111, 23);
            dataInicioInput.TabIndex = 0;
            // 
            // dataFimInput
            // 
            dataFimInput.Format = DateTimePickerFormat.Custom;
            dataFimInput.Location = new Point(146, 35);
            dataFimInput.Name = "dataFimInput";
            dataFimInput.Size = new Size(111, 23);
            dataFimInput.TabIndex = 1;
            // 
            // dataInicio
            // 
            dataInicio.AutoSize = true;
            dataInicio.Location = new Point(12, 17);
            dataInicio.Name = "dataInicio";
            dataInicio.Size = new Size(82, 15);
            dataInicio.TabIndex = 2;
            dataInicio.Text = "Data de início:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 17);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "Data fim:";
            // 
            // correcaoInput
            // 
            correcaoInput.DecimalPlaces = 2;
            correcaoInput.Location = new Point(282, 35);
            correcaoInput.Name = "correcaoInput";
            correcaoInput.Size = new Size(111, 23);
            correcaoInput.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 17);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 5;
            label2.Text = "Correção anual:";
            // 
            // contabilizarBtn
            // 
            contabilizarBtn.Location = new Point(12, 78);
            contabilizarBtn.Name = "contabilizarBtn";
            contabilizarBtn.Size = new Size(111, 49);
            contabilizarBtn.TabIndex = 6;
            contabilizarBtn.Text = "CONTABILIZAR";
            contabilizarBtn.UseVisualStyleBackColor = true;
            contabilizarBtn.Click += contabilizarBtn_Click;
            // 
            // fecharBtn
            // 
            fecharBtn.Location = new Point(146, 78);
            fecharBtn.Name = "fecharBtn";
            fecharBtn.Size = new Size(111, 49);
            fecharBtn.TabIndex = 7;
            fecharBtn.Text = "FECHAR";
            fecharBtn.UseVisualStyleBackColor = true;
            fecharBtn.Click += fecharBtn_Click;
            // 
            // ContabilizacaoReceitasAluguel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 148);
            Controls.Add(fecharBtn);
            Controls.Add(contabilizarBtn);
            Controls.Add(label2);
            Controls.Add(correcaoInput);
            Controls.Add(label1);
            Controls.Add(dataInicio);
            Controls.Add(dataFimInput);
            Controls.Add(dataInicioInput);
            Name = "ContabilizacaoReceitasAluguel";
            Text = "ContabilizacaoReceitasAluguel";
            ((System.ComponentModel.ISupportInitialize)correcaoInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dataInicioInput;
        private DateTimePicker dataFimInput;
        private Label dataInicio;
        private Label label1;
        private NumericUpDown correcaoInput;
        private Label label2;
        private Button contabilizarBtn;
        private Button fecharBtn;
    }
}