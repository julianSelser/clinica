using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

// pantalla de eleccion de listado segun los criterios especificados en el enunciado
namespace Clinica_Frba.Listados_Estadisticos
{
    public partial class ListadosEstadisticos : Form
    {
        private Form padre;

        public ListadosEstadisticos(Form padre)
        {
            InitializeComponent();
            this.padre = padre;

            listadoSelector.SelectedIndex = 0;
            semestreSelector.SelectedIndex = 0;
        }

        private void mostrar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new MostrarListado(this, listadoSelector.SelectedIndex, listadoSelector.Text, semestreSelector.Text, anioPicker.Text), this);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }
    }
}
