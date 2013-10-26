﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using Clinica_Frba.Exceptions;
using Clinica_Frba.AppModel;

namespace Clinica_Frba
{
    class Controller
    {
        private static Regex patronAlfanumerico = new Regex("[a-zA-Z0-9]");
        private static Regex patronCodigo = new Regex(@"^\d+$");
        public enum TipoValidacion { Alfanumerico, Dinero, Codigo, Patente };
        public static void validarCampos(List<AbstractCampo> campos)
        {
            string mensajeError = "";
            foreach (AbstractCampo campo in campos)
            {
                try
                {
                    campo.validar();
                }
                catch (ValidationException ex)
                {
                    mensajeError += ex.mensaje;
                }
            }
            if (!stringEstaVacio(mensajeError)) { throw new ValidationException(mensajeError); }

        }

        //si se agrega un nuevo tipo, se debe agregar en TipoValidacion, y la opcion en este metodo con la condicion y el mensaje correspondiente si falla esa condicion
        public static void validarTipo(Campo campo)
        {
            if (!stringEstaVacio(campo.texto))
            {
                switch (campo.tipoVal)
                {
                    case TipoValidacion.Alfanumerico:
                        if (!stringValido(campo.texto)) { throw new ValidationException("-El campo " + campo.nombre + " debe ser alfanumérico." + Environment.NewLine); }
                        break;
                    case TipoValidacion.Dinero:
                        if (!stringEsDinero(campo.texto)) { throw new ValidationException("-El campo " + campo.nombre + " debe representar dinero.(sin letras, negativo ni ',')" + Environment.NewLine); }
                        break;
                    case TipoValidacion.Codigo:
                        if (!stringEsCodigo(campo.texto)) { throw new ValidationException("-El campo " + campo.nombre + " no es un código válido. Solo se permiten números." + Environment.NewLine); }
                        break;

                }

            }
        }
        public static Boolean stringValido(string unString)
        {
            return patronAlfanumerico.IsMatch(unString);
        }
        public static Boolean stringEstaVacio(string unString)
        {
            return unString.Length == 0;
        }
        public static Boolean stringEsNumero(string unString)
        {
            double num;
            return double.TryParse(unString, out num);

        }
        public static Boolean stringEsDinero(string unString)
        {
            double num;
            return double.TryParse(unString, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out num);
        }
        public static Boolean stringEsCodigo(string unString)
        {
            return patronCodigo.IsMatch(unString);
        }
    }
}
