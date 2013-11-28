using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Asistente que agrupa la logica de volver a la ventana anterior, inicializar una nueva o cargar una grilla

namespace Clinica_Frba.AppModel
{
    class AsistenteVistas
    {
        public static void volverAPadreYCerrar(Form ventanaPadre, Form ventana)
        {
            ventanaPadre.Visible = true;
            ventanaPadre.Activate();
            ventanaPadre.Select();
            ventana.Close();
        }
        public static void mostrarNuevaVentana(Form ventanaNueva, Form ventanaPadre)
        {
            ventanaNueva.Visible = true;
            ventanaNueva.Activate();
            ventanaNueva.Select();
            ventanaPadre.Hide();
        }

        public static void cargarGrilla(DataGridView grid, System.Data.DataTable dataTable)
        {
            grid.DataSource = dataTable; 
            grid.AutoResizeColumns(); //ajusta el tamaño de las columnas y filas a su contenido
            grid.AutoResizeRows();
        }
    }
}
