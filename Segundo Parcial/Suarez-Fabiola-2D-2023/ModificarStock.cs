using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Entidades;

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
        /// <summary>
        /// No le permite ingresar al usuario caracteres especiales, sólo permite ingresar números sin decimales
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
        /// Carga los productos que se van a mostrar en el ListBox
        /// </summary>
        public void CargarItemsProductos()
        {
            if (Producto.ObtenerProductos().Count == 0) return;

            Lb_ModificarProductos.Items.Clear();
            foreach (Producto producto in Producto.ObtenerProductos())
            {
                Lb_ModificarProductos.Items.Add(producto);
            }
        }
        /// <summary>
        /// Cierra la página ModificarStock y en el evento FormClosed abre/regresa a la página anterior
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
        private void ModificarStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            if (formHeladera != null)
            {
                formHeladera.CargarListaProductos(formHeladera.dataGridName, Producto.ObtenerProductos());
            }
        }
        /// <summary>
        /// Dibuja los productos cargados en el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si tiene un stock válido, modifica el stock del producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModificarStock_Click(object sender, EventArgs e)
        {
            int indexProducto = Lb_ModificarProductos.SelectedIndex;
            string cantidadIngresada = Tb_Cantidad.Text;

            if (!int.TryParse(cantidadIngresada, out int cantidadStock))
            {
                MessageBox.Show("Debe ingresar una cantidad de stock válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Validadores.ValidarCampoStock(indexProducto, cantidadStock, Lb_ModificarProductos.Items.Cast<Producto>().ToList()))
            {
                if (Vendedor.ModificarProducto(indexProducto, Producto.ObtenerProductos(), cantidadStock, null, ""))
                {
                    CargarItemsProductos();
                    MessageBox.Show($"Stock del producto modificado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lo sentimos, no se pudo modificar el producto. Intente más tarde.");
                }
            }
        }
        /// <summary>
        /// Redirecciona a la pantalla Agregar un nuevo producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabel_AgregarProducto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Enabled = false;
            FormAgregarProducto agregarProducto = new FormAgregarProducto();
            agregarProducto.ShowDialog();
        }
    }
}
