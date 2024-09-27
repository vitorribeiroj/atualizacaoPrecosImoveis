namespace ImoveisPrecoDesktopApp
{
    partial class AdicionarDespesaWindow
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
            tituloLabel = new Label();
            label2 = new Label();
            descricaoInput = new TextBox();
            label3 = new Label();
            label4 = new Label();
            despesaTipoComboBox = new ComboBox();
            dataPagamentoPicker = new DateTimePicker();
            IR_dedutivel_SIM_btn = new RadioButton();
            IR_dedutivel_NAO_btn = new RadioButton();
            label5 = new Label();
            label6 = new Label();
            addDespesaBtn = new Button();
            cleanFieldsBtn = new Button();
            valorInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)valorInput).BeginInit();
            SuspendLayout();
            // 
            // tituloLabel
            // 
            tituloLabel.AutoSize = true;
            tituloLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tituloLabel.Location = new Point(14, 23);
            tituloLabel.Name = "tituloLabel";
            tituloLabel.Size = new Size(292, 20);
            tituloLabel.TabIndex = 0;
            tituloLabel.Text = "Despesa relativa ao imóvel #ID - Apelido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 69);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Descrição";
            // 
            // descricaoInput
            // 
            descricaoInput.Location = new Point(19, 87);
            descricaoInput.Name = "descricaoInput";
            descricaoInput.Size = new Size(286, 23);
            descricaoInput.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 129);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 3;
            label3.Text = "Classificação";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 187);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 5;
            label4.Text = "Valor";
            // 
            // despesaTipoComboBox
            // 
            despesaTipoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            despesaTipoComboBox.FormattingEnabled = true;
            despesaTipoComboBox.Location = new Point(19, 147);
            despesaTipoComboBox.Name = "despesaTipoComboBox";
            despesaTipoComboBox.Size = new Size(286, 23);
            despesaTipoComboBox.TabIndex = 6;
            // 
            // dataPagamentoPicker
            // 
            dataPagamentoPicker.Format = DateTimePickerFormat.Custom;
            dataPagamentoPicker.Location = new Point(192, 205);
            dataPagamentoPicker.Name = "dataPagamentoPicker";
            dataPagamentoPicker.Size = new Size(112, 23);
            dataPagamentoPicker.TabIndex = 7;
            // 
            // IR_dedutivel_SIM_btn
            // 
            IR_dedutivel_SIM_btn.AutoSize = true;
            IR_dedutivel_SIM_btn.Location = new Point(19, 273);
            IR_dedutivel_SIM_btn.Name = "IR_dedutivel_SIM_btn";
            IR_dedutivel_SIM_btn.Size = new Size(45, 19);
            IR_dedutivel_SIM_btn.TabIndex = 8;
            IR_dedutivel_SIM_btn.Text = "SIM";
            IR_dedutivel_SIM_btn.UseVisualStyleBackColor = true;
            // 
            // IR_dedutivel_NAO_btn
            // 
            IR_dedutivel_NAO_btn.AutoSize = true;
            IR_dedutivel_NAO_btn.Location = new Point(70, 273);
            IR_dedutivel_NAO_btn.Name = "IR_dedutivel_NAO_btn";
            IR_dedutivel_NAO_btn.Size = new Size(51, 19);
            IR_dedutivel_NAO_btn.TabIndex = 9;
            IR_dedutivel_NAO_btn.Text = "NÃO";
            IR_dedutivel_NAO_btn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 246);
            label5.Name = "label5";
            label5.Size = new Size(173, 15);
            label5.TabIndex = 10;
            label5.Text = "Dedutível do Imposto de Renda";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(192, 187);
            label6.Name = "label6";
            label6.Size = new Size(112, 15);
            label6.TabIndex = 11;
            label6.Text = "Data do pagamento";
            // 
            // addDespesaBtn
            // 
            addDespesaBtn.Location = new Point(348, 77);
            addDespesaBtn.Name = "addDespesaBtn";
            addDespesaBtn.Size = new Size(130, 50);
            addDespesaBtn.TabIndex = 12;
            addDespesaBtn.Text = "Adicionar";
            addDespesaBtn.UseVisualStyleBackColor = true;
            addDespesaBtn.Click += addDespesaBtn_Click;
            // 
            // cleanFieldsBtn
            // 
            cleanFieldsBtn.Location = new Point(348, 152);
            cleanFieldsBtn.Name = "cleanFieldsBtn";
            cleanFieldsBtn.Size = new Size(130, 50);
            cleanFieldsBtn.TabIndex = 13;
            cleanFieldsBtn.Text = "Limpar";
            cleanFieldsBtn.UseVisualStyleBackColor = true;
            cleanFieldsBtn.Click += cleanFieldsBtn_Click;
            // 
            // valorInput
            // 
            valorInput.DecimalPlaces = 2;
            valorInput.Location = new Point(19, 205);
            valorInput.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            valorInput.Name = "valorInput";
            valorInput.Size = new Size(140, 23);
            valorInput.TabIndex = 14;
            // 
            // AdicionarDespesaWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 312);
            Controls.Add(valorInput);
            Controls.Add(cleanFieldsBtn);
            Controls.Add(addDespesaBtn);
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
            Controls.Add(tituloLabel);
            MaximizeBox = false;
            Name = "AdicionarDespesaWindow";
            Text = "AdicionarDespesa";
            Load += AdicionarDespesa_Load;
            ((System.ComponentModel.ISupportInitialize)valorInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tituloLabel;
        private Label label2;
        private TextBox descricaoInput;
        private Label label3;

        private Label label4;
        private ComboBox despesaTipoComboBox;
        private DateTimePicker dataPagamentoPicker;
        private RadioButton IR_dedutivel_SIM_btn;
        private RadioButton IR_dedutivel_NAO_btn;
        private Label label5;
        private Label label6;
        private Button addDespesaBtn;
        private Button cleanFieldsBtn;
        private NumericUpDown valorInput;
    }
}