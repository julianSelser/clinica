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
    }
}
