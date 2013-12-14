using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.AppModel.Excepciones
{
    class AfiliadoYaTieneTurnoException : UserDefinedException
    {
        public AfiliadoYaTieneTurnoException()
        {
            this.mensaje = "ERROR: El afiliado ya tiene un turno asignado para este horario con otro profesional de la clínica.";
        }
    }
}
