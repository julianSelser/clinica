using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    public class Rol
    {
        private int id;
        private string nombre;
        private bool habilitado;
        private List<Funcionalidad> funcionalidades; //declaro la lista de funcionalidades
    }
}
