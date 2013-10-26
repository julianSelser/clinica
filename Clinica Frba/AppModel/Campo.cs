using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Exceptions;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.AppModel
{
    class Campo : AbstractCampo
    {
        public string texto { get; set; }
        public string nombre { get; set; }
        public bool obligatorio { get; set; }
        public Controller.TipoValidacion tipoVal { get; set; }

        public Campo(string nom, string text, bool oblig, Controller.TipoValidacion val)
        {
            this.nombre = nom;
            this.texto = text;
            this.obligatorio = oblig;
            this.tipoVal = val;
        }
        //Metodo que valida si el campo cumple con las restricciones impuestas.
        public override void validar()
        {
            string mensaje = "";
            bool rta = true;

            if (this.obligatorio && Controller.stringEstaVacio(this.texto)) { mensaje += "-El campo " + this.nombre + " es obligatorio." + Environment.NewLine; rta = false; }
            try
            {
                Controller.validarTipo(this);
            }
            catch (ValidationException ex)
            {
                mensaje += ex.mensaje;
                rta = false;
            }

            if (rta) { return; }
            else { throw new ValidationException(mensaje); }
        }
    }
}
