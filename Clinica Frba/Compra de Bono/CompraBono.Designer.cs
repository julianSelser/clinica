namespace Clinica_Frba.Compra_de_Bono
{
    partial class CompraBono
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
            this.botonRegreso = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonQuitarAfiliado = new System.Windows.Forms.Button();
            this.labPlan = new System.Windows.Forms.Label();
            this.labAfiliado = new System.Windows.Forms.Label();
            this.labNroPlan = new System.Windows.Forms.Label();
            this.labNroAfiliado = new System.Windows.Forms.Label();
            this.botonBuscarAfiliado = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labPrecioFarmacia = new System.Windows.Forms.Label();
            this.labPrecioConsulta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.botonComprar = new System.Windows.Forms.Button();
            this.textCantBonosConsulta = new System.Windows.Forms.TextBox();
            this.textCantBonosFarmacia = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonRegreso
            // 
            this.botonRegreso.Location = new System.Drawing.Point(15, 253);
            this.botonRegreso.Name = "botonRegreso";
            this.botonRegreso.Size = new System.Drawing.Size(75, 23);
            this.botonRegreso.TabIndex = 5;
            this.botonRegreso.Text = "Volver";
            this.botonRegreso.UseVisualStyleBackColor = true;
            this.botonRegreso.Click += new System.EventHandler(this.botonRegreso_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonQuitarAfiliado);
            this.groupBox1.Controls.Add(this.labPlan);
            this.groupBox1.Controls.Add(this.labAfiliado);
            this.groupBox1.Controls.Add(this.labNroPlan);
            this.groupBox1.Controls.Add(this.labNroAfiliado);
            this.groupBox1.Controls.Add(this.botonBuscarAfiliado);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 56);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos personales";
            // 
            // botonQuitarAfiliado
            // 
            this.botonQuitarAfiliado.Location = new System.Drawing.Point(171, 22);
            this.botonQuitarAfiliado.Name = "botonQuitarAfiliado";
            this.botonQuitarAfiliado.Size = new System.Drawing.Size(46, 21);
            this.botonQuitarAfiliado.TabIndex = 12;
            this.botonQuitarAfiliado.Text = "Quitar";
            this.botonQuitarAfiliado.UseVisualStyleBackColor = true;
            this.botonQuitarAfiliado.Visible = false;
            this.botonQuitarAfiliado.Click += new System.EventHandler(this.botonQuitarAfiliado_Click);
            // 
            // labPlan
            // 
            this.labPlan.AutoSize = true;
            this.labPlan.Location = new System.Drawing.Point(239, 24);
            this.labPlan.Name = "labPlan";
            this.labPlan.Size = new System.Drawing.Size(31, 13);
            this.labPlan.TabIndex = 9;
            this.labPlan.Text = "Plan:";
            // 
            // labAfiliado
            // 
            this.labAfiliado.AutoSize = true;
            this.labAfiliado.Location = new System.Drawing.Point(18, 25);
            this.labAfiliado.Name = "labAfiliado";
            this.labAfiliado.Size = new System.Drawing.Size(44, 13);
            this.labAfiliado.TabIndex = 8;
            this.labAfiliado.Text = "Afiliado:";
            // 
            // labNroPlan
            // 
            this.labNroPlan.AutoSize = true;
            this.labNroPlan.Location = new System.Drawing.Point(286, 24);
            this.labNroPlan.Name = "labNroPlan";
            this.labNroPlan.Size = new System.Drawing.Size(33, 13);
            this.labNroPlan.TabIndex = 13;
            this.labNroPlan.Text = "(plan)";
            this.labNroPlan.Visible = false;
            // 
            // labNroAfiliado
            // 
            this.labNroAfiliado.AutoSize = true;
            this.labNroAfiliado.Location = new System.Drawing.Point(68, 25);
            this.labNroAfiliado.Name = "labNroAfiliado";
            this.labNroAfiliado.Size = new System.Drawing.Size(46, 13);
            this.labNroAfiliado.TabIndex = 12;
            this.labNroAfiliado.Text = "(afiliado)";
            this.labNroAfiliado.Visible = false;
            // 
            // botonBuscarAfiliado
            // 
            this.botonBuscarAfiliado.Location = new System.Drawing.Point(171, 22);
            this.botonBuscarAfiliado.Name = "botonBuscarAfiliado";
            this.botonBuscarAfiliado.Size = new System.Drawing.Size(46, 21);
            this.botonBuscarAfiliado.TabIndex = 11;
            this.botonBuscarAfiliado.Text = "Elegir";
            this.botonBuscarAfiliado.UseVisualStyleBackColor = true;
            this.botonBuscarAfiliado.Click += new System.EventHandler(this.botonBuscarAfiliado_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(94, 20);
            this.textBox1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labPrecioFarmacia);
            this.groupBox2.Controls.Add(this.labPrecioConsulta);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(15, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 57);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Precios";
            // 
            // labPrecioFarmacia
            // 
            this.labPrecioFarmacia.AutoSize = true;
            this.labPrecioFarmacia.Location = new System.Drawing.Point(323, 24);
            this.labPrecioFarmacia.Name = "labPrecioFarmacia";
            this.labPrecioFarmacia.Size = new System.Drawing.Size(39, 13);
            this.labPrecioFarmacia.TabIndex = 14;
            this.labPrecioFarmacia.Text = "(pfarm)";
            this.labPrecioFarmacia.Visible = false;
            // 
            // labPrecioConsulta
            // 
            this.labPrecioConsulta.AutoSize = true;
            this.labPrecioConsulta.Location = new System.Drawing.Point(100, 24);
            this.labPrecioConsulta.Name = "labPrecioConsulta";
            this.labPrecioConsulta.Size = new System.Drawing.Size(42, 13);
            this.labPrecioConsulta.TabIndex = 13;
            this.labPrecioConsulta.Text = "(pcons)";
            this.labPrecioConsulta.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bono Farmacia:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bono Consulta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Bonos Consulta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bonos Farmacia:";
            // 
            // botonComprar
            // 
            this.botonComprar.Location = new System.Drawing.Point(328, 253);
            this.botonComprar.Name = "botonComprar";
            this.botonComprar.Size = new System.Drawing.Size(74, 22);
            this.botonComprar.TabIndex = 14;
            this.botonComprar.Text = "Comprar";
            this.botonComprar.UseVisualStyleBackColor = true;
            this.botonComprar.Click += new System.EventHandler(this.botonComprar_Click);
            // 
            // textCantBonosConsulta
            // 
            this.textCantBonosConsulta.Location = new System.Drawing.Point(228, 161);
            this.textCantBonosConsulta.MaxLength = 3;
            this.textCantBonosConsulta.Name = "textCantBonosConsulta";
            this.textCantBonosConsulta.Size = new System.Drawing.Size(38, 20);
            this.textCantBonosConsulta.TabIndex = 15;
            // 
            // textCantBonosFarmacia
            // 
            this.textCantBonosFarmacia.Location = new System.Drawing.Point(228, 197);
            this.textCantBonosFarmacia.MaxLength = 3;
            this.textCantBonosFarmacia.Name = "textCantBonosFarmacia";
            this.textCantBonosFarmacia.Size = new System.Drawing.Size(38, 20);
            this.textCantBonosFarmacia.TabIndex = 16;
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 297);
            this.Controls.Add(this.textCantBonosFarmacia);
            this.Controls.Add(this.textCantBonosConsulta);
            this.Controls.Add(this.botonComprar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.botonRegreso);
            this.Name = "CompraBono";
            this.Text = "Comprar_Bono";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonRegreso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonBuscarAfiliado;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labPlan;
        private System.Windows.Forms.Label labAfiliado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botonComprar;
        private System.Windows.Forms.TextBox textCantBonosConsulta;
        private System.Windows.Forms.TextBox textCantBonosFarmacia;
        private System.Windows.Forms.Button botonQuitarAfiliado;
        private System.Windows.Forms.Label labNroPlan;
        private System.Windows.Forms.Label labNroAfiliado;
        private System.Windows.Forms.Label labPrecioFarmacia;
        private System.Windows.Forms.Label labPrecioConsulta;
    }
}