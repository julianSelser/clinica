using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.AppModel.Excepciones;

namespace Clinica_Frba.AppModel
{
    class ExcepcionValidacion : UserDefinedException
    {
        public ExcepcionValidacion(string msgError)
        {
            this.mensaje = msgError;
        }
    }
}
