using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.AppModel.Excepciones
{
    class DecrementarCantFamiliaresException : UserDefinedException
    {
        public DecrementarCantFamiliaresException()
        {
            this.mensaje = "No es posible especificar una cantidad de hijos menor a la cantidad de familiares registrados";
        }
    }
}
