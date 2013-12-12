using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;
using System.Data;
using Clinica_Frba.AppModel.Excepciones;

//Clase que tiene por objetivo servir de interfaz entre la base de datos y las funcionalidades de ABM afiliado.
//Permite hacer consultas como cuantos familiares tiene registrado un familiar titular, 
//buscar el nro de un afiliado, verificar la existencia de un afiliado duplicado,
//crear listados de planes medicos, registrar cambios de planes, entre otras cosas.

namespace Clinica_Frba.AppModel
{
    class AppAfiliado : ConectorSQL
    {
        public static void darBajaAfiliado(int nroAfiliado)
        {
            ejecutarProcedure("darBajaAfiliado", nroAfiliado, Globales.getFechaSistema());
        }

        public static int cantidadFamiliaresACargoRegistrados(Afiliado afiliado)
        {
            return ejecutarProcedureWithReturnValue("cantFamiliaresRegistrados", afiliado.nroAfiliado);
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
            if (cantidadFamiliaresACargoRegistrados(afiliado) > afiliado.cantFamiliaresACargo) throw new DecrementarCantFamiliaresException(); 
            ejecutarProcedure("updateAfiliado", afiliado.nroAfiliado, afiliado.direccion, afiliado.telefono, afiliado.mail, afiliado.codPlan, afiliado.estadoCivil, afiliado.cantFamiliaresACargo);
        }

        public static int buscarNroAfiliado(Afiliado afiliado)
        {
            return ejecutarProcedureWithReturnValue("buscarNroAfiliado",afiliado.nombre, afiliado.apellido, afiliado.tipoDoc, afiliado.nroDoc);
        }

        public static DataTable getAfiliados(string nombre, string apellido, string tipoDoc,int nroDoc ,string nroRaiz)
        {
            long nroAfiliadoRaiz = 0;
            int numeroDoc = 0;
            if (numeroDoc != 0) numeroDoc = nroDoc;
            if (nroRaiz != "")
            {
                nroAfiliadoRaiz = Convert.ToInt64(nroRaiz);
                nroAfiliadoRaiz = (nroAfiliadoRaiz - (nroAfiliadoRaiz % 100));
            }
            return traerDataTable("getAfiliados", nombre, apellido, tipoDoc, numeroDoc ,nroAfiliadoRaiz);
        }

        internal static void existeAfiliado(Afiliado afiliado)
        {
            if(checkIfExists("getAfiliados",afiliado.nombre, afiliado.apellido, afiliado.tipoDoc, afiliado.nroDoc, 0)) throw new AfiliadoYaExisteException(afiliado);
        }

        internal static List<PlanMedico> traerPlanesMedicos()
        {
            DataTable table = traerDataTable("getPlanesMedicos",0,"",0,0);
            return crearListaPlanesMedicos(table);
        }

        private static List<PlanMedico> crearListaPlanesMedicos(DataTable table)
        {
            DataRowCollection rows = table.Rows;
            List<PlanMedico> planes = new List<PlanMedico>();
            foreach (DataRow row in rows)
            {
                PlanMedico plan = crearPlan(row);
                planes.Add(plan);
            }
            return planes;
        }

        private static PlanMedico crearPlan(DataRow row)
        {
            int cod = Convert.ToInt32(row["Codigo"].ToString());
            string descripcion = row["Descripcion"].ToString();
            int precioConsulta = Convert.ToInt32(row["Precio Bono Consulta"].ToString());
            int precioFarmacia = Convert.ToInt32(row["Precio Bono Farmacia"].ToString());
            PlanMedico plan = new PlanMedico();
            plan.codigo = cod;
            plan.descripcion = descripcion;
            plan.precioBonoConsulta = precioConsulta;
            plan.precioBonoFarmacia = precioFarmacia;
            return plan;
        }

        internal static bool tieneConyuge(Afiliado afiliado)
        {
            return checkIfExists("getConyuge",afiliado.nroAfiliado);
        }

        internal static void registrarCambioPlanMedico(Afiliado afiliado, int planMedicoOrigen, string motivo)
        {
            ejecutarProcedure("registrarCambioPlanMedico", afiliado.nroAfiliado, Globales.getFechaSistema(), planMedicoOrigen, afiliado.codPlan, motivo);
        }
    }
}
