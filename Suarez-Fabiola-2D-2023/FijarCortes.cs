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
    public partial class FijarCortes : Form
    {
        public FijarCortes()
        {
            InitializeComponent();
            Lb_FijarCorte.DrawMode = DrawMode.OwnerDrawFixed;
            CargarItemsProductos();
        }

        private void CargarItemsProductos()
        {
            if (DatosEnMemoria.listaProductos.Count == 0) return;

            Lb_FijarCorte.Items.Clear();
            foreach (Producto producto in DatosEnMemoria.listaProductos)
            {
                Lb_FijarCorte.Items.Add(producto);
            }
        }

        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FijarCortes_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            formHeladera.Enabled = true;
        }

        private void Lb_FijarCorte_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string nombreProducto = ((Producto)Lb_FijarCorte.Items[e.Index]).Nombre;
            string corteDelProducto = ((Producto)Lb_FijarCorte.Items[e.Index]).TipoCorte;

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

            // Dibujar el nombre del corte en la segunda columna
            e.Graphics.DrawString(corteDelProducto, e.Font, brush, col2Rect,
                new StringFormat() { Alignment = StringAlignment.Far });

            e.DrawFocusRectangle();
        }

        public bool ValidarCampos(int indexProducto, string corteIngresado)
        {
            List<Producto> productos = Lb_FijarCorte.Items.Cast<Producto>().ToList();
            bool esValido = false;

            if (indexProducto < 0 && string.IsNullOrEmpty(corteIngresado))
            {
                MessageBox.Show("Debe seleccionar un producto e ingresar un tipo de corte.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (indexProducto < 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(corteIngresado))
            {
                MessageBox.Show("Debe ingresar un tipo de corte.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (corteIngresado == Producto.ObtenerCorteProducto(indexProducto, corteIngresado, productos))
            {
                MessageBox.Show($"No hay cambios en el tipo de corte. El corte ingresado es igual al corte actual.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                esValido = true;
            }

            return esValido;
        }

        private void Btn_FijarCorte_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_FijarCorte.SelectedIndex;
            string corteIngresado = Tb_Corte.Text;

            if (ValidarCampos(indexProducto, corteIngresado))
            {
                if (Producto.ModificarTipoDeCorteProducto(corteIngresado, indexProducto, DatosEnMemoria.listaProductos))
                {
                    CargarItemsProductos();
                    MessageBox.Show($"Tipo de corte del producto modificado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lo sentimos, no se pudo modificar el producto. Intente más tarde.");
                }
            }
        }

        private void Tb_Corte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
