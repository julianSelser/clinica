﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class ABM_Profesional : Form
    {
        private Form padre;

        public ABM_Profesional(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Alta_Profesional(this), this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Baja_Profesional(this), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Modificar_Profesional(this), this);
        }
    }
}
