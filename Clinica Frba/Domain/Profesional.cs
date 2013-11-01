using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    class Profesional
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string tipoDoc { get; set; }
        public int nroDoc { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNac { get; set; }
        public int nroMatricula { get; set; }
        public DateTime fechaAtencionHasta { get; set; }
        public DateTime fechaAtencionDesde { get; set; }
        public bool habilitado { get; set; }

        public Profesional(int _id, string _nombre, string _apellido, string _sexo, string _tipoDoc, int _nroDoc, string _direccion, int _telefono, string _mail, DateTime _fechaNac, int _nroMatricula, DateTime _fechaAtencionDesde, DateTime _fechaAtencionHasta, bool _habilitado)
        {
            this.id = _id;
            this.nombre = _nombre;
            this.apellido= _apellido;
            this.sexo = _sexo;
            this.tipoDoc = _tipoDoc;
            this.nroDoc= _nroDoc;
            this.direccion = _direccion;
            this.telefono = _telefono;
            this.mail = _mail;
            this.fechaNac = _fechaNac;
            this.nroMatricula = _nroMatricula;
            this.fechaAtencionHasta = _fechaAtencionHasta;
            this.fechaAtencionDesde = _fechaAtencionDesde;
            this.habilitado = _habilitado;
        }
    }
}
