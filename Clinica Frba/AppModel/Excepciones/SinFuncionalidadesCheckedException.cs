using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.AppModel.Excepciones
{
    class SinFuncionalidadesCheckedException : UserDefinedException
    {
        public SinFuncionalidadesCheckedException()
        {
            this.mensaje = "No ha seleccionado ninguna funcionalidad. Por favor seleccione al menos una del listado.";
        }
    }
}
