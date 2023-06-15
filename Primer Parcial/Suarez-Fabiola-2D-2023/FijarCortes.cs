using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Entidades;

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
        /// <summary>
        /// No permite ingresarle al usuario caracteres especiales, sólo permite ingresar letras y espacios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Corte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Carga los productos que se van a mostrar en el ListBox
        /// </summary>
        private void CargarItemsProductos()
        {
            List<Producto> listaProductos = DatosEnMemoria.ObtenerListaProductos();
            if (listaProductos.Count == 0) return;

            Lb_FijarCorte.Items.Clear();
            foreach (Producto producto in listaProductos)
            {
                Lb_FijarCorte.Items.Add(producto);
            }
        }
        /// <summary>
        /// Cierra la página FijarCortes y en el evento FormClosed abre/regresa a la página anterior
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
        private void FijarCortes_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            if (formHeladera != null)
            {
                formHeladera.CargarListaProductos(formHeladera.dataGridName, DatosEnMemoria.ObtenerListaProductos());
            }
        }
        /// <summary>
        /// Dibuja los productos cargados en el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si tiene un tipo de corte válido, modifica el tipo de corte del producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FijarCorte_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_FijarCorte.SelectedIndex;
            string corteIngresado = Tb_Corte.Text;

            if (Validadores.ValidarCampoTipoDeCorte(indexProducto, corteIngresado, Lb_FijarCorte.Items.Cast<Producto>().ToList()))
            {
                if (Vendedor.ModificarProducto(indexProducto, DatosEnMemoria.ObtenerListaProductos(), null, null, corteIngresado))
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
    }
}
