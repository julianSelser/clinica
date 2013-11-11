namespace Clinica_Frba.Abm_de_Afiliado
{
    partial class PeticionAccion
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
            this.altaConyuge = new System.Windows.Forms.Button();
            this.altaFamiliar = new System.Windows.Forms.Button();
            this.finalizar = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // altaConyuge
            // 
            this.altaConyuge.Location = new System.Drawing.Point(83, 48);
            this.altaConyuge.Name = "altaConyuge";
            this.altaConyuge.Size = new System.Drawing.Size(125, 23);
            this.altaConyuge.TabIndex = 1;
            this.altaConyuge.Text = "Dar alta conyuge";
            this.altaConyuge.UseVisualStyleBackColor = true;
            this.altaConyuge.Click += new System.EventHandler(this.altaConyuge_Click);
            // 
            // altaFamiliar
            // 
            this.altaFamiliar.Location = new System.Drawing.Point(83, 77);
            this.altaFamiliar.Name = "altaFamiliar";
            this.altaFamiliar.Size = new System.Drawing.Size(125, 23);
            this.altaFamiliar.TabIndex = 2;
            this.altaFamiliar.Text = "Dar alta familiar";
            this.altaFamiliar.UseVisualStyleBackColor = true;
            this.altaFamiliar.Click += new System.EventHandler(this.altaFamiliar_Click);
            // 
            // finalizar
            // 
            this.finalizar.Location = new System.Drawing.Point(83, 123);
            this.finalizar.Name = "finalizar";
            this.finalizar.Size = new System.Drawing.Size(125, 23);
            this.finalizar.TabIndex = 3;
            this.finalizar.Text = "Finalizar";
            this.finalizar.UseVisualStyleBackColor = true;
            this.finalizar.Click += new System.EventHandler(this.finalizar_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(83, 19);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(125, 23);
            this.modificarButton.TabIndex = 4;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // PeticionAccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 168);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.finalizar);
            this.Controls.Add(this.altaFamiliar);
            this.Controls.Add(this.altaConyuge);
            this.Name = "PeticionAccion";
            this.Text = "Peticion Acción";
            this.Activated += new System.EventHandler(this.PeticionAccion_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button altaConyuge;
        private System.Windows.Forms.Button altaFamiliar;
        private System.Windows.Forms.Button finalizar;
        private System.Windows.Forms.Button modificarButton;
    }
}