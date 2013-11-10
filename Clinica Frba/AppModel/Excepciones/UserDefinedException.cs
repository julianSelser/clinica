using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.AppModel.Excepciones
{
    abstract class UserDefinedException : ApplicationException
    {
        public string mensaje { get; set; }
    }
}
