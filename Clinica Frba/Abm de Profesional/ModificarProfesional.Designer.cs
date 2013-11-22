namespace Clinica_Frba.Abm_de_Profesional
{
    partial class ModificarProfesional
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
            this.label5 = new System.Windows.Forms.Label();
            this.direcBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.telBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.especialidadesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.idBox = new System.Windows.Forms.TextBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion:";
            // 
            // direcBox
            // 
            this.direcBox.Location = new System.Drawing.Point(99, 129);
            this.direcBox.MaxLength = 255;
            this.direcBox.Name = "direcBox";
            this.direcBox.Size = new System.Drawing.Size(174, 20);
            this.direcBox.TabIndex = 9;
            this.direcBox.TextChanged += new System.EventHandler(this.direcBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telefono:";
            // 
            // telBox
            // 
            this.telBox.Location = new System.Drawing.Point(99, 170);
            this.telBox.MaxLength = 10;
            this.telBox.Name = "telBox";
            this.telBox.Size = new System.Drawing.Size(174, 20);
            this.telBox.TabIndex = 11;
            this.telBox.TextChanged += new System.EventHandler(this.telBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Mail:";
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(99, 209);
            this.mailBox.MaxLength = 255;
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(174, 20);
            this.mailBox.TabIndex = 21;
            this.mailBox.TextChanged += new System.EventHandler(this.mailBox_TextChanged);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(448, 226);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(85, 34);
            this.acceptButton.TabIndex = 30;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(567, 226);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 34);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(335, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Especialidades:";
            // 
            // especialidadesCheckedListBox
            // 
            this.especialidadesCheckedListBox.FormattingEnabled = true;
            this.especialidadesCheckedListBox.Location = new System.Drawing.Point(338, 96);
            this.especialidadesCheckedListBox.Name = "especialidadesCheckedListBox";
            this.especialidadesCheckedListBox.Size = new System.Drawing.Size(314, 79);
            this.especialidadesCheckedListBox.TabIndex = 33;
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(99, 89);
            this.idBox.Name = "idBox";
            this.idBox.ReadOnly = true;
            this.idBox.Size = new System.Drawing.Size(67, 20);
            this.idBox.TabIndex = 34;
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(41, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(611, 40);
            this.errorBox.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "ID Médico:";
            // 
            // ModificarProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 286);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.especialidadesCheckedListBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.telBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.direcBox);
            this.Controls.Add(this.label5);
            this.Name = "ModificarProfesional";
            this.Text = "Modificar Profesional";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox direcBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox telBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckedListBox especialidadesCheckedListBox;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Label label1;
    }
}