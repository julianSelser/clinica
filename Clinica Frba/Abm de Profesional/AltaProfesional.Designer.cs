namespace Clinica_Frba.Abm_de_Profesional
{
    partial class AltaProfesional
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
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.apellidoBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tipoDocBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nroDocBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.direcBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.telBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.matriculaBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.especialidadesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.fechaNacBox = new System.Windows.Forms.DateTimePicker();
            this.masculinoRadioButton = new System.Windows.Forms.RadioButton();
            this.femeninoRadioButton = new System.Windows.Forms.RadioButton();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(136, 68);
            this.nombreBox.MaxLength = 255;
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(203, 20);
            this.nombreBox.TabIndex = 1;
            this.nombreBox.TextChanged += new System.EventHandler(this.nombreBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido:";
            // 
            // apellidoBox
            // 
            this.apellidoBox.Location = new System.Drawing.Point(136, 94);
            this.apellidoBox.MaxLength = 255;
            this.apellidoBox.Name = "apellidoBox";
            this.apellidoBox.Size = new System.Drawing.Size(203, 20);
            this.apellidoBox.TabIndex = 3;
            this.apellidoBox.TextChanged += new System.EventHandler(this.apellidoBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo Doc:";
            // 
            // tipoDocBox
            // 
            this.tipoDocBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoDocBox.FormattingEnabled = true;
            this.tipoDocBox.Items.AddRange(new object[] {
            "DNI",
            "LE",
            "LC"});
            this.tipoDocBox.Location = new System.Drawing.Point(136, 122);
            this.tipoDocBox.Name = "tipoDocBox";
            this.tipoDocBox.Size = new System.Drawing.Size(55, 21);
            this.tipoDocBox.TabIndex = 5;
            this.tipoDocBox.SelectedIndexChanged += new System.EventHandler(this.tipoDocBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Numero Doc:";
            // 
            // nroDocBox
            // 
            this.nroDocBox.Location = new System.Drawing.Point(136, 154);
            this.nroDocBox.MaxLength = 9;
            this.nroDocBox.Name = "nroDocBox";
            this.nroDocBox.Size = new System.Drawing.Size(203, 20);
            this.nroDocBox.TabIndex = 7;
            this.nroDocBox.TextChanged += new System.EventHandler(this.nroDocBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion:";
            // 
            // direcBox
            // 
            this.direcBox.Location = new System.Drawing.Point(136, 181);
            this.direcBox.MaxLength = 255;
            this.direcBox.Name = "direcBox";
            this.direcBox.Size = new System.Drawing.Size(203, 20);
            this.direcBox.TabIndex = 9;
            this.direcBox.TextChanged += new System.EventHandler(this.direcBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telefono:";
            // 
            // telBox
            // 
            this.telBox.Location = new System.Drawing.Point(136, 208);
            this.telBox.MaxLength = 10;
            this.telBox.Name = "telBox";
            this.telBox.Size = new System.Drawing.Size(203, 20);
            this.telBox.TabIndex = 11;
            this.telBox.TextChanged += new System.EventHandler(this.telBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fecha Nacimiento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Numero Matricula:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Mail:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 258);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Sexo:";
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(136, 232);
            this.mailBox.MaxLength = 255;
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(203, 20);
            this.mailBox.TabIndex = 21;
            this.mailBox.TextChanged += new System.EventHandler(this.mailBox_TextChanged);
            // 
            // matriculaBox
            // 
            this.matriculaBox.Location = new System.Drawing.Point(139, 313);
            this.matriculaBox.MaxLength = 9;
            this.matriculaBox.Name = "matriculaBox";
            this.matriculaBox.Size = new System.Drawing.Size(200, 20);
            this.matriculaBox.TabIndex = 23;
            this.matriculaBox.TextChanged += new System.EventHandler(this.matriculaBox_TextChanged);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(529, 368);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(85, 34);
            this.acceptButton.TabIndex = 30;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(637, 368);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 34);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // especialidadesCheckedListBox
            // 
            this.especialidadesCheckedListBox.FormattingEnabled = true;
            this.especialidadesCheckedListBox.Location = new System.Drawing.Point(6, 23);
            this.especialidadesCheckedListBox.Name = "especialidadesCheckedListBox";
            this.especialidadesCheckedListBox.Size = new System.Drawing.Size(319, 244);
            this.especialidadesCheckedListBox.TabIndex = 35;
            // 
            // fechaNacBox
            // 
            this.fechaNacBox.Location = new System.Drawing.Point(139, 281);
            this.fechaNacBox.Name = "fechaNacBox";
            this.fechaNacBox.Size = new System.Drawing.Size(200, 20);
            this.fechaNacBox.TabIndex = 38;
            // 
            // masculinoRadioButton
            // 
            this.masculinoRadioButton.AutoSize = true;
            this.masculinoRadioButton.Location = new System.Drawing.Point(136, 258);
            this.masculinoRadioButton.Name = "masculinoRadioButton";
            this.masculinoRadioButton.Size = new System.Drawing.Size(34, 17);
            this.masculinoRadioButton.TabIndex = 39;
            this.masculinoRadioButton.TabStop = true;
            this.masculinoRadioButton.Text = "M";
            this.masculinoRadioButton.UseVisualStyleBackColor = true;
            this.masculinoRadioButton.CheckedChanged += new System.EventHandler(this.masculinoRadioButton_CheckedChanged);
            // 
            // femeninoRadioButton
            // 
            this.femeninoRadioButton.AutoSize = true;
            this.femeninoRadioButton.Location = new System.Drawing.Point(176, 258);
            this.femeninoRadioButton.Name = "femeninoRadioButton";
            this.femeninoRadioButton.Size = new System.Drawing.Size(31, 17);
            this.femeninoRadioButton.TabIndex = 40;
            this.femeninoRadioButton.TabStop = true;
            this.femeninoRadioButton.Text = "F";
            this.femeninoRadioButton.UseVisualStyleBackColor = true;
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(27, 13);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(701, 38);
            this.errorBox.TabIndex = 41;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.especialidadesCheckedListBox);
            this.groupBox1.Location = new System.Drawing.Point(397, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 277);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Especialidades Médicas";
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(27, 359);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(85, 34);
            this.limpiarButton.TabIndex = 43;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // AltaProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 423);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.femeninoRadioButton);
            this.Controls.Add(this.masculinoRadioButton);
            this.Controls.Add(this.fechaNacBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.matriculaBox);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.telBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.direcBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nroDocBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tipoDocBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apellidoBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreBox);
            this.Controls.Add(this.label1);
            this.Name = "AltaProfesional";
            this.Text = "Alta Profesional";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apellidoBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tipoDocBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nroDocBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox direcBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox telBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.TextBox matriculaBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckedListBox especialidadesCheckedListBox;
        private System.Windows.Forms.DateTimePicker fechaNacBox;
        private System.Windows.Forms.RadioButton masculinoRadioButton;
        private System.Windows.Forms.RadioButton femeninoRadioButton;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button limpiarButton;
    }
}