namespace Clinica_Frba.Generar_Receta
{
    partial class ElegirBonoFarmacia
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
            this.afiliadoBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grillaBonosFarmacia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBonosFarmacia)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(358, 268);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // afiliadoBox
            // 
            this.afiliadoBox.Location = new System.Drawing.Point(92, 29);
            this.afiliadoBox.Name = "afiliadoBox";
            this.afiliadoBox.ReadOnly = true;
            this.afiliadoBox.Size = new System.Drawing.Size(72, 20);
            this.afiliadoBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nro. Afiliado:";
            // 
            // grillaBonosFarmacia
            // 
            this.grillaBonosFarmacia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaBonosFarmacia.Location = new System.Drawing.Point(19, 62);
            this.grillaBonosFarmacia.Name = "grillaBonosFarmacia";
            this.grillaBonosFarmacia.Size = new System.Drawing.Size(414, 197);
            this.grillaBonosFarmacia.TabIndex = 13;
            this.grillaBonosFarmacia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaBonosFarmacia_CellContentClick);
            // 
            // ElegirBonoFarmacia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 300);
            this.Controls.Add(this.grillaBonosFarmacia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.afiliadoBox);
            this.Controls.Add(this.cancelButton);
            this.Name = "ElegirBonoFarmacia";
            this.Text = "Elegir Bono Farmacia";
            ((System.ComponentModel.ISupportInitialize)(this.grillaBonosFarmacia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox afiliadoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grillaBonosFarmacia;

    }
}