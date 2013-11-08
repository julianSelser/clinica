using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 Abstraccion que almacena los datos de un afiliado
 */
namespace Clinica_Frba.Domain
{
    class Afiliado
    {
        public int nroAfiliado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public char sexo { get; set; }
        public string tipoDoc { get; set; }
        public int nroDoc { get; set; }
        public string direccion { get; set; }
        public string mail { get; set; }
        public int telefono { get; set; }
        public DateTime fechaNac { get; set; }
        public int codPlan { get; set; }
        public string estadoCivil { get; set; }
	    public int nroTitular { get; set; }
	    public int nroConyuge { get; set; }
	    public DateTime fechaBaja { get; set; }
	    public int nroConsulta { get; set; }
        public int cantFamiliaresACargo { get; set; }

        public Afiliado()
        {
        }
    }
}
