using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    class Profesional : Persona
    {
        public int nroMatricula { get; set; }
        public bool habilitado { get; set; }
        public int id { get; set; }

        public Profesional(int _id, string _nombre, string _apellido, char _sexo, string _tipoDoc, int _nroDoc, string _direccion, int _telefono, string _mail, DateTime _fechaNac, int _nroMatricula, bool _habilitado)
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
            this.habilitado = _habilitado;
        }

        public Profesional() { }
    }
}
