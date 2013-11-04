using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Clinica_Frba.Domain;

namespace Clinica_Frba.AppModel
{
    class AppRol : ConectorSQL
    {
        private static void habilitarRol(int idRol)
        {
            ejecutarProcedure("habilitarRol", idRol);
        }

        private static void inhabilitarRol(int idRol)
        {
            ejecutarProcedure("inhabilitarRol", idRol);
        }

        private static void modificarRol1(int idRol) //carga una vista con los datos apartir de un id, en este caso el nombre y las funcionalidades
        {
            List<String> listaDeFuncionalidades;

            listaDeFuncionalidades = getFuncionalidadesRol(idRol);

            DataTable tablaNombre = traerDataTable("getNombreRol", idRol);
            DataRowCollection rowNombre = tablaNombre.Rows;

            foreach (DataRow dr in rowNombre) //lo hago por mas que la lista tenga un solo valor
            {
                String nombre = dr["NombreRol"].ToString();
            }
        }

        private static void modificarRol2(string nombre) //modifica los datos
        {
            //va a setear el nuevo nombre
            //va a hacer un delet de todas las anteriores funcionalidades de ese id
            //va a hacer un insert de todas las nuevas funcionalidades
        }

        private static List<String> getFuncionalidadesRol(int idRol) //modifica los datos
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
        }
    }
}
