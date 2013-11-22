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
            this.planMedicoBox = new System.Windows.Forms.ComboBox();
            this.cantFamiliaresBox = new System.Windows.Forms.TextBox();
            this.estadoCivilBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelFamiliares = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelEstadoCivil = new System.Windows.Forms.Label();
            this.telBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.direcBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nroAfiliadoBox = new System.Windows.Forms.TextBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // planMedicoBox
            // 
            this.planMedicoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.planMedicoBox.FormattingEnabled = true;
            this.planMedicoBox.Location = new System.Drawing.Point(518, 73);
            this.planMedicoBox.Name = "planMedicoBox";
            this.planMedicoBox.Size = new System.Drawing.Size(178, 21);
            this.planMedicoBox.TabIndex = 173;
            this.planMedicoBox.SelectedIndexChanged += new System.EventHandler(this.planMedicoBox_SelectedIndexChanged);
            // 
            // cantFamiliaresBox
            // 
            this.cantFamiliaresBox.Location = new System.Drawing.Point(548, 131);
            this.cantFamiliaresBox.MaxLength = 2;
            this.cantFamiliaresBox.Name = "cantFamiliaresBox";
            this.cantFamiliaresBox.Size = new System.Drawing.Size(47, 20);
            this.cantFamiliaresBox.TabIndex = 169;
            this.cantFamiliaresBox.TextChanged += new System.EventHandler(this.cantFamiliaresBox_TextChanged);
            // 
            // estadoCivilBox
            // 
            this.estadoCivilBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estadoCivilBox.FormattingEnabled = true;
            this.estadoCivilBox.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Viudo/a",
            "Concubinato",
            "Divorciado/a"});
            this.estadoCivilBox.Location = new System.Drawing.Point(518, 103);
            this.estadoCivilBox.Name = "estadoCivilBox";
            this.estadoCivilBox.Size = new System.Drawing.Size(178, 21);
            this.estadoCivilBox.TabIndex = 168;
            this.estadoCivilBox.SelectedIndexChanged += new System.EventHandler(this.estadoCivilBox_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(585, 177);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 34);
            this.cancelButton.TabIndex = 167;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(478, 177);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(85, 34);
            this.acceptButton.TabIndex = 166;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(99, 165);
            this.mailBox.MaxLength = 255;
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(229, 20);
            this.mailBox.TabIndex = 165;
            this.mailBox.TextChanged += new System.EventHandler(this.mailBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 163;
            this.label11.Text = "Mail:";
            // 
            // labelFamiliares
            // 
            this.labelFamiliares.AutoSize = true;
            this.labelFamiliares.Location = new System.Drawing.Point(390, 134);
            this.labelFamiliares.Name = "labelFamiliares";
            this.labelFamiliares.Size = new System.Drawing.Size(152, 13);
            this.labelFamiliares.TabIndex = 162;
            this.labelFamiliares.Text = "Cantidad de familiares a cargo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(390, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 161;
            this.label9.Text = "Plan Medico:";
            // 
            // labelEstadoCivil
            // 
            this.labelEstadoCivil.AutoSize = true;
            this.labelEstadoCivil.Location = new System.Drawing.Point(390, 104);
            this.labelEstadoCivil.Name = "labelEstadoCivil";
            this.labelEstadoCivil.Size = new System.Drawing.Size(65, 13);
            this.labelEstadoCivil.TabIndex = 160;
            this.labelEstadoCivil.Text = "Estado Civil:";
            // 
            // telBox
            // 
            this.telBox.Location = new System.Drawing.Point(99, 134);
            this.telBox.MaxLength = 10;
            this.telBox.Name = "telBox";
            this.telBox.Size = new System.Drawing.Size(229, 20);
            this.telBox.TabIndex = 158;
            this.telBox.TextChanged += new System.EventHandler(this.telBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 157;
            this.label6.Text = "Telefono:";
            // 
            // direcBox
            // 
            this.direcBox.Location = new System.Drawing.Point(99, 104);
            this.direcBox.MaxLength = 255;
            this.direcBox.Name = "direcBox";
            this.direcBox.Size = new System.Drawing.Size(229, 20);
            this.direcBox.TabIndex = 156;
            this.direcBox.TextChanged += new System.EventHandler(this.direcBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 155;
            this.label5.Text = "Direccion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "Nro Afiliado:";
            // 
            // nroAfiliadoBox
            // 
            this.nroAfiliadoBox.Location = new System.Drawing.Point(99, 71);
            this.nroAfiliadoBox.Name = "nroAfiliadoBox";
            this.nroAfiliadoBox.ReadOnly = true;
            this.nroAfiliadoBox.Size = new System.Drawing.Size(229, 20);
            this.nroAfiliadoBox.TabIndex = 175;
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(37, 13);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(659, 41);
            this.errorBox.TabIndex = 176;
            // 
            // ModificarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 228);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.nroAfiliadoBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.planMedicoBox);
            this.Controls.Add(this.cantFamiliaresBox);
            this.Controls.Add(this.estadoCivilBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelFamiliares);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelEstadoCivil);
            this.Controls.Add(this.telBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.direcBox);
            this.Controls.Add(this.label5);
            this.Name = "ModificarAfiliado";
            this.Text = "Modificar Afiliado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox planMedicoBox;
        private System.Windows.Forms.TextBox cantFamiliaresBox;
        private System.Windows.Forms.ComboBox estadoCivilBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelFamiliares;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelEstadoCivil;
        private System.Windows.Forms.TextBox telBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox direcBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nroAfiliadoBox;
        private System.Windows.Forms.TextBox errorBox;

    }
}