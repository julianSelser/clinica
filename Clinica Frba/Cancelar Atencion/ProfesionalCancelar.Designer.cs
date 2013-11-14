namespace Clinica_Frba.Cancelar_Atencion
{
    partial class ProfesionalCancelar
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
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.desdeTextBox = new System.Windows.Forms.TextBox();
            this.hastaTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(243, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "cancelar periodo";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "desde";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "hasta";
            // 
            // desdeTextBox
            // 
            this.desdeTextBox.Location = new System.Drawing.Point(173, 12);
            this.desdeTextBox.Name = "desdeTextBox";
            this.desdeTextBox.Size = new System.Drawing.Size(106, 20);
            this.desdeTextBox.TabIndex = 16;
            // 
            // hastaTextBox
            // 
            this.hastaTextBox.Location = new System.Drawing.Point(352, 12);
            this.hastaTextBox.Name = "hastaTextBox";
            this.hastaTextBox.Size = new System.Drawing.Size(106, 20);
            this.hastaTextBox.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.hastaTextBox);
            this.groupBox3.Controls.Add(this.desdeTextBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(13, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 38);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 39);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(559, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Para ver todos sus turnos deje en blanco los campos de fechas, puede usarlos para" +
                " buscar sus turnos en un periodo.";
            // 
            // ProfesionalCancelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 356);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "ProfesionalCancelar";
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox desdeTextBox;
        private System.Windows.Forms.TextBox hastaTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;

    }
}