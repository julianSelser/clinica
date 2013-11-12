using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;

namespace Clinica_Frba.AppModel.Excepciones
{
    class MedicoYaExisteException : UserDefinedException
    {
        public MedicoYaExisteException(Profesional profesional)
        {
            this.mensaje = "ERROR: El profesional ya se encuentra registrado.\n\n\nProfesional: " + profesional.nombre + " " + profesional.apellido + "\n\n" + profesional.tipoDoc + ".: " + profesional.nroDoc.ToString();
        }
    }
}
