using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suarez_Fabiola_2D_2023
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

        public static double ObtenerStockDisponible(int indexProducto, int cantidad, List<Producto> listaProductos)
        {
            if (indexProducto >= 0 & cantidad >= 0)
            {
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    Producto productoSeleccionado = listaProductos[indexProducto];
                    return productoSeleccionado.StockDisponible;
                }
            }
            return 0;
        }
        public static double ObtenerPrecioProducto(int indexProducto, double precio, List<Producto> listaProductos)
        {
            if (indexProducto >= 0 & precio >= 0)
            {
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    Producto productoSeleccionado = listaProductos[indexProducto];
                    return productoSeleccionado.PrecioPorKilo;
                }
            }
            return 0;
        }

        public static string ObtenerCorteProducto(int indexProducto, string tipoCorte, List<Producto> listaProductos)
        {
            if (indexProducto >= 0 & !string.IsNullOrEmpty(tipoCorte))
            {
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    Producto productoSeleccionado = listaProductos[indexProducto];
                    return productoSeleccionado.TipoCorte;
                }
            }
            return string.Empty;
        }

        public static double CalcularPrecio(int cantidadIngresadaEnGramos, double precioPorKilo)
        {
            double cantidadEnKilos = (double)cantidadIngresadaEnGramos / 1000; // Convertir la cantidad a kilos
            double precioTotal = 0; 
            if(cantidadIngresadaEnGramos> 0 & precioPorKilo > 0)
            {
                precioTotal = cantidadEnKilos * precioPorKilo;
            }
            return precioTotal;
        }

        public static bool ModificarStockDisponible(int nuevoStock, int indexProducto, List<Producto> listaProductos)
        {
            bool seModifico = false;
            if (indexProducto >= 0 && nuevoStock >= 0)
            {
                for (int i = 0; i < listaProductos.Count; i++)
                {                    
                    listaProductos[indexProducto].StockDisponible = nuevoStock;
                }
                seModifico = true;
            }
            return seModifico;
        }
        public static bool ModificarPrecioProducto(double nuevoPrecio, int indexProducto, List<Producto> listaProductos)
        {
            bool seModifico = false;
            if (indexProducto >= 0 && nuevoPrecio >= 0)
            {
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    listaProductos[indexProducto].PrecioPorKilo = nuevoPrecio;
                }
                seModifico = true;
            }
            return seModifico;
        }
        public static bool ModificarTipoDeCorteProducto(string nuevoCorte, int indexProducto, List<Producto> listaProductos)
        {
            bool seModifico = false;
            if (indexProducto >= 0 && !string.IsNullOrEmpty(nuevoCorte))
            {
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    listaProductos[indexProducto].TipoCorte = Usuario.Capitalize(nuevoCorte);
                }
                seModifico = true;
            }
            return seModifico;
        }
        public static bool AgregarProductoALaLista(string nombre, string descripcion, string corte, double precio, double stock, List<Producto> listaProductos)
        {
            bool seModifico = false;
            Producto nuevoProducto = new Producto(nombre, descripcion, corte, precio, stock);

            if (nuevoProducto != null)
            {
                listaProductos.Add(nuevoProducto);
                seModifico = true;
            }

            return seModifico;
        }
    }
}
