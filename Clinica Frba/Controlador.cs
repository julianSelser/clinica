﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using Clinica_Frba.AppModel;

namespace Clinica_Frba
{
    class Controlador
    {
        private static Regex alfanumerico = new Regex("[a-zA-Z0-9]");
        private static Regex codigo = new Regex(@"^\d+$");
        public enum TipoValidacion { Alfanumerico, Dinero, Codigo };
        public static void validarCampos(List<CampoAbstracto> campos)
        {
            string mensajeError = "";
            foreach (CampoAbstracto campo in campos)
            {
                try
                {
                    campo.validar();
                }
                catch (ExcepcionValidacion ex)
                {
                    mensajeError += ex.mensaje;
                }
            }
            if (!stringVacio(mensajeError)) { throw new ExcepcionValidacion(mensajeError); }

        }

        //si se agrega un nuevo tipo, se debe agregar en TipoValidacion, y la opcion en este metodo con la condicion y el mensaje correspondiente si falla esa condicion
        public static void validarTipo(Campo campo)
        {
            if (!stringVacio(campo.texto))
            {
                switch (campo.tipoVal)
                {
                    case TipoValidacion.Alfanumerico:
                        if (!stringValido(campo.texto)) { throw new ExcepcionValidacion("-El campo " + campo.nombre + " debe ser alfanumérico." + Environment.NewLine); }
                        break;
                    case TipoValidacion.Dinero:
                        if (!esDinero(campo.texto)) { throw new ExcepcionValidacion("-El campo " + campo.nombre + " debe representar dinero.(sin letras, negativo ni ',')" + Environment.NewLine); }
                        break;
                    case TipoValidacion.Codigo:
                        if (!esCodigo(campo.texto)) { throw new ExcepcionValidacion("-El campo " + campo.nombre + " no es un código válido. Solo se permiten números." + Environment.NewLine); }
                        break;

                }

            }
        }

        public static Boolean stringNumero(string unString)
        {
            double num;
            return double.TryParse(unString, out num);

        }

        public static Boolean stringVacio(string unString)
        {
            return unString.Length == 0;
        }
        
        public static Boolean esDinero(string unString)
        {
            double num;
            return double.TryParse(unString, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out num);
        }

        public static Boolean esCodigo(string unString)
        {
            return codigo.IsMatch(unString);
        }

        public static Boolean stringValido(string unString)
        {
            return alfanumerico.IsMatch(unString);
        }

        //wrapper para el parseo de datetime, parsea si puede, sino devuelve null, no maneja excepciones de parseo
        public static DateTime? parsear(string cadena)
        {
            return (!cadenaEsVaciaONull(cadena)) ? DateTime.Parse(cadena) : (DateTime?)null;
        }

        //valida que un string nombre tenga el nombre y el apellido
        public static bool tieneNombreYAPellido(string nombreYapellido)
        {
            return new Regex(@"^\s*\w+\s+\w+\s*$").IsMatch(nombreYapellido);
        }

        //separa el nombre y el apellido en una cadena donde viene todo junto
        public static string[] separarNombreYApellido(string nombreYapellido)
        {
            return nombreYapellido.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool cadenaEsNumerica(string cadena)
        {
            return new Regex(@"^\d+$").IsMatch(cadena);
        }

        public static bool cadenaEsVaciaONull(string cadena)
        {
            if (cadena == null) return true;

            foreach (char c in cadena) if (c != ' ') return false; //chequea si son todos whitespace

            return true; //si llega aca eran todos whitespace
        }
    }
}
