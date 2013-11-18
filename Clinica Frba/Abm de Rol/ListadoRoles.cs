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

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class ListadoRoles : Form//, IListado //era una interfaz pero al final no se implementa
    {
        public Form padre;
        public string funcion; //para saber si es baja o modificacion

        public ListadoRoles(Form padre, string funcion)
        {
            InitializeComponent(); //instancia la clase
            this.padre = padre;
            this.funcion = funcion; //si es para baja o modificacion
            cargarGrilla();
            ocultarColumnas();
            cargarBotonFuncionalidad();
        }

        public void cargarGrilla()
        {
            AsistenteVistas.cargarGrilla(grillaRoles, AppRol.traerDataTableRoles(nombreBox.Text));
        }

        private void ocultarColumnas() //oculto las columnas que no son de interes
        {
        }

        private void cargarBotonFuncionalidad() //esto cargaria el boton en la grilla
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Seleccionar Rol";
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaRoles.Columns.Add(col);
        }

        private bool estaDadoDeBaja(DataGridViewRow fila)
        {
            int index = grillaRoles.Columns["Habilitado"].Index;
            return !(bool)fila.Cells[index].Value;
        }


        private Rol crearRol(int fila)
        {
            Rol rol = new Rol();
            int index = grillaRoles.Columns["ID Rol"].Index;
            rol.id = Convert.ToInt32(grillaRoles.Rows.SharedRow(fila).Cells[index].Value.ToString());
            return rol;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreBox.Text = "";
        }

        private void grillaRoles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grillaRoles.Columns["Seleccionar"].Index && e.RowIndex >= 0) //Para que la accion de click sea valida solo sobre el boton
            {
                DataGridViewRow fila = grillaRoles.Rows[e.RowIndex];
                if (!estaDadoDeBaja(fila))
                {
                    Rol rol = crearRol(e.RowIndex); //instancia un afiliado y luego depende de la funcionalidad, abrirá otra ventana
                    if (funcion == "Baja") AsistenteVistas.mostrarNuevaVentana(new Baja_Rol(this, rol), this);
                    if (funcion == "Modificar") AsistenteVistas.mostrarNuevaVentana(new Modificar_Rol2(this, rol), this);
                }
                else MessageBox.Show("El Rol seleccionado se encuentra inhabilitado");
            }
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }



    }
}
