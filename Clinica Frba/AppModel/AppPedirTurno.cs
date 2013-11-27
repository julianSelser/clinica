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

        internal static DataTable traerFechasAgenda(Profesional profesional)
        {
            return crearListadoFechas(traerDataTable("getFechasDisponiblesAgenda", profesional.id));
        }

        private static DataTable crearListadoFechas(DataTable dataTable)
        {
            throw new NotImplementedException();
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
