using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 Abstraccion que almacena los datos de un afiliado
 */
namespace Clinica_Frba.Domain
{
    class Afiliado : Persona
    {
        public int nroAfiliado { get; set; }
        public int codPlan { get; set; }
        public string estadoCivil { get; set; }
	    public int nroTitular { get; set; }
	    public int nroConyuge { get; set; }
	    public DateTime fechaBaja { get; set; }
	    public int nroConsulta { get; set; }
        public int cantFamiliaresACargo { get; set; }

        public Afiliado(int _nroAfiliado, string _nombre, string _apellido, char _sexo, string _tipoDoc, int _nroDoc, string _direccion,
            string _mail, int _telefono, DateTime _fechaNac, int _codPlan, string _estadoCivil, int _nroTitular, int _nroConyuge, 
            DateTime _fechaBaja, int _nroConsulta, int _cantFamiliaresACargo)
        {
            this.nroAfiliado = _nroAfiliado;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.sexo = _sexo;
            this.tipoDoc = _tipoDoc;
            this.nroDoc = _nroDoc;
            this.direccion = _direccion;
            this.telefono = _telefono;
            this.mail = _mail;
            this.fechaNac = _fechaNac;
            this.codPlan = _codPlan;
            this.estadoCivil = _estadoCivil;
            this.nroTitular = _nroTitular;
            this.nroConyuge = _nroConyuge;
            this.fechaBaja = _fechaBaja;
            this.nroConsulta = _nroConsulta;
            this.cantFamiliaresACargo = _cantFamiliaresACargo;
        }

        public Afiliado() { }
    }
}
