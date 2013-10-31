using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Domain
{
    class Profesional
    {
        public string nombre;
        public string apellido;
        public string tipoDoc;
        public string nroDoc;
        public string direccion;
        public string telefono;
        public string fechaNac;
        public string nroMatricula;
        public string fechaAtencionHasta;
        public string fechaAtencionDesde;
        public string mail;
        public string sexo;

        //si al metodo le ponia un nombre diferente al de la clase me tiraba error
        public Profesional(string unNombre, string unApellido, string unTipoDoc, string unNroDoc, string unaDireccion, string unTelefono, string unaFechaNac, string unNroMatricula, string unaFechaAtencionHasta, string unaFechaAtencionDesde, string unMail, string unSexo){
            this.nombre = unNombre;
            this.apellido = unApellido;
            this.tipoDoc = unTipoDoc;
            this.nroDoc = unNroDoc;
            this.direccion = unaDireccion;
            this.telefono = unTelefono;
            this.fechaNac = unaFechaNac;
            this.nroMatricula = unNroMatricula;
            this.fechaAtencionHasta = unaFechaAtencionHasta;
            this.fechaAtencionDesde = unaFechaAtencionDesde;
            this.mail = unMail;
            this.sexo = unSexo;
        }
    }
}
