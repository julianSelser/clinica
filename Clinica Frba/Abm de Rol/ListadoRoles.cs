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

//Funcionalidad que muestra el listado de roles existentes y poder seleccionarlo para baja o modificacion

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class ListadoRoles : Form
    {
        public Form padre;
        PantallaPrincipal pantallaPrincipal; //necesita conocerla para manipular los botones
        public string funcion; //para saber si es baja o modificacion

        public ListadoRoles(Form padre, string funcion, PantallaPrincipal pantallaPrincipal)
        {
            InitializeComponent(); //instancia la clase
            this.pantallaPrincipal = pantallaPrincipal; 
            this.padre = padre;
            this.funcion = funcion; //si es para baja o modificacion
            cargarGrilla();
            cargarBotonFuncionalidad();
        }

        public void cargarGrilla()
        {
            AsistenteVistas.cargarGrilla(grillaRoles, AppRol.traerDataTableRoles(nombreBox.Text));
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

        private void ListadoRoles_Activated(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private Rol crearRol(int fila)
        {
            Rol rol = new Rol();
            int index = grillaRoles.Columns["ID Rol"].Index;
            rol.id = Convert.ToInt32(grillaRoles.Rows.SharedRow(fila).Cells[index].Value.ToString());
            index = grillaRoles.Columns["Nombre"].Index;
            rol.nombre = grillaRoles.Rows.SharedRow(fila).Cells[index].Value.ToString();
            index = grillaRoles.Columns["Habilitado"].Index;
            rol.habilitado = Convert.ToBoolean(grillaRoles.Rows.SharedRow(fila).Cells[index].Value.ToString());
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
            if (e.ColumnIndex == grillaRoles.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaRoles.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
            {
                DataGridViewRow fila = grillaRoles.Rows[e.RowIndex];

                    Rol rol = crearRol(e.RowIndex); //instancia un afiliado y luego depende de la funcionalidad, abrirá otra ventana
                    if (funcion == "Baja")
                    {
                        if (!estaDadoDeBaja(fila))
                        {
                            AsistenteVistas.mostrarNuevaVentana(new Baja_Rol(this, rol), this);
                        }
                        else 
                        {
                            MessageBox.Show("El Rol seleccionado ya se encuentra inhabilitado");
                        }
                    }
                    if (funcion == "Modificar") AsistenteVistas.mostrarNuevaVentana(new Modificar_Rol2(this, rol, pantallaPrincipal), this);
                    //en modificar no muestro la ventana de error si esta dado de baja, porque se puede volver a habilitar
            }
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }



    }
}
