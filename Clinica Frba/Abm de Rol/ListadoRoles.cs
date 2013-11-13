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
    public partial class ListadoRoles : Form, IListado //esta bien este listado aca?
    {
        public Form padre;
        public string funcion; //para saber si es baja o modificacion

        public ListadoRoles(Form padre, string funcion)
        {
            InitializeComponent(); //instancia la clase
            this.padre = padre;
            this.funcion = funcion;
        }


        private bool estaDadoDeBaja(DataGridViewRow fila)
        {
            int index = grillaProfesionales.Columns["Habilitado"].Index;
            return !(bool)fila.Cells[index].Value;
        }
/*
        private void grillaProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                else MessageBox.Show("El Rol seleccionado se encuentra inhabilitado");
            }
        }
    */
    
    }
}
