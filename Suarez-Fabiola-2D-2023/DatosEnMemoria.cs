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
            new Producto("Bistec de soja", "Corte de proteína de soja con sabor a carne", "Bistec", 12, 0),
            new Producto("Seitan", "Corte de proteína de trigo con textura similar a la carne", "Seitan", 10.99, 15),
            new Producto("Filete de tempeh", "Corte de proteína de soja fermentada con sabor a nuez", "Filete", 99.9, 12),
            new Producto("Chorizo vegano", "Corte de proteína vegetal con sabor a chorizo", "Chorizo", 799, 30),
            new Producto("Carne de lentejas", "Corte de lentejas cocidas y condimentadas con sabor a carne", "Lentejas", 300, 25),
        };
        public static List<Producto> listaProductosDelCarrito = new List<Producto>();

        public static bool AgregarProductoAlCarrito(Producto producto)
        {
            if(producto != null)
            {
                listaProductosDelCarrito.Add(producto);
                return true;
            }
            return false;
        }
    }     
}
