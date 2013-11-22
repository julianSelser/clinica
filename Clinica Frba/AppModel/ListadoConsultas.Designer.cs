namespace Clinica_Frba.AppModel
{
    partial class ListadoConsultas
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
            this.grillaTurnos = new System.Windows.Forms.DataGridView();
            this.fechaAtencionPicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.checkConsultaSinResultado = new System.Windows.Forms.CheckBox();
            this.selectProfesionalButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.profesionalBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nroAfiliadoBox = new System.Windows.Forms.TextBox();
            this.selectAfiliadoButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTurnos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(653, 421);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // grillaTurnos
            // 
            this.grillaTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTurnos.Location = new System.Drawing.Point(25, 188);
            this.grillaTurnos.Name = "grillaTurnos";
            this.grillaTurnos.Size = new System.Drawing.Size(702, 227);
            this.grillaTurnos.TabIndex = 13;
            this.grillaTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaTurnos_CellContentClick);
            // 
            // fechaAtencionPicker
            // 
            this.fechaAtencionPicker.Location = new System.Drawing.Point(121, 122);
            this.fechaAtencionPicker.Name = "fechaAtencionPicker";
            this.fechaAtencionPicker.Size = new System.Drawing.Size(200, 20);
            this.fechaAtencionPicker.TabIndex = 14;
            this.fechaAtencionPicker.ValueChanged += new System.EventHandler(this.fechaAtencionPicker_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorBox);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.checkConsultaSinResultado);
            this.groupBox1.Controls.Add(this.selectProfesionalButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.profesionalBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nroAfiliadoBox);
            this.groupBox1.Controls.Add(this.selectAfiliadoButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fechaAtencionPicker);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 159);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Consulta";
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(353, 32);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(334, 39);
            this.errorBox.TabIndex = 25;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(612, 119);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 27;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // checkConsultaSinResultado
            // 
            this.checkConsultaSinResultado.AutoSize = true;
            this.checkConsultaSinResultado.Location = new System.Drawing.Point(353, 81);
            this.checkConsultaSinResultado.Name = "checkConsultaSinResultado";
            this.checkConsultaSinResultado.Size = new System.Drawing.Size(134, 17);
            this.checkConsultaSinResultado.TabIndex = 29;
            this.checkConsultaSinResultado.Text = "Consultas sin resultado";
            this.checkConsultaSinResultado.UseVisualStyleBackColor = true;
            this.checkConsultaSinResultado.CheckedChanged += new System.EventHandler(this.checkConsultaSinResultado_CheckedChanged);
            // 
            // selectProfesionalButton
            // 
            this.selectProfesionalButton.Location = new System.Drawing.Point(190, 75);
            this.selectProfesionalButton.Name = "selectProfesionalButton";
            this.selectProfesionalButton.Size = new System.Drawing.Size(131, 23);
            this.selectProfesionalButton.TabIndex = 27;
            this.selectProfesionalButton.Text = "Seleccionar profesional";
            this.selectProfesionalButton.UseVisualStyleBackColor = true;
            this.selectProfesionalButton.Click += new System.EventHandler(this.selectProfesionalButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Profesional:";
            // 
            // profesionalBox
            // 
            this.profesionalBox.Location = new System.Drawing.Point(73, 78);
            this.profesionalBox.Name = "profesionalBox";
            this.profesionalBox.ReadOnly = true;
            this.profesionalBox.Size = new System.Drawing.Size(100, 20);
            this.profesionalBox.TabIndex = 26;
            this.profesionalBox.TextChanged += new System.EventHandler(this.profesionalBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Afiliado:";
            // 
            // nroAfiliadoBox
            // 
            this.nroAfiliadoBox.Location = new System.Drawing.Point(73, 34);
            this.nroAfiliadoBox.Name = "nroAfiliadoBox";
            this.nroAfiliadoBox.ReadOnly = true;
            this.nroAfiliadoBox.Size = new System.Drawing.Size(100, 20);
            this.nroAfiliadoBox.TabIndex = 22;
            this.nroAfiliadoBox.TextChanged += new System.EventHandler(this.nroAfiliadoBox_TextChanged);
            // 
            // selectAfiliadoButton
            // 
            this.selectAfiliadoButton.Location = new System.Drawing.Point(190, 32);
            this.selectAfiliadoButton.Name = "selectAfiliadoButton";
            this.selectAfiliadoButton.Size = new System.Drawing.Size(131, 23);
            this.selectAfiliadoButton.TabIndex = 24;
            this.selectAfiliadoButton.Text = "Seleccionar Afiliado";
            this.selectAfiliadoButton.UseVisualStyleBackColor = true;
            this.selectAfiliadoButton.Click += new System.EventHandler(this.selectAfiliadoButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Fecha de Atención:";
            // 
            // ListadoConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 453);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grillaTurnos);
            this.Controls.Add(this.cancelButton);
            this.Name = "ListadoConsultas";
            this.Text = "Registro Resultado de Atención";
            ((System.ComponentModel.ISupportInitialize)(this.grillaTurnos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView grillaTurnos;
        private System.Windows.Forms.DateTimePicker fechaAtencionPicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nroAfiliadoBox;
        private System.Windows.Forms.Button selectAfiliadoButton;
        private System.Windows.Forms.Button selectProfesionalButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox profesionalBox;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.CheckBox checkConsultaSinResultado;
    }
}