using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        public string TipoDeCompra { get; set; }
        public string NombreCliente { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadComprada { get; set; }
        public double Precio { get; set; }
        public double Recargo { get; set; }
        public double PrecioFinal { get; set; }

        public Factura(string tipoDeCompra, string nombreCliente, string nombreProducto, int cantidadComprada, double precio, double recargo)
        {
            TipoDeCompra = tipoDeCompra;
            NombreCliente = nombreCliente;
            NombreProducto = nombreProducto;
            CantidadComprada = cantidadComprada;
            Precio = precio;
            Recargo = recargo;
            PrecioFinal = Precio + Recargo;
        }
        /// <summary>
        /// Agrega facturas a la lista de historial de facturas
        /// </summary>
        /// <param name="listaHistorialDeFacturas">Lista de facturas a agregar a historial</param>
        /// <param name="listaHistorialVentas">Lista de en donde se van a agregar las facturas</param>
        /// <returns>Retorna True si se agregaron y False si no</returns>
        public static bool AgregarFacturasAlHistorial(List<Factura> listaFacturas, List<Factura> listaHistorialVentas)
        {
            if (listaFacturas.Count == 0) return false;
            foreach (Factura factura in listaFacturas)
            {
                if (factura != null)
                {
                    DatosEnMemoria.AgregarFacturaAHistorial(factura);
                }
            }
            return true;
        }
    }
}
