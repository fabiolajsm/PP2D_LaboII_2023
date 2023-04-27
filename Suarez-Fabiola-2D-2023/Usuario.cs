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
        public Usuario(string email, string contrasena, TipoUsuario tipo)
        {
            this.Email = email;
            this.Contrasena = contrasena;
            this.TipoDeUsuario = tipo;
        }
        /// <summary>
        /// Valida que el usuario exista en la lista de usuarios existentes
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>Retorna True si existe el usuario y False si no</returns>
        public bool ValidarExistenciaDeUsuario(string email, string contrasena)
        {
            foreach (Usuario usuario in DatosEnMemoria.listaVendedores)
            {
                if (usuario != null && usuario.Email == email && usuario.Contrasena == contrasena)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
