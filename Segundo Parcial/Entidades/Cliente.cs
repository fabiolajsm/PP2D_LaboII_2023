using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Usuario
    {
        public float MontoMaximoDeCompra { get; set; }

        public Cliente(string nombre, string apellido, string email, string contrasena, float montoMaximo)
           : base(nombre, apellido, email, contrasena, TipoUsuario.Cliente)
        {
            this.MontoMaximoDeCompra = montoMaximo;
        }
        /// <summary>
        /// Obtiene el mensaje de bienvenida que se le va a mostrar al cliente cuando ingrese a la aplicación
        /// </summary>
        /// <returns>Retorna el mensaje de bienvenida en string</returns>
        public override string ObtenerMensajeBienvenida()
        {
            return $"Bienvenido/a a nuestra tienda en línea. Echa un vistazo a nuestra lista de productos y encuentra lo que necesitas. ¡Que tengas una excelente experiencia de compra!";
        }
        /// <summary>
        /// Si el monto máximo de compra es válido, lo modifica
        /// </summary>
        /// <param name="cliente">Cliente a modificarle el monto máximo de compra</param>
        /// <param name="listaClientes">Lista de clientes</param>
        /// <param name="monto">Monto a designar</param>
        /// <returns></returns>
        public static bool ModificarMontoMaximoDeCompra(Cliente cliente, List<Cliente> listaClientes, float monto)
        {
            if (cliente == null || listaClientes.Count < 0) return false;
            foreach (Cliente clienteLista in listaClientes)
            {
                if (clienteLista.NombreCompleto == cliente.NombreCompleto)
                {
                    cliente.MontoMaximoDeCompra = monto;
                    clienteLista.MontoMaximoDeCompra = monto;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Obtiene el cliente buscándolo por nombre en la lista de clientes
        /// </summary>
        /// <param name="nombreCompleto">Nombre del cliente</param>
        /// <param name="listaClientes">Lista de clientes</param>
        /// <returns>Obtiene Cliente si lo encuentra y null si no</returns>
        public static Cliente? ObtenerClientePorNombre(string nombreCompleto, List<Cliente> listaClientes)
        {
            if (string.IsNullOrEmpty(nombreCompleto) || listaClientes.Count < 0) return null;
            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.NombreCompleto == nombreCompleto.Trim())
                {
                    return cliente;
                }
            }
            return null;
        }
    }
}
