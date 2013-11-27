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
            return traerDataTable("getFechasDisponiblesAgenda", profesional.id);
        }

        internal static DataTable traerTimeslotsFecha(Profesional profesional, DateTime fechaAgenda)
        {
            return traerDataTable("getTimeslotsFecha", profesional.id, fechaAgenda);
        }
    }
}
