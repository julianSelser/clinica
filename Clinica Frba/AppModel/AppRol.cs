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
    class AppRol : ConectorSQL
    {

        public static void inhabilitarRol(Rol rol) //para dar de baja
        {
            ejecutarProcedure("inhabilitarRol", rol.id);
        }

        public static void habilitarRol(Rol rol) //para dar de baja
        {
            ejecutarProcedure("habilitarRol", rol.id);
        }

        internal static void updateRol(Rol rol, List<Funcionalidad> listaFuncionalidadesNuevas)
        {
            updateNombreRol(rol);
            deleteFuncionalidades(rol);
            darAltaFuncionalidadesDeRol(rol, listaFuncionalidadesNuevas);
        }

        private static void deleteFuncionalidades(Rol rol)
        {
            ejecutarProcedure("sacarTodaFuncionalidadARol", rol.id);
        }

        public static DataTable getDataTableRolesPorId(int idRol)
        {
            DataTable tablaNombre = traerDataTable("getNombreRol", idRol);
            return tablaNombre;
        }    

        //aca empiezo a trabajar con lo de joni ------------------------

        internal static List<Funcionalidad> getFuncionalidades()
        {
            DataTable table = traerDataTable("getFuncionalidades");
            return crearListaFuncionalidades(table);
        }


        private static List<Funcionalidad> crearListaFuncionalidades(DataTable table)
        {
            DataRowCollection rows = table.Rows;
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            foreach (DataRow row in rows)
            {
                Funcionalidad funcionalidad = crearFuncionalidad(row);
                funcionalidades.Add(funcionalidad);
            }
            return funcionalidades;
        }


        private static Funcionalidad crearFuncionalidad(DataRow row)
        {
            int cod = Convert.ToInt32(row["Id_Funcionalidad"].ToString());
            string descripcion = row["Descripcion"].ToString();
            Funcionalidad funcionalidad = new Funcionalidad();
            funcionalidad.id = cod;
            funcionalidad.descripcion = descripcion;
            return funcionalidad;
        }


        public static List<Funcionalidad> getFuncionalidadesRol(Rol rol)
        {
            DataTable table = traerDataTable("getFuncionalidadesRol", rol.id);
            DataRowCollection rows = table.Rows;
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            int id;
            foreach (DataRow row in rows)
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                id = Convert.ToInt32(row["Id_Funcionalidad"].ToString());
                funcionalidad.id = id;
                funcionalidades.Add(funcionalidad);
            }
            return funcionalidades;
        }


        public static DataTable traerDataTableRoles(string nombre)
        {
            return traerDataTable("getRoles", nombre); //traerme todos los roles
        }


        internal static void darAltaRol(Rol rol, List<Funcionalidad> funcionalidades)
        {
            rol.id = darAltaRol(rol);
            darAltaFuncionalidadesDeRol(rol, funcionalidades);
        }

        private static int darAltaRol(Rol rol)
        {
            if (buscarRol(rol) > 0) throw new RolYaExisteException(rol);
            ejecutarProcedure("altaRol", rol.nombre);
            return buscarRol(rol);
        }

        private static int buscarRol(Rol rol)
        {
            return ejecutarProcedureWithReturnValue("getIdRol", rol.nombre);
        }

        private static void darAltaFuncionalidadesDeRol(Rol rol, List<Funcionalidad> funcionalidades)
        {
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                ejecutarProcedure("altaRol_Funcionalidad", funcionalidad.id, rol.id);
            }
        }

        private static void updateNombreRol(Rol rol)
        {
            if (buscarRol(rol) > 0) throw new RolYaExisteException(rol);
            ejecutarProcedure("modificarRol", rol.id, rol.nombre);
        }
    }
}
