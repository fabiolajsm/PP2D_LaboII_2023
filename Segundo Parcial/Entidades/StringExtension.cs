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
        public static bool EsFormatoEmail(this string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(emailPattern);

            return !string.IsNullOrWhiteSpace(email) && regex.IsMatch(email);
        }
    }
}
