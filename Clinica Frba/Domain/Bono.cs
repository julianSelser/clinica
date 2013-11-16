using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    public abstract class Bono
    {
        public int numero { get; set; }
        public DateTime fechaImpresion { get; set; }
        public int nroAfiliado { get; set; }
        public int CodPlan { get; set; }
        public int idCompra { get; set; }
        public int nroUsuario { get; set; }
    }
}
