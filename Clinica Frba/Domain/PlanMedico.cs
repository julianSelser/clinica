using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    public class PlanMedico
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public int precioBonoConsulta { get; set; }
        public int precioBonoFarmacia { get; set; }
    }
}
