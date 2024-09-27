namespace ImoveisPrecoDesktopApp
{
    partial class ProgressForm
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
            progressBarConsulta = new ProgressBar();
            label1 = new Label();
            SuspendLayout();
            // 
            // progressBarConsulta
            // 
            progressBarConsulta.Location = new Point(12, 37);
            progressBarConsulta.Name = "progressBarConsulta";
            progressBarConsulta.Size = new Size(226, 29);
            progressBarConsulta.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(187, 15);
            label1.TabIndex = 1;
            label1.Text = "Carregando dados para consulta...";
            // 
            // ProgressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 80);
            Controls.Add(label1);
            Controls.Add(progressBarConsulta);
            MaximizeBox = false;
            Name = "ProgressForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBarConsulta;
        private Label label1;
    }
}