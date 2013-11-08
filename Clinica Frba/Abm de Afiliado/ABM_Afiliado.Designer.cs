namespace Clinica_Frba.Abm_de_Afiliado
{
    partial class ABM_Afiliado
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
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.altaButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.bajaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "ABM Afiliado";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(63, 218);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(157, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // altaButton
            // 
            this.altaButton.Location = new System.Drawing.Point(63, 77);
            this.altaButton.Name = "altaButton";
            this.altaButton.Size = new System.Drawing.Size(157, 23);
            this.altaButton.TabIndex = 5;
            this.altaButton.Text = "Dar de alta";
            this.altaButton.UseVisualStyleBackColor = true;
            this.altaButton.Click += new System.EventHandler(this.altaButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(63, 106);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(157, 23);
            this.modificarButton.TabIndex = 6;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // bajaButton
            // 
            this.bajaButton.Location = new System.Drawing.Point(63, 135);
            this.bajaButton.Name = "bajaButton";
            this.bajaButton.Size = new System.Drawing.Size(157, 23);
            this.bajaButton.TabIndex = 7;
            this.bajaButton.Text = "Dar de baja";
            this.bajaButton.UseVisualStyleBackColor = true;
            this.bajaButton.Click += new System.EventHandler(this.bajaButton_Click);
            // 
            // ABM_Afiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.bajaButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.altaButton);
            this.Name = "ABM_Afiliado";
            this.Text = "Afiliado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button altaButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button bajaButton;
    }
}