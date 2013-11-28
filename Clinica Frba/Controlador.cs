using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using Clinica_Frba.AppModel;

//Clase que valida los inputs de los campos que sean del tipo esperado.
//En caso de no ser matcheados con las expresiones regulares especificadas 
//para el tipo de campo en particular, es decir, que no esten
//incluidos en la variedad de caracteres que admite, arroja una excepcion
//que luego será catcheada por otro componente, permitiendo mostrar un mensaje de error acorde.

namespace Clinica_Frba
{
    class Controlador
    {
        private static Regex email = new Regex(
            @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" 
            + "@" 
            + @"((([\-\w]+\.)+[a-záéíóúñA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
        private static Regex alfa = new Regex("[A-Za-záéíóúñ ]");
        private static Regex alfanumerico = new Regex("[a-zA-Z0-9]");
        public enum TipoValidacion { Email, Alfa, Alfanumerico, Dinero, Codigo };
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
                switch (campo.tipoVal) //dependiendo del tipo de campo, utiliza el metodo correspondiente para comparar contra la expresion regular, en caso de no cumplir muestra un mensaje de error distinto
                {
                    case TipoValidacion.Email:
                        if (!stringEmailValido(campo.texto)) { throw new ExcepcionValidacion("-El campo " + campo.nombre + " debe contener caracteres válidos para un e-mail." + Environment.NewLine); }
                        break;
                    case TipoValidacion.Alfa:
                        if (!stringAlfa(campo.texto)) { throw new ExcepcionValidacion("-El campo " + campo.nombre + " debe ser solo letras." + Environment.NewLine); }
                        break;
                    case TipoValidacion.Alfanumerico:
                        if (!stringValido(campo.texto)) { throw new ExcepcionValidacion("-El campo " + campo.nombre + " debe ser alfanumérico." + Environment.NewLine); }
                        break;
                    case TipoValidacion.Dinero:
                        if (!esDinero(campo.texto)) { throw new ExcepcionValidacion("-El campo " + campo.nombre + " debe representar dinero.(sin letras, negativo ni ',')" + Environment.NewLine); }
                        break;
                    case TipoValidacion.Codigo:
                        if (!cadenaEsNumerica(campo.texto)) { throw new ExcepcionValidacion("-El campo " + campo.nombre + " no es un código válido. Solo se permiten números." + Environment.NewLine); }
                        break;

                }

            }
        }

        private static bool stringEmailValido(string mail)
        {
            return email.IsMatch(mail);
        }

        public static Boolean stringAlfa(string unString) //se fija si algun caracter no matchea con la expresion regular, en caso de no matchear, devuelve false
        {
            foreach(char unChar in unString)
            {
                if(!alfa.IsMatch(unChar.ToString())) return false;
            }
            return true;
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
