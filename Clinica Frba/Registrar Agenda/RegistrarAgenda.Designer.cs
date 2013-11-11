namespace Clinica_Frba.Registrar_Agenda
{
    partial class RegistrarAgenda
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonQuitarMedico = new System.Windows.Forms.Button();
            this.labMedico = new System.Windows.Forms.Label();
            this.labNroMedico = new System.Windows.Forms.Label();
            this.botonBuscarMedico = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboSabadoHasta = new System.Windows.Forms.ComboBox();
            this.comboSabadoDesde = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboViernesHasta = new System.Windows.Forms.ComboBox();
            this.comboViernesDesde = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboJuevesHasta = new System.Windows.Forms.ComboBox();
            this.comboJuevesDesde = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboMiercolesHasta = new System.Windows.Forms.ComboBox();
            this.comboMiercolesDesde = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboMartesHasta = new System.Windows.Forms.ComboBox();
            this.comboMartesDesde = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboLunesHasta = new System.Windows.Forms.ComboBox();
            this.comboLunesDesde = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSabado = new System.Windows.Forms.CheckBox();
            this.chkViernes = new System.Windows.Forms.CheckBox();
            this.chkJueves = new System.Windows.Forms.CheckBox();
            this.chkMiercoles = new System.Windows.Forms.CheckBox();
            this.chkMartes = new System.Windows.Forms.CheckBox();
            this.chkLunes = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonQuitarMedico);
            this.groupBox1.Controls.Add(this.labMedico);
            this.groupBox1.Controls.Add(this.labNroMedico);
            this.groupBox1.Controls.Add(this.botonBuscarMedico);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 56);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos personales";
            // 
            // botonQuitarMedico
            // 
            this.botonQuitarMedico.Location = new System.Drawing.Point(144, 21);
            this.botonQuitarMedico.Name = "botonQuitarMedico";
            this.botonQuitarMedico.Size = new System.Drawing.Size(46, 21);
            this.botonQuitarMedico.TabIndex = 12;
            this.botonQuitarMedico.Text = "Quitar";
            this.botonQuitarMedico.UseVisualStyleBackColor = true;
            this.botonQuitarMedico.Visible = false;
            this.botonQuitarMedico.Click += new System.EventHandler(this.botonQuitarMedico_Click);
            // 
            // labMedico
            // 
            this.labMedico.AutoSize = true;
            this.labMedico.Location = new System.Drawing.Point(18, 25);
            this.labMedico.Name = "labMedico";
            this.labMedico.Size = new System.Drawing.Size(62, 13);
            this.labMedico.TabIndex = 8;
            this.labMedico.Text = "Profesional:";
            // 
            // labNroMedico
            // 
            this.labNroMedico.AutoSize = true;
            this.labNroMedico.Location = new System.Drawing.Point(86, 25);
            this.labNroMedico.Name = "labNroMedico";
            this.labNroMedico.Size = new System.Drawing.Size(28, 13);
            this.labNroMedico.TabIndex = 12;
            this.labNroMedico.Text = "(pro)";
            this.labNroMedico.Visible = false;
            // 
            // botonBuscarMedico
            // 
            this.botonBuscarMedico.Location = new System.Drawing.Point(144, 21);
            this.botonBuscarMedico.Name = "botonBuscarMedico";
            this.botonBuscarMedico.Size = new System.Drawing.Size(46, 21);
            this.botonBuscarMedico.TabIndex = 11;
            this.botonBuscarMedico.Text = "Elegir";
            this.botonBuscarMedico.UseVisualStyleBackColor = true;
            this.botonBuscarMedico.Click += new System.EventHandler(this.botonBuscarMedico_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(41, 20);
            this.textBox1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboSabadoHasta);
            this.groupBox2.Controls.Add(this.comboSabadoDesde);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.comboViernesHasta);
            this.groupBox2.Controls.Add(this.comboViernesDesde);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboJuevesHasta);
            this.groupBox2.Controls.Add(this.comboJuevesDesde);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboMiercolesHasta);
            this.groupBox2.Controls.Add(this.comboMiercolesDesde);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboMartesHasta);
            this.groupBox2.Controls.Add(this.comboMartesDesde);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboLunesHasta);
            this.groupBox2.Controls.Add(this.comboLunesDesde);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkSabado);
            this.groupBox2.Controls.Add(this.chkViernes);
            this.groupBox2.Controls.Add(this.chkJueves);
            this.groupBox2.Controls.Add(this.chkMiercoles);
            this.groupBox2.Controls.Add(this.chkMartes);
            this.groupBox2.Controls.Add(this.chkLunes);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 242);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Días de atención";
            this.groupBox2.Visible = false;
            // 
            // comboSabadoHasta
            // 
            this.comboSabadoHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSabadoHasta.FormattingEnabled = true;
            this.comboSabadoHasta.Items.AddRange(new object[] {
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
            this.comboSabadoHasta.Location = new System.Drawing.Point(285, 153);
            this.comboSabadoHasta.Name = "comboSabadoHasta";
            this.comboSabadoHasta.Size = new System.Drawing.Size(68, 21);
            this.comboSabadoHasta.TabIndex = 29;
            // 
            // comboSabadoDesde
            // 
            this.comboSabadoDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSabadoDesde.FormattingEnabled = true;
            this.comboSabadoDesde.Items.AddRange(new object[] {
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
            this.comboSabadoDesde.Location = new System.Drawing.Point(167, 153);
            this.comboSabadoDesde.Name = "comboSabadoDesde";
            this.comboSabadoDesde.Size = new System.Drawing.Size(68, 21);
            this.comboSabadoDesde.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Hasta:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(123, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Desde:";
            // 
            // comboViernesHasta
            // 
            this.comboViernesHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboViernesHasta.FormattingEnabled = true;
            this.comboViernesHasta.Items.AddRange(new object[] {
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
            this.comboViernesHasta.Location = new System.Drawing.Point(285, 126);
            this.comboViernesHasta.Name = "comboViernesHasta";
            this.comboViernesHasta.Size = new System.Drawing.Size(68, 21);
            this.comboViernesHasta.TabIndex = 25;
            // 
            // comboViernesDesde
            // 
            this.comboViernesDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboViernesDesde.FormattingEnabled = true;
            this.comboViernesDesde.Items.AddRange(new object[] {
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
            this.comboViernesDesde.Location = new System.Drawing.Point(167, 126);
            this.comboViernesDesde.Name = "comboViernesDesde";
            this.comboViernesDesde.Size = new System.Drawing.Size(68, 21);
            this.comboViernesDesde.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Hasta:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(123, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Desde:";
            // 
            // comboJuevesHasta
            // 
            this.comboJuevesHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJuevesHasta.FormattingEnabled = true;
            this.comboJuevesHasta.Items.AddRange(new object[] {
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
            this.comboJuevesHasta.Location = new System.Drawing.Point(285, 99);
            this.comboJuevesHasta.Name = "comboJuevesHasta";
            this.comboJuevesHasta.Size = new System.Drawing.Size(68, 21);
            this.comboJuevesHasta.TabIndex = 21;
            // 
            // comboJuevesDesde
            // 
            this.comboJuevesDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJuevesDesde.FormattingEnabled = true;
            this.comboJuevesDesde.Items.AddRange(new object[] {
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
            this.comboJuevesDesde.Location = new System.Drawing.Point(167, 99);
            this.comboJuevesDesde.Name = "comboJuevesDesde";
            this.comboJuevesDesde.Size = new System.Drawing.Size(68, 21);
            this.comboJuevesDesde.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Hasta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(123, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Desde:";
            // 
            // comboMiercolesHasta
            // 
            this.comboMiercolesHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMiercolesHasta.FormattingEnabled = true;
            this.comboMiercolesHasta.Items.AddRange(new object[] {
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
            this.comboMiercolesHasta.Location = new System.Drawing.Point(285, 72);
            this.comboMiercolesHasta.Name = "comboMiercolesHasta";
            this.comboMiercolesHasta.Size = new System.Drawing.Size(68, 21);
            this.comboMiercolesHasta.TabIndex = 17;
            // 
            // comboMiercolesDesde
            // 
            this.comboMiercolesDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMiercolesDesde.FormattingEnabled = true;
            this.comboMiercolesDesde.Items.AddRange(new object[] {
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
            this.comboMiercolesDesde.Location = new System.Drawing.Point(167, 72);
            this.comboMiercolesDesde.Name = "comboMiercolesDesde";
            this.comboMiercolesDesde.Size = new System.Drawing.Size(68, 21);
            this.comboMiercolesDesde.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Hasta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Desde:";
            // 
            // comboMartesHasta
            // 
            this.comboMartesHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMartesHasta.FormattingEnabled = true;
            this.comboMartesHasta.Items.AddRange(new object[] {
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
            this.comboMartesHasta.Location = new System.Drawing.Point(285, 45);
            this.comboMartesHasta.Name = "comboMartesHasta";
            this.comboMartesHasta.Size = new System.Drawing.Size(68, 21);
            this.comboMartesHasta.TabIndex = 13;
            // 
            // comboMartesDesde
            // 
            this.comboMartesDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMartesDesde.FormattingEnabled = true;
            this.comboMartesDesde.Items.AddRange(new object[] {
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
            this.comboMartesDesde.Location = new System.Drawing.Point(167, 45);
            this.comboMartesDesde.Name = "comboMartesDesde";
            this.comboMartesDesde.Size = new System.Drawing.Size(68, 21);
            this.comboMartesDesde.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Desde:";
            // 
            // comboLunesHasta
            // 
            this.comboLunesHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLunesHasta.FormattingEnabled = true;
            this.comboLunesHasta.Items.AddRange(new object[] {
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
            this.comboLunesHasta.Location = new System.Drawing.Point(285, 18);
            this.comboLunesHasta.Name = "comboLunesHasta";
            this.comboLunesHasta.Size = new System.Drawing.Size(68, 21);
            this.comboLunesHasta.TabIndex = 9;
            // 
            // comboLunesDesde
            // 
            this.comboLunesDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLunesDesde.FormattingEnabled = true;
            this.comboLunesDesde.Items.AddRange(new object[] {
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
            this.comboLunesDesde.Location = new System.Drawing.Point(167, 18);
            this.comboLunesDesde.Name = "comboLunesDesde";
            this.comboLunesDesde.Size = new System.Drawing.Size(68, 21);
            this.comboLunesDesde.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Desde:";
            // 
            // chkSabado
            // 
            this.chkSabado.AutoSize = true;
            this.chkSabado.Location = new System.Drawing.Point(15, 157);
            this.chkSabado.Name = "chkSabado";
            this.chkSabado.Size = new System.Drawing.Size(63, 17);
            this.chkSabado.TabIndex = 5;
            this.chkSabado.Text = "Sábado";
            this.chkSabado.UseVisualStyleBackColor = true;
            // 
            // chkViernes
            // 
            this.chkViernes.AutoSize = true;
            this.chkViernes.Location = new System.Drawing.Point(15, 130);
            this.chkViernes.Name = "chkViernes";
            this.chkViernes.Size = new System.Drawing.Size(61, 17);
            this.chkViernes.TabIndex = 4;
            this.chkViernes.Text = "Viernes";
            this.chkViernes.UseVisualStyleBackColor = true;
            // 
            // chkJueves
            // 
            this.chkJueves.AutoSize = true;
            this.chkJueves.Location = new System.Drawing.Point(15, 103);
            this.chkJueves.Name = "chkJueves";
            this.chkJueves.Size = new System.Drawing.Size(60, 17);
            this.chkJueves.TabIndex = 3;
            this.chkJueves.Text = "Jueves";
            this.chkJueves.UseVisualStyleBackColor = true;
            // 
            // chkMiercoles
            // 
            this.chkMiercoles.AutoSize = true;
            this.chkMiercoles.Location = new System.Drawing.Point(15, 76);
            this.chkMiercoles.Name = "chkMiercoles";
            this.chkMiercoles.Size = new System.Drawing.Size(71, 17);
            this.chkMiercoles.TabIndex = 2;
            this.chkMiercoles.Text = "Miércoles";
            this.chkMiercoles.UseVisualStyleBackColor = true;
            // 
            // chkMartes
            // 
            this.chkMartes.AutoSize = true;
            this.chkMartes.Location = new System.Drawing.Point(15, 49);
            this.chkMartes.Name = "chkMartes";
            this.chkMartes.Size = new System.Drawing.Size(58, 17);
            this.chkMartes.TabIndex = 1;
            this.chkMartes.Text = "Martes";
            this.chkMartes.UseVisualStyleBackColor = true;
            // 
            // chkLunes
            // 
            this.chkLunes.AutoSize = true;
            this.chkLunes.Location = new System.Drawing.Point(15, 22);
            this.chkLunes.Name = "chkLunes";
            this.chkLunes.Size = new System.Drawing.Size(55, 17);
            this.chkLunes.TabIndex = 0;
            this.chkLunes.Text = "Lunes";
            this.chkLunes.UseVisualStyleBackColor = true;
            // 
            // RegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 384);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "RegistrarAgenda";
            this.Text = "Registrar Agenda";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonQuitarMedico;
        private System.Windows.Forms.Label labMedico;
        private System.Windows.Forms.Label labNroMedico;
        private System.Windows.Forms.Button botonBuscarMedico;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSabado;
        private System.Windows.Forms.CheckBox chkViernes;
        private System.Windows.Forms.CheckBox chkJueves;
        private System.Windows.Forms.CheckBox chkMiercoles;
        private System.Windows.Forms.CheckBox chkMartes;
        private System.Windows.Forms.CheckBox chkLunes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboLunesDesde;
        private System.Windows.Forms.ComboBox comboLunesHasta;
        private System.Windows.Forms.ComboBox comboSabadoHasta;
        private System.Windows.Forms.ComboBox comboSabadoDesde;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboViernesHasta;
        private System.Windows.Forms.ComboBox comboViernesDesde;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboJuevesHasta;
        private System.Windows.Forms.ComboBox comboJuevesDesde;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboMiercolesHasta;
        private System.Windows.Forms.ComboBox comboMiercolesDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboMartesHasta;
        private System.Windows.Forms.ComboBox comboMartesDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}