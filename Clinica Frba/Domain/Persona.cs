using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    public abstract class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public char sexo { get; set; }
        public string tipoDoc { get; set; }
        public int nroDoc { get; set; }
        public string direccion { get; set; }
        public long telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNac { get; set; }
    }
}
