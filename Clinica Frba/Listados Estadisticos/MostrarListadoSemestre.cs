using System;
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
    public partial class MostrarListadoSemestre : Form
    {
        private Form padre;

        public MostrarListadoSemestre(Form padre, int listadoID, string tipoListado, string semestre, string anio)
        {
            InitializeComponent();
            this.padre = padre;

            info.Text = tipoListado;

            int mes =  semestre == "1er semestre"? 1 : 7 ;

            grilla.DataSource = ConectorSQL.traerDataTable("elegirListado", listadoID, anio, mes, mes + 5);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }
    }
}
