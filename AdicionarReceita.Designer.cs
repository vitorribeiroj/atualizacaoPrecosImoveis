namespace ImoveisPrecoDesktopApp
{
    partial class AdicionarReceita
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
            cleanFieldsBtn = new Button();
            addReceitaBtn = new Button();
            label6 = new Label();
            dataRecebimentoPicker = new DateTimePicker();
            receitaTipoComboBox = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            descricaoInput = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)valorInput).BeginInit();
            SuspendLayout();
            // 
            // valorInput
            // 
            valorInput.DecimalPlaces = 2;
            valorInput.Location = new Point(21, 159);
            valorInput.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            valorInput.Name = "valorInput";
            valorInput.Size = new Size(140, 23);
            valorInput.TabIndex = 24;
            // 
            // cleanFieldsBtn
            // 
            cleanFieldsBtn.Location = new Point(177, 211);
            cleanFieldsBtn.Name = "cleanFieldsBtn";
            cleanFieldsBtn.Size = new Size(130, 50);
            cleanFieldsBtn.TabIndex = 23;
            cleanFieldsBtn.Text = "Limpar";
            cleanFieldsBtn.UseVisualStyleBackColor = true;
            // 
            // addReceitaBtn
            // 
            addReceitaBtn.Location = new Point(21, 211);
            addReceitaBtn.Name = "addReceitaBtn";
            addReceitaBtn.Size = new Size(130, 50);
            addReceitaBtn.TabIndex = 22;
            addReceitaBtn.Text = "Adicionar";
            addReceitaBtn.UseVisualStyleBackColor = true;
            addReceitaBtn.Click += addReceitaBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(194, 141);
            label6.Name = "label6";
            label6.Size = new Size(118, 15);
            label6.TabIndex = 21;
            label6.Text = "Data do recebimento";
            // 
            // dataRecebimentoPicker
            // 
            dataRecebimentoPicker.Format = DateTimePickerFormat.Custom;
            dataRecebimentoPicker.Location = new Point(194, 159);
            dataRecebimentoPicker.Name = "dataRecebimentoPicker";
            dataRecebimentoPicker.Size = new Size(112, 23);
            dataRecebimentoPicker.TabIndex = 20;
            // 
            // receitaTipoComboBox
            // 
            receitaTipoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            receitaTipoComboBox.FormattingEnabled = true;
            receitaTipoComboBox.Location = new Point(21, 101);
            receitaTipoComboBox.Name = "receitaTipoComboBox";
            receitaTipoComboBox.Size = new Size(286, 23);
            receitaTipoComboBox.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 141);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 18;
            label4.Text = "Valor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 83);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 17;
            label3.Text = "Classificação";
            // 
            // descricaoInput
            // 
            descricaoInput.Location = new Point(21, 41);
            descricaoInput.Name = "descricaoInput";
            descricaoInput.Size = new Size(286, 23);
            descricaoInput.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 23);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 15;
            label2.Text = "Descrição";
            // 
            // AdicionarReceita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 284);
            Controls.Add(valorInput);
            Controls.Add(cleanFieldsBtn);
            Controls.Add(addReceitaBtn);
            Controls.Add(label6);
            Controls.Add(dataRecebimentoPicker);
            Controls.Add(receitaTipoComboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(descricaoInput);
            Controls.Add(label2);
            Name = "AdicionarReceita";
            Text = "AdicionarReceita";
            ((System.ComponentModel.ISupportInitialize)valorInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown valorInput;
        private Button cleanFieldsBtn;
        private Button addReceitaBtn;
        private Label label6;
        private DateTimePicker dataRecebimentoPicker;
        private ComboBox receitaTipoComboBox;
        private Label label4;
        private Label label3;
        private TextBox descricaoInput;
        private Label label2;
    }
}