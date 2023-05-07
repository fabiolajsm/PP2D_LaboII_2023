using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Suarez_Fabiola_2D_2023
{
    public static class ValidadorLoginUsuario
    {
        /// <summary>
        /// Valida el formato de un Email
        /// </summary>
        /// <param name="email">Email a validar</param>
        /// <param name="error_email">Control de error de email</param>
        /// <returns>Retorna True si es válido y False si no</returns>
        public static bool ValidarFormatoEmail(string email, System.Windows.Forms.Label error_email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(emailPattern);
            if (string.IsNullOrWhiteSpace(email))
            {
                error_email.Text = "⚠ Debe ingresar Email";
                error_email.Visible = true;
                return false;
            }
            else if (!regex.IsMatch(email))
            {
                error_email.Text = $"⚠ Email no existente. Por favor ingresar un Email válido (Ej: lola@gmail.com)";
                error_email.Visible = true;
                return false;
            }
            else
            {
                error_email.Visible = false;
                return true;
            }
        }
        /// <summary>
        /// Valida el formato de una Contraseña 
        /// </summary>
        /// <param name="contraseña">Contraseña a validar</param>
        /// <param name="error_contraseña">Control de error de contraseña</param>
        /// <returns>Retorna True si es válido y False si no</returns>
        public static bool ValidarFormatoContraseña(string contraseña, System.Windows.Forms.Label error_contraseña)
        {
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                error_contraseña.Visible = true;
                return false;
            }
            else
            {
                error_contraseña.Visible = false;
                return true;
            }
        }
        /// <summary>
        /// Obtiene el usuario buscandolo por email y contraseña
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>Si no se encontró el usuario retorna Null y de lo contrario retorna el Usuario</returns>
        public static Usuario? BuscarUsuarioPorEmailYContraseña(string email, string contrasena)
        {
            foreach (Usuario usuario in DatosEnMemoria.listaUsuarios)
            {
                if (usuario.Email == email && usuario.Contrasena == contrasena)
                {
                    return usuario;
                }
            }
            return null;
        }
    }
}
