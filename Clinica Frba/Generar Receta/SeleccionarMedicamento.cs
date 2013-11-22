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

//Esta vista permite seleccionar un medicamento, filtrando por nro de medicamento o descripcion contiene

namespace Clinica_Frba.Generar_Receta
{
    public partial class SeleccionarMedicamento : Form
    {
        Form padre;

        public SeleccionarMedicamento(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            cargarGrilla();
            cargarBotonFuncionalidad();
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Nro. Medicamento", nroMedicamentoBox.Text, false, Controlador.TipoValidacion.Codigo));
            campos.Add(new Campo("Descripcion contiene", descripcionBox.Text, false, Controlador.TipoValidacion.Alfanumerico));
            
            try
            {
                Controlador.validarCampos(campos);
                buscarButton.Enabled = true;
                errorBox.Text = "";
            }
            catch (ExcepcionValidacion validacion)
            {
                errorBox.Text = validacion.mensaje;
                buscarButton.Enabled = false;
            }
        }

        private void cargarGrilla()
        {
            Medicamento medicamento = armarBusquedaMedicamento();
            AsistenteVistas.cargarGrilla(grillaMedicamentos, AppReceta.traerMedicamentos(medicamento));
            grillaMedicamentos.Columns["Descripcion Medicamento"].Width = 450;
        }

        private void cargarBotonFuncionalidad()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Seleccionar";
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaMedicamentos.Columns.Add(col);
        }

        private Medicamento armarBusquedaMedicamento()
        {
            Medicamento medicamento = new Medicamento();
            if (nroMedicamentoBox.Text != "") medicamento.nroMedicamento = Convert.ToInt32(nroMedicamentoBox.Text);
            else medicamento.nroMedicamento = -1;
            medicamento.descripcion = descripcionBox.Text;
            return medicamento;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            (padre as GenerarReceta).medicamento_aux = new Medicamento();
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nroMedicamentoBox.Clear();
            descripcionBox.Clear();
            cargarGrilla();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void grillaMedicamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grillaMedicamentos.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaMedicamentos.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
            {
                (padre as GenerarReceta).medicamento_aux = crearMedicamento(e.RowIndex);
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
        }

        private Medicamento crearMedicamento(int fila)
        {
            Medicamento medicamento = new Medicamento();
            int index = grillaMedicamentos.Columns["Nro. Medicamento"].Index;
            medicamento.nroMedicamento = Convert.ToInt32(grillaMedicamentos.Rows.SharedRow(fila).Cells[index].Value.ToString());
            index = grillaMedicamentos.Columns["Descripcion Medicamento"].Index;
            medicamento.descripcion = grillaMedicamentos.Rows.SharedRow(fila).Cells[index].Value.ToString();
            return medicamento;
        }

        private void nroMedicamentoBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void descripcionBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

    }
}
