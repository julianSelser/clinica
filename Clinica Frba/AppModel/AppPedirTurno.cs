using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Clinica_Frba.Domain;
using Clinica_Frba.AppModel.Excepciones;

//Clase que tiene por objetivo servir de interfaz entre la base de datos y las funcionalidades de Pedir Turno.
//Por ejemplo, traer las fechas disponibles de un profesional, los horarios de dicha fecha disponibles, 
//crear listados de los mismos, entre otras cosas, generar un turno, entre otras cosas.

namespace Clinica_Frba.AppModel
{
    class AppPedirTurno : ConectorSQL
    {

        internal static List<DateTime> traerFechasAgenda(Profesional profesional)
        {
            if (!checkIfExists("getFechasDisponiblesAgenda", profesional.id, Globales.getFechaSistema())) throw new NoHayHorarioDisponiblesException();
            return crearListadoFechas(traerDataTable("getFechasDisponiblesAgenda", profesional.id, Globales.getFechaSistema()));
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

        internal static List<DateTime> traerTimeslotsFecha(Profesional profesional, DateTime fechaAgenda)
        {
            return crearListadoTimeslots(traerDataTable("getTimeslotsFecha", profesional.id, fechaAgenda, Globales.getFechaSistema()));
        }

        private static List<DateTime> crearListadoTimeslots(DataTable table)
        {
            DataRowCollection rows = table.Rows;
            List<DateTime> horarios = new List<DateTime>();
            foreach (DataRow row in rows)
            {
                DateTime horario = crearHorario(row);
                horarios.Add(horario);
            }
            return horarios;
        }

        private static DateTime crearHorario(DataRow row)
        {
            return Convert.ToDateTime(row["Horarios Disponibles"].ToString());
        }

        internal static void generarTurno(Afiliado afiliado, Profesional profesional, EspecialidadMedica especialidadTurno, DateTime timeslot)
        {
            if(checkIfExists("getTurnoAfiliado", afiliado.nroAfiliado, timeslot)) throw new AfiliadoYaTieneTurnoException();
            ejecutarProcedure("generarTurno", afiliado.nroAfiliado, profesional.id, especialidadTurno.codigo, timeslot);
        }
    }
}
