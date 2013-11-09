using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;


namespace Clinica_Frba.AppModel
{
    class Globales
    {
        public static DateTime getFechaSistema()
        {
            return Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaSistema"]);
        }
    }
}
