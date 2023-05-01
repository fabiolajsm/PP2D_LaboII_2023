using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suarez_Fabiola_2D_2023
{
    public partial class AgregarAlCarrito : Form
    {
        float montoMaximoDeCompra;
        public AgregarAlCarrito(float montoDeCompra)
        {
            InitializeComponent();
            Lb_Productos.DrawMode = DrawMode.OwnerDrawFixed;
            Btn_Comprar.Enabled = false;
            CargarItemsProductos();
            CargarDatosDelCarrito(dataGridView, DatosEnMemoria.listaProductosDelCarrito);
            montoMaximoDeCompra = montoDeCompra;
        }

        private void CargarItemsProductos()
        {
            Lb_Productos.Items.Clear();
            foreach (Producto producto in DatosEnMemoria.listaProductos)
            {
                if (producto.StockDisponible > 0 & producto.CantidadDeseada == 0)
                {
                    Lb_Productos.Items.Add(producto);
                }
            }
            if (DatosEnMemoria.listaProductosDelCarrito.Count > 0)
            {
                Btn_Comprar.Enabled = true;
            }
        }
        private void CargarDatosDelCarrito(DataGridView dataGridView, List<Producto> listaProductos)
        {
            dataGridView.Rows.Clear();
            foreach (Producto producto in listaProductos)
            {
                double precioProducto = Producto.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo);
                if (precioProducto > 0 & producto.CantidadDeseada > 0)
                {
                    int rowIndex = dataGridView.Rows.Add();
                    DataGridViewRow row = dataGridView.Rows[rowIndex];
                    row.Cells["Nombre"].Value = producto.Nombre;
                    row.Cells["Precio"].Value = $"${precioProducto.ToString("0")}";
                    row.Cells["Cantidad"].Value = producto.CantidadDeseada;
                }
            }
        }

        private void Lb_Productos_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string nombreProducto = ((Producto)Lb_Productos.Items[e.Index]).Nombre;
            double precioPorKiloProducto = ((Producto)Lb_Productos.Items[e.Index]).PrecioPorKilo;

            Brush brush = SystemBrushes.WindowText;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                brush = SystemBrushes.GradientInactiveCaption;
            }

            // Calcular la posición y tamaño de las dos columnas
            int width = e.Bounds.Width;
            int col1Width = (int)(width * 0.6);
            int col2Width = width - col1Width;
            Rectangle col1Rect = new Rectangle(e.Bounds.X, e.Bounds.Y, col1Width, e.Bounds.Height);
            Rectangle col2Rect = new Rectangle(e.Bounds.X + col1Width, e.Bounds.Y, col2Width, e.Bounds.Height);

            // Dibujar el nombre del producto en la primera columna
            e.Graphics.DrawString(nombreProducto, e.Font, brush, col1Rect);

            // Dibujar el precio por kilo en la segunda columna
            string precioPorKiloTexto = String.Format("${0:N2}", precioPorKiloProducto);
            e.Graphics.DrawString(precioPorKiloTexto, e.Font, brush, col2Rect,
                new StringFormat() { Alignment = StringAlignment.Far });

            e.DrawFocusRectangle();
        }

        private void Btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        public bool ValidarCampos(int indexProducto, int cantidadIngresada, bool esAgregarAlCarrito)
        {
            List<Producto> productos = Lb_Productos.Items.Cast<Producto>().ToList();
            double stockDisponible = Producto.ObtenerStockDisponible(indexProducto, cantidadIngresada, productos);
            bool esValido = false;

            if (indexProducto < 0 && cantidadIngresada < 1)
            {
                MessageBox.Show("Debe seleccionar un producto e ingresar cantidad.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (indexProducto < 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cantidadIngresada < 1)
            {
                MessageBox.Show($"Debe ingresar una cantidad mayor a {cantidadIngresada} gramos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (stockDisponible < cantidadIngresada & esAgregarAlCarrito)
            {
                MessageBox.Show($"Lo sentimos, sólo nos quedan {stockDisponible} gr, del producto seleccionado", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (!esAgregarAlCarrito & !DatosEnMemoria.ExisteProductoEnELCarrito(productos[indexProducto])) { 
                MessageBox.Show($"No se encontró producto en el carrito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!esAgregarAlCarrito && DatosEnMemoria.ObtenerCantidadProductoDelCarrito(productos[indexProducto]) < cantidadIngresada)
            {
                MessageBox.Show($"No se puede eliminar más de la cantidad del producto agregado al carrito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                esValido = true;
            }

            return esValido;
        }
        private void Btn_AgregarAlCarrito_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_Productos.SelectedIndex;
            int cantidadIngresada = 0;
            try
            {
                if (!int.TryParse(Tb_Cantidad.Text, out cantidadIngresada))
                {
                    MessageBox.Show("Debe ingresar una cantidad válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Debe ingresar una cantidad válida");
            }

            List<Producto> productos = Lb_Productos.Items.Cast<Producto>().ToList();

            if (ValidarCampos(indexProducto, cantidadIngresada, true))
            {
                Producto productoSeleccionado = productos[indexProducto];
                // le restamos al stock disponible la cantidad ingresada:
                productoSeleccionado.StockDisponible -= cantidadIngresada;

                // Agregamos el producto a la lista de listaProductosDelCarrito
                Producto nuevoProducto = new Producto
                {
                    Nombre = productoSeleccionado.Nombre,
                    Descripcion = productoSeleccionado.Descripcion,
                    TipoCorte = productoSeleccionado.TipoCorte,
                    PrecioPorKilo = productoSeleccionado.PrecioPorKilo,
                    StockDisponible = productoSeleccionado.StockDisponible,
                    CantidadDeseada = cantidadIngresada
                };

                if (DatosEnMemoria.AgregarProductoAlCarrito(nuevoProducto))
                {
                    // Recargamos la lista de productos segun el stock disponible:
                    CargarItemsProductos();
                    MessageBox.Show($"Producto agregado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualizar precio final:
                    double precioPorKilo = Producto.ObtenerPrecioProducto(indexProducto, productos);
                    double precioProducto = Producto.CalcularPrecio(cantidadIngresada, precioPorKilo);
                    double precioFinal = double.Parse(Lb_Total.Text.Split(':')[1].Trim()) + precioProducto;

                    Lb_Total.Text = $"Total: {precioFinal.ToString("0")}";
                    CargarDatosDelCarrito(dataGridView, DatosEnMemoria.listaProductosDelCarrito);
                }
            }
        }
        private void Btn_EliminarDelCarrito_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_Productos.SelectedIndex;
            int cantidadIngresada = 0;
            try
            {
                if (!int.TryParse(Tb_Cantidad.Text, out cantidadIngresada))
                {
                    MessageBox.Show("Debe ingresar una cantidad válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Debe ingresar una cantidad válida");
            }

            if (ValidarCampos(indexProducto, cantidadIngresada, false))
            {
                List<Producto> productos = Lb_Productos.Items.Cast<Producto>().ToList();
                Producto productoSeleccionado = productos[indexProducto];
                
                // borramos el producto del carrito
                if (DatosEnMemoria.EliminarProductoDelCarrito(productoSeleccionado, cantidadIngresada))
                {
                    // le restamos al stock disponible la cantidad ingresada:
                    productoSeleccionado.StockDisponible += cantidadIngresada;
                    // recargamos la lista de productos segun el stock disponible:
                    CargarItemsProductos();
                    MessageBox.Show($"Producto eliminado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualizar precio final:
                    double precioPorKilo = Producto.ObtenerPrecioProducto(indexProducto, productos);
                    double precioProducto = Producto.CalcularPrecio(cantidadIngresada, precioPorKilo);
                    // le restamos el precio de lo ingresado
                    double precioActual = double.Parse(Lb_Total.Text.Split(':')[1].Trim());
                    double precioFinal = (precioActual <= 0 ? 0 : precioActual - precioProducto);
                    Lb_Total.Text = $"Total: {precioFinal.ToString("0")}";

                    // Actualizar el detalle del carrito
                    CargarDatosDelCarrito(dataGridView, DatosEnMemoria.listaProductosDelCarrito);
                }
                else
                {
                    MessageBox.Show($"No se encontró producto en el carrito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            Gb_ListaDeProductos.Enabled = false;
            float precioFinal = float.Parse(Lb_Total.Text.Split(':')[1].Trim());
            MetodoDePago metodoDePago = new MetodoDePago(montoMaximoDeCompra, precioFinal);
        }
    }
}
