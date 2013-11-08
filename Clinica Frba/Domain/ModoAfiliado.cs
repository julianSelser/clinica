using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
Esta abstraccion permite enviar a una ventana de AltaAfiliado el modo 
en que se inicializa segun de que tipo de afiliado se trate
*/
namespace Clinica_Frba.Domain
{
    public class ModoAfiliado
    {
        public string modo { get; set; }
        public int nroAfiliado { get; set; }
    }
}
