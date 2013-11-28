using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Domain;

namespace Clinica_Frba.AppModel.Excepciones
{
    class MatriculaDuplicadaException : UserDefinedException
    {
        public MatriculaDuplicadaException(Profesional profesional)
        {
            this.mensaje = "ERROR: Ya se existe un profesional con mismo número de matrícula: "+ profesional.nroMatricula;
        }
    }
}
