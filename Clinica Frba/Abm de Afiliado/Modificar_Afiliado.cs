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
    public partial class Modificar_Afiliado : Form
    {
        private Form padre;

        public Modificar_Afiliado(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Modificar_Afiliado2(this), this);
        }
    }
}
