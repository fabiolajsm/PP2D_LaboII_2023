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
        public double StockDisponible { get; set; }
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

        public static double ObtenerPrecioProducto(int indexProducto, List<Producto> listaProductos)
        {
            if(indexProducto >= 0)
            {
                for(int i = 0; i < listaProductos.Count; i++)
                {                   
                    return listaProductos[indexProducto].PrecioPorKilo;
                }
            }
            return 0;
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
    }
}
