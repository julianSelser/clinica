namespace Clinica_Frba.Abm_de_Afiliado
{
    partial class ModificarAfiliado
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
            this.button1 = new System.Windows.Forms.Button();
            this.nroAfiliado = new System.Windows.Forms.TextBox();
            this.labelAfiliado = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nroAfiliado
            // 
            this.nroAfiliado.Location = new System.Drawing.Point(142, 48);
            this.nroAfiliado.Name = "nroAfiliado";
            this.nroAfiliado.Size = new System.Drawing.Size(100, 20);
            this.nroAfiliado.TabIndex = 11;
            // 
            // labelAfiliado
            // 
            this.labelAfiliado.AutoSize = true;
            this.labelAfiliado.Location = new System.Drawing.Point(47, 51);
            this.labelAfiliado.Name = "labelAfiliado";
            this.labelAfiliado.Size = new System.Drawing.Size(84, 13);
            this.labelAfiliado.TabIndex = 10;
            this.labelAfiliado.Text = "Número Afiliado:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ModificarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 141);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nroAfiliado);
            this.Controls.Add(this.labelAfiliado);
            this.Controls.Add(this.button2);
            this.Name = "ModificarAfiliado";
            this.Text = "Modificar Afiliado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nroAfiliado;
        private System.Windows.Forms.Label labelAfiliado;
        private System.Windows.Forms.Button button2;
    }
}