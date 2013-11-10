using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;

namespace Clinica_Frba.AppModel.Excepciones
{
    class AfiliadoYaExisteException : UserDefinedException
    {

        public AfiliadoYaExisteException(Afiliado afiliado)
        {
            this.mensaje = "ERROR: El afiliado ya se encuentra registrado.\n\n\nAfiliado: " + afiliado.nombre + " " + afiliado.apellido + "\n\n" + afiliado.tipoDoc + ".: " + afiliado.nroDoc.ToString();
        }
    }
}
