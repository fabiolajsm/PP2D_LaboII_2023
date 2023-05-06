using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suarez_Fabiola_2D_2023.eTipoUsuario;

namespace Suarez_Fabiola_2D_2023
{
    public class Cliente : Usuario
    {
        public float MontoMaximoDeCompra { get; set; }

        public Cliente() { }

        public Cliente(string nombre, string apellido, string email, string contrasena, TipoUsuario tipoDeUsuario, float montoMaximo)
           : base(nombre, apellido, email, contrasena, tipoDeUsuario)
        {
            this.MontoMaximoDeCompra = montoMaximo;
        }
    }
}
