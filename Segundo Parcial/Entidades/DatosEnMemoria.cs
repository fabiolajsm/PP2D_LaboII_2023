using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class DatosEnMemoria
    {
        private static readonly List<Producto> listaProductos = new List<Producto>()   
        {
            new Producto(1,"Bistec de soja", "Corte de proteína de soja con sabor a carne", "Bistec", 1000, 0),
            new Producto(2,"Filete", "Corte de proteína de trigo con textura similar a la carne", "Filete", 710, 2000),
            new Producto(3,"Filete de tempeh", "Corte de proteína de soja fermentada con sabor a nuez", "Filete", 500.99, 4000),
            new Producto(4,"Chorizo vegano", "Corte de proteína vegetal con sabor a chorizo", "Chorizo", 900, 1000),
            new Producto(5,"Carne de lentejas", "Corte de lentejas cocidas y condimentadas con sabor a carne", "Lentejas", 2000, 5000),
        };
        private static readonly List<Usuario> listaUsuarios = new List<Usuario>()   
        {
            new Cliente("Julia", "Lopez", "julia@gmail.com", "contra", 0),
            new Cliente("Pepe", "Rana", "pepe@gmail.com", "1234", 0),
            new Vendedor("Petunia", "Mostaza", "petunia@gmail.com", "jejeje", 0),
            new Vendedor("Roberto", "Yalo", "roberto@gmail.com", "5000", 0),
    
        };
        private static readonly List<Vendedor> listaVendedores = new List<Vendedor>()   
        {
            new Vendedor("Petunia", "Mostaza", "petunia@gmail.com", "jejeje", 0),
            new Vendedor("Roberto", "Yalo", "roberto@gmail.com", "5000", 0),
   
        };
        private static readonly List<Cliente> listaClientes = new List<Cliente>()   
        {
            new Cliente("Julia", "Lopez", "julia@gmail.com", "contra", 0),
            new Cliente("Pepe", "Rana", "pepe@gmail.com", "1234", 2000),
    
        };
        private static readonly List<Factura> HistorialVentas = new List<Factura>();
        /// <summary>
        /// Obtiene una copia de la lista de usuarios en los Datos en memoria
        /// </summary>
        /// <returns>List<Usuario> copia de la lista de usuarios</returns>
        public static List<Usuario> ObtenerListaUsuarios()
        {
            return new List<Usuario>(listaUsuarios);
        }
        /// <summary>
        /// Obtiene una copia de la lista de vendedores en los Datos en memoria
        /// </summary>
        /// <returns>List<Vendedor> copia de la lista de vendedores</returns>
        public static List<Vendedor> ObtenerListaVendedores()
        {
            return new List<Vendedor>(listaVendedores);
        }
        /// <summary>
        /// Obtiene una copia de la lista de clientes en los Datos en memoria
        /// </summary>
        /// <returns>List<Cliente> copia de la lista de clientes</returns>
        public static List<Cliente> ObtenerListaClientes()
        {
            return new List<Cliente>(listaClientes);
        }
        /// <summary>
        /// Obtiene una copia de la lista de facturas(historial de ventas) en los Datos en memoria
        /// </summary>
        /// <returns>List<Factura> copia de la lista de facturas</returns>
        public static List<Factura> ObtenerHistorialVentas()
        {
            return new List<Factura>(HistorialVentas);
        }
        /// <summary>
        /// Agrega una factura a la lista de facturas(historial de ventas)
        /// </summary>
        /// <param name="factura">Factura a agregar a la lista</param>
        public static void AgregarFacturaAHistorial(Factura factura)
        {
            HistorialVentas.Add(factura);
        }
        /// <summary>
        /// Agrega un producto a la lista de productos
        /// </summary>
        /// <param name="producto">Producto a agregar a la lista</param>
        public static void AgregarProducto(Producto producto)
        {
            listaProductos.Add(producto);
        }
    }
}
