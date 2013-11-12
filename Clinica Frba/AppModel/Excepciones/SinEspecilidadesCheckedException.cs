using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.AppModel.Excepciones
{
    class SinEspecilidadesCheckedException : UserDefinedException
    {
        public SinEspecilidadesCheckedException()
        {
            this.mensaje = "No ha seleccionado ninguna especialidad. Por favor seleccione al menos una del listado.";
        }
    }
}
