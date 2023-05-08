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
        public static bool ValidarCampoTipoDeCorte(int indexProducto, string corteIngresado, List<Producto> productos)
        {
            if (productos.Count == 0) return false;
            if (indexProducto < 0 && string.IsNullOrEmpty(corteIngresado))
            {
                MessageBox.Show("Debe seleccionar un producto e ingresar un tipo de corte.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (indexProducto < 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(corteIngresado))
            {
                MessageBox.Show("Debe ingresar un tipo de corte.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (corteIngresado == Producto.ObtenerCorteProducto(indexProducto, corteIngresado, productos))
            {
                MessageBox.Show($"No hay cambios en el tipo de corte. El corte ingresado es igual al corte actual.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public static bool ValidarCampoPrecio(int indexProducto, double precio, List<Producto> productos)
        {
            if(productos.Count == 0) return false;

            if (indexProducto < 0 & precio < 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista e ingresar un precio mayor o igual a cero.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (indexProducto < 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false;
            }
            else if (precio < 0)
            {
                MessageBox.Show("Debe ingresar un precio mayor o igual a cero.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (Producto.ObtenerPrecioProducto(indexProducto, precio, productos) == precio)
            {
                MessageBox.Show($"No hay cambios en el precio. El precio ingresado es igual al precio actual.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false;
            }

            return true;
        }
        public static bool ValidarCampoStock(int indexProducto, int cantidadIngresada, List<Producto> productos)
        {
            if (productos.Count == 0) return false;

            if (indexProducto < 0 && cantidadIngresada < 0)
            {
                MessageBox.Show("Debe seleccionar un producto e ingresar una cantidad mayor o igual a cero.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false;
            }
            else if (indexProducto < 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false;
            }
            else if (cantidadIngresada < 0)
            {
                MessageBox.Show($"Debe ingresar una cantidad mayor a cero gramos y sin decimales.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false;
            }
            else if (Producto.ObtenerStockDisponible(indexProducto, cantidadIngresada, productos) == cantidadIngresada)
            {
                MessageBox.Show($"No hay cambios en el stock. La cantidad ingresada es igual al stock disponible actual.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false;
            }
            return true;
        }
    }
}
