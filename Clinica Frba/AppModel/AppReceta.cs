using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;
using System.Data;

namespace Clinica_Frba.AppModel
{
    class AppReceta : ConectorSQL
    {
        internal static DataTable traerBonosFarmacia(Afiliado afiliado)
        {
            return traerDataTable("getBonosFarmacia", afiliado.nroAfiliado, Globales.getFechaSistema());
        }
    }
}
