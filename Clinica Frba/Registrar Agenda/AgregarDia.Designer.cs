namespace Clinica_Frba.Registrar_Agenda
{
    partial class AgregarDia
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboHasta = new System.Windows.Forms.ComboBox();
            this.comboDesde = new System.Windows.Forms.ComboBox();
            this.comboSabHasta = new System.Windows.Forms.ComboBox();
            this.comboSabDesde = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboDia = new System.Windows.Forms.ComboBox();
            this.botAceptar = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "hasta las:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Atender desde las:";
            // 
            // comboHasta
            // 
            this.comboHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHasta.FormattingEnabled = true;
            this.comboHasta.Items.AddRange(new object[] {
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00"});
            this.comboHasta.Location = new System.Drawing.Point(231, 42);
            this.comboHasta.Name = "comboHasta";
            this.comboHasta.Size = new System.Drawing.Size(53, 21);
            this.comboHasta.TabIndex = 10;
            // 
            // comboDesde
            // 
            this.comboDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDesde.FormattingEnabled = true;
            this.comboDesde.Items.AddRange(new object[] {
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30"});
            this.comboDesde.Location = new System.Drawing.Point(113, 42);
            this.comboDesde.Name = "comboDesde";
            this.comboDesde.Size = new System.Drawing.Size(53, 21);
            this.comboDesde.TabIndex = 9;
            // 
            // comboSabHasta
            // 
            this.comboSabHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSabHasta.FormattingEnabled = true;
            this.comboSabHasta.Items.AddRange(new object[] {
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00"});
            this.comboSabHasta.Location = new System.Drawing.Point(231, 42);
            this.comboSabHasta.Name = "comboSabHasta";
            this.comboSabHasta.Size = new System.Drawing.Size(53, 21);
            this.comboSabHasta.TabIndex = 15;
            this.comboSabHasta.Visible = false;
            // 
            // comboSabDesde
            // 
            this.comboSabDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSabDesde.FormattingEnabled = true;
            this.comboSabDesde.Items.AddRange(new object[] {
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30"});
            this.comboSabDesde.Location = new System.Drawing.Point(113, 42);
            this.comboSabDesde.Name = "comboSabDesde";
            this.comboSabDesde.Size = new System.Drawing.Size(53, 21);
            this.comboSabDesde.TabIndex = 14;
            this.comboSabDesde.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Día de la semana:";
            // 
            // comboDia
            // 
            this.comboDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDia.FormattingEnabled = true;
            this.comboDia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado"});
            this.comboDia.Location = new System.Drawing.Point(113, 15);
            this.comboDia.Name = "comboDia";
            this.comboDia.Size = new System.Drawing.Size(99, 21);
            this.comboDia.TabIndex = 17;
            this.comboDia.SelectedIndexChanged += new System.EventHandler(this.comboDia_SelectedIndexChanged);
            // 
            // botAceptar
            // 
            this.botAceptar.Location = new System.Drawing.Point(209, 69);
            this.botAceptar.Name = "botAceptar";
            this.botAceptar.Size = new System.Drawing.Size(75, 23);
            this.botAceptar.TabIndex = 19;
            this.botAceptar.Text = "Aceptar";
            this.botAceptar.UseVisualStyleBackColor = true;
            this.botAceptar.Click += new System.EventHandler(this.botAceptar_Click);
            // 
            // botCancelar
            // 
            this.botCancelar.Location = new System.Drawing.Point(12, 69);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(75, 23);
            this.botCancelar.TabIndex = 18;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // AgregarDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 106);
            this.Controls.Add(this.botAceptar);
            this.Controls.Add(this.botCancelar);
            this.Controls.Add(this.comboDia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboSabHasta);
            this.Controls.Add(this.comboSabDesde);
            this.Controls.Add(this.comboHasta);
            this.Controls.Add(this.comboDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AgregarDia";
            this.Text = "Agregar día de atención";
            this.Load += new System.EventHandler(this.AgregarDia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboHasta;
        private System.Windows.Forms.ComboBox comboDesde;
        private System.Windows.Forms.ComboBox comboSabHasta;
        private System.Windows.Forms.ComboBox comboSabDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboDia;
        private System.Windows.Forms.Button botAceptar;
        private System.Windows.Forms.Button botCancelar;
    }
}