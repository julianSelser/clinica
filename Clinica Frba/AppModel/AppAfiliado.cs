using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;

namespace Clinica_Frba.AppModel
{
    class AppAfiliado : ConectorSQL
    {
        public static void darBajaAfiliado(int nroAfiliado)
        {
            ejecutarProcedure("darBajaAfiliado", nroAfiliado);
        }

        public static void altaAfiliado(Afiliado afiliado)
        {
            ejecutarProcedure("darAltaAfiliado", afiliado.nombre, afiliado.apellido, afiliado.sexo, afiliado.tipoDoc, afiliado.nroDoc, afiliado.direccion, afiliado.mail, afiliado.telefono, afiliado.fechaNac, afiliado.codPlan,afiliado.estadoCivil, afiliado.cantFamiliaresACargo);
        }

        public static int buscarNroAfiliado(Afiliado afiliado)
        {
            return ejecutarProcedureWithReturnValue("buscarNroAfiliado",afiliado.nombre, afiliado.apellido, afiliado.tipoDoc, afiliado.nroDoc);
        }
    }
}
