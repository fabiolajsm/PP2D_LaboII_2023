using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suarez_Fabiola_2D_2023.eTipoUsuario;


namespace Suarez_Fabiola_2D_2023
{
    public class Vendedor : Usuario
    {    
        public int CantidadVendida { get; set; }

        public Vendedor(string nombre, string apellido, string email, string contrasena, TipoUsuario tipoDeUsuario)
            : base(nombre, apellido, email, contrasena, tipoDeUsuario)
        {
            CantidadVendida = 0;
        }
        public Vendedor(string nombre, string apellido, string email, string contrasena, TipoUsuario tipoDeUsuario, int cantidadVendida) 
            : base(nombre, apellido, email, contrasena, tipoDeUsuario)
        {
            CantidadVendida = cantidadVendida;
        }
        /// <summary>
        /// Lógica para iniciar sesión de un vendedor
        /// </summary>
        public override void IniciarSesion()
        {
            FormHeladera formHeladera = new FormHeladera(this);
            formHeladera.Show();
        }
        /// <summary>
        /// Modifica la propiedad de un producto seleccionado en la lista de productos 
        /// </summary>
        /// <param name="indexProducto">Index del producto seleccionado</param>
        /// <param name="listaProductos">Lista de productos</param>
        /// <param name="nuevoStock">Si quiere modificar el stock, pasa el nuevo stock, del resto pasa un null</param>
        /// <param name="nuevoPrecio">Si quiere modificar el precio, pasa el nuevo precio, del resto pasa un null</param>
        /// <param name="nuevoCorte">Si quiere modificar el tipo de corte, pasa el nuevo tipo de corte, del resto pasa un string vacío</param>
        /// <returns></returns>
        public static bool ModificarProducto(int indexProducto, List<Producto> listaProductos, int? nuevoStock = null, double? nuevoPrecio = null, string nuevoCorte = "")
        {
            bool seModifico = false;

            if (indexProducto >= 0)
            {
                Producto productoSeleccionado = listaProductos[indexProducto];
                if (nuevoStock != null)
                {
                    productoSeleccionado.StockDisponible = nuevoStock.Value;
                    seModifico = true;
                }
                if (nuevoPrecio != null)
                {
                    productoSeleccionado.PrecioPorKilo = nuevoPrecio.Value;
                    seModifico = true;
                }
                if (!string.IsNullOrEmpty(nuevoCorte))
                {
                    productoSeleccionado.TipoCorte = Utilidades.Capitalize(nuevoCorte);
                    seModifico = true;
                }
            }

            return seModifico;
        }
    }
}
