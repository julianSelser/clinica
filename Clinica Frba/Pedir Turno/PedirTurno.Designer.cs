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
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nroAfiliadoBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.profesionalBox = new System.Windows.Forms.TextBox();
            this.selectAfiliadoButton = new System.Windows.Forms.Button();
            this.selectProfesionalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(290, 218);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 8;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(385, 218);
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
            this.label1.Location = new System.Drawing.Point(134, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "EN CONSTRUCCION";
            // 
            // nroAfiliadoBox
            // 
            this.nroAfiliadoBox.Location = new System.Drawing.Point(129, 25);
            this.nroAfiliadoBox.Name = "nroAfiliadoBox";
            this.nroAfiliadoBox.ReadOnly = true;
            this.nroAfiliadoBox.Size = new System.Drawing.Size(100, 20);
            this.nroAfiliadoBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Afiliado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Profesional:";
            // 
            // profesionalBox
            // 
            this.profesionalBox.Location = new System.Drawing.Point(129, 59);
            this.profesionalBox.Name = "profesionalBox";
            this.profesionalBox.ReadOnly = true;
            this.profesionalBox.Size = new System.Drawing.Size(100, 20);
            this.profesionalBox.TabIndex = 14;
            // 
            // selectAfiliadoButton
            // 
            this.selectAfiliadoButton.Location = new System.Drawing.Point(270, 20);
            this.selectAfiliadoButton.Name = "selectAfiliadoButton";
            this.selectAfiliadoButton.Size = new System.Drawing.Size(131, 23);
            this.selectAfiliadoButton.TabIndex = 15;
            this.selectAfiliadoButton.Text = "Seleccionar Afiliado";
            this.selectAfiliadoButton.UseVisualStyleBackColor = true;
            this.selectAfiliadoButton.Click += new System.EventHandler(this.selectAfiliadoButton_Click);
            // 
            // selectProfesionalButton
            // 
            this.selectProfesionalButton.Location = new System.Drawing.Point(270, 54);
            this.selectProfesionalButton.Name = "selectProfesionalButton";
            this.selectProfesionalButton.Size = new System.Drawing.Size(131, 25);
            this.selectProfesionalButton.TabIndex = 16;
            this.selectProfesionalButton.Text = "Seleccionar profesional";
            this.selectProfesionalButton.UseVisualStyleBackColor = true;
            this.selectProfesionalButton.Click += new System.EventHandler(this.selectProfesionalButton_Click);
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 253);
            this.Controls.Add(this.selectProfesionalButton);
            this.Controls.Add(this.selectAfiliadoButton);
            this.Controls.Add(this.profesionalBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nroAfiliadoBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Name = "PedirTurno";
            this.Text = "Pedido de Turno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nroAfiliadoBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox profesionalBox;
        private System.Windows.Forms.Button selectAfiliadoButton;
        private System.Windows.Forms.Button selectProfesionalButton;
    }
}