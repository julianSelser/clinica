namespace Clinica_Frba.Pedir_Turno
{
    partial class SeleccionarTimeslot
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
            this.grillaTimeslots = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTimeslots)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(215, 302);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // grillaTimeslots
            // 
            this.grillaTimeslots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTimeslots.Location = new System.Drawing.Point(25, 45);
            this.grillaTimeslots.Name = "grillaTimeslots";
            this.grillaTimeslots.Size = new System.Drawing.Size(265, 238);
            this.grillaTimeslots.TabIndex = 11;
            // 
            // SeleccionarTimeslot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 336);
            this.Controls.Add(this.grillaTimeslots);
            this.Controls.Add(this.cancelButton);
            this.Name = "SeleccionarTimeslot";
            this.Text = "Seleccionar Horario";
            ((System.ComponentModel.ISupportInitialize)(this.grillaTimeslots)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView grillaTimeslots;
    }
}