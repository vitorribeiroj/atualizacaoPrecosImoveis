namespace ImoveisPrecoDesktopApp
{
    partial class PaginaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LogoBox = new PictureBox();
            ConsultarImovelBtn = new Button();
            CadastrarImovelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // LogoBox
            // 
            LogoBox.BackgroundImage = Properties.Resources.logo;
            LogoBox.Image = Properties.Resources.logo;
            LogoBox.Location = new Point(0, 0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new Size(266, 202);
            LogoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoBox.TabIndex = 0;
            LogoBox.TabStop = false;
            // 
            // ConsultarImovelBtn
            // 
            ConsultarImovelBtn.BackColor = SystemColors.WindowFrame;
            ConsultarImovelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ConsultarImovelBtn.ForeColor = SystemColors.ControlLightLight;
            ConsultarImovelBtn.Location = new Point(272, 12);
            ConsultarImovelBtn.Name = "ConsultarImovelBtn";
            ConsultarImovelBtn.Size = new Size(200, 50);
            ConsultarImovelBtn.TabIndex = 1;
            ConsultarImovelBtn.Text = "CONSULTAR IMÓVEL";
            ConsultarImovelBtn.UseVisualStyleBackColor = false;
            ConsultarImovelBtn.Click += ConsultarImovelBtn_Click;
            // 
            // CadastrarImovelBtn
            // 
            CadastrarImovelBtn.BackColor = SystemColors.WindowFrame;
            CadastrarImovelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            CadastrarImovelBtn.ForeColor = SystemColors.ControlLightLight;
            CadastrarImovelBtn.Location = new Point(272, 68);
            CadastrarImovelBtn.Name = "CadastrarImovelBtn";
            CadastrarImovelBtn.Size = new Size(200, 50);
            CadastrarImovelBtn.TabIndex = 2;
            CadastrarImovelBtn.Text = "CADASTRAR IMÓVEL";
            CadastrarImovelBtn.UseVisualStyleBackColor = false;
            CadastrarImovelBtn.Click += CadastrarImovelBtn_Click;
            // 
            // PaginaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 201);
            Controls.Add(CadastrarImovelBtn);
            Controls.Add(ConsultarImovelBtn);
            Controls.Add(LogoBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "PaginaPrincipal";
            Text = "$ISTEMA IMÓVEI$ - Consulta e Determinação de Preços";
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ResumeLayout(false);
        }



        #endregion

        private PictureBox LogoBox;
        private Button ConsultarImovelBtn;
        private Button CadastrarImovelBtn;

    }
}