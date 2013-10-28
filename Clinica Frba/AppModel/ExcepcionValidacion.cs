using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.AppModel
{
    class ExcepcionValidacion : Exception
    {
        public string mensaje { get; set; }

        public ExcepcionValidacion(string msgError)
        {
            this.mensaje = msgError;
        }
    }
}
