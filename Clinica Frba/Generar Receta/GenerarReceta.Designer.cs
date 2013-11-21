namespace Clinica_Frba.Generar_Receta
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
            this.comboMedicamento1 = new System.Windows.Forms.ComboBox();
            this.comboMedicamento2 = new System.Windows.Forms.ComboBox();
            this.comboMedicamento3 = new System.Windows.Forms.ComboBox();
            this.comboMedicamento4 = new System.Windows.Forms.ComboBox();
            this.comboMedicamento5 = new System.Windows.Forms.ComboBox();
            this.bonoBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.limpiarButton = new System.Windows.Forms.Button();
            this.selectConsultaButton = new System.Windows.Forms.Button();
            this.selecBonoButton = new System.Windows.Forms.Button();
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
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(325, 440);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 6;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            // 
            // consultaBox
            // 
            this.consultaBox.Location = new System.Drawing.Point(128, 35);
            this.consultaBox.Name = "consultaBox";
            this.consultaBox.ReadOnly = true;
            this.consultaBox.Size = new System.Drawing.Size(72, 20);
            this.consultaBox.TabIndex = 8;
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
            // comboMedicamento1
            // 
            this.comboMedicamento1.FormattingEnabled = true;
            this.comboMedicamento1.Location = new System.Drawing.Point(16, 61);
            this.comboMedicamento1.Name = "comboMedicamento1";
            this.comboMedicamento1.Size = new System.Drawing.Size(372, 21);
            this.comboMedicamento1.TabIndex = 10;
            // 
            // comboMedicamento2
            // 
            this.comboMedicamento2.FormattingEnabled = true;
            this.comboMedicamento2.Location = new System.Drawing.Point(16, 88);
            this.comboMedicamento2.Name = "comboMedicamento2";
            this.comboMedicamento2.Size = new System.Drawing.Size(372, 21);
            this.comboMedicamento2.TabIndex = 11;
            // 
            // comboMedicamento3
            // 
            this.comboMedicamento3.FormattingEnabled = true;
            this.comboMedicamento3.Location = new System.Drawing.Point(16, 115);
            this.comboMedicamento3.Name = "comboMedicamento3";
            this.comboMedicamento3.Size = new System.Drawing.Size(372, 21);
            this.comboMedicamento3.TabIndex = 12;
            // 
            // comboMedicamento4
            // 
            this.comboMedicamento4.FormattingEnabled = true;
            this.comboMedicamento4.Location = new System.Drawing.Point(16, 142);
            this.comboMedicamento4.Name = "comboMedicamento4";
            this.comboMedicamento4.Size = new System.Drawing.Size(372, 21);
            this.comboMedicamento4.TabIndex = 13;
            // 
            // comboMedicamento5
            // 
            this.comboMedicamento5.FormattingEnabled = true;
            this.comboMedicamento5.Location = new System.Drawing.Point(16, 169);
            this.comboMedicamento5.Name = "comboMedicamento5";
            this.comboMedicamento5.Size = new System.Drawing.Size(372, 21);
            this.comboMedicamento5.TabIndex = 14;
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
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboCantidad1);
            this.groupBox2.Controls.Add(this.comboCantidad5);
            this.groupBox2.Controls.Add(this.comboCantidad4);
            this.groupBox2.Controls.Add(this.comboCantidad3);
            this.groupBox2.Controls.Add(this.comboCantidad2);
            this.groupBox2.Controls.Add(this.comboMedicamento1);
            this.groupBox2.Controls.Add(this.comboMedicamento2);
            this.groupBox2.Controls.Add(this.comboMedicamento3);
            this.groupBox2.Controls.Add(this.comboMedicamento4);
            this.groupBox2.Controls.Add(this.comboMedicamento5);
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
            this.label3.Location = new System.Drawing.Point(18, 34);
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
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(398, 71);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 27;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // selectConsultaButton
            // 
            this.selectConsultaButton.Location = new System.Drawing.Point(231, 33);
            this.selectConsultaButton.Name = "selectConsultaButton";
            this.selectConsultaButton.Size = new System.Drawing.Size(118, 23);
            this.selectConsultaButton.TabIndex = 28;
            this.selectConsultaButton.Text = "Seleccionar Consulta";
            this.selectConsultaButton.UseVisualStyleBackColor = true;
            // 
            // selecBonoButton
            // 
            this.selecBonoButton.Location = new System.Drawing.Point(231, 69);
            this.selecBonoButton.Name = "selecBonoButton";
            this.selecBonoButton.Size = new System.Drawing.Size(118, 23);
            this.selecBonoButton.TabIndex = 29;
            this.selecBonoButton.Text = "Seleccionar Bono";
            this.selecBonoButton.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.ComboBox comboMedicamento1;
        private System.Windows.Forms.ComboBox comboMedicamento2;
        private System.Windows.Forms.ComboBox comboMedicamento3;
        private System.Windows.Forms.ComboBox comboMedicamento4;
        private System.Windows.Forms.ComboBox comboMedicamento5;
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
    }
}