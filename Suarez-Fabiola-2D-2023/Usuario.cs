using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suarez_Fabiola_2D_2023.eTipoUsuario;

namespace Suarez_Fabiola_2D_2023
{
    public class Usuario
    {
        public string Nombre { get; }
        public string Apellido { get; }
        public string NombreCompleto { get; }
        public string Email { get; }
        public string Contrasena { get; }
        public TipoUsuario TipoDeUsuario { get; }

        public Usuario(string email, string contrasena)
        {
            this.Email = email;
            this.Contrasena = contrasena;
        }
        public Usuario(string nombre, string apellido, string email, string contrasena, TipoUsuario tipo)
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

        /// <summary>
        /// Valida que el usuario exista en la lista de usuarios existentes
        /// </summary>
        /// <param name="usuarioIngresado">Usuario a validar</param>
        /// <returns>Retorna True si existe en la lista de usuario y False si no</returns>
        public static bool ValidarExistenciaDeUsuario(Usuario usuarioIngresado)
        {
            return DatosEnMemoria.listaUsuarios.Any(usuario => usuario == usuarioIngresado);
        }

        /// <summary>
        /// Obtiene el tipo de usuario de un Usuario indicado
        /// </summary>
        /// <param name="usuarioIngresado">Usuario a buscar el tipo</param>
        /// <returns>Retorna el tipo de usuario, puede ser Cliente, Vendedor o SinAsignar</returns>
        public static TipoUsuario ObtenerTipoDeUsuario(Usuario usuarioIngresado)
        {
            foreach (Usuario usuario in DatosEnMemoria.listaUsuarios)
            {
                if (usuario == usuarioIngresado)
                {
                    return usuario.TipoDeUsuario;
                }
            }

            return TipoUsuario.SinAsignar;
        }

        /// <summary>
        /// Valida que los usuarios sean iguales
        /// </summary>
        /// <param name="a">Usuario a</param>
        /// <param name="b">Usuario b</param>
        /// <returns>Retorna True si son iguales y False si no</returns>
        public static bool operator == (Usuario a, Usuario b)
        {
            return (a.Email == b.Email) & (a.Contrasena == b.Contrasena);
        }
        /// <summary>
        /// Valida que los usuarios sean diferentes
        /// </summary>
        /// <param name="a">Usuario a</param>
        /// <param name="b">Usuario b</param>
        /// <returns>Retorna True si son diferentes y False si no</returns>
        public static bool operator != (Usuario a, Usuario b)
        {
            return (a.Email != b.Email) & (a.Contrasena != b.Contrasena);
        }
    }
}
