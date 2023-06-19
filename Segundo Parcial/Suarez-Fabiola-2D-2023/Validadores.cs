using Entidades;
using System.Reflection;

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
            if (string.IsNullOrWhiteSpace(email))
            {
                error_email.Text = "⚠ Debe ingresar Email";
                error_email.Visible = true;
                return false;
            }
            else if (!email.EsFormatoEmail())
            {
                error_email.Text = $"⚠ Por favor ingresar un Email válido (Ej: lola@gmail.com)";
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
        /// <param name="id">Id del producto a seleccionado</param>
        /// <param name="cantidadIngresada">Cantidad de producto ingresado</param>
        /// <param name="esAgregarAlCarrito">Indica si es para agregar al carrito en vez de para eliminar del carrito</param>
        /// <returns>Retorna True si son válidos y False de lo contrario</returns>
        public static bool ValidarCamposParaModificarCarrito(int id, int cantidadIngresada, bool esAgregarAlCarrito, List<Producto> productos, List<Producto> productosCarrito)
        {
            if (productos.Count == 0) return false;
            Producto? producto = Producto.ObtenerProductoPorId(id, productos);
            double stockDisponible = producto.StockDisponible;

            if (id < 1 && cantidadIngresada < 1)
            {
                MessageBox.Show("Debe seleccionar un producto e ingresar cantidad.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (id < 1)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cantidadIngresada < 1)
            {
                MessageBox.Show($"Debe ingresar una cantidad mayor a {cantidadIngresada} gramos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (stockDisponible < cantidadIngresada & esAgregarAlCarrito)
            {
                MessageBox.Show($"Lo sentimos, sólo nos quedan {stockDisponible} gr, del producto seleccionado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!esAgregarAlCarrito & Producto.ExisteProductoEnELCarrito(producto.Id, productosCarrito) == false)
            {
                MessageBox.Show($"No se encontró producto en el carrito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!esAgregarAlCarrito && Producto.ObtenerCantidadProductoDelCarrito(producto, productosCarrito) < cantidadIngresada)
            {
                MessageBox.Show($"No se puede eliminar más de la cantidad del producto agregado al carrito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Valida si el campo que se va a modificar tiene un valor ingresado válido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nombreAtributo">Nombre del atributo que se va a validar</param>
        /// <param name="valorIngresado">Valor a validar</param>
        /// <param name="productoSeleccionado">Producto seleccionado a modificar</param>
        /// <returns>Retorna True si se ingresó un valor válido y False si no</returns>
        public static bool ValidarCampoAModificar<T>(string nombreAtributo, T valorIngresado, Producto productoSeleccionado)
        {
            if (string.IsNullOrEmpty(nombreAtributo) || valorIngresado == null || productoSeleccionado == null)
                return false;

            switch (nombreAtributo.ToLower())
            {
                case "precio":
                    double nuevoPrecio;
                    if (!double.TryParse(valorIngresado.ToString(), out nuevoPrecio) || nuevoPrecio < 0)
                    {
                        MessageBox.Show("Debe ingresar un precio válido mayor o igual a 0.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (nuevoPrecio == productoSeleccionado.PrecioPorKilo)
                    {
                        MessageBox.Show("El nuevo precio ingresado es igual al precio actual.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;

                case "stock":
                    double nuevoStock;
                    if (!double.TryParse(valorIngresado.ToString(), out nuevoStock) || nuevoStock < 0)
                    {
                        MessageBox.Show("Debe ingresar un stock válido mayor o igual a 0.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (nuevoStock == productoSeleccionado.StockDisponible)
                    {
                        MessageBox.Show("El nuevo stock ingresado es igual al stock actual.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;

                case "tipo de corte":
                    string nuevoTipoCorte = valorIngresado.ToString().Trim();
                    if (string.IsNullOrEmpty(nuevoTipoCorte))
                    {
                        MessageBox.Show("Debe ingresar un tipo de corte válido.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (nuevoTipoCorte.ToLower() == productoSeleccionado.TipoCorte.ToLower())
                    {
                        MessageBox.Show("El nuevo tipo de corte ingresado es igual al tipo de corte actual.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;
                default:
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Valida todos los campos de un prodcuto antes de agregarlo a la lista
        /// </summary>
        /// <param name="nombre">Nombre del producto</param>
        /// <param name="descripcion">Descripción del producto</param>
        /// <param name="corte">Tipo de corte del producto</param>
        /// <param name="precioString">Precio por kilo del producto</param>
        /// <param name="stockString">Stock disponible del producto</param>
        /// <returns>Retorna True si los campos son válidos y False si no</returns>
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