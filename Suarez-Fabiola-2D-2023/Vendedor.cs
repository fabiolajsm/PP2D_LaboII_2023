﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suarez_Fabiola_2D_2023.eTipoUsuario;


namespace Suarez_Fabiola_2D_2023
{
    public class Vendedor : Usuario
    {
        public Vendedor(string nombre, string apellido, string email, string contrasena, TipoUsuario tipoDeUsuario) 
            : base(nombre, apellido, email, contrasena, tipoDeUsuario)
        {
        }
    }
}
