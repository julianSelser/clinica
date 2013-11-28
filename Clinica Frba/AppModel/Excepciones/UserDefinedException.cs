using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Exception general personalizada de la cual heredan otro tipos de excepciones con mensajes especificos de cada una

namespace Clinica_Frba.AppModel.Excepciones
{
    abstract class UserDefinedException : ApplicationException
    {
        public string mensaje { get; set; }
    }
}
