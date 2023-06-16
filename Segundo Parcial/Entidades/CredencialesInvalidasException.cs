using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CredencialesInvalidasException : Exception
    {
        public CredencialesInvalidasException()
            : base("Usuario y/o contraseña inválidos.")
        {
        }
    }
}
