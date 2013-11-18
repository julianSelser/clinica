namespace Clinica_Frba.Registro_de_LLegada
{
    partial class RegistroLlegada
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
            this.selectProfesionalButton = new System.Windows.Forms.Button();
            this.selectAfiliadoButton = new System.Windows.Forms.Button();
            this.profesionalBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nroAfiliadoBox = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.grillaTurnos = new System.Windows.Forms.DataGridView();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(538, 458);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 37);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectProfesionalButton
            // 
            this.selectProfesionalButton.Location = new System.Drawing.Point(191, 57);
            this.selectProfesionalButton.Name = "selectProfesionalButton";
            this.selectProfesionalButton.Size = new System.Drawing.Size(131, 23);
            this.selectProfesionalButton.TabIndex = 22;
            this.selectProfesionalButton.Text = "Seleccionar profesional";
            this.selectProfesionalButton.UseVisualStyleBackColor = true;
            this.selectProfesionalButton.Click += new System.EventHandler(this.selectProfesionalButton_Click);
            // 
            // selectAfiliadoButton
            // 
            this.selectAfiliadoButton.Location = new System.Drawing.Point(191, 21);
            this.selectAfiliadoButton.Name = "selectAfiliadoButton";
            this.selectAfiliadoButton.Size = new System.Drawing.Size(131, 23);
            this.selectAfiliadoButton.TabIndex = 21;
            this.selectAfiliadoButton.Text = "Seleccionar Afiliado";
            this.selectAfiliadoButton.UseVisualStyleBackColor = true;
            this.selectAfiliadoButton.Click += new System.EventHandler(this.selectAfiliadoButton_Click);
            // 
            // profesionalBox
            // 
            this.profesionalBox.Location = new System.Drawing.Point(74, 60);
            this.profesionalBox.Name = "profesionalBox";
            this.profesionalBox.ReadOnly = true;
            this.profesionalBox.Size = new System.Drawing.Size(100, 20);
            this.profesionalBox.TabIndex = 20;
            this.profesionalBox.TextChanged += new System.EventHandler(this.profesionalBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Profesional:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Afiliado:";
            // 
            // nroAfiliadoBox
            // 
            this.nroAfiliadoBox.Location = new System.Drawing.Point(74, 23);
            this.nroAfiliadoBox.Name = "nroAfiliadoBox";
            this.nroAfiliadoBox.ReadOnly = true;
            this.nroAfiliadoBox.Size = new System.Drawing.Size(100, 20);
            this.nroAfiliadoBox.TabIndex = 17;
            this.nroAfiliadoBox.TextChanged += new System.EventHandler(this.nroAfiliadoBox_TextChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.selectProfesionalButton);
            this.groupBox.Controls.Add(this.nroAfiliadoBox);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.profesionalBox);
            this.groupBox.Controls.Add(this.selectAfiliadoButton);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(337, 100);
            this.groupBox.TabIndex = 23;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Seleccione Afiliado y Médico";
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(355, 17);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(303, 39);
            this.errorBox.TabIndex = 24;
            // 
            // grillaTurnos
            // 
            this.grillaTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTurnos.Location = new System.Drawing.Point(12, 130);
            this.grillaTurnos.Name = "grillaTurnos";
            this.grillaTurnos.ReadOnly = true;
            this.grillaTurnos.Size = new System.Drawing.Size(646, 322);
            this.grillaTurnos.TabIndex = 25;
            this.grillaTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaTurnos_CellContentClick);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(583, 89);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 26;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 502);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.grillaTurnos);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.cancelButton);
            this.Name = "RegistroLlegada";
            this.Text = "Registro de Llegada";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button selectProfesionalButton;
        private System.Windows.Forms.Button selectAfiliadoButton;
        private System.Windows.Forms.TextBox profesionalBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nroAfiliadoBox;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.DataGridView grillaTurnos;
        private System.Windows.Forms.Button limpiarButton;
    }
}