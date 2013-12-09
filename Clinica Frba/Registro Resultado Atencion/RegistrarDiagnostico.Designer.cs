namespace Clinica_Frba.Registro_Resultado_Atencion
{
    partial class RegistrarDiagnostico
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
            this.nroTurnoBox = new System.Windows.Forms.TextBox();
            this.enfermedadesBox = new System.Windows.Forms.TextBox();
            this.sintomasBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nroTurnoBox
            // 
            this.nroTurnoBox.Location = new System.Drawing.Point(168, 25);
            this.nroTurnoBox.Name = "nroTurnoBox";
            this.nroTurnoBox.ReadOnly = true;
            this.nroTurnoBox.Size = new System.Drawing.Size(56, 20);
            this.nroTurnoBox.TabIndex = 0;
            // 
            // enfermedadesBox
            // 
            this.enfermedadesBox.Location = new System.Drawing.Point(22, 124);
            this.enfermedadesBox.MaxLength = 254;
            this.enfermedadesBox.Multiline = true;
            this.enfermedadesBox.Name = "enfermedadesBox";
            this.enfermedadesBox.Size = new System.Drawing.Size(432, 55);
            this.enfermedadesBox.TabIndex = 1;
            this.enfermedadesBox.TextChanged += new System.EventHandler(this.enfermedadesBox_TextChanged);
            // 
            // sintomasBox
            // 
            this.sintomasBox.Location = new System.Drawing.Point(22, 42);
            this.sintomasBox.MaxLength = 254;
            this.sintomasBox.Multiline = true;
            this.sintomasBox.Name = "sintomasBox";
            this.sintomasBox.Size = new System.Drawing.Size(432, 56);
            this.sintomasBox.TabIndex = 2;
            this.sintomasBox.TextChanged += new System.EventHandler(this.sintomasBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nro de turno de la consulta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Síntomas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enfermedades";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.enfermedadesBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sintomasBox);
            this.groupBox1.Location = new System.Drawing.Point(24, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 196);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese síntomas y enfermedades";
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(244, 25);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(255, 39);
            this.errorBox.TabIndex = 26;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(424, 284);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 27;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(24, 284);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 28;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(328, 284);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 29;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // RegistrarDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 319);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nroTurnoBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrarDiagnostico";
            this.Text = "Registrar Diagnostico";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nroTurnoBox;
        private System.Windows.Forms.TextBox enfermedadesBox;
        private System.Windows.Forms.TextBox sintomasBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button aceptarButton;
    }
}