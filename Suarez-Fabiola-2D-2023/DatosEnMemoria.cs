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
        public static List<Producto> listaProductos = new List<Producto>()
        {
            new Producto("Bistec de soja", "Corte de proteína de soja con sabor a carne", "Bistec", 1000, 0),
            new Producto("Filete", "Corte de proteína de trigo con textura similar a la carne", "Filete", 710, 2000),
            new Producto("Filete de tempeh", "Corte de proteína de soja fermentada con sabor a nuez", "Filete", 500.99, 4000),
            new Producto("Chorizo vegano", "Corte de proteína vegetal con sabor a chorizo", "Chorizo", 900, 1000),
            new Producto("Carne de lentejas", "Corte de lentejas cocidas y condimentadas con sabor a carne", "Lentejas", 2000, 5000),
        };
        public static List<Usuario> listaUsuarios = new List<Usuario>()
        {
            new Cliente("Julia", "Lopez", "julia@gmail.com", "contra", TipoUsuario.Cliente, 0),
            new Cliente("Pepe", "Rana", "pepe@gmail.com", "1234", TipoUsuario.Cliente, 0),
            new Vendedor("Petunia", "Mostaza", "petunia@gmail.com", "jejeje", TipoUsuario.Vendedor, 0),
            new Vendedor("Roberto", "Yalo", "roberto@gmail.com", "5000", TipoUsuario.Vendedor, 0),
        };
        public static List<Vendedor> listaVendedores = new List<Vendedor>()
        {
            new Vendedor("Petunia", "Mostaza", "petunia@gmail.com", "jejeje", TipoUsuario.Vendedor, 0),
            new Vendedor("Roberto", "Yalo", "roberto@gmail.com", "5000", TipoUsuario.Vendedor, 0),
        };
        public static List<Cliente> listaClientes = new List<Cliente>()
        {
            new Cliente("Julia", "Lopez", "julia@gmail.com", "contra", TipoUsuario.Cliente, 0),
            new Cliente("Pepe", "Rana", "pepe@gmail.com", "1234", TipoUsuario.Cliente, 2000),
        };        
        public static List<Producto> listaProductosDelCarrito = new List<Producto>();
    }
}
