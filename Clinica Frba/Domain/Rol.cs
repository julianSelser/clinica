using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    public class Rol
    {
        public int id{ get;  set; }
        public string nombre { get; set; }
        public bool habilitado { get; set; }
        public List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        public Rol(int id, string nombre, bool habilitado) 
        {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
        }

        public Rol() { }

    }
}

