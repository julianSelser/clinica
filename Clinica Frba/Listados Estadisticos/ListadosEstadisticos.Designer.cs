namespace Clinica_Frba.Listados_Estadisticos
{
    partial class ListadosEstadisticos
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
            this.mostrar = new System.Windows.Forms.Button();
            this.anioPicker = new System.Windows.Forms.DateTimePicker();
            this.listadoSelector = new System.Windows.Forms.ComboBox();
            this.semestreSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(251, 106);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 9;
            this.volver.Text = "volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // mostrar
            // 
            this.mostrar.Location = new System.Drawing.Point(169, 106);
            this.mostrar.Name = "mostrar";
            this.mostrar.Size = new System.Drawing.Size(75, 23);
            this.mostrar.TabIndex = 8;
            this.mostrar.Text = "mostrar";
            this.mostrar.UseVisualStyleBackColor = true;
            this.mostrar.Click += new System.EventHandler(this.mostrar_Click);
            // 
            // anioPicker
            // 
            this.anioPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.anioPicker.CustomFormat = "yyyy";
            this.anioPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.anioPicker.Location = new System.Drawing.Point(214, 51);
            this.anioPicker.Name = "anioPicker";
            this.anioPicker.ShowUpDown = true;
            this.anioPicker.Size = new System.Drawing.Size(83, 20);
            this.anioPicker.TabIndex = 10;
            // 
            // listadoSelector
            // 
            this.listadoSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listadoSelector.FormattingEnabled = true;
            this.listadoSelector.Items.AddRange(new object[] {
            "TOP-5 Especialidades con mas cancelaciones",
            "TOP-5 Bonos farmacia vencidos por afiliado",
            "TOP-5 Especialidades con más bonos recetados",
            "TOP-10 utilización de bonos comprados por terceros"});
            this.listadoSelector.Location = new System.Drawing.Point(14, 19);
            this.listadoSelector.Name = "listadoSelector";
            this.listadoSelector.Size = new System.Drawing.Size(283, 21);
            this.listadoSelector.TabIndex = 11;
            // 
            // semestreSelector
            // 
            this.semestreSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semestreSelector.FormattingEnabled = true;
            this.semestreSelector.Items.AddRange(new object[] {
            "1er semestre",
            "2do semestre"});
            this.semestreSelector.Location = new System.Drawing.Point(66, 50);
            this.semestreSelector.Name = "semestreSelector";
            this.semestreSelector.Size = new System.Drawing.Size(94, 21);
            this.semestreSelector.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "semestre";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.semestreSelector);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listadoSelector);
            this.groupBox1.Controls.Add(this.anioPicker);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 88);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "tipo de listado";
            // 
            // ListadosEstadisticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 143);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.mostrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadosEstadisticos";
            this.Text = "Listados Estadísticos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button mostrar;
        private System.Windows.Forms.DateTimePicker anioPicker;
        private System.Windows.Forms.ComboBox listadoSelector;
        private System.Windows.Forms.ComboBox semestreSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}