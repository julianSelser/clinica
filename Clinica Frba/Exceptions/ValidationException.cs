using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Exceptions
{
    class ValidationException : Exception
    {
        public string mensaje { get; set; }

        public ValidationException(string msgError)
        {
            this.mensaje = msgError;
        }
    }
}
