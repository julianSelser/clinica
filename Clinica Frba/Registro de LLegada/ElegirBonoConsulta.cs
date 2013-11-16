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
            this.nroAfiliadoBox.Text = turno.nroAfiliado.ToString();
            this.profesionalBox.Text = turno.idMedico.ToString();
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
            col.Text = "Elegir Bono";
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
            if (e.ColumnIndex == grillaBonos.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaBonos.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
            {
                DataGridViewRow fila = grillaBonos.Rows[e.RowIndex];
                BonoConsulta bono = armarBonoConsulta(e.RowIndex);
                AppRegistrarLlegada.registrarLlegada(turno, bono);
                MessageBox.Show("Se ha registrado la llegada correctamente.");
                AsistenteVistas.volverAPadreYCerrar((padre as RegistroLlegada).padre, this);
            }
        }

        private BonoConsulta armarBonoConsulta(int fila)
        {
            BonoConsulta bono = new BonoConsulta();
            bono.nroUsuario = turno.nroAfiliado;
            int index = grillaBonos.Columns["Nro. de Bono"].Index;
            bono.numero = Convert.ToInt32(grillaBonos.Rows.SharedRow(fila).Cells[index].Value.ToString());
            return bono;
        }
    }
}
