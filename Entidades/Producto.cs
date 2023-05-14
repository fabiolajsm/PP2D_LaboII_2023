using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoCorte { get; set; }
        public double PrecioPorKilo { get; set; }
        public double StockDisponible { get; set; } // en gramos
        public int CantidadDeseada { get; set; }

        public Producto()
        {
            Nombre = "";
            Descripcion = "";
            TipoCorte = "";
            PrecioPorKilo = 0;
            StockDisponible = 0;
            CantidadDeseada = 0;
        }
        public Producto(string nombre, string descripcion, string tipoCorte, double precioPorKilo, double stockDisponible)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            TipoCorte = tipoCorte;
            PrecioPorKilo = precioPorKilo;
            StockDisponible = stockDisponible;
            CantidadDeseada = 0;
        }
        public Producto(string nombre, string descripcion, string tipoCorte, double precioPorKilo, double stockDisponible, int cantidadDeseada) : this()
        {
            Nombre = nombre;
            Descripcion = descripcion;
            TipoCorte = tipoCorte;
            PrecioPorKilo = precioPorKilo;
            StockDisponible = stockDisponible;
            CantidadDeseada = cantidadDeseada;
        }
        /// <summary>
        /// Obtiene un producto buscándolo por nombre en la lista de productos
        /// </summary>
        /// <param name="nombreDelProducto">Nombre del producto a buscar</param>
        /// <param name="listaProductos">Lista productos</param>
        /// <returns>Retorna el producto segun el nombre ingresado</returns>
        public Producto? ObtenerProductoPorNombre(string nombreDelProducto, List<Producto> listaProductos)
        {
            if (string.IsNullOrEmpty(nombreDelProducto) || listaProductos.Count < 0) return null;
            foreach (Producto producto in listaProductos)
            {
                if (producto.Nombre == nombreDelProducto)
                {
                    return producto;
                }
            }
            return null;
        }
        /// <summary>
        /// Obtiene el atributo indicado del producto seleccionado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="indexProducto"></param>
        /// <param name="propiedad"></param> puedo usarlo como indexador
        /// <param name="listaProductos"></param>
        /// <param name="valorPorDefecto"></param>
        /// <returns>Retorna la propiedad del producto segun su valor por defecto</returns>
        public static T ObtenerPropiedadProducto<T>(int indexProducto, Func<Producto, T> propiedad, List<Producto> listaProductos, T valorPorDefecto = default(T))
        {
            if (indexProducto >= 0 && listaProductos != null && listaProductos.Count > indexProducto) // como sobrecarga mejor de ultimo
            {
                Producto productoSeleccionado = listaProductos[indexProducto];
                return propiedad(productoSeleccionado);
            }
            return valorPorDefecto;
        }
        /// <summary>
        /// Agrega un producto a la lista de productos
        /// </summary>
        /// <param name="nuevoProducto">Producto a agregar</param>
        /// <param name="listaProductos">Lista de productos en donde se va a agregar</param>
        /// <returns>Retorna True si se agregó y False si no</returns>
        public static bool AgregarProductoALaLista(Producto nuevoProducto)
        {
            if (nuevoProducto == null) return false;

            DatosEnMemoria.AgregarProducto(nuevoProducto);
            return true;
        }
        /// <summary>
        /// Busca si existe un producto en la lista de productos del carrito
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>Retorna True si existe y False si no</returns>
        public static bool ExisteProductoEnELCarrito(string nombreProducto, List<Producto> listaProductos, List<Producto> listaProductosDelCarrito)
        {
            if (string.IsNullOrEmpty(nombreProducto) || listaProductos.Count == 0 || listaProductosDelCarrito.Count == 0)
            {
                return false;
            }

            return listaProductosDelCarrito.Any(prod => prod.Nombre == nombreProducto);
        }
        /// <summary>
        /// Obtiene la cantidad deseada de un producto de a lista de productos del carrito
        /// </summary>
        /// <param name="producto">Producto al que se le obtendrá la cantidad deseada</param>
        /// <returns>Retorna la cantidad deseada del producto ingresado</returns>
        public static int ObtenerCantidadProductoDelCarrito(Producto producto, List<Producto> listaProductosCarrito)
        {
            if (producto == null || listaProductosCarrito.Count == 0) return 0;

            foreach (Producto item in listaProductosCarrito)
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
        public static bool AgregarProductoAlCarrito(Producto producto, int cantidadDeseada,List<Producto> listaProductosDelCarrito)
        {
            if (producto != null || cantidadDeseada > 0)
            {
                Producto productoEnCarrito = listaProductosDelCarrito.Find(p => p.Nombre == producto.Nombre);

                if (productoEnCarrito != null)
                {
                    productoEnCarrito.CantidadDeseada += cantidadDeseada;
                    productoEnCarrito.StockDisponible -= cantidadDeseada;
                }
                else
                {
                    producto.StockDisponible -= cantidadDeseada;
                    producto.CantidadDeseada = cantidadDeseada;
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
                    productoEnCarrito.CantidadDeseada -= cantidad;
                    producto.StockDisponible = productoEnCarrito.StockDisponible;
                    producto.CantidadDeseada = productoEnCarrito.CantidadDeseada;
                }
                return true;
            }
            return false;
        }
    }
}
