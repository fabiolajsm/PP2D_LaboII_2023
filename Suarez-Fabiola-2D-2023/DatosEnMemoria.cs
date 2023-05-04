using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suarez_Fabiola_2D_2023.eTipoUsuario;

namespace Suarez_Fabiola_2D_2023
{
    public static class DatosEnMemoria
    {
        public static List<Usuario> listaUsuarios = new List<Usuario>()
        {
            new Usuario("Julia", "Lopez", "julia@gmail.com", "contra", TipoUsuario.Cliente),
            new Usuario("Pepe", "Rana", "pepe@gmail.com", "1234", TipoUsuario.Cliente),
            new Usuario("Petunia", "Mostaza", "petunia@gmail.com", "jejeje", TipoUsuario.Vendedor),
            new Usuario("Roberto", "Yalo", "roberto@gmail.com", "5000", TipoUsuario.Vendedor),
        };
        public static List<Vendedor> listaVendedores = new List<Vendedor>()
        {
            new Vendedor("Petunia", "Mostaza", "petunia@gmail.com", "jejeje", TipoUsuario.Vendedor),
            new Vendedor("Roberto", "Yalo", "roberto@gmail.com", "5000", TipoUsuario.Vendedor),
        };
        public static List<Cliente> listaClientes = new List<Cliente>()
        {
            new Cliente("Julia", "Lopez", "julia@gmail.com", "contra", TipoUsuario.Cliente),
            new Cliente("Pepe", "Rana", "pepe@gmail.com", "1234", TipoUsuario.Cliente),
        };
        public static List<Producto> listaProductos = new List<Producto>()
        {
            new Producto("Bistec de soja", "Corte de proteína de soja con sabor a carne", "Bistec", 1000, 0),
            new Producto("Filete", "Corte de proteína de trigo con textura similar a la carne", "Filete", 710, 2000),
            new Producto("Filete de tempeh", "Corte de proteína de soja fermentada con sabor a nuez", "Filete", 500.99, 4000),
            new Producto("Chorizo vegano", "Corte de proteína vegetal con sabor a chorizo", "Chorizo", 900, 1000),
            new Producto("Carne de lentejas", "Corte de lentejas cocidas y condimentadas con sabor a carne", "Lentejas", 2000, 5000),
        };
        public static List<Producto> listaProductosDelCarrito = new List<Producto>();

        public static bool AgregarProductoAlCarrito(Producto producto)
        {
            if (producto != null)
            {
                Producto productoEnCarrito = listaProductosDelCarrito.Find(p => p.Nombre == producto.Nombre);

                if (productoEnCarrito != null)
                {
                    productoEnCarrito.CantidadDeseada += producto.CantidadDeseada;
                }
                else
                {
                    listaProductosDelCarrito.Add(producto);
                }

                return true;
            }

            return false;
        }

        public static bool EliminarProductoDelCarrito(Producto producto, int cantidad)
        {
            if (producto == null || cantidad <= 0)  return false;

              
            Producto productoEnCarrito = listaProductosDelCarrito.Find(p => p.Nombre == producto.Nombre);

            if(productoEnCarrito != null)
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

        public static bool ExisteProductoEnELCarrito(Producto producto)
        {
            if (producto == null)
            {
                return false;
            }

            foreach (Producto prod in listaProductosDelCarrito)
            {
                if (prod.Nombre == producto.Nombre)
                {
                    return true;
                }
            }

            return false;
        }

        public static int ObtenerCantidadProductoDelCarrito(Producto producto)
        {
            if(producto == null) return 0;

            foreach (Producto item in listaProductosDelCarrito)
            {
                if(item.Nombre == producto.Nombre)
                {
                    return item.CantidadDeseada;
                }
            }
            return 0;
        }
    }
}
