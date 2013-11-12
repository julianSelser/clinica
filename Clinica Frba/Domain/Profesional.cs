using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    class Profesional
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public char sexo { get; set; }
        public string tipoDoc { get; set; }
        public int nroDoc { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNac { get; set; }
        public int nroMatricula { get; set; }
        public DateTime fechaAtencionHasta { get; set; }
        public DateTime fechaAtencionDesde { get; set; }
        public bool habilitado { get; set; }
    }
}
