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
    public partial class FormVenta : Form
    {
        private Cliente cliente;
        private bool esVendedor;
        public FormVenta(Cliente cliente, bool esVendedor)
        {
            InitializeComponent();
            Lb_Productos.DrawMode = DrawMode.OwnerDrawFixed;
            InicializarItemsComboBox();
            CargarItemsProductos();
            CalcularPrecioTotal(DatosEnMemoria.listaProductosDelCarrito);
            CargarDatosDelCarrito(dataGridView, DatosEnMemoria.listaProductosDelCarrito);
            this.cliente = cliente;
            this.esVendedor = esVendedor;
            if (this.cliente.MontoMaximoDeCompra != 0)
            {
                Lb_MontoMaximo.Text = $"Su monto máximo de compra es de ${this.cliente.MontoMaximoDeCompra}";
            }
        }

        public void CalcularPrecioTotal(List<Producto> listaProductos)
        {
            double precioTotal = 0;
            if (listaProductos.Count <= 0) Lb_Total.Text = "Total: 0";
            else
            {
                foreach (Producto producto in listaProductos)
                {
                    precioTotal += Producto.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo);
                }
                Lb_Total.Text = $"Total: {precioTotal.ToString("#0.00")}";
            }
        }

        private void InicializarItemsComboBox()
        {
            Cb_FiltrarPorCorte.Items.Clear();
            Cb_FiltrarPorCorte.Items.Add("Ver todos los tipos de corte");
            Cb_FiltrarPorCorte.SelectedIndex = 0;

            List<string> nombresCorte = DatosEnMemoria.listaProductos
                .Where(p => p.StockDisponible > 0 || (p.StockDisponible <= 0 && p.CantidadDeseada > 0))
                .Select(p => p.TipoCorte)
                .Distinct()
                .ToList();

            nombresCorte.ForEach(corte => Cb_FiltrarPorCorte.Items.Add(corte));
        }
        private void Cb_FiltrarPorCorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            string corteSeleccionado = Cb_FiltrarPorCorte.SelectedItem?.ToString();
            List<Producto> productos = Lb_Productos.Items.Cast<Producto>().ToList();

            if (productos.Count > 0 && !string.IsNullOrEmpty(corteSeleccionado))
            {
                List<Producto> productosFiltrados = DatosEnMemoria.listaProductos.Where(p => p.TipoCorte == corteSeleccionado).ToList();
                if (corteSeleccionado != "Ver todos los tipos de corte")
                {
                    Lb_Productos.Items.Clear();
                    foreach (Producto productoFiltrado in productosFiltrados)
                    {
                        Lb_Productos.Items.Add(productoFiltrado);
                    }
                }
                else
                {
                    Lb_Productos.Items.Clear();

                    foreach (Producto producto in DatosEnMemoria.listaProductos)
                    {
                        if (producto.StockDisponible > 0 || (producto.StockDisponible <= 0 && producto.CantidadDeseada > 0))
                        {
                            Lb_Productos.Items.Add(producto);
                        }
                    }
                }
            }
        }
        private void CargarItemsProductos()
        {
            string corteSeleccionado = Cb_FiltrarPorCorte.SelectedItem?.ToString();
            Lb_Productos.Items.Clear();

            if (string.IsNullOrEmpty(corteSeleccionado) || corteSeleccionado == "Ver todos los tipos de corte")
            {
                foreach (Producto producto in DatosEnMemoria.listaProductos)
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
                    List<Producto> productosFiltrados = DatosEnMemoria.listaProductos.Where(p => p.TipoCorte == corteSeleccionado).ToList();
                    foreach (Producto productoFiltrado in productosFiltrados)
                    {
                        Lb_Productos.Items.Add(productoFiltrado);
                    }
                }
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
                    row.Cells["Precio"].Value = $"${precioProducto.ToString("#0.00")}";
                    row.Cells["Cantidad"].Value = $"{producto.CantidadDeseada} gr";
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
            else if (!esAgregarAlCarrito & DatosEnMemoria.ExisteProductoEnELCarrito(productos[indexProducto]) == false)
            {
                MessageBox.Show($"No se encontró producto en el carrito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!esAgregarAlCarrito && DatosEnMemoria.ObtenerCantidadProductoDelCarrito(productos[indexProducto]) < cantidadIngresada)
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
            int cantidadIngresada;

            if (!int.TryParse(Tb_Cantidad.Text, out cantidadIngresada))
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Producto> productos = Lb_Productos.Items.Cast<Producto>().ToList();

            if (ValidarCampos(indexProducto, cantidadIngresada, true))
            {
                Producto productoSeleccionado = productos[indexProducto];
                productoSeleccionado.CantidadDeseada = cantidadIngresada;
                
                if (DatosEnMemoria.AgregarProductoAlCarrito(productoSeleccionado))
                {
                    // Recargamos la lista de productos segun el stock disponible:
                    CargarItemsProductos();
                    MessageBox.Show($"Producto agregado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CalcularPrecioTotal(DatosEnMemoria.listaProductosDelCarrito);
                    CargarDatosDelCarrito(dataGridView, DatosEnMemoria.listaProductosDelCarrito);
                }
            }
        }
        private void Btn_EliminarDelCarrito_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_Productos.SelectedIndex;
            int cantidadIngresada;

            if (!int.TryParse(Tb_Cantidad.Text, out cantidadIngresada))
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidarCampos(indexProducto, cantidadIngresada, false))
            {
                List<Producto> productos = Lb_Productos.Items.Cast<Producto>().ToList();
                Producto productoSeleccionado = productos[indexProducto];

                // borramos el producto del carrito
                if (DatosEnMemoria.EliminarProductoDelCarrito(productoSeleccionado, cantidadIngresada))
                {
                    // recargamos la lista de productos segun el stock disponible:
                    CargarItemsProductos();
                    MessageBox.Show($"Producto eliminado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CalcularPrecioTotal(DatosEnMemoria.listaProductosDelCarrito);
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
            double precioFinal = double.Parse(Lb_Total.Text.Split(':')[1].Trim());
            if (precioFinal > cliente.MontoMaximoDeCompra)
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
                FormMetodoDePago metodoDePago = new FormMetodoDePago(precioFinal, cliente);
                metodoDePago.Show();
            }
        }

        private void Btn_VolverVendedor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (esVendedor)
            {
                ElegirCliente elegirCliente = (ElegirCliente)Application.OpenForms["ElegirCliente"];
                elegirCliente.Enabled = true;
            }
        }

        private void Btn_ModificarMonto_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMonto formMonto = new FormMonto(cliente, $"Su monto actual es de ${cliente.MontoMaximoDeCompra}. Ingrese el nuevo monto máximo de compra:");
            formMonto.Show();
        }

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
    }
}
