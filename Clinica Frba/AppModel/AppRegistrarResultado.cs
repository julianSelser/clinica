using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;
using System.Data;

//Clase que tiene por objetivo servir de interfaz entre la base de datos y las funcionalidades de Registrar Resultado de Atencion.

namespace Clinica_Frba.AppModel
{
    internal class AppRegistrarResultado : ConectorSQL
    {
        public static DataTable traerConsultas(Afiliado afiliado, Profesional profesional, DateTime fechaAtencion, bool sinResultado)
        {
            return traerDataTable("getConsultasMedicas", afiliado.nroAfiliado, profesional.id, fechaAtencion, sinResultado, false);
        }

        internal static void registrarResultado(ConsultaMedica consulta)
        {
            ejecutarProcedure("updateConsultaMedica", consulta.idConsulta, consulta.sintomas, consulta.enfermedades);
        }

        internal static DataTable traerConsultasConResultados(Afiliado afiliado, Profesional profesional, DateTime fechaAtencion)
        {
            return traerDataTable("getConsultasMedicas", afiliado.nroAfiliado, profesional.id, fechaAtencion, false, true);
        }
    }
}
