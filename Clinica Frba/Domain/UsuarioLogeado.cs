using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    public class UsuarioLogeado
    {

        public Rol Rol { get; set; }
        public string UserName { get; set; }
        public Persona Persona { get; set; }
        private static UsuarioLogeado _instance = null;
        public static UsuarioLogeado Instance
        {
            get { return _instance = (null == _instance) ? new UsuarioLogeado() : _instance; }
        }

        private UsuarioLogeado() { }
    }
}
