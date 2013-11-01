using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Clinica_Frba.Domain;

namespace Clinica_Frba.AppModel
{
    //esta va a ser la clase que le va a pegar a la BD
    class AppProfesional : ConectorSQL
    {
        public static Profesional traerUnMedico(string id)
        {
            Profesional medico;
            DataTable medicos = traerDataTableMedicos();
            if (medicos.Rows.Count > 0)
            {
                medicos.PrimaryKey = new DataColumn[] { medicos.Columns["ID Medico"] };
            }
            DataRow fila = medicos.Rows.Find(id);
            medico = new Profesional(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString(), fila[3].ToString(), fila[4].ToString(), Convert.ToInt32(fila[5]), fila[6].ToString(), Convert.ToInt32(fila[7]), fila[8].ToString(), Convert.ToDateTime(fila[9]), Convert.ToInt32(fila[10]), Convert.ToDateTime(fila[11]), Convert.ToDateTime(fila[12]), Convert.ToBoolean(fila[13])); ;
            return medico;
        }

        public static DataTable traerDataTableMedicos()
        {
            return ConectorSQL.traerDataTable("getMedicos");
        }
    }
}
