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
        public AgregarAlCarrito()
        {
            InitializeComponent();
            Lb_Productos.DrawMode = DrawMode.OwnerDrawFixed;
            CargarItemsProductos();
            // Habilitaremos el botón Continuar cuando haya método de pago
            Btn_Continuar.Enabled = false;
        }

        private void CargarItemsProductos()
        {
            Lb_Productos.Items.Clear();
            foreach (Producto producto in DatosEnMemoria.listaProductos)
            {
                if (producto.StockDisponible > 0)
                {
                    Lb_Productos.Items.Add(producto);
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
                brush = SystemBrushes.HighlightText;
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

        public bool ValidarCampos(int indexProducto, int cantidadIngresada)
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
            else if (stockDisponible < cantidadIngresada)
            {
                MessageBox.Show($"Lo sentimos, sólo nos quedan {stockDisponible} gr, del producto seleccionado", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else {              
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
            double stockDisponible = Producto.ObtenerStockDisponible(indexProducto, cantidadIngresada, productos);

            if(ValidarCampos(indexProducto, cantidadIngresada))
            {
                Producto productoSeleccionado = productos[indexProducto];
                // le restamos el stock disponible al producto seleccionado:
                productoSeleccionado.StockDisponible -= cantidadIngresada;
                // Recargamos la lista de productos segun el stock disponible:
                CargarItemsProductos();

                // Agregamos el producto a la lista de listaProductosDelCarrito
                Producto productoAgregar = new Producto
                {
                    Nombre = productoSeleccionado.Nombre,
                    Descripcion = productoSeleccionado.Descripcion,
                    TipoCorte = productoSeleccionado.TipoCorte,
                    PrecioPorKilo = productoSeleccionado.PrecioPorKilo,
                    StockDisponible = productoSeleccionado.StockDisponible,
                    CantidadDeseada = cantidadIngresada
                };

                if (DatosEnMemoria.AgregarProductoAlCarrito(productoAgregar))
                {
                    MessageBox.Show($"Producto agregado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualizar precio final:
                    double precioPorKilo = Producto.ObtenerPrecioProducto(indexProducto, productos);
                    double precioProducto = Producto.CalcularPrecio(cantidadIngresada, precioPorKilo);
                    double precioFinal = double.Parse(Lb_Total.Text.Split(':')[1].Trim()) + precioProducto;

                    Lb_Total.Text = $"Total: {precioFinal.ToString("F2")}";
                }
            }
        }
        private void Btn_EliminarDelCarrito_Click(object sender, EventArgs e)
        {

            MessageBox.Show("aja borrare");    
        }

        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            Gb_ListaDeProductos.Enabled = false;
        }

    }
}
