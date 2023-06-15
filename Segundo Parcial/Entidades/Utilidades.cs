using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Utilidades
    {
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
        /// Calcula el precio final de un producto segun la cantidad del producto y su precio por kilo
        /// </summary>
        /// <param name="cantidadIngresadaEnGramos">Cantidad del producto en gramos</param>
        /// <param name="precioPorKilo">Precio por kilo del producto</param>
        /// <returns>Retorna el precio del producto segun la cantidad ingresada en gramos</returns>
        public static double CalcularPrecio(int cantidadIngresadaEnGramos, double precioPorKilo)
        {
            double cantidadEnKilos = (double)cantidadIngresadaEnGramos / 1000; // Convertir la cantidad a kilos
            double precioTotal = 0;
            if (cantidadIngresadaEnGramos > 0 & precioPorKilo > 0)
            {
                precioTotal = cantidadEnKilos * precioPorKilo;
            }
            return precioTotal;
        }
        /// <summary>
        /// Obtiene el usuario buscandolo por email y contraseña
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>Si no se encontró el usuario retorna Null y de lo contrario retorna el Usuario</returns>
        public static Usuario? BuscarUsuarioPorEmailYContraseña(string email, string contrasena, List<Usuario> listaUsuarios)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasena) || listaUsuarios.Count == 0) { return null; }
            foreach (Usuario usuario in listaUsuarios)
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
