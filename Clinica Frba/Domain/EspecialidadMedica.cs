using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Abstraccion que representa a una especialidad medica

namespace Clinica_Frba.Domain
{
    public class EspecialidadMedica
    {
        public int codigo {get; set;}
        public string descripcion { get; set; }
        public int tipoEspecilidadCodigo {get; set;}
    }
}
