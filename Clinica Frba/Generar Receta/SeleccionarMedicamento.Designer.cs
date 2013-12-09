namespace Clinica_Frba.Generar_Receta
{
    partial class SeleccionarMedicamento
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
            this.grillaMedicamentos = new System.Windows.Forms.DataGridView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buscarButton = new System.Windows.Forms.Button();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.descripcionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nroMedicamentoBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMedicamentos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaMedicamentos
            // 
            this.grillaMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaMedicamentos.Location = new System.Drawing.Point(12, 147);
            this.grillaMedicamentos.Name = "grillaMedicamentos";
            this.grillaMedicamentos.Size = new System.Drawing.Size(655, 227);
            this.grillaMedicamentos.TabIndex = 14;
            this.grillaMedicamentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaMedicamentos_CellContentClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(592, 380);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.errorBox);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.descripcionBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nroMedicamentoBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 115);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Medicamento";
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(552, 78);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 28;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(364, 24);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(263, 39);
            this.errorBox.TabIndex = 25;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(460, 78);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 27;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Descripcion contiene:";
            // 
            // descripcionBox
            // 
            this.descripcionBox.Location = new System.Drawing.Point(121, 62);
            this.descripcionBox.MaxLength = 254;
            this.descripcionBox.Name = "descripcionBox";
            this.descripcionBox.Size = new System.Drawing.Size(204, 20);
            this.descripcionBox.TabIndex = 26;
            this.descripcionBox.TextChanged += new System.EventHandler(this.descripcionBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Nro. Medicamento:";
            // 
            // nroMedicamentoBox
            // 
            this.nroMedicamentoBox.Location = new System.Drawing.Point(121, 27);
            this.nroMedicamentoBox.MaxLength = 9;
            this.nroMedicamentoBox.Name = "nroMedicamentoBox";
            this.nroMedicamentoBox.Size = new System.Drawing.Size(204, 20);
            this.nroMedicamentoBox.TabIndex = 22;
            this.nroMedicamentoBox.TextChanged += new System.EventHandler(this.nroMedicamentoBox_TextChanged);
            // 
            // SeleccionarMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.grillaMedicamentos);
            this.Name = "SeleccionarMedicamento";
            this.Text = "Seleccionar Medicamento";
            ((System.ComponentModel.ISupportInitialize)(this.grillaMedicamentos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaMedicamentos;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descripcionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nroMedicamentoBox;
        private System.Windows.Forms.Button buscarButton;
    }
}