using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Globalization;

//Clase con acceso a las configuraciones del App.config para traer la fecha del sistema.
//Todos los componentes de la aplicacion tienen acceso a esta clase y poder obtener la fecha.

namespace Clinica_Frba.AppModel
{
    class Globales
    {
        public static DateTime getFechaSistema()
        {
            DateTimeFormatInfo esp = new CultureInfo("es-ES", true).DateTimeFormat;
            return Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaSistema"], esp);
        }
    }
}
