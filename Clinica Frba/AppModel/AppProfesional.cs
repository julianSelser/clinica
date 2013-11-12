using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Clinica_Frba.Domain;
using Clinica_Frba.AppModel.Excepciones;

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

        internal static List<EspecialidadMedica> getEspecialidades()
        {
            DataTable table = traerDataTable("getEspecialidades");
            return crearListaEspecialidades(table);
        }

        private static List<EspecialidadMedica> crearListaEspecialidades(DataTable table)
        {
            DataRowCollection rows = table.Rows;
            List<EspecialidadMedica> especialidades = new List<EspecialidadMedica>();
            foreach (DataRow row in rows)
            {
                EspecialidadMedica especialidad = crearEspecialidad(row);
                especialidades.Add(especialidad);
            }
            return especialidades;
        }

        private static EspecialidadMedica crearEspecialidad(DataRow row)
        {
            int cod = Convert.ToInt32(row["Codigo"].ToString());
            string descripcion = row["Descripcion"].ToString();
            int tipoCodigo = Convert.ToInt32(row["Tipo Codigo"].ToString());
            EspecialidadMedica especialidad = new EspecialidadMedica();
            especialidad.codigo = cod;
            especialidad.descripcion = descripcion;
            especialidad.tipoEspecilidadCodigo = tipoCodigo;
            return especialidad;
        }

        internal static void darAltaProfesional(Profesional profesional, List<EspecialidadMedica> especialidades)
        {
            profesional.id = darAltaMedico(profesional);
            darAltaEspecialidadesDeMedico(profesional, especialidades);
        }

        private static int darAltaMedico(Profesional profesional)
        {
            if (buscarMedico(profesional)>0) throw new MedicoYaExisteException(profesional);
            ejecutarProcedure("altaMedico", profesional.nombre, profesional.apellido, profesional.sexo, profesional.tipoDoc, profesional.nroDoc, profesional.direccion, profesional.telefono, profesional.mail, profesional.fechaNac, profesional.nroMatricula);
            return buscarMedico(profesional);
        }

        private static int buscarMedico(Profesional profesional)
        {
            return ejecutarProcedureWithReturnValue("getIdMedico", profesional.nombre, profesional.apellido, profesional.tipoDoc, profesional.nroDoc);
        }

        private static void darAltaEspecialidadesDeMedico(Profesional profesional, List<EspecialidadMedica> especialidades)
        {
            foreach (EspecialidadMedica especialidad in especialidades)
            {
                ejecutarProcedure("altaMedico_Especialidad", especialidad.codigo, profesional.id);
            }
        }
    }
}
