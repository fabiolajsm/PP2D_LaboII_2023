﻿using System;
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
            new Usuario("julia@gmail.com", "contra", TipoUsuario.Cliente),
            new Usuario("pepe@gmail.com", "1234", TipoUsuario.Cliente),
            new Usuario("petunia@gmail.com", "jejeje", TipoUsuario.Vendedor),
            new Usuario("roberto@gmail.com", "5000", TipoUsuario.Vendedor),
        };
        public static List<Vendedor> listaVendedores = new List<Vendedor>()    
        {
            new Vendedor("petunia@gmail.com", "jejeje", TipoUsuario.Vendedor),
            new Vendedor("roberto@gmail.com", "5000", TipoUsuario.Vendedor),
        };
        public static List<Cliente> listaClientes = new List<Cliente>()
        {
            new Cliente("julia@gmail.com", "contra", TipoUsuario.Cliente),
            new Cliente("pepe@gmail.com", "1234", TipoUsuario.Cliente),
        };
    }
}
