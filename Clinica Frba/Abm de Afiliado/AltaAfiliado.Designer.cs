﻿namespace Clinica_Frba.Abm_de_Afiliado
{
    partial class AltaAfiliado
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.mail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelFamiliares = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelEstadoCivil = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.telefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nroDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tipoDoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.estadoCivil = new System.Windows.Forms.ComboBox();
            this.cantFamiliares = new System.Windows.Forms.TextBox();
            this.sexoButton1 = new System.Windows.Forms.RadioButton();
            this.sexoButton2 = new System.Windows.Forms.RadioButton();
            this.fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.planMedico = new System.Windows.Forms.ComboBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(506, 225);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 34);
            this.cancelButton.TabIndex = 135;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(393, 225);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(85, 34);
            this.aceptarButton.TabIndex = 134;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(390, 52);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(163, 20);
            this.mail.TabIndex = 125;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(348, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 124;
            this.label12.Text = "Sexo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(348, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 123;
            this.label11.Text = "Mail:";
            // 
            // labelFamiliares
            // 
            this.labelFamiliares.AutoSize = true;
            this.labelFamiliares.Location = new System.Drawing.Point(348, 147);
            this.labelFamiliares.Name = "labelFamiliares";
            this.labelFamiliares.Size = new System.Drawing.Size(152, 13);
            this.labelFamiliares.TabIndex = 122;
            this.labelFamiliares.Text = "Cantidad de familiares a cargo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(348, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 121;
            this.label9.Text = "Plan Medico:";
            // 
            // labelEstadoCivil
            // 
            this.labelEstadoCivil.AutoSize = true;
            this.labelEstadoCivil.Location = new System.Drawing.Point(348, 117);
            this.labelEstadoCivil.Name = "labelEstadoCivil";
            this.labelEstadoCivil.Size = new System.Drawing.Size(65, 13);
            this.labelEstadoCivil.TabIndex = 120;
            this.labelEstadoCivil.Text = "Estado Civil:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 116;
            this.label7.Text = "Fecha Nacimiento";
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(138, 166);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(100, 20);
            this.telefono.TabIndex = 115;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 114;
            this.label6.Text = "Telefono:";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(138, 139);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(100, 20);
            this.direccion.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 112;
            this.label5.Text = "Direccion:";
            // 
            // nroDoc
            // 
            this.nroDoc.Location = new System.Drawing.Point(138, 112);
            this.nroDoc.Name = "nroDoc";
            this.nroDoc.Size = new System.Drawing.Size(100, 20);
            this.nroDoc.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "Numero Documento:";
            // 
            // tipoDoc
            // 
            this.tipoDoc.FormattingEnabled = true;
            this.tipoDoc.Items.AddRange(new object[] {
            "DNI",
            "LE",
            "LC"});
            this.tipoDoc.Location = new System.Drawing.Point(138, 80);
            this.tipoDoc.Name = "tipoDoc";
            this.tipoDoc.Size = new System.Drawing.Size(100, 21);
            this.tipoDoc.TabIndex = 109;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Tipo Documento:";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(138, 52);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(100, 20);
            this.apellido.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Apellido:";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(138, 26);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(100, 20);
            this.nombre.TabIndex = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Nombre:";
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
            this.estadoCivil.Location = new System.Drawing.Point(432, 112);
            this.estadoCivil.Name = "estadoCivil";
            this.estadoCivil.Size = new System.Drawing.Size(121, 21);
            this.estadoCivil.TabIndex = 138;
            // 
            // cantFamiliares
            // 
            this.cantFamiliares.Location = new System.Drawing.Point(506, 144);
            this.cantFamiliares.Name = "cantFamiliares";
            this.cantFamiliares.Size = new System.Drawing.Size(47, 20);
            this.cantFamiliares.TabIndex = 140;
            // 
            // sexoButton1
            // 
            this.sexoButton1.AutoSize = true;
            this.sexoButton1.Location = new System.Drawing.Point(392, 82);
            this.sexoButton1.Name = "sexoButton1";
            this.sexoButton1.Size = new System.Drawing.Size(34, 17);
            this.sexoButton1.TabIndex = 141;
            this.sexoButton1.TabStop = true;
            this.sexoButton1.Text = "M";
            this.sexoButton1.UseVisualStyleBackColor = true;
            this.sexoButton1.CheckedChanged += new System.EventHandler(this.sexoButton1_CheckedChanged);
            // 
            // sexoButton2
            // 
            this.sexoButton2.AutoSize = true;
            this.sexoButton2.Location = new System.Drawing.Point(432, 82);
            this.sexoButton2.Name = "sexoButton2";
            this.sexoButton2.Size = new System.Drawing.Size(31, 17);
            this.sexoButton2.TabIndex = 142;
            this.sexoButton2.TabStop = true;
            this.sexoButton2.Text = "F";
            this.sexoButton2.UseVisualStyleBackColor = true;
            this.sexoButton2.CheckedChanged += new System.EventHandler(this.sexoButton1_CheckedChanged);
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Location = new System.Drawing.Point(138, 192);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.fechaNacimiento.TabIndex = 143;
            // 
            // planMedico
            // 
            this.planMedico.FormattingEnabled = true;
            this.planMedico.Items.AddRange(new object[] {
            "555555",
            "555556",
            "555557",
            "555558"});
            this.planMedico.Location = new System.Drawing.Point(432, 23);
            this.planMedico.Name = "planMedico";
            this.planMedico.Size = new System.Drawing.Size(121, 21);
            this.planMedico.TabIndex = 144;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(32, 225);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(85, 34);
            this.limpiarButton.TabIndex = 145;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // AltaAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 271);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.planMedico);
            this.Controls.Add(this.fechaNacimiento);
            this.Controls.Add(this.sexoButton2);
            this.Controls.Add(this.sexoButton1);
            this.Controls.Add(this.cantFamiliares);
            this.Controls.Add(this.estadoCivil);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelFamiliares);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelEstadoCivil);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.telefono);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.direccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nroDoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tipoDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.label1);
            this.Name = "AltaAfiliado";
            this.Text = "Alta Afiliado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelFamiliares;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelEstadoCivil;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nroDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tipoDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox estadoCivil;
        private System.Windows.Forms.TextBox cantFamiliares;
        private System.Windows.Forms.RadioButton sexoButton1;
        private System.Windows.Forms.RadioButton sexoButton2;
        private System.Windows.Forms.DateTimePicker fechaNacimiento;
        private System.Windows.Forms.ComboBox planMedico;
        private System.Windows.Forms.Button limpiarButton;
    }
}