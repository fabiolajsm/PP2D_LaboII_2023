using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suarez_Fabiola_2D_2023.eTipoUsuario;

namespace Suarez_Fabiola_2D_2023
{
    public class Cliente : Usuario
    {
        public float MontoMaximoDeCompra { get; set; }

        public Cliente() { }

        public Cliente(string nombre, string apellido, string email, string contrasena, TipoUsuario tipoDeUsuario, float montoMaximo)
           : base(nombre, apellido, email, contrasena, tipoDeUsuario)
        {
            this.MontoMaximoDeCompra = montoMaximo;
        }

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
    }
}
