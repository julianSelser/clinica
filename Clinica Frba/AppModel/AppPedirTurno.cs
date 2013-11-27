using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Clinica_Frba.Domain;

namespace Clinica_Frba.AppModel
{
    class AppPedirTurno : ConectorSQL
    {

        internal static List<DateTime> traerFechasAgenda(Profesional profesional)
        {
            return crearListadoFechas(traerDataTable("getFechasDisponiblesAgenda", profesional.id));
        }

        private static List<DateTime> crearListadoFechas(DataTable table)
        {
            DataRowCollection rows = table.Rows;
            List<DateTime> fechas = new List<DateTime>();
            foreach (DataRow row in rows)
            {
                DateTime fecha = crearFecha(row);
                fechas.Add(fecha);
            }
            return fechas;
        }

        private static DateTime crearFecha(DataRow row)
        {
           return Convert.ToDateTime(row["Fechas Disponibles"].ToString());
        }

        internal static DataTable traerTimeslotsFecha(Profesional profesional, DateTime fechaAgenda)
        {
            return crearListadoTimeslots(traerDataTable("getTimeslotsFecha", profesional.id, fechaAgenda));
        }

        private static DataTable crearListadoTimeslots(DataTable dataTable)
        {
            throw new NotImplementedException();
        }
    }
}
