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

//inicializa una nueva ventana con la lista de afiliados,
//se puede filtrar por criterios y al seleccionar una fila se comporta distinto
//segun el tipo de funcionalidad especificada que recibio por parametro

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class ListadoProfesionales : Form, IListado
    {
        public Form padre;
        public string funcion;

        public ListadoProfesionales(Form padre, string funcion)
        {
            InitializeComponent();
            this.padre = padre;
            this.funcion = funcion;
            cargarGrilla();
            ocultarColumnas();
            cargarBotonFuncionalidad();
            validarCampos();
        }


        private void ocultarColumnas() //oculto las columnas que no son de interes
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            try
            {   //Se carga la grilla ejecutando el procedure con los valores de filtro como parametro
                cargarGrilla();
            }
            catch (Exception ex)
            {
                ErrorManager.fatalError(padre, this, ex);
            }
        }

        public void cargarGrilla()
        {
            AsistenteVistas.cargarGrilla(grillaProfesionales, AppProfesional.traerDataTableMedicos());
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            inicializarCampos(); //Limpia los campos
        }

        private void inicializarCampos()
        {
            nombreBox.Text = "";
            apellidoBox.Text = "";
        }

        private void cargarBotonFuncionalidad()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = funcion;
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaProfesionales.Columns.Add(col);
        }

        private bool estaDadoDeBaja(DataGridViewRow fila)
        {
            int index = grillaProfesionales.Columns["Habilitado"].Index;
            return !(bool)fila.Cells[index].Value;
        }

        private void grillaAfiliados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grillaProfesionales.Columns["Seleccionar"].Index && e.RowIndex >= 0) //Para que la accion de click sea valida solo sobre el boton
            {
                DataGridViewRow fila = grillaProfesionales.Rows[e.RowIndex];
                if (!estaDadoDeBaja(fila))
                {
                    Profesional profesional = crearProfesional(e.RowIndex); //instancia un afiliado y luego depende de la funcionalidad, abrirá otra ventana
                    if (funcion == "Baja") AsistenteVistas.mostrarNuevaVentana(new BajaProfesional(this, profesional), this);
                    if (funcion == "Modificar") AsistenteVistas.mostrarNuevaVentana(new ModificarProfesional(this, profesional), this);
                }
                else MessageBox.Show("El profesional seleccionado se encuentra inhabilitado");
            }
            
        }

        private Profesional crearProfesional(int fila)
        {
            Profesional profesional = new Profesional();
            int index = grillaProfesionales.Columns["ID Medico"].Index;
            profesional.id = Convert.ToInt32(grillaProfesionales.Rows.SharedRow(fila).Cells[index].Value.ToString());
            return profesional;
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Nombre", nombreBox.Text, false, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Apellido", apellidoBox.Text, false, Controlador.TipoValidacion.Alfa));
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

        private void ListadoProfesionales_Activated(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void nombreBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void apellidoBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }
    }
}
