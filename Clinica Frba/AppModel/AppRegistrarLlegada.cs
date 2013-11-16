using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using Clinica_Frba.Domain;

namespace Clinica_Frba.AppModel
{
    internal class AppRegistrarLlegada : ConectorSQL
    {
        public static DataTable traerTurnosAfiliadoMedico(Afiliado afiliado, Profesional profesional)
        {
            return traerDataTable("getTurnosAfiliadoMedicoRegistroLlegada", afiliado.nroAfiliado, profesional.id, Globales.getFechaSistema());
        }
    }
}
