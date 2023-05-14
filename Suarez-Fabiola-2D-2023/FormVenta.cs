using System;
using System.Data;
using Entidades;

namespace Suarez_Fabiola_2D_2023
{
    public partial class FormVenta : Form
    {
        private Cliente cliente;
        private bool esVendedor;
        private List<Producto> listaProductos = DatosEnMemoria.ObtenerListaProductos();
        public static List<Producto> listaProductosDelCarrito = new List<Producto>();
        private bool mostrarModalBienvenida;

        public FormVenta(Cliente cliente, bool esVendedor, bool mostrarBienvenida)
        {
            this.cliente = cliente ?? new Cliente();
            this.esVendedor = esVendedor;
            this.mostrarModalBienvenida = mostrarBienvenida;
            
            InitializeComponent();
            Lb_Productos.DrawMode = DrawMode.OwnerDrawFixed;
            InicializarItemsComboBox();
            CargarItemsProductos();
            CalcularPrecioTotal();
            CargarDatosDelCarrito(dataGridView);

            if (this.cliente.MontoMaximoDeCompra != 0)
            {
                Lb_MontoMaximo.Text = $"Su monto máximo de compra es de ${this.cliente.MontoMaximoDeCompra.ToString("#0.00")}";
            }
        }
        /// <summary>
        /// Cuando carga el form se le asignan estilos diferentes si es un Cliente o un Vendedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVenta_Load(object sender, EventArgs e)
        {
            if (esVendedor)
            {
                this.BackColor = Color.FromArgb(138, 121, 104);
                Gb_ListaDeProductos.BackColor = Color.FromArgb(211, 200, 187);
                Gb_CarritoDeCompra.BackColor = Color.FromArgb(211, 200, 187);
                Btn_VolverVendedor.Visible = true;
                Btn_ModificarMonto.Visible = false;
            }
            else
            {
                this.BackColor = Color.FromArgb(241, 247, 238);
                Gb_ListaDeProductos.BackColor = Color.FromArgb(176, 190, 169);
                Gb_CarritoDeCompra.BackColor = Color.FromArgb(176, 190, 169);
                Btn_VolverVendedor.Visible = false;
                Btn_ModificarMonto.Visible = true;
            }
        }
        /// <summary>
        /// Se cargan los diferentes cortes para el ComboBox Filtrar por corte
        /// </summary>
        private void InicializarItemsComboBox()
        {
            Cb_FiltrarPorCorte.Items.Clear();
            Cb_FiltrarPorCorte.Items.Add("Ver todos los tipos de corte");
            Cb_FiltrarPorCorte.SelectedIndex = 0;

            List<string> nombresCorte = listaProductos
                .Where(p => p.StockDisponible > 0 || (p.StockDisponible <= 0 && p.CantidadDeseada > 0))
                .Select(p => p.TipoCorte)
                .Distinct()
                .ToList();

            nombresCorte.ForEach(corte => Cb_FiltrarPorCorte.Items.Add(corte));
        }
        /// <summary>
        /// Se agregan los productos al ListBox para que se muestren
        /// </summary>
        private void CargarItemsProductos()
        {
            string corteSeleccionado = Cb_FiltrarPorCorte.SelectedItem?.ToString();
            Lb_Productos.Items.Clear();

            if (string.IsNullOrEmpty(corteSeleccionado) || corteSeleccionado == "Ver todos los tipos de corte")
            {
                foreach (Producto producto in listaProductos)
                {
                    if (producto.StockDisponible > 0 || (producto.StockDisponible <= 0 && producto.CantidadDeseada > 0))
                    {
                        Lb_Productos.Items.Add(producto);
                    }
                }
            }
            else
            {
                if (corteSeleccionado != "Ver todos los tipos de corte")
                {
                    Lb_Productos.Items.Clear();
                    List<Producto> productosFiltrados = listaProductos.Where(p => p.TipoCorte == corteSeleccionado).ToList();
                    foreach (Producto productoFiltrado in productosFiltrados)
                    {
                        Lb_Productos.Items.Add(productoFiltrado);
                    }
                }
            }
        }
        /// <summary>
        /// Calcula el precio total de la lista listaProductosDelCarrito y lo muestra
        /// </summary>
        private void CalcularPrecioTotal()
        {
            var precioTotal = listaProductosDelCarrito.Sum(producto => Utilidades.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo));
            Lb_Total.Text = $"Total: ${precioTotal:#0.00}";
        }
        /// <summary>
        /// Actualiza la lista de productos a mostrar en el dataGridView (lista donde se muestra el detalle del carrito de compra)
        /// </summary>
        /// <param name="dataGridView"></param>
        private void CargarDatosDelCarrito(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            foreach (Producto producto in listaProductosDelCarrito)
            {
                double precioProducto = Utilidades.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo);
                if (precioProducto > 0 & producto.CantidadDeseada > 0)
                {
                    int rowIndex = dataGridView.Rows.Add();
                    DataGridViewRow row = dataGridView.Rows[rowIndex];
                    row.Cells["Nombre"].Value = producto.Nombre;
                    row.Cells["Precio"].Value = $"${precioProducto.ToString("#0.00")}";
                    row.Cells["Cantidad"].Value = $"{producto.CantidadDeseada} gr";
                }
            }
        }
        /// <summary>
        /// Filtra los productos según el tipo de corte seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_FiltrarPorCorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            string corteSeleccionado = Cb_FiltrarPorCorte.SelectedItem?.ToString();
            List<Producto> productos = Lb_Productos.Items.Cast<Producto>().ToList();

            if (productos.Count > 0 && !string.IsNullOrEmpty(corteSeleccionado))
            {
                List<Producto> productosFiltrados = listaProductos
                    .Where(p => corteSeleccionado == "Ver todos los tipos de corte" || p.TipoCorte == corteSeleccionado)
                    .Where(p => p.StockDisponible > 0 || (p.StockDisponible <= 0 && p.CantidadDeseada > 0))
                    .ToList();

                Lb_Productos.Items.Clear();
                foreach (Producto productoFiltrado in productosFiltrados)
                {
                    Lb_Productos.Items.Add(productoFiltrado);
                }
            }
        }
        /// <summary>
        /// Dibuja los productos en el ListBox, mostrando el Nombre y el Precio por kilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Cierra la sesión del usuario y redirecciona al Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            LimpiarListaProductosCarrito();
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
        /// <summary>
        /// Agrega un producto a la lista listaProductosDelCarrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AgregarAlCarrito_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_Productos.SelectedIndex;
            int cantidadIngresada;

            if (!int.TryParse(Tb_Cantidad.Text, out cantidadIngresada))
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Producto> productos = Lb_Productos.Items.Cast<Producto>().ToList();

            if (Validadores.ValidarCamposParaModificarCarrito(indexProducto, cantidadIngresada, true, Lb_Productos.Items.Cast<Producto>().ToList(), listaProductosDelCarrito))
            {
                Producto productoSeleccionado = productos[indexProducto];

                if (Producto.AgregarProductoAlCarrito(productoSeleccionado, cantidadIngresada, listaProductosDelCarrito))
                {
                    // Recargamos la lista de productos segun el stock disponible:
                    CargarItemsProductos();
                    MessageBox.Show($"Producto agregado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CalcularPrecioTotal();
                    CargarDatosDelCarrito(dataGridView);
                }
            }
        }
        /// <summary>
        /// Elimina un producto de la lista listaProductosDelCarrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_EliminarDelCarrito_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_Productos.SelectedIndex;
            int cantidadIngresada;

            if (!int.TryParse(Tb_Cantidad.Text, out cantidadIngresada))
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Validadores.ValidarCamposParaModificarCarrito(indexProducto, cantidadIngresada, false, Lb_Productos.Items.Cast<Producto>().ToList(), listaProductosDelCarrito))
            {
                List<Producto> productos = Lb_Productos.Items.Cast<Producto>().ToList();
                Producto productoSeleccionado = productos[indexProducto];

                // borramos el producto del carrito
                if (Producto.EliminarProductoDelCarrito(productoSeleccionado, cantidadIngresada, listaProductosDelCarrito))
                {
                    // recargamos la lista de productos segun el stock disponible:
                    CargarItemsProductos();
                    MessageBox.Show($"Producto eliminado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CalcularPrecioTotal();
                    // Actualizar el detalle del carrito
                    CargarDatosDelCarrito(dataGridView);
                }
                else
                {
                    MessageBox.Show($"No se encontró producto en el carrito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Si el monto máximo de compra alcanza para comprar redirecciona al Metodo de pago
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            double precioFinal = double.Parse(Lb_Total.Text.Split('$')[1].Trim());
            if (cliente.MontoMaximoDeCompra == 0)
            {
                MessageBox.Show("No tiene monto máximo de compra/fondos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (precioFinal > cliente.MontoMaximoDeCompra)
            {
                MessageBox.Show("El precio supera el monto máximo de compra.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (precioFinal < 1)
            {
                MessageBox.Show("Para comprar necesita añadir productos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Hide();
                FormMetodoDePago metodoDePago = new FormMetodoDePago(precioFinal, cliente, esVendedor);
                metodoDePago.Show();
            }
        }
        /// <summary>
        /// Cierra el FormVenta y en el evento FormClosed abre/regresa a la página anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_VolverVendedor_Click(object sender, EventArgs e)
        {
            LimpiarListaProductosCarrito();
            this.Close();
        }
        /// <summary>
        /// Al momento de cerrar el FormVenta, abre la página abierta anteriormente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (esVendedor)
            {
                ElegirCliente elegirCliente = (ElegirCliente)Application.OpenForms["ElegirCliente"];
                elegirCliente.Enabled = true;
                LimpiarListaProductosCarrito();
            }
        }
        /// <summary>
        /// Cierra el FormVenta y redirecciona al FormMonto para modificar el monto máximo de compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModificarMonto_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMonto formMonto = new FormMonto(cliente, $"Su monto actual es de ${cliente.MontoMaximoDeCompra}. Ingrese el nuevo monto máximo de compra:");
            formMonto.Show();
        }
        /// <summary>
        /// No permite ingresarle al usuario caracteres especiales, sólo permite numeros sin decimales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Elimina todos los productos de la lista de productos del carrito
        /// </summary>
        public static void LimpiarListaProductosCarrito()
        {
            listaProductosDelCarrito.Clear();
        }
        /// <summary>
        /// Muestra mensaje de bienvenida apenas se entra a la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVenta_Shown(object sender, EventArgs e)
        {
            if (!esVendedor && mostrarModalBienvenida)
            {
                MessageBox.Show(cliente.ObtenerMensajeBienvenida());
            }
        }
    }
}
