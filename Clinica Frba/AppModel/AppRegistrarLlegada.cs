using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using Clinica_Frba.Domain;

//Clase que tiene por objetivo servir de interfaz entre la base de datos y las funcionalidades de Registrar Llegada.

namespace Clinica_Frba.AppModel
{
    internal class AppRegistrarLlegada : ConectorSQL
    {
        public static DataTable traerTurnosAfiliadoMedico(Afiliado afiliado, Profesional profesional)
        {
            return traerDataTable("getTurnosAfiliadoMedicoRegistroLlegada", afiliado.nroAfiliado, profesional.id, Globales.getFechaSistema());
        }

        internal static DataTable traerBonos(Turno turno)
        {
            return traerDataTable("getBonoConsultaRegistroLlegada", turno.nroAfiliado);
        }

        internal static void registrarLlegada(Turno turno, BonoConsulta bono)
        {
            ejecutarProcedure("registrarLlegada", bono.nroUsuario, bono.numero, turno.numero, turno.fecha, Globales.getFechaSistema());
        }
    }
}
