namespace Clinica_Frba.Pedir_Turno
{
    partial class PedirTurno
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
            this.label1 = new System.Windows.Forms.Label();
            this.nroAfiliadoBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.profesionalBox = new System.Windows.Forms.TextBox();
            this.selectAfiliadoButton = new System.Windows.Forms.Button();
            this.selectProfesionalButton = new System.Windows.Forms.Button();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.grillaFechas = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaFechas)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(440, 511);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(310, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "EN CONSTRUCCION";
            // 
            // nroAfiliadoBox
            // 
            this.nroAfiliadoBox.Location = new System.Drawing.Point(98, 32);
            this.nroAfiliadoBox.Name = "nroAfiliadoBox";
            this.nroAfiliadoBox.ReadOnly = true;
            this.nroAfiliadoBox.Size = new System.Drawing.Size(100, 20);
            this.nroAfiliadoBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Afiliado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Profesional:";
            // 
            // profesionalBox
            // 
            this.profesionalBox.Location = new System.Drawing.Point(98, 66);
            this.profesionalBox.Name = "profesionalBox";
            this.profesionalBox.ReadOnly = true;
            this.profesionalBox.Size = new System.Drawing.Size(100, 20);
            this.profesionalBox.TabIndex = 14;
            // 
            // selectAfiliadoButton
            // 
            this.selectAfiliadoButton.Location = new System.Drawing.Point(239, 27);
            this.selectAfiliadoButton.Name = "selectAfiliadoButton";
            this.selectAfiliadoButton.Size = new System.Drawing.Size(131, 23);
            this.selectAfiliadoButton.TabIndex = 15;
            this.selectAfiliadoButton.Text = "Seleccionar Afiliado";
            this.selectAfiliadoButton.UseVisualStyleBackColor = true;
            this.selectAfiliadoButton.Click += new System.EventHandler(this.selectAfiliadoButton_Click);
            // 
            // selectProfesionalButton
            // 
            this.selectProfesionalButton.Location = new System.Drawing.Point(239, 61);
            this.selectProfesionalButton.Name = "selectProfesionalButton";
            this.selectProfesionalButton.Size = new System.Drawing.Size(131, 25);
            this.selectProfesionalButton.TabIndex = 16;
            this.selectProfesionalButton.Text = "Seleccionar profesional";
            this.selectProfesionalButton.UseVisualStyleBackColor = true;
            this.selectProfesionalButton.Click += new System.EventHandler(this.selectProfesionalButton_Click);
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(12, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(503, 39);
            this.errorBox.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectProfesionalButton);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.nroAfiliadoBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.selectAfiliadoButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.profesionalBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 108);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(408, 63);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 29;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // grillaFechas
            // 
            this.grillaFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaFechas.Location = new System.Drawing.Point(12, 197);
            this.grillaFechas.Name = "grillaFechas";
            this.grillaFechas.Size = new System.Drawing.Size(503, 296);
            this.grillaFechas.TabIndex = 30;
            this.grillaFechas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaFechas_CellContentClick);
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 546);
            this.Controls.Add(this.grillaFechas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.cancelButton);
            this.Name = "PedirTurno";
            this.Text = "Pedido de Turno";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaFechas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nroAfiliadoBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox profesionalBox;
        private System.Windows.Forms.Button selectAfiliadoButton;
        private System.Windows.Forms.Button selectProfesionalButton;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.DataGridView grillaFechas;
    }
}