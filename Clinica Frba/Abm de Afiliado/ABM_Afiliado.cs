﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class ABM_Afiliado : Form
    {
        private Form padre;

        public ABM_Afiliado(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new BajaAfiliado(this), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificarAfiliado(this), this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new AltaAfiliado("Titular",this), this);
        }
    }
}
