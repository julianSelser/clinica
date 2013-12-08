using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.AppModel.Excepciones
{
    class NoHayHorarioDisponiblesException : UserDefinedException
    {
        public NoHayHorarioDisponiblesException()
        {
            this.mensaje = "El profesional no tiene horarios disponibles, están todos ocupados.";
        }
    }
}
