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
    public partial class FijarPrecios : Form
    {
        public FijarPrecios()
        {
            InitializeComponent();
            Lb_FijarPrecio.DrawMode = DrawMode.OwnerDrawFixed;
            CargarItemsProductos();
        }
        private void CargarItemsProductos()
        {
            if (DatosEnMemoria.listaProductos.Count == 0) return;

            Lb_FijarPrecio.Items.Clear();
            foreach (Producto producto in DatosEnMemoria.listaProductos)
            {
                Lb_FijarPrecio.Items.Add(producto);
            }
        }
        private void Lb_FijarPrecio_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string nombreProducto = ((Producto)Lb_FijarPrecio.Items[e.Index]).Nombre;
            double precioPorKiloProducto = ((Producto)Lb_FijarPrecio.Items[e.Index]).PrecioPorKilo;

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

        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FijarPrecios_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            formHeladera.Enabled = true;
        }

        private void Tb_Precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permite sólo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public bool ValidarCampos(int indexProducto, double precio)
        {
            List<Producto> productos = Lb_FijarPrecio.Items.Cast<Producto>().ToList();
            double precioActual = Producto.ObtenerPrecioProducto(indexProducto, precio, productos);
            bool esValido = false;

            if (indexProducto < 0 && precio < 0)
            {
                MessageBox.Show("Debe seleccionar un producto e ingresar cantidad.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (indexProducto < 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (precioActual == precio)
            {
                MessageBox.Show($"No hay cambios en el precio. El precio ingresado es igual al precio actual.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                esValido = true;
            }

            return esValido;
        }

        private void Btn_FijarPrecio_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_FijarPrecio.SelectedIndex;
            string precioIngresado = Tb_Precio.Text;
            double precio;
            if (string.IsNullOrEmpty(precioIngresado))
            {
                MessageBox.Show("Debe ingresar una cantidad de stock", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (!double.TryParse(precioIngresado, out precio))
                {
                    MessageBox.Show("Debe ingresar una cantidad de stock", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Debe ingresar una cantidad de stock");
            }
            if (ValidarCampos(indexProducto, precio))
            {
                if (Producto.ModificarPrecioProducto(precio, indexProducto, DatosEnMemoria.listaProductos))
                {
                    CargarItemsProductos();
                    MessageBox.Show($"Precio del producto modificado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
