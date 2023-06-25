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
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int CantidadComprada { get; set; }
        public string MetodoDePago { get; set; }
        public double Precio { get; set; }
        public double Recargo { get; set; }
        public double PrecioFinal { get; set; }

        public Factura(string tipoDeCompra, int idProducto, string nombreProducto, int idCliente, string nombreCliente, int cantidadComprada, string metodoDePago, double precio, double recargo)
        {
            TipoDeCompra = tipoDeCompra;
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            IdCliente = idCliente;
            NombreCliente = nombreCliente;
            CantidadComprada = cantidadComprada;
            MetodoDePago = metodoDePago;
            Precio = precio;
            Recargo = recargo;
            PrecioFinal = Precio + Recargo;
        }
        /// <summary>
        /// Agrega facturas a la lista de historial de facturas
        /// </summary>
        /// <param name="listaHistorialDeFacturas">Lista de facturas a agregar a historial</param>
        /// <returns>Retorna True si se agregaron y False si no</returns>
        public static bool AgregarFacturasAlHistorial(List<Factura> listaFacturas)
        {
            if (listaFacturas.Count == 0) return false;
            return ArchivoHistorialVentas.EscribirHistorialVentas(listaFacturas);
        }
    }
}
