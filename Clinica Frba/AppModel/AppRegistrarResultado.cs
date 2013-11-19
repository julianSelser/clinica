using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;
using System.Data;

namespace Clinica_Frba.AppModel
{
    internal class AppRegistrarResultado : ConectorSQL
    {
        public static DataTable traerConsultas(Afiliado afiliado, Profesional profesional, DateTime fechaAtencion)
        {
            return traerDataTable("getConsultasMedicas", afiliado.nroAfiliado, profesional.id, fechaAtencion);
        }

        internal static void registrarResultado(ConsultaMedica consulta)
        {
            ejecutarProcedure("registrarResultadoAtencion", consulta.idTurno, consulta.sintomas, consulta.enfermedades);
        }
    }
}
