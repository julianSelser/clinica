﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Listados_Estadisticos
{
    public partial class MostrarListado : Form
    {
        private Form padre;

        public MostrarListado(Form padre, int listadoID, string tipoListado, string semestre, string anio)
        {
            InitializeComponent();
            this.padre = padre;

            info.Text = tipoListado;

            grilla.DataSource = ConectorSQL.traerDataTable("getListadoEstadistico", semestre, listadoID, anio);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }
    }
}
