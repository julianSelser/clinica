namespace Clinica_Frba.Login
{
    partial class ElegirRol
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
            this.rolComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(50, 50);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 6;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // rolComboBox
            // 
            this.rolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rolComboBox.FormattingEnabled = true;
            this.rolComboBox.Location = new System.Drawing.Point(12, 12);
            this.rolComboBox.Name = "rolComboBox";
            this.rolComboBox.Size = new System.Drawing.Size(150, 21);
            this.rolComboBox.TabIndex = 8;
            // 
            // ElegirRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 85);
            this.Controls.Add(this.rolComboBox);
            this.Controls.Add(this.acceptButton);
            this.Name = "ElegirRol";
            this.Text = "Elegir rol";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElegirRol_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.ComboBox rolComboBox;
    }
}