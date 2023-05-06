using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Suarez_Fabiola_2D_2023
{
    public partial class ModificarStock : Form
    {
        public ModificarStock()
        {
            InitializeComponent();
            Lb_ModificarProductos.DrawMode = DrawMode.OwnerDrawFixed;
            CargarItemsProductos();
        }

        private void CargarItemsProductos()
        {
            if (DatosEnMemoria.listaProductos.Count == 0) return;

            Lb_ModificarProductos.Items.Clear();
            foreach (Producto producto in DatosEnMemoria.listaProductos)
            {
                Lb_ModificarProductos.Items.Add(producto);
            }
        }

        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            formHeladera.Enabled = true;
        }

        private void Lb_ModificarProductos_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string nombreProducto = ((Producto)Lb_ModificarProductos.Items[e.Index]).Nombre;
            double stockDisponible = ((Producto)Lb_ModificarProductos.Items[e.Index]).StockDisponible;

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

            // Dibujar el stock Disponible en la segunda columna

            e.Graphics.DrawString($"{stockDisponible.ToString()} gr", e.Font, brush, col2Rect,
                new StringFormat() { Alignment = StringAlignment.Far });

            e.DrawFocusRectangle();
        }
        public bool ValidarCampos(int indexProducto, int cantidadIngresada)
        {
            List<Producto> productos = Lb_ModificarProductos.Items.Cast<Producto>().ToList();
            bool esValido = false;

            if (indexProducto < 0 && cantidadIngresada < 0)
            {
                MessageBox.Show("Debe seleccionar un producto e ingresar una cantidad mayor o igual a cero.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (indexProducto < 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cantidadIngresada < 0)
            {
                MessageBox.Show($"Debe ingresar una cantidad mayor a cero gramos y sin decimales.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Producto.ObtenerStockDisponible(indexProducto, cantidadIngresada, productos) == cantidadIngresada)
            {
                MessageBox.Show($"No hay cambios en el stock. La cantidad ingresada es igual al stock disponible actual.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                esValido = true;
            }

            return esValido;
        }
        private void Btn_ModificarStock_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_ModificarProductos.SelectedIndex;
            string cantidadIngresada = Tb_Cantidad.Text;

            if (!int.TryParse(cantidadIngresada, out int cantidadStock))
            {
                MessageBox.Show("Debe ingresar una cantidad de stock válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidarCampos(indexProducto, cantidadStock))
            {
                if (Producto.ModificarStockDisponible(cantidadStock, indexProducto, DatosEnMemoria.listaProductos))
                {
                    CargarItemsProductos();
                    MessageBox.Show($"Stock del producto modificado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Tb_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
