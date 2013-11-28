using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Clase abstracta de la cual se hereda la firma del metodo de validar el campo
namespace Clinica_Frba.AppModel
{
    public abstract class CampoAbstracto
    {
        public abstract void validar();
    }
}
