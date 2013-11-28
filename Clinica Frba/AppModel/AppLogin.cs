using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using Clinica_Frba.Domain;
using System.Security.Cryptography;
using System.Windows.Forms;

// clase que trabaja con login y accede a la base de datos para recuperar, del usuario logeado:
// - las funcionalidades
// - los roles
// - la persona asociada
// - si se pudo logear y estado de habilitacion de la cuenta
namespace Clinica_Frba.AppModel
{
    class AppLogin
    {
        public static int intentarLogear(string username, string password) 
        {
            byte[] passEncriptada = new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));

            return ConectorSQL.ejecutarProcedureWithReturnValue("intentarLogear", username, passEncriptada);
        }

        public static List<Rol> traerRoles() 
        {
            DataTable rolesDT = ConectorSQL.traerDataTable("traerRolesDeUsuario", UsuarioLogeado.Instance.UserName);

            List<Rol> roles = new List<Rol>();

            //por cada rol traido de la base, se lo asigna a los roles a devolver en formato de objetos
            foreach (DataRow rowR in rolesDT.Rows) 
            {
                Rol rol = new Rol( Convert.ToInt32((decimal)rowR["id_rol"]), (string)rowR["Nombre"], (bool)rowR["Habilitado"]);
                
                roles.Add(rol);
            }

            return roles; 
        }

        public static List<Funcionalidad> traerFuncionalidades() 
        {
            DataTable funcionalidadesDT = ConectorSQL.traerDataTable("traerFuncionalidadesDeRol", UsuarioLogeado.Instance.Rol.id);

            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            //por cada funcion traida, se la adhiere a las funcionalidades a devolver
            foreach (DataRow rowF in funcionalidadesDT.Rows)
            {
                var funcionalidad = new Funcionalidad(Convert.ToInt32((decimal)rowF["id_funcionalidad"]), (string)rowF["descripcion"]);

                funcionalidades.Add(funcionalidad);
            }

            return funcionalidades;
        }

        public static void cargarUsuario()
        {
            string rol = UsuarioLogeado.Instance.Rol.nombre;

            UsuarioLogeado.Instance.Persona = null;

            if (rol == "Profesional" || rol == "Afiliado") // si fuera cualquier otro rol, no hay usuario que traer
            {
                // se trae los datos de la persona y se lo asigna al usuario logeado
                DataTable datosUsuario = ConectorSQL.traerDataTable("traerDatosUsuario", UsuarioLogeado.Instance.UserName, UsuarioLogeado.Instance.Rol.nombre);

                DataRow d = datosUsuario.Rows[0];

                if (rol == "Profesional")
                {
                    UsuarioLogeado.Instance.Persona = new Profesional(Convert.ToInt32((decimal)d["id_medico"]), (string)d["nombre"], (string)d["apellido"]
                                                                      , '-', (string)d["tipo_doc"], Convert.ToInt32((decimal)d["nro_doc"])
                                                                      , (string)d["direccion"], Convert.ToInt32((decimal)d["telefono"]), (string)d["mail"]
                                                                      , (DateTime)d["fecha_nac"], Convert.ToInt32((decimal)d["nro_matricula"])
                                                                      ,(bool)d["habilitado"]);


                }
                else if (rol == "Afiliado")
                {
                    UsuarioLogeado.Instance.Persona = new Afiliado(Convert.ToInt32(d["Nro_Afiliado"]), (string)d["Nombre"], (string)d["Apellido"]
                                                                  , '-', (string)d["Tipo_Doc"], Convert.ToInt32(d["Nro_Doc"]), (string)d["Direccion"]
                                                                  , (string)d["Mail"], Convert.ToInt32(d["Telefono"]), (DateTime)d["Fecha_Nac"], Convert.ToInt32(d["Cod_Plan"])
                                                                  , (string)d["Estado_Civil"], (d["Nro_Titular"].GetType()!=typeof(DBNull))?Convert.ToInt32(d["Nro_Titular"]):0, (d["Nro_Conyuge"].GetType()!=typeof(DBNull))?Convert.ToInt32(d["Nro_Conyuge"]):0
                                                                  , (d["Fecha_Baja"].GetType()!=typeof(DBNull))?(DateTime)d["Fecha_Baja"]:DateTime.Now, Convert.ToInt32(d["Nro_Consulta"]), Convert.ToInt32(d["CantFamiliaresACargo"]));
                }
            }
        }
    }
}