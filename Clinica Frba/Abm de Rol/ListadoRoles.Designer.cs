namespace Clinica_Frba.Abm_de_Rol
{
    partial class ListadoRoles
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
            this.errorBox = new System.Windows.Forms.TextBox();
            this.grillaRoles = new System.Windows.Forms.DataGridView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRoles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorBox
            // 
            this.errorBox.ForeColor = System.Drawing.Color.Red;
            this.errorBox.Location = new System.Drawing.Point(15, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(436, 39);
            this.errorBox.TabIndex = 14;
            // 
            // grillaRoles
            // 
            this.grillaRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaRoles.Location = new System.Drawing.Point(15, 135);
            this.grillaRoles.Name = "grillaRoles";
            this.grillaRoles.RowTemplate.ReadOnly = true;
            this.grillaRoles.Size = new System.Drawing.Size(436, 235);
            this.grillaRoles.TabIndex = 12;
            this.grillaRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaRoles_CellContentClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(360, 376);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 25);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(89, 30);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(100, 20);
            this.nombreBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre Rol:";
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(325, 28);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 1;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(230, 28);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 0;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nombreBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 69);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            // 
            // ListadoRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 412);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grillaRoles);
            this.Name = "ListadoRoles";
            this.Text = "Listado Roles";
            ((System.ComponentModel.ISupportInitialize)(this.grillaRoles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.DataGridView grillaRoles;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}