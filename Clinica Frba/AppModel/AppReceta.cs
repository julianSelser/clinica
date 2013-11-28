using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;
using System.Data;

//Clase que tiene por objetivo servir de interfaz entre la base de datos y las funcionalidades de Generar Receta.

namespace Clinica_Frba.AppModel
{
    class AppReceta : ConectorSQL
    {
        internal static DataTable traerBonosFarmacia(Afiliado afiliado)
        {
            return traerDataTable("getBonosFarmacia", afiliado.nroAfiliado, Globales.getFechaSistema());
        }

        internal static DataTable traerMedicamentos(Medicamento medicamento)
        {
            return traerDataTable("traerMedicamentos", medicamento.nroMedicamento, medicamento.descripcion);
        }

        internal static void registrarReceta(Afiliado afiliado, ConsultaMedica consulta, BonoFarmacia bono, List<Medicamento> medicamentosDeLaReceta)
        {
            foreach(Medicamento medicamento in medicamentosDeLaReceta)
            {
                ejecutarProcedure("registrarReceta", afiliado.nroAfiliado, consulta.idConsulta, bono.numero, medicamento.nroMedicamento, medicamento.cantidad, Globales.getFechaSistema());
            }
        }
    }
}
