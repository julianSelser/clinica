using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Frba.Helpers
{
    class FormHelper
    {
        public static void volverAPadre(Form ventanaPadre)
        {
            ventanaPadre.Visible = true;
            ventanaPadre.Activate();
            ventanaPadre.Select();
        }
        public static void mostrarNuevaVentana(Form ventanaNueva, Form ventanaPadre)
        {
            ventanaNueva.Visible = true;
            ventanaNueva.Activate();
            ventanaNueva.Select();
            ventanaPadre.Hide();
        }

        public static DataGridView cargarGrid(DataGridView grid, System.Data.DataTable dataTable)
        {
            grid.DataSource = dataTable;
            grid.AutoResizeColumns();
            grid.AutoResizeRows();

            return grid;
        }
    }
}
