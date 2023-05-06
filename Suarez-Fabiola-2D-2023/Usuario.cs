using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suarez_Fabiola_2D_2023.eTipoUsuario;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Suarez_Fabiola_2D_2023
{
    public abstract class Usuario
    {
        public string Nombre { get; }
        public string Apellido { get; }
        public string NombreCompleto { get; }
        public string Email { get; }
        public string Contrasena { get; }
        public TipoUsuario TipoDeUsuario { get; }

        public Usuario()
        {
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.NombreCompleto = string.Empty;
            this.Email = string.Empty;
            this.Contrasena = string.Empty;
            this.TipoDeUsuario = eTipoUsuario.TipoUsuario.SinAsignar;
        }

        public Usuario(string email, string contrasena) :this()
        {
            this.Email = email;
            this.Contrasena = contrasena;
        }

        public Usuario(string nombre, string apellido, string email, string contrasena, TipoUsuario tipo):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreCompleto = $"{Capitalize(this.Nombre)} {Capitalize(this.Apellido)}";
            this.Email = email;
            this.Contrasena = contrasena;
            this.TipoDeUsuario = tipo;
        }

        /// <summary>
        /// Capitaliza la palabra ingresada. Ej: flor => Flor
        /// </summary>
        /// <param name="palabra">Palabra a Capitalizar</param>
        /// <returns>Si existe la palabra la retorna capitalizada, si no, retorna la misma palabra sin modificar</returns>
        public static string Capitalize(string palabra)
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
