using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public static class StringExtension
    {
        /// <summary>
        /// Valida si un string tiene el formato de un email
        /// </summary>
        /// <param name="email">String a validar</param>
        /// <returns>Retorna True si tiene el formato de un email y False si no</returns>
        public static bool EsFormatoEmail(this string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(emailPattern);

            return !string.IsNullOrWhiteSpace(email) && regex.IsMatch(email);
        }
        /// <summary>
        /// Capitaliza la palabra ingresada. Ej: flor => Flor
        /// </summary>
        /// <param name="palabra">Palabra a Capitalizar</param>
        /// <returns>Si existe la palabra la retorna capitalizada, si no, retorna la misma palabra sin modificar</returns>
        public static string Capitalize(this string palabra)
        {
            if (string.IsNullOrEmpty(palabra))
            {
                return palabra;
            }
            string palabraCapitalizada = char.ToUpper(palabra[0]) + palabra.Substring(1);
            return palabraCapitalizada.Trim();
        }
    }
}
