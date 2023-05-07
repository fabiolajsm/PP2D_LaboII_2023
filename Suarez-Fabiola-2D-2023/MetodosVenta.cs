using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Suarez_Fabiola_2D_2023
{
    public static class MetodosVenta
    {
        /// <summary>
        /// Muestra una alerta con el mensaje de error
        /// </summary>
        /// <param name="mensaje">Mensaje de error a mostrar</param>
        public static void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Valida los campos ListBox y TextBox del Gb_ListaDeProductos y devuelve un mensaje de error de no ser válidos
        /// </summary>
        /// <param name="indexProducto">Index del producto a buscar en la lista</param>
        /// <param name="cantidadIngresada">Cantidad de producto ingresado</param>
        /// <param name="esAgregarAlCarrito">Indica si es para agregar al carrito en vez de para eliminar del carrito</param>
        /// <returns>Retorna True si son válidos y False de lo contrario</returns>
        public static bool ValidarCampos(int indexProducto, int cantidadIngresada, bool esAgregarAlCarrito, List<Producto> productos)
        {
            double stockDisponible = Producto.ObtenerStockDisponible(indexProducto, cantidadIngresada, productos);
            if (productos.Count == 0) return false;
            if (indexProducto < 0 && cantidadIngresada < 1)
            {
                MostrarError("Debe seleccionar un producto e ingresar cantidad.");
                return false;
            }
            if (indexProducto < 0)
            {
                MostrarError("Debe seleccionar un producto de la lista.");
                return false;
            }
            if (cantidadIngresada < 1)
            {
                MostrarError($"Debe ingresar una cantidad mayor a {cantidadIngresada} gramos.");
                return false;
            }
            if (stockDisponible < cantidadIngresada & esAgregarAlCarrito)
            {
                MostrarError($"Lo sentimos, sólo nos quedan {stockDisponible} gr, del producto seleccionado");
                return false;
            }
            if (!esAgregarAlCarrito & ExisteProductoEnELCarrito(productos[indexProducto]) == false)
            {
                MostrarError($"No se encontró producto en el carrito");
                return false;
            }
            if (!esAgregarAlCarrito && ObtenerCantidadProductoDelCarrito(productos[indexProducto]) < cantidadIngresada)
            {
                MostrarError($"No se puede eliminar más de la cantidad del producto agregado al carrito");
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        private static bool ExisteProductoEnELCarrito(Producto producto)
        {
            if (producto == null)
            {
                return false;
            }

            foreach (Producto prod in DatosEnMemoria.listaProductosDelCarrito)
            {
                if (prod.Nombre == producto.Nombre)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        private static int ObtenerCantidadProductoDelCarrito(Producto producto)
        {
            if (producto == null) return 0;

            foreach (Producto item in DatosEnMemoria.listaProductosDelCarrito)
            {
                if (item.Nombre == producto.Nombre)
                {
                    return item.CantidadDeseada;
                }
            }
            return 0;
        }
        /// <summary>
        /// Agrega un producto al carrito
        /// </summary>
        /// <param name="producto">Producto a agregar</param>
        /// <param name="listaProductosDelCarrito">Lista a la que se le agregará el nuevo producto</param>
        /// <returns>Retorna True si se pudo agregar y False si no</returns>
        public static bool AgregarProductoAlCarrito(Producto producto, List<Producto> listaProductosDelCarrito)
        {
            if (producto != null)
            {
                Producto productoEnCarrito = listaProductosDelCarrito.Find(p => p.Nombre == producto.Nombre);

                if (productoEnCarrito != null)
                {
                    productoEnCarrito.CantidadDeseada += producto.CantidadDeseada;
                    productoEnCarrito.StockDisponible -= producto.StockDisponible;
                }
                else
                {
                    producto.StockDisponible -= producto.CantidadDeseada;
                    listaProductosDelCarrito.Add(producto);
                }

                return true;
            }
            return false;
        }
        /// <summary>
        /// Elimina un producto del carrito
        /// </summary>
        /// <param name="producto">Producto a eliminar</param>
        /// <param name="cantidad">Cantidad de producto a eliminar</param>
        /// <param name="listaProductosDelCarrito">Lista a la que se le va a eliminar el producto</param>
        /// <returns>Retorna True si se pudo eliminar y False si no</returns>
        public static bool EliminarProductoDelCarrito(Producto producto, int cantidad, List<Producto> listaProductosDelCarrito)
        {
            if (producto == null || cantidad <= 0 || listaProductosDelCarrito.Count < 1) return false;
            Producto productoEnCarrito = listaProductosDelCarrito.Find(p => p.Nombre == producto.Nombre);

            if (productoEnCarrito != null)
            {
                if (cantidad == productoEnCarrito.CantidadDeseada)
                {
                    producto.StockDisponible += cantidad;
                    listaProductosDelCarrito.Remove(productoEnCarrito);
                }
                else
                {
                    productoEnCarrito.StockDisponible += cantidad;
                    producto.StockDisponible = productoEnCarrito.StockDisponible;
                    productoEnCarrito.CantidadDeseada -= cantidad;
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Agrega una lista de productos del carrito a la listaProductosDelCarrito en Datos en Memoria
        /// </summary>
        /// <param name="listaCarrito">Lista a agregar</param>
        /// <returns>Retorna True si se agregó y False si no</returns>
        public static bool AgregarProductosAlCarrito(List<Producto> listaCarrito)
        {
            if (listaCarrito != null)
            {
                DatosEnMemoria.listaProductosDelCarrito.AddRange(listaCarrito);
            }
            return false;
        }
    }
}

