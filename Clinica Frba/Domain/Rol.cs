using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    public class Rol
    {
        private int id{ get;  set; }
        private string nombre { get; set; }
        private bool habilitado { get; set; }
        private List<Funcionalidad> funcionalidades; //declaro la lista de funcionalidades
    }

}

