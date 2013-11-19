using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;

namespace Clinica_Frba.AppModel.Excepciones
{
    class RolYaExisteException : UserDefinedException
    {
        public RolYaExisteException(Rol rol)
        {
            this.mensaje = "ERROR: El rol ya se encuentra registrado.\n\n\nRol: " + rol.nombre.ToString();
        }
    }
}
