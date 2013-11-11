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
            medico = new Profesional(); ;
            return medico;
        }

        public static DataTable traerDataTableMedicos()
        {
            return ConectorSQL.traerDataTable("getMedicos");
        }
    }
}
