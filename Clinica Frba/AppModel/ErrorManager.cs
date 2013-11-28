using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Abm_de_Afiliado;
using Clinica_Frba.AppModel;
using Clinica_Frba.AppModel.Excepciones;

//Clase que sirve de manejo de errores para mostrar ventanas de tipo dialog con mensajes informativos cuando se provoca una excepcion

namespace Clinica_Frba.AppModel
{
    class ErrorManager
    {
        public static void fatalError(Form padre, Form form, Exception ex) //muestra una ventana con mensaje de error fatal, cierra la ventana actual y vuelve a la ventana padre
        {
            MessageBox.Show("Ha ocurrido un error, por favor reintente mas tarde. \n Detalle: \n" + ex.Message.ToString(), "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            AsistenteVistas.volverAPadreYCerrar(padre, form);
            form.Close();
        }

        public static void messageErrorBox(UserDefinedException ex ,string nombreVentana) //muestra una ventana con icono de error
        {
            MessageBox.Show(ex.mensaje, nombreVentana, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void messageWarningBox(UserDefinedException ex, string nombreVentana) //muestra una ventana con icono de advertencia
        {
            MessageBox.Show(ex.mensaje, nombreVentana, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
