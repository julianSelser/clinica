using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    class ConsultaMedica
    {
        public int idConsulta { get; set; }
        public int nroTurno { get; set; }
        public string enfermedades { get; set; }
        public string sintomas { get; set; }
        public DateTime fechaTurno { get; set; }
        public DateTime fechaLlegada { get; set; }
    }
}
