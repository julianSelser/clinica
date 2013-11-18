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
        /*
        private static void habilitarRol(int idRol)
        {
            ejecutarProcedure("habilitarRol", idRol);
        }
        */
        public static void inhabilitarRol(Rol rol) //para dar de baja
        {
            ejecutarProcedure("inhabilitarRol", rol.id);
        }

  
        //MODIFICAR_ROL_1 YA NO VA A ESTAR MAS (en cambio va a haber un listado)
        /*      private static void modificarRol1(int idRol) //carga una vista con los datos apartir de un id, en este caso el nombre y las funcionalidades
        {
            List<String> listaDeFuncionalidades;

            listaDeFuncionalidades = getFuncionalidadesRol(idRol);

            DataTable tablaNombre = traerDataTable("getNombreRol", idRol);
            DataRowCollection rowNombre = tablaNombre.Rows;

            foreach (DataRow dr in rowNombre) //lo hago por mas que la lista tenga un solo valor
            {
                String nombre = dr["NombreRol"].ToString();
            }
        }*/

        private static void modificarRol2(string nombre) //modifica los datos
        {
            //va a setear el nuevo nombre
            //va a hacer un delet de todas las anteriores funcionalidades de ese id
            //va a hacer un insert de todas las nuevas funcionalidades
        }

/*        private static List<String> getFuncionalidadesRol(int idRol) //modifica los datos
        {
            List<String> nombresFuncionalidades = new List<String>();

            DataTable listaF = traerDataTable("getFuncionalidadesRol", idRol);

            DataRowCollection rowFuncionalidad = listaF.Rows; //hace una lista de filas atravez de la tabla

            foreach (DataRow dr in rowFuncionalidad) //para cada elemento de la lista
            {
                String nombre = dr["Descripcion"].ToString(); //seteo el cambo descripcion de esa fila
                nombresFuncionalidades.Add(nombre);
            }
            //hasta aca mete los nombres de la tabla de funcionalidades en una lista

            return nombresFuncionalidades;
        
        }*/

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

    }
}
