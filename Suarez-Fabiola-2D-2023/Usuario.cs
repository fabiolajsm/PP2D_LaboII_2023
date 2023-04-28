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
        public string Email { get; }
        public string Contrasena { get; }
        public TipoUsuario TipoDeUsuario { get; }

        public Usuario(string email, string contrasena)
        {
            this.Email = email;
            this.Contrasena = contrasena;
        }
        public Usuario(string email, string contrasena, TipoUsuario tipo)
        {
            this.Email = email;
            this.Contrasena = contrasena;
            this.TipoDeUsuario = tipo;
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
