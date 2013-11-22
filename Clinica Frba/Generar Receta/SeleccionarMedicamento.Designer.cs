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
            this.grillaMedicamentos.Size = new System.Drawing.Size(516, 227);
            this.grillaMedicamentos.TabIndex = 14;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(453, 380);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorBox);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.descripcionBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nroMedicamentoBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 115);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Medicamento";
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(239, 27);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(263, 39);
            this.errorBox.TabIndex = 25;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(427, 78);
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
            this.descripcionBox.Name = "descripcionBox";
            this.descripcionBox.ReadOnly = true;
            this.descripcionBox.Size = new System.Drawing.Size(100, 20);
            this.descripcionBox.TabIndex = 26;
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
            this.nroMedicamentoBox.Name = "nroMedicamentoBox";
            this.nroMedicamentoBox.ReadOnly = true;
            this.nroMedicamentoBox.Size = new System.Drawing.Size(100, 20);
            this.nroMedicamentoBox.TabIndex = 22;
            // 
            // SeleccionarMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 412);
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
    }
}