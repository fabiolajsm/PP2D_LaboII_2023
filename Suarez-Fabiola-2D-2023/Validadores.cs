using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Suarez_Fabiola_2D_2023
{
    public static class Validadores
    {
        /// <summary>
        /// Valida el formato de un Email
        /// </summary>
        /// <param name="email">Email a validar</param>
        /// <param name="error_email">Control de error de email</param>
        /// <returns>Retorna True si es válido y False si no</returns>
        public static bool ValidarFormatoEmail(string email, System.Windows.Forms.Label error_email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(emailPattern);
            if (string.IsNullOrWhiteSpace(email))
            {
                error_email.Text = "⚠ Debe ingresar Email";
                error_email.Visible = true;
                return false;
            }
            else if (!regex.IsMatch(email))
            {
                error_email.Text = $"⚠ Email no existente. Por favor ingresar un Email válido (Ej: lola@gmail.com)";
                error_email.Visible = true;
                return false;
            }
            else
            {
                error_email.Visible = false;
                return true;
            }
        }
        /// <summary>
        /// Valida el formato de una Contraseña 
        /// </summary>
        /// <param name="contraseña">Contraseña a validar</param>
        /// <param name="error_contraseña">Control de error de contraseña</param>
        /// <returns>Retorna True si es válido y False si no</returns>
        public static bool ValidarFormatoContraseña(string contraseña, System.Windows.Forms.Label error_contraseña)
        {
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                error_contraseña.Visible = true;
                return false;
            }
            else
            {
                error_contraseña.Visible = false;
                return true;
            }
        }
        /// <summary>
        /// Valida los campos ListBox y TextBox del Gb_ListaDeProductos y devuelve un mensaje de error de no ser válidos
        /// </summary>
        /// <param name="indexProducto">Index del producto a buscar en la lista</param>
        /// <param name="cantidadIngresada">Cantidad de producto ingresado</param>
        /// <param name="esAgregarAlCarrito">Indica si es para agregar al carrito en vez de para eliminar del carrito</param>
        /// <returns>Retorna True si son válidos y False de lo contrario</returns>
        public static bool ValidarCamposParaModificarCarrito(int indexProducto, int cantidadIngresada, bool esAgregarAlCarrito, List<Producto> productos)
        {
            if (productos.Count == 0) return false;
            double stockDisponible = Producto.ObtenerPropiedadProducto<double>(indexProducto, p => p.StockDisponible, productos);

            if (indexProducto < 0 && cantidadIngresada < 1)
            {
                Utilidades.MostrarError("Debe seleccionar un producto e ingresar cantidad.");
                return false;
            }
            if (indexProducto < 0)
            {
                Utilidades.MostrarError("Debe seleccionar un producto de la lista.");
                return false;
            }
            if (cantidadIngresada < 1)
            {
                Utilidades.MostrarError($"Debe ingresar una cantidad mayor a {cantidadIngresada} gramos.");
                return false;
            }
            if (stockDisponible < cantidadIngresada & esAgregarAlCarrito)
            {
                Utilidades.MostrarError($"Lo sentimos, sólo nos quedan {stockDisponible} gr, del producto seleccionado");
                return false;
            }
            if (!esAgregarAlCarrito & Producto.ExisteProductoEnELCarrito(productos[indexProducto].Nombre, productos) == false)
            {
                Utilidades.MostrarError($"No se encontró producto en el carrito");
                return false;
            }
            if (!esAgregarAlCarrito && Producto.ObtenerCantidadProductoDelCarrito(productos[indexProducto], DatosEnMemoria.listaProductosDelCarrito) < cantidadIngresada)
            {
                Utilidades.MostrarError($"No se puede eliminar más de la cantidad del producto agregado al carrito");
                return false;
            }

            return true;
        }
        /// <summary>
        /// Valida el tipo de corte y muestra un mensaje de error si no es válido
        /// </summary>
        /// <param name="indexProducto">Index del producto a buscar en la lista</param>
        /// <param name="corteIngresado">Tipo de corte ingresado a validar</param>
        /// <param name="productos">Lista de productos</param>
        /// <returns>Retorna True si es válidos y False si no</returns>
        public static bool ValidarCampoTipoDeCorte(int indexProducto, string corteIngresado, List<Producto> productos)
        {
            if (productos.Count == 0) return false;
            string tipoCorteProducto = Producto.ObtenerPropiedadProducto<string>(indexProducto, p => p.TipoCorte, productos);

            if (indexProducto < 0 && string.IsNullOrEmpty(corteIngresado))
            {
                Utilidades.MostrarError("Debe seleccionar un producto e ingresar un tipo de corte.");
                return false;
            }
            else if (indexProducto < 0)
            {
                Utilidades.MostrarError("Debe seleccionar un producto de la lista.");
                return false;
            }
            else if (string.IsNullOrEmpty(corteIngresado))
            {
                Utilidades.MostrarError("Debe ingresar un tipo de corte.");
                return false;
            }
            else if (corteIngresado == tipoCorteProducto)
            {
                Utilidades.MostrarError($"No hay cambios en el tipo de corte. El corte ingresado es igual al corte actual.");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Valida el precio y muestra un mensaje de error si no es válido
        /// </summary>
        /// <param name="indexProducto">Index del producto a buscar en la lista</param>
        /// <param name="precio">Precio ingresado a validar</param>
        /// <param name="productos">Lista de productos</param>
        /// <returns>Retorna True si es válidos y False si no</returns>
        public static bool ValidarCampoPrecio(int indexProducto, double precio, List<Producto> productos)
        {
            if (productos.Count == 0) return false;
            double precioProducto = Producto.ObtenerPropiedadProducto<double>(indexProducto, p => p.PrecioPorKilo, productos, precio);


            if (indexProducto < 0 & precio < 0)
            {
                Utilidades.MostrarError("Debe seleccionar un producto de la lista e ingresar un precio mayor o igual a cero.");
                return false;
            }
            else if (indexProducto < 0)
            {
                Utilidades.MostrarError("Debe seleccionar un producto de la lista.");
                return false;
            }
            else if (precio < 0)
            {
                Utilidades.MostrarError("Debe ingresar un precio mayor o igual a cero.");
                return false;
            }
            else if (precioProducto == precio)
            {
                Utilidades.MostrarError($"No hay cambios en el precio. El precio ingresado es igual al precio actual.");
                return false;
            }

            return true;
        }
        /// <summary>
        /// Valida el stock ingresado y muestra un mensaje de error si no es válido
        /// </summary>
        /// <param name="indexProducto">Index del producto a buscar en la lista</param>
        /// <param name="corteIngresado">Stock ingresado a validar</param>
        /// <param name="productos">Lista de productos</param>
        /// <returns>Retorna True si es válidos y False si no</returns>
        public static bool ValidarCampoStock(int indexProducto, int cantidadIngresada, List<Producto> productos)
        {
            if (productos.Count == 0) return false;
            double stockDisponible = Producto.ObtenerPropiedadProducto<double>(indexProducto, p => p.StockDisponible, productos);

            if (indexProducto < 0 && cantidadIngresada < 0)
            {
                Utilidades.MostrarError("Debe seleccionar un producto e ingresar una cantidad mayor o igual a cero.");
                return false;
            }
            else if (indexProducto < 0)
            {
                Utilidades.MostrarError("Debe seleccionar un producto de la lista.");
                return false;
            }
            else if (cantidadIngresada < 0)
            {
                Utilidades.MostrarError($"Debe ingresar una cantidad mayor a cero gramos y sin decimales.");
                return false;
            }
            else if (stockDisponible == cantidadIngresada)
            {
                Utilidades.MostrarError($"No hay cambios en el stock. La cantidad ingresada es igual al stock disponible actual.");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="corte"></param>
        /// <param name="precioString"></param>
        /// <param name="stockString"></param>
        /// <returns></returns>
        public static bool ValidarCamposAgregarProducto(string nombre, string descripcion, string corte, string precioString, string stockString)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(corte) || string.IsNullOrEmpty(precioString) || string.IsNullOrEmpty(stockString))
            {
                MessageBox.Show("Todos los campos son requeridos y deben ser válidos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(precioString, out double precio))
            {
                MessageBox.Show($"Debe ingresar un precio válido.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(stockString, out double stock))
            {
                MessageBox.Show($"Debe ingresar un stock válido.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (precio < 0)
            {
                MessageBox.Show("Debe ingresar un precio mayor o igual a cero.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (stock < 0)
            {
                MessageBox.Show("Debe ingresar un stock mayor o igual a cero.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
