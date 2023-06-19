using Entidades;
using System.Data;
using System.Globalization;

namespace Suarez_Fabiola_2D_2023
{
    public partial class FormVenta : Form
    {
        private Cliente cliente;
        private bool esVendedor;
        private bool mostrarModalBienvenida;
        public static List<Producto> listaProductos;
        public static List<Producto> listaProductosDelCarrito;

        public FormVenta(Cliente cliente, bool esVendedor, bool mostrarBienvenida)
        {
            this.cliente = cliente;
            this.esVendedor = esVendedor;
            this.mostrarModalBienvenida = mostrarBienvenida;

            listaProductos = new List<Producto>();
            listaProductosDelCarrito = new List<Producto>();

            InitializeComponent();
            CargarItemsProductos();
            InicializarItemsComboBox();
            CalcularPrecioTotal();
            CargarDatosDelCarrito();
            float montoDeCompra = cliente != null ? cliente.MontoMaximoDeCompra : 0;
            Lb_MontoMaximo.Text = $"Monto máximo de compra: ${montoDeCompra}";          
        }
        // Eventos del formulario

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
        /// Filtra los productos según el tipo de corte seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_FiltrarPorCorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewProductos.Columns.Clear();
            dataGridViewProductos.Columns.Add("Id", "");
            dataGridViewProductos.Columns.Add("Producto", "Producto");
            dataGridViewProductos.Columns.Add("StockDisponible", "Gramos disponibles");
            dataGridViewProductos.Columns.Add("PrecioPorKilo", "Precio por kilo");
            dataGridViewProductos.Columns["Id"].Visible = false;

            string corteSeleccionado = Cb_FiltrarPorCorte.SelectedItem?.ToString();
            if (listaProductos != null && listaProductos.Count > 0 && !string.IsNullOrEmpty(corteSeleccionado))
            {
                dataGridViewProductos.Rows.Clear();
                List<Producto> productosFiltrados = listaProductos
                    .Where(p => corteSeleccionado == "Ver todos los tipos de corte" || p.TipoCorte == corteSeleccionado)
                    .Where(p => p.StockDisponible > 0 || (p.StockDisponible <= 0 && p.CantidadDeseada > 0))
                    .ToList();

                foreach (Producto producto in productosFiltrados)
                {
                    if (producto.StockDisponible > 0 || producto.StockDisponible == 0 && producto.CantidadDeseada > 0)
                    {
                        dataGridViewProductos.Rows.Add(producto.Id, producto.Nombre, producto.StockDisponible, $"${producto.PrecioPorKilo.ToString("#0.00")}");
                    }
                }
            }
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
            int cantidadIngresada;
            if (!int.TryParse(Tb_Cantidad.Text, out cantidadIngresada))
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                int indiceFilaSeleccionada = dataGridViewProductos.SelectedRows[0].Index;
                int idSeleccionado = Convert.ToInt32(dataGridViewProductos.Rows[indiceFilaSeleccionada].Cells["Id"].Value);
                Producto? productoSeleccionado = Entidades.Producto.ObtenerProductoPorId(idSeleccionado, listaProductos);

                if (Validadores.ValidarCamposParaModificarCarrito(idSeleccionado, cantidadIngresada, true, listaProductos, listaProductosDelCarrito))
                {
                    if (Entidades.Producto.AgregarProductoAlCarrito(productoSeleccionado, cantidadIngresada, listaProductosDelCarrito))
                    {
                        // Recargamos la lista de productos según el stock disponible:
                        CalcularPrecioTotal();
                        CargarItemsProductos();
                        CargarDatosDelCarrito();
                        MessageBox.Show($"Producto agregado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
            int cantidadIngresada;
            if (!int.TryParse(Tb_Cantidad.Text, out cantidadIngresada))
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                int indiceFilaSeleccionada = dataGridViewProductos.SelectedRows[0].Index;
                int idSeleccionado = Convert.ToInt32(dataGridViewProductos.Rows[indiceFilaSeleccionada].Cells["Id"].Value);
                Producto? productoSeleccionado = Entidades.Producto.ObtenerProductoPorId(idSeleccionado, listaProductos);

                if (Validadores.ValidarCamposParaModificarCarrito(productoSeleccionado.Id, cantidadIngresada, false, listaProductos, listaProductosDelCarrito))
                {
                    if (Entidades.Producto.EliminarProductoDelCarrito(productoSeleccionado, cantidadIngresada, listaProductosDelCarrito))
                    {
                        // Recargamos la lista de productos según el stock disponible:
                        CargarItemsProductos();
                        MessageBox.Show($"Producto eliminado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CalcularPrecioTotal();
                        CargarDatosDelCarrito();
                    }
                    else
                    {
                        MessageBox.Show($"No se encontró producto en el carrito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            else if (precioFinal < 10)
            {
                MessageBox.Show("Para comprar necesita añadir productos y el monto tiene que ser mayor a 10 pesos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Métodos de inicialización y carga de datos

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
        /// Carga los productos a mostrar en el dataGridView de productos
        /// </summary>
        private void CargarItemsProductos()
        {
            listaProductos = ProductosDAO.LeerProductos();
            dataGridViewProductos.AutoGenerateColumns = false;
            // Limpiar las columnas y filas existentes en el DataGridView
            dataGridViewProductos.Columns.Clear();
            dataGridViewProductos.Rows.Clear();

            dataGridViewProductos.Columns.Add("Id", "");
            dataGridViewProductos.Columns.Add("Producto", "Producto");
            dataGridViewProductos.Columns.Add("StockDisponible", "Gramos disponibles");
            dataGridViewProductos.Columns.Add("PrecioPorKilo", "Precio por kilo");
            dataGridViewProductos.Columns["Id"].Visible = false;

            foreach (Producto producto in listaProductos)
            {
                if (producto.StockDisponible > 0 || producto.StockDisponible == 0 && producto.CantidadDeseada > 0)
                {
                    dataGridViewProductos.Rows.Add(producto.Id, producto.Nombre, producto.StockDisponible, $"${producto.PrecioPorKilo.ToString("#0.00")}");
                }
            }
        }
        /// <summary>
        /// Calcula el precio total de la lista listaProductosDelCarrito y lo muestra
        /// </summary>
        private void CalcularPrecioTotal()
        {
            var precioTotal = listaProductosDelCarrito.Sum(producto => Producto.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo));
            Lb_Total.Text = $"Total: ${precioTotal:#0.00}";
        }
        /// <summary>
        /// Actualiza la lista de productos a mostrar en el dataGridView (lista donde se muestra el detalle del carrito de compra)
        /// </summary>
        /// <param name="dataGridView"></param>
        private void CargarDatosDelCarrito()
        {
            dataGridViewCarrito.Rows.Clear();
            foreach (Producto producto in listaProductosDelCarrito)
            {
                double precioProducto = Producto.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo);
                if (precioProducto > 0 & producto.CantidadDeseada > 0)
                {
                    int rowIndex = dataGridViewCarrito.Rows.Add();
                    DataGridViewRow row = dataGridViewCarrito.Rows[rowIndex];
                    row.Cells["Nombre"].Value = producto.Nombre;
                    row.Cells["Precio"].Value = $"${precioProducto.ToString("#0.00")}";
                    row.Cells["Cantidad"].Value = $"{producto.CantidadDeseada} gr";
                }
            }
        }
        /// <summary>
        /// Elimina todos los productos de la lista de productos del carrito
        /// </summary>
        public static void LimpiarListaProductosCarrito()
        {
            listaProductosDelCarrito.Clear();
        }
    }
}