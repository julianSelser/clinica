using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;
using System.Data;

namespace Clinica_Frba.AppModel
{
    class AppAfiliado : ConectorSQL
    {
        public static void darBajaAfiliado(int nroAfiliado)
        {
            ejecutarProcedure("darBajaAfiliado", nroAfiliado, Globales.getFechaSistema());
        }

        public static void altaAfiliadoTitular(Afiliado afiliado)
        {
            ejecutarProcedure("darAltaAfiliado", afiliado.nombre, afiliado.apellido, afiliado.sexo, afiliado.tipoDoc, afiliado.nroDoc, afiliado.direccion, afiliado.mail, afiliado.telefono, afiliado.fechaNac, afiliado.codPlan,afiliado.estadoCivil, afiliado.cantFamiliaresACargo, 'T', afiliado.nroAfiliado);
        }
        public static void altaAfiliadoConyuge(Afiliado afiliado)
        {
            ejecutarProcedure("darAltaAfiliado", afiliado.nombre, afiliado.apellido, afiliado.sexo, afiliado.tipoDoc, afiliado.nroDoc, afiliado.direccion, afiliado.mail, afiliado.telefono, afiliado.fechaNac, afiliado.codPlan, afiliado.estadoCivil, afiliado.cantFamiliaresACargo, 'C', afiliado.nroAfiliado);
        }
        public static void altaAfiliadoFamiliar(Afiliado afiliado)
        {
            ejecutarProcedure("darAltaAfiliado", afiliado.nombre, afiliado.apellido, afiliado.sexo, afiliado.tipoDoc, afiliado.nroDoc, afiliado.direccion, afiliado.mail, afiliado.telefono, afiliado.fechaNac, afiliado.codPlan, afiliado.estadoCivil, afiliado.cantFamiliaresACargo, 'F', afiliado.nroAfiliado);
        }

        public static int buscarNroAfiliado(Afiliado afiliado)
        {
            return ejecutarProcedureWithReturnValue("buscarNroAfiliado",afiliado.nombre, afiliado.apellido, afiliado.tipoDoc, afiliado.nroDoc);
        }

        public static DataTable getAfiliados(string nombre, string apellido, string nroRaiz)
        {
            int nro = 0;
            if (nroRaiz != "") { nro = Convert.ToInt32(nroRaiz); }
            return traerDataTable("getAfiliados", nombre, apellido, nro);
        }
    }
}
