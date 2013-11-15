using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{

    public class Funcionalidad
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public Funcionalidad(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }


        public Funcionalidad() { }
    }
}



