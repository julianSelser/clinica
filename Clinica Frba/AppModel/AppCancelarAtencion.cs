using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;

// clase que trabaja con la cancelacion de atencion y trae, es responsable de:
// - saber que turnos traer (de afiliado o medico) y traerlas
// - informar a la base de los turnos cancelados, tanto de un dia como de periodos
namespace Clinica_Frba.AppModel
{
    public class AppCancelarAtencion
    {
        //llama la tabla correspondiente segun el tipo de usuario que se elige
        public static DataTable traerTablaPedida(string nombreYapellido, string tipoUsr ,string nroDoc, string tipoDoc, DateTime? desde, DateTime? hasta) 
        {
            string nombre = Controlador.separarNombreYApellido(nombreYapellido)[0];
            string apellido = Controlador.separarNombreYApellido(nombreYapellido)[1];

            return (tipoUsr == "Profesional") ? traerDiasDeProfesional(nombre, apellido, Convert.ToInt32(nroDoc), tipoDoc, desde, hasta) : traerTurnosAfiliado(nombre, apellido, Convert.ToInt32(nroDoc), tipoDoc);
        }

        public static DataTable traerTurnosAfiliado(string nombre, string apellido, int nroDoc, string tipoDoc)
        {
            return ConectorSQL.traerDataTable("getTurnosDeAfiliado", nombre, apellido, nroDoc, tipoDoc);
        }

        public static DataTable traerDiasDeProfesional(string nombre, string apellido, int nroDoc, string tipoDoc, DateTime? desde, DateTime? hasta)
        {
            //todo este if es un workaround para que ande el conector...si le mando null interpreta que no hay arguementos
            if (desde == null || hasta == null)
            {
                return ConectorSQL.traerDataTable("getTurnosDeMedico", nombre, apellido, nroDoc, tipoDoc, "", "");
            }
            else
            {
                return ConectorSQL.traerDataTable("getTurnosDeMedico", nombre, apellido, nroDoc, tipoDoc, desde, hasta);
            }
        }

        public static void cancelarPeriodo(DataTable periodo, string motivo) 
        {
            ConectorSQL.ejecutarProcedure("cancelarPeriodo", periodo, motivo);
        }

        public static void cancelarAtencion(DataGridViewSelectedRowCollection seleccion, string motivo) 
        {
            DataGridViewRow row = seleccion[0];

            ConectorSQL.ejecutarProcedure("cancelarTurno", row.Cells["Numero"].Value, "No asistencia", motivo);
        }
    }
}
