using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    class Turno
    {
        public int numero { get; set; }
        public DateTime fecha { get; set; }
        public int nroAfiliado { get; set; }
        public int idMedico { get; set; }
        public int codEspecialidad { get; set; }
    }
}
