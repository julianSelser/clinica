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
    //Clase que hace de interfaz de cada componente del ABM profesional con sus respectivos procedures.
    //Tambien crea listados de especialidades medicas y valida existencias de datos duplicados.
    class AppProfesional : ConectorSQL
    {

        public static List<EspecialidadMedica> getEspecialidadesMedico(Profesional profesional)
        {
            DataTable table = traerDataTable("getEspecialidadesMedico", profesional.id);
            DataRowCollection rows = table.Rows;
            List<EspecialidadMedica> especialidades = new List<EspecialidadMedica>();
            int codigo;
            foreach (DataRow row in rows)
            {
                EspecialidadMedica especialidad = new EspecialidadMedica();
                codigo = Convert.ToInt32(row["Cod_Especialidad"].ToString());
                especialidad.codigo = codigo;
                especialidades.Add(especialidad);
            }
            return especialidades;
        }
      
        public static DataTable traerDataTableMedicos(string nombre, string apellido, int matricula, int especialidad)
        {
            return traerDataTable("getMedicos", nombre, apellido, matricula, especialidad);
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
            if (existeMatricula(profesional)) throw new MatriculaDuplicadaException(profesional);
            ejecutarProcedure("altaMedico", profesional.nombre, profesional.apellido, profesional.sexo, profesional.tipoDoc, profesional.nroDoc, profesional.direccion, profesional.telefono, profesional.mail, profesional.fechaNac, profesional.nroMatricula);
            return buscarMedico(profesional);
        }

        private static bool existeMatricula(Profesional profesional)
        {
            return checkIfExists("existeMatricula", profesional.nroMatricula);
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

        public static void darBajaProfesional(Profesional profesional)
        {
            ejecutarProcedure("bajaMedico", profesional.id);
        }

        internal static void updateProfesional(Profesional profesional, List<EspecialidadMedica> listaEspecialidadesNuevas)
        {
            updateMedico(profesional);
            deleteEspecialidades(profesional);
            darAltaEspecialidadesDeMedico(profesional, listaEspecialidadesNuevas);
        }

        private static void deleteEspecialidades(Profesional profesional)
        {
            ejecutarProcedure("deleteEspecialidades", profesional.id);
        }

        private static void updateMedico(Profesional profesional)
        {
            ejecutarProcedure("updateMedico", profesional.id, profesional.direccion, profesional.telefono, profesional.mail);
        }
    }
}
