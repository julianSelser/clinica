namespace Clinica_Frba.Abm_de_Afiliado
{
    partial class ModificarAfiliado2
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
            this.planMedico = new System.Windows.Forms.ComboBox();
            this.cantFamiliares = new System.Windows.Forms.TextBox();
            this.estadoCivil = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelFamiliares = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelEstadoCivil = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // planMedico
            // 
            this.planMedico.FormattingEnabled = true;
            this.planMedico.Location = new System.Drawing.Point(403, 22);
            this.planMedico.Name = "planMedico";
            this.planMedico.Size = new System.Drawing.Size(121, 21);
            this.planMedico.TabIndex = 173;
            // 
            // cantFamiliares
            // 
            this.cantFamiliares.Location = new System.Drawing.Point(451, 80);
            this.cantFamiliares.Name = "cantFamiliares";
            this.cantFamiliares.Size = new System.Drawing.Size(73, 20);
            this.cantFamiliares.TabIndex = 169;
            // 
            // estadoCivil
            // 
            this.estadoCivil.FormattingEnabled = true;
            this.estadoCivil.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Viudo/a",
            "Concubinato",
            "Divorciado/a"});
            this.estadoCivil.Location = new System.Drawing.Point(403, 52);
            this.estadoCivil.Name = "estadoCivil";
            this.estadoCivil.Size = new System.Drawing.Size(121, 21);
            this.estadoCivil.TabIndex = 168;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(451, 121);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 34);
            this.cancelButton.TabIndex = 167;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(344, 121);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(85, 34);
            this.acceptButton.TabIndex = 166;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(99, 83);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(127, 20);
            this.textBox6.TabIndex = 165;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 163;
            this.label11.Text = "Mail:";
            // 
            // labelFamiliares
            // 
            this.labelFamiliares.AutoSize = true;
            this.labelFamiliares.Location = new System.Drawing.Point(263, 83);
            this.labelFamiliares.Name = "labelFamiliares";
            this.labelFamiliares.Size = new System.Drawing.Size(152, 13);
            this.labelFamiliares.TabIndex = 162;
            this.labelFamiliares.Text = "Cantidad de familiares a cargo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 161;
            this.label9.Text = "Plan Medico:";
            // 
            // labelEstadoCivil
            // 
            this.labelEstadoCivil.AutoSize = true;
            this.labelEstadoCivil.Location = new System.Drawing.Point(263, 53);
            this.labelEstadoCivil.Name = "labelEstadoCivil";
            this.labelEstadoCivil.Size = new System.Drawing.Size(65, 13);
            this.labelEstadoCivil.TabIndex = 160;
            this.labelEstadoCivil.Text = "Estado Civil:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(99, 52);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(127, 20);
            this.textBox5.TabIndex = 158;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 157;
            this.label6.Text = "Telefono:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(99, 22);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(127, 20);
            this.textBox4.TabIndex = 156;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 155;
            this.label5.Text = "Direccion:";
            // 
            // ModificarAfiliado2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 171);
            this.Controls.Add(this.planMedico);
            this.Controls.Add(this.cantFamiliares);
            this.Controls.Add(this.estadoCivil);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelFamiliares);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelEstadoCivil);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Name = "ModificarAfiliado2";
            this.Text = "Modificar Afiliado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox planMedico;
        private System.Windows.Forms.TextBox cantFamiliares;
        private System.Windows.Forms.ComboBox estadoCivil;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelFamiliares;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelEstadoCivil;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;

    }
}