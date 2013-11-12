using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Abm_de_Afiliado;
using Clinica_Frba.AppModel;
using Clinica_Frba.AppModel.Excepciones;

namespace Clinica_Frba.AppModel
{
    class ErrorManager
    {
        public static void fatalError(Form padre, Form form, Exception ex)
        {
            MessageBox.Show("Ha ocurrido un error, por favor reintente mas tarde. \n Detalle: \n" + ex.Message.ToString());
            AsistenteVistas.volverAPadreYCerrar(padre, form);
            form.Close();
        }

        public static void messageErrorBox(UserDefinedException ex ,string nombreVentana)
        {
            MessageBox.Show(ex.mensaje, nombreVentana, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void messageWarningBox(UserDefinedException ex, string nombreVentana)
        {
            MessageBox.Show(ex.mensaje, nombreVentana, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
