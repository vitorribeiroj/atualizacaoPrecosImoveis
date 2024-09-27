namespace ImoveisPrecoDesktopApp
{
    partial class JanelaAmortizacaoFinanciamento
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
            valorAmortizacaoInput = new TextBox();
            meioAmortizacaoComboBox = new ComboBox();
            addBtn = new Button();
            fecharBtn = new Button();
            label2 = new Label();
            dataAmortizacaoInput = new DateTimePicker();
            label3 = new Label();
            amortizacoesGridView = new DataGridView();
            label4 = new Label();
            excluirBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)amortizacoesGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "Valor:";
            // 
            // valorAmortizacaoInput
            // 
            valorAmortizacaoInput.Location = new Point(12, 34);
            valorAmortizacaoInput.Name = "valorAmortizacaoInput";
            valorAmortizacaoInput.Size = new Size(152, 23);
            valorAmortizacaoInput.TabIndex = 1;
            // 
            // meioAmortizacaoComboBox
            // 
            meioAmortizacaoComboBox.FormattingEnabled = true;
            meioAmortizacaoComboBox.Location = new Point(183, 34);
            meioAmortizacaoComboBox.Name = "meioAmortizacaoComboBox";
            meioAmortizacaoComboBox.Size = new Size(151, 23);
            meioAmortizacaoComboBox.TabIndex = 2;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(12, 212);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(100, 37);
            addBtn.TabIndex = 3;
            addBtn.Text = "ADICIONAR";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += saveBtn_Click;
            // 
            // fecharBtn
            // 
            fecharBtn.Location = new Point(246, 212);
            fecharBtn.Name = "fecharBtn";
            fecharBtn.Size = new Size(100, 37);
            fecharBtn.TabIndex = 4;
            fecharBtn.Text = "FECHAR";
            fecharBtn.UseVisualStyleBackColor = true;
            fecharBtn.Click += cancelBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(183, 16);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 5;
            label2.Text = "Meio:";
            // 
            // dataAmortizacaoInput
            // 
            dataAmortizacaoInput.Format = DateTimePickerFormat.Custom;
            dataAmortizacaoInput.Location = new Point(351, 34);
            dataAmortizacaoInput.Name = "dataAmortizacaoInput";
            dataAmortizacaoInput.Size = new Size(151, 23);
            dataAmortizacaoInput.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(351, 16);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 7;
            label3.Text = "Data:";
            // 
            // amortizacoesGridView
            // 
            amortizacoesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            amortizacoesGridView.Location = new Point(12, 94);
            amortizacoesGridView.Name = "amortizacoesGridView";
            amortizacoesGridView.RowTemplate.Height = 25;
            amortizacoesGridView.Size = new Size(490, 99);
            amortizacoesGridView.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 76);
            label4.Name = "label4";
            label4.Size = new Size(176, 15);
            label4.TabIndex = 9;
            label4.Text = "Detalhamento das amortizações";
            // 
            // excluirBtn
            // 
            excluirBtn.Location = new Point(128, 212);
            excluirBtn.Name = "excluirBtn";
            excluirBtn.Size = new Size(100, 37);
            excluirBtn.TabIndex = 10;
            excluirBtn.Text = "EXCLUIR";
            excluirBtn.UseVisualStyleBackColor = true;
            excluirBtn.Click += excluirBtn_Click;
            // 
            // JanelaAmortizacaoFinanciamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 272);
            Controls.Add(excluirBtn);
            Controls.Add(label4);
            Controls.Add(amortizacoesGridView);
            Controls.Add(label3);
            Controls.Add(dataAmortizacaoInput);
            Controls.Add(label2);
            Controls.Add(fecharBtn);
            Controls.Add(addBtn);
            Controls.Add(meioAmortizacaoComboBox);
            Controls.Add(valorAmortizacaoInput);
            Controls.Add(label1);
            Name = "JanelaAmortizacaoFinanciamento";
            Text = "Amortização";
            ((System.ComponentModel.ISupportInitialize)amortizacoesGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox valorAmortizacaoInput;
        private ComboBox meioAmortizacaoComboBox;
        private Button addBtn;
        private Button fecharBtn;
        private Label label2;
        private DateTimePicker dataAmortizacaoInput;
        private Label label3;
        private DataGridView amortizacoesGridView;
        private Label label4;
        private Button excluirBtn;
    }
}