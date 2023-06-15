using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vendedor : Usuario
    {
        public Vendedor(string nombre, string apellido, string email, string contrasena)
            : base(nombre, apellido, email, contrasena)
        {
        }
        /// <summary>
        /// Obtiene el mensaje de bienvenida que se le va a mostrar al vendedor cuando ingrese a la aplicación
        /// </summary>
        /// <returns>Retorna el mensaje de bienvenida en string</returns>
        public override string ObtenerMensajeBienvenida()
        {
            return $"¡Hola! Bienvenido/a al panel de control de vendedor! Aquí puedes administrar tu inventario y hacer cambios y ajustes necesarios. ¡Gracias por ser parte de nuestro equipo de vendedores!";
        }
        /// <summary>
        /// Modifica la propiedad de un producto seleccionado en la lista de productos 
        /// </summary>
        /// <param name="indexProducto">Index del producto seleccionado</param>
        /// <param name="listaProductos">Lista de productos</param>
        /// <param name="nuevoStock">Si quiere modificar el stock, pasa el nuevo stock, del resto pasa un null</param>
        /// <param name="nuevoPrecio">Si quiere modificar el precio, pasa el nuevo precio, del resto pasa un null</param>
        /// <param name="nuevoCorte">Si quiere modificar el tipo de corte, pasa el nuevo tipo de corte, del resto pasa un string vacío</param>
        /// <returns>Retorna True si se modificó y False si no</returns>
        public static bool ModificarProducto(int indexProducto, List<Producto> listaProductos, int? nuevoStock = null, double? nuevoPrecio = null, string nuevoCorte = "")
        {
            bool seModifico = false;

            if (indexProducto >= 0)
            {
                Producto productoSeleccionado = listaProductos[indexProducto];
                if (nuevoStock != null)
                {
                    productoSeleccionado.StockDisponible = nuevoStock.Value;
                    seModifico = true;
                }
                if (nuevoPrecio != null)
                {
                    productoSeleccionado.PrecioPorKilo = nuevoPrecio.Value;
                    seModifico = true;
                }
                if (!string.IsNullOrEmpty(nuevoCorte))
                {
                    productoSeleccionado.TipoCorte = Utilidades.Capitalize(nuevoCorte);
                    seModifico = true;
                }
            }

            return seModifico;
        }
    }
}
