using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Entidades;

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
        /// <summary>
        /// No permite ingresarle al usuario caracteres especiales, sólo permite números y una coma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Carga los productos que se van a mostrar en el ListBox
        /// </summary>
        private void CargarItemsProductos()
        {
            if (DatosEnMemoria.ObtenerListaProductos().Count == 0) return;
            Lb_FijarPrecio.Items.Clear();

            foreach (Producto producto in DatosEnMemoria.ObtenerListaProductos())
            {
                Lb_FijarPrecio.Items.Add(producto);
            }
        }
        /// <summary>
        /// Dibuja los productos cargados en el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Cierra la página FijarPrecios y en el evento FormClosed abre/regresa a la página anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Regresa a la página Heladera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FijarPrecios_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            if (formHeladera != null)
            {   
                formHeladera.CargarListaProductos(formHeladera.dataGridName, DatosEnMemoria.ObtenerListaProductos());
            }
        }
        /// <summary>
        /// Si tiene un precio válido, modifica el precio del producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FijarPrecio_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_FijarPrecio.SelectedIndex;
            string precioIngresado = Tb_Precio.Text;
            double precio;
            string mensajeError = "Debe ingresar un precio válido";

            if (string.IsNullOrEmpty(precioIngresado))
            {
                MessageBox.Show(mensajeError, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(precioIngresado, out precio))
            {
                MessageBox.Show(mensajeError, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Validadores.ValidarCampoPrecio(indexProducto, precio, Lb_FijarPrecio.Items.Cast<Producto>().ToList()))
            {
                if (Vendedor.ModificarProducto(indexProducto, DatosEnMemoria.ObtenerListaProductos(), null, precio, ""))
                {
                    CargarItemsProductos();
                    MessageBox.Show($"Precio del producto modificado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lo sentimos, no se pudo modificar el producto. Intente más tarde.");
                }
            }
        }
    }
}
