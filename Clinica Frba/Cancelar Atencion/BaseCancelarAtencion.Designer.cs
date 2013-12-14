namespace Clinica_Frba.Cancelar_Atencion
{
    partial class BaseCancelarAtencion
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
            this.volver = new System.Windows.Forms.Button();
            this.cancelarAtencion = new System.Windows.Forms.Button();
            this.grilla = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buscar = new System.Windows.Forms.Button();
            this.cancelarPeriodo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(429, 12);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(100, 23);
            this.volver.TabIndex = 3;
            this.volver.Text = "volver atras";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // cancelarAtencion
            // 
            this.cancelarAtencion.Location = new System.Drawing.Point(177, 12);
            this.cancelarAtencion.Name = "cancelarAtencion";
            this.cancelarAtencion.Size = new System.Drawing.Size(100, 23);
            this.cancelarAtencion.TabIndex = 2;
            this.cancelarAtencion.Text = "cancelar atencion";
            this.cancelarAtencion.UseVisualStyleBackColor = true;
            this.cancelarAtencion.Click += new System.EventHandler(this.cancelarAtencion_Click);
            // 
            // grilla
            // 
            this.grilla.AllowUserToAddRows = false;
            this.grilla.AllowUserToDeleteRows = false;
            this.grilla.AllowUserToResizeColumns = false;
            this.grilla.AllowUserToResizeRows = false;
            this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla.Location = new System.Drawing.Point(12, 92);
            this.grilla.Name = "grilla";
            this.grilla.ReadOnly = true;
            this.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grilla.Size = new System.Drawing.Size(581, 220);
            this.grilla.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buscar);
            this.groupBox2.Controls.Add(this.cancelarAtencion);
            this.groupBox2.Controls.Add(this.volver);
            this.groupBox2.Controls.Add(this.cancelarPeriodo);
            this.groupBox2.Location = new System.Drawing.Point(13, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 42);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(51, 12);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(100, 23);
            this.buscar.TabIndex = 10;
            this.buscar.Text = "buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // cancelarPeriodo
            // 
            this.cancelarPeriodo.Location = new System.Drawing.Point(303, 12);
            this.cancelarPeriodo.Name = "cancelarPeriodo";
            this.cancelarPeriodo.Size = new System.Drawing.Size(100, 23);
            this.cancelarPeriodo.TabIndex = 10;
            this.cancelarPeriodo.Text = "cancelar periodo";
            this.cancelarPeriodo.UseVisualStyleBackColor = true;
            this.cancelarPeriodo.Click += new System.EventHandler(this.cancelarPeriodo_Click);
            // 
            // BaseCancelarAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(605, 356);
            this.Controls.Add(this.grilla);
            this.Controls.Add(this.groupBox2);
            this.Name = "BaseCancelarAtencion";
            this.Text = "Cancelar Atención";
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Button volver;
        protected System.Windows.Forms.Button cancelarAtencion;
        protected System.Windows.Forms.DataGridView grilla;
        protected System.Windows.Forms.Button cancelarPeriodo;
        protected System.Windows.Forms.Button buscar;
    }
}