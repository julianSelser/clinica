﻿namespace Clinica_Frba.Generar_Receta
{
    partial class GenerarReceta
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
            this.consultaBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bonoBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selecBonoButton = new System.Windows.Forms.Button();
            this.selectConsultaButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboCantidad1 = new System.Windows.Forms.ComboBox();
            this.comboCantidad5 = new System.Windows.Forms.ComboBox();
            this.comboCantidad4 = new System.Windows.Forms.ComboBox();
            this.comboCantidad3 = new System.Windows.Forms.ComboBox();
            this.comboCantidad2 = new System.Windows.Forms.ComboBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.medicamentoBox1 = new System.Windows.Forms.TextBox();
            this.medicamentoBox2 = new System.Windows.Forms.TextBox();
            this.medicamentoBox3 = new System.Windows.Forms.TextBox();
            this.medicamentoBox4 = new System.Windows.Forms.TextBox();
            this.medicamentoBox5 = new System.Windows.Forms.TextBox();
            this.selecMedicamento1 = new System.Windows.Forms.Button();
            this.selecMedicamento2 = new System.Windows.Forms.Button();
            this.selecMedicamento3 = new System.Windows.Forms.Button();
            this.selecMedicamento4 = new System.Windows.Forms.Button();
            this.selecMedicamento5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(416, 440);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(325, 440);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 6;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // consultaBox
            // 
            this.consultaBox.Location = new System.Drawing.Point(128, 35);
            this.consultaBox.Name = "consultaBox";
            this.consultaBox.ReadOnly = true;
            this.consultaBox.Size = new System.Drawing.Size(72, 20);
            this.consultaBox.TabIndex = 8;
            this.consultaBox.TextChanged += new System.EventHandler(this.consultaBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nro. de Consulta:";
            // 
            // bonoBox
            // 
            this.bonoBox.Location = new System.Drawing.Point(128, 71);
            this.bonoBox.Name = "bonoBox";
            this.bonoBox.ReadOnly = true;
            this.bonoBox.Size = new System.Drawing.Size(72, 20);
            this.bonoBox.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selecBonoButton);
            this.groupBox1.Controls.Add(this.selectConsultaButton);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bonoBox);
            this.groupBox1.Controls.Add(this.consultaBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 116);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione la consulta y el bono a utilizar";
            // 
            // selecBonoButton
            // 
            this.selecBonoButton.Location = new System.Drawing.Point(231, 69);
            this.selecBonoButton.Name = "selecBonoButton";
            this.selecBonoButton.Size = new System.Drawing.Size(118, 23);
            this.selecBonoButton.TabIndex = 29;
            this.selecBonoButton.Text = "Seleccionar Bono";
            this.selecBonoButton.UseVisualStyleBackColor = true;
            this.selecBonoButton.Click += new System.EventHandler(this.selecBonoButton_Click);
            // 
            // selectConsultaButton
            // 
            this.selectConsultaButton.Location = new System.Drawing.Point(231, 33);
            this.selectConsultaButton.Name = "selectConsultaButton";
            this.selectConsultaButton.Size = new System.Drawing.Size(118, 23);
            this.selectConsultaButton.TabIndex = 28;
            this.selectConsultaButton.Text = "Seleccionar Consulta";
            this.selectConsultaButton.UseVisualStyleBackColor = true;
            this.selectConsultaButton.Click += new System.EventHandler(this.selectConsultaButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(398, 71);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 27;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nro. de Bono Farmacia:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selecMedicamento5);
            this.groupBox2.Controls.Add(this.selecMedicamento4);
            this.groupBox2.Controls.Add(this.selecMedicamento3);
            this.groupBox2.Controls.Add(this.selecMedicamento2);
            this.groupBox2.Controls.Add(this.selecMedicamento1);
            this.groupBox2.Controls.Add(this.medicamentoBox5);
            this.groupBox2.Controls.Add(this.medicamentoBox4);
            this.groupBox2.Controls.Add(this.medicamentoBox3);
            this.groupBox2.Controls.Add(this.medicamentoBox2);
            this.groupBox2.Controls.Add(this.medicamentoBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboCantidad1);
            this.groupBox2.Controls.Add(this.comboCantidad5);
            this.groupBox2.Controls.Add(this.comboCantidad4);
            this.groupBox2.Controls.Add(this.comboCantidad3);
            this.groupBox2.Controls.Add(this.comboCantidad2);
            this.groupBox2.Location = new System.Drawing.Point(12, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 207);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Receta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(418, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Medicamento";
            // 
            // comboCantidad1
            // 
            this.comboCantidad1.FormattingEnabled = true;
            this.comboCantidad1.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboCantidad1.Location = new System.Drawing.Point(421, 61);
            this.comboCantidad1.Name = "comboCantidad1";
            this.comboCantidad1.Size = new System.Drawing.Size(37, 21);
            this.comboCantidad1.TabIndex = 15;
            // 
            // comboCantidad5
            // 
            this.comboCantidad5.FormattingEnabled = true;
            this.comboCantidad5.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboCantidad5.Location = new System.Drawing.Point(421, 169);
            this.comboCantidad5.Name = "comboCantidad5";
            this.comboCantidad5.Size = new System.Drawing.Size(37, 21);
            this.comboCantidad5.TabIndex = 30;
            // 
            // comboCantidad4
            // 
            this.comboCantidad4.FormattingEnabled = true;
            this.comboCantidad4.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboCantidad4.Location = new System.Drawing.Point(421, 142);
            this.comboCantidad4.Name = "comboCantidad4";
            this.comboCantidad4.Size = new System.Drawing.Size(37, 21);
            this.comboCantidad4.TabIndex = 29;
            // 
            // comboCantidad3
            // 
            this.comboCantidad3.FormattingEnabled = true;
            this.comboCantidad3.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboCantidad3.Location = new System.Drawing.Point(421, 115);
            this.comboCantidad3.Name = "comboCantidad3";
            this.comboCantidad3.Size = new System.Drawing.Size(37, 21);
            this.comboCantidad3.TabIndex = 28;
            // 
            // comboCantidad2
            // 
            this.comboCantidad2.FormattingEnabled = true;
            this.comboCantidad2.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboCantidad2.Location = new System.Drawing.Point(421, 88);
            this.comboCantidad2.Name = "comboCantidad2";
            this.comboCantidad2.Size = new System.Drawing.Size(37, 21);
            this.comboCantidad2.TabIndex = 27;
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(12, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(479, 39);
            this.errorBox.TabIndex = 26;
            // 
            // medicamentoBox1
            // 
            this.medicamentoBox1.Location = new System.Drawing.Point(16, 62);
            this.medicamentoBox1.Name = "medicamentoBox1";
            this.medicamentoBox1.ReadOnly = true;
            this.medicamentoBox1.Size = new System.Drawing.Size(239, 20);
            this.medicamentoBox1.TabIndex = 32;
            // 
            // medicamentoBox2
            // 
            this.medicamentoBox2.Location = new System.Drawing.Point(16, 89);
            this.medicamentoBox2.Name = "medicamentoBox2";
            this.medicamentoBox2.ReadOnly = true;
            this.medicamentoBox2.Size = new System.Drawing.Size(239, 20);
            this.medicamentoBox2.TabIndex = 33;
            // 
            // medicamentoBox3
            // 
            this.medicamentoBox3.Location = new System.Drawing.Point(16, 116);
            this.medicamentoBox3.Name = "medicamentoBox3";
            this.medicamentoBox3.ReadOnly = true;
            this.medicamentoBox3.Size = new System.Drawing.Size(239, 20);
            this.medicamentoBox3.TabIndex = 34;
            // 
            // medicamentoBox4
            // 
            this.medicamentoBox4.Location = new System.Drawing.Point(16, 142);
            this.medicamentoBox4.Name = "medicamentoBox4";
            this.medicamentoBox4.ReadOnly = true;
            this.medicamentoBox4.Size = new System.Drawing.Size(239, 20);
            this.medicamentoBox4.TabIndex = 35;
            // 
            // medicamentoBox5
            // 
            this.medicamentoBox5.Location = new System.Drawing.Point(16, 168);
            this.medicamentoBox5.Name = "medicamentoBox5";
            this.medicamentoBox5.ReadOnly = true;
            this.medicamentoBox5.Size = new System.Drawing.Size(239, 20);
            this.medicamentoBox5.TabIndex = 36;
            // 
            // selecMedicamento1
            // 
            this.selecMedicamento1.Location = new System.Drawing.Point(261, 61);
            this.selecMedicamento1.Name = "selecMedicamento1";
            this.selecMedicamento1.Size = new System.Drawing.Size(142, 23);
            this.selecMedicamento1.TabIndex = 37;
            this.selecMedicamento1.Text = "Seleccionar Medicamento";
            this.selecMedicamento1.UseVisualStyleBackColor = true;
            // 
            // selecMedicamento2
            // 
            this.selecMedicamento2.Location = new System.Drawing.Point(261, 90);
            this.selecMedicamento2.Name = "selecMedicamento2";
            this.selecMedicamento2.Size = new System.Drawing.Size(142, 23);
            this.selecMedicamento2.TabIndex = 38;
            this.selecMedicamento2.Text = "Seleccionar Medicamento";
            this.selecMedicamento2.UseVisualStyleBackColor = true;
            // 
            // selecMedicamento3
            // 
            this.selecMedicamento3.Location = new System.Drawing.Point(261, 115);
            this.selecMedicamento3.Name = "selecMedicamento3";
            this.selecMedicamento3.Size = new System.Drawing.Size(142, 23);
            this.selecMedicamento3.TabIndex = 39;
            this.selecMedicamento3.Text = "Seleccionar Medicamento";
            this.selecMedicamento3.UseVisualStyleBackColor = true;
            // 
            // selecMedicamento4
            // 
            this.selecMedicamento4.Location = new System.Drawing.Point(261, 139);
            this.selecMedicamento4.Name = "selecMedicamento4";
            this.selecMedicamento4.Size = new System.Drawing.Size(142, 23);
            this.selecMedicamento4.TabIndex = 40;
            this.selecMedicamento4.Text = "Seleccionar Medicamento";
            this.selecMedicamento4.UseVisualStyleBackColor = true;
            // 
            // selecMedicamento5
            // 
            this.selecMedicamento5.Location = new System.Drawing.Point(261, 166);
            this.selecMedicamento5.Name = "selecMedicamento5";
            this.selecMedicamento5.Size = new System.Drawing.Size(142, 23);
            this.selecMedicamento5.TabIndex = 41;
            this.selecMedicamento5.Text = "Seleccionar Medicamento";
            this.selecMedicamento5.UseVisualStyleBackColor = true;
            // 
            // GenerarReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 485);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.aceptarButton);
            this.Name = "GenerarReceta";
            this.Text = "Generar Receta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.TextBox consultaBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bonoBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboCantidad5;
        private System.Windows.Forms.ComboBox comboCantidad4;
        private System.Windows.Forms.ComboBox comboCantidad3;
        private System.Windows.Forms.ComboBox comboCantidad2;
        private System.Windows.Forms.ComboBox comboCantidad1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button selecBonoButton;
        private System.Windows.Forms.Button selectConsultaButton;
        private System.Windows.Forms.Button selecMedicamento5;
        private System.Windows.Forms.Button selecMedicamento4;
        private System.Windows.Forms.Button selecMedicamento3;
        private System.Windows.Forms.Button selecMedicamento2;
        private System.Windows.Forms.Button selecMedicamento1;
        private System.Windows.Forms.TextBox medicamentoBox5;
        private System.Windows.Forms.TextBox medicamentoBox4;
        private System.Windows.Forms.TextBox medicamentoBox3;
        private System.Windows.Forms.TextBox medicamentoBox2;
        private System.Windows.Forms.TextBox medicamentoBox1;
    }
}