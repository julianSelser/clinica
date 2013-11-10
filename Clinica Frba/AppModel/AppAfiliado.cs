using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;
using System.Data;
using Clinica_Frba.AppModel.Excepciones;

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

        public static void actualizarAfiliado(Afiliado afiliado)
        {
            ejecutarProcedure("updateAfiliado", afiliado.nroAfiliado, afiliado.direccion, afiliado.telefono, afiliado.mail, afiliado.codPlan, afiliado.estadoCivil, afiliado.cantFamiliaresACargo);
        }

        public static int buscarNroAfiliado(Afiliado afiliado)
        {
            return ejecutarProcedureWithReturnValue("buscarNroAfiliado",afiliado.nombre, afiliado.apellido, afiliado.tipoDoc, afiliado.nroDoc);
        }

        public static DataTable getAfiliados(string nombre, string apellido, string tipoDoc,int nroDoc ,string nroRaiz)
        {
            int nroAfiliadoRaiz = 0;
            int numeroDoc = 0;
            if (numeroDoc != 0) numeroDoc = nroDoc;
            if (nroRaiz != "") nroAfiliadoRaiz = Convert.ToInt32(nroRaiz);
            return traerDataTable("getAfiliados", nombre, apellido, tipoDoc, numeroDoc ,nroAfiliadoRaiz);
        }

        internal static void existeAfiliado(Afiliado afiliado)
        {
            if(checkIfExists("getAfiliados",afiliado.nombre, afiliado.apellido, afiliado.tipoDoc, afiliado.nroDoc, 0)) throw new AfiliadoYaExisteException(afiliado);
        }
    }
}
