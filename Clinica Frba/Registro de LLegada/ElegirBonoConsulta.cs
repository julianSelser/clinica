using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;
using Clinica_Frba.Domain;

namespace Clinica_Frba.Registro_de_LLegada
{
    public partial class ElegirBonoConsulta : Form
    {

        Form padre;
        Turno turno;

        internal ElegirBonoConsulta(Form padre, Turno turno)
        {
            InitializeComponent();
            this.padre = padre;
            this.turno = turno;
            cargarGrilla();
            cargarBotonFuncionalidad();
        }

        private void cargarGrilla()
        {
            AsistenteVistas.cargarGrilla(grillaBonos, AppRegistrarLlegada.traerBonos(turno));
        }

        private void cargarBotonFuncionalidad()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Registrar Llegada";
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaBonos.Columns.Add(col);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void grillaBonos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grillaBonos.Columns["Seleccionar"].Index && e.RowIndex >= 0) //Para que la accion de click sea valida solo sobre el boton
            {
                DataGridViewRow fila = grillaBonos.Rows[e.RowIndex];
                BonoConsulta bono = armarBonoConsulta();
                AppRegistrarLlegada.registrarLlegada(turno, bono);
            }
        }

        private BonoConsulta armarBonoConsulta()
        {
            throw new NotImplementedException();
        }
    }
}
