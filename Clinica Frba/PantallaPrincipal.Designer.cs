namespace Clinica_Frba
{
    partial class PantallaPrincipal
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.deslogButton = new System.Windows.Forms.Button();
            this.usuarioLogueado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Red;
            this.lblTitulo.Location = new System.Drawing.Point(227, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(271, 46);
            this.lblTitulo.TabIndex = 14;
            this.lblTitulo.Text = "Clinica FRBA";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(525, 14);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(112, 32);
            this.loginButton.TabIndex = 15;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // deslogButton
            // 
            this.deslogButton.Location = new System.Drawing.Point(643, 14);
            this.deslogButton.Name = "deslogButton";
            this.deslogButton.Size = new System.Drawing.Size(112, 32);
            this.deslogButton.TabIndex = 17;
            this.deslogButton.Text = "Desloguear";
            this.deslogButton.UseVisualStyleBackColor = true;
            this.deslogButton.Click += new System.EventHandler(this.deslogButton_Click);
            // 
            // usuarioLogueado
            // 
            this.usuarioLogueado.AutoSize = true;
            this.usuarioLogueado.Location = new System.Drawing.Point(522, 49);
            this.usuarioLogueado.Name = "usuarioLogueado";
            this.usuarioLogueado.Size = new System.Drawing.Size(0, 13);
            this.usuarioLogueado.TabIndex = 18;
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 412);
            this.Controls.Add(this.usuarioLogueado);
            this.Controls.Add(this.deslogButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.lblTitulo);
            this.Name = "PantallaPrincipal";
            this.Text = "Pantalla Principal";
            this.Load += new System.EventHandler(this.PantallaPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button deslogButton;
        private System.Windows.Forms.Label usuarioLogueado;


    }
}

