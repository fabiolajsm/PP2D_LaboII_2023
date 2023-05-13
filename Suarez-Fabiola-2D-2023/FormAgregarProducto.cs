using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Suarez_Fabiola_2D_2023
{
    public partial class FormAgregarProducto : Form
    {
        public FormAgregarProducto()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cierra la página AgregarProducto y en el evento FormClosed abre/regresa a la página anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Regresa a la página ModificarStock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAgregarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            ModificarStock modificarStock = (ModificarStock)Application.OpenForms["ModificarStock"];
            modificarStock.CargarItemsProductos();
            modificarStock.Enabled = true;
        }       
        /// <summary>
        /// Si los datos del producto a agregar son válidos agrega el producto a la lista de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AgregarProducto_Click(object sender, EventArgs e)
        {
            if (Validadores.ValidarCamposAgregarProducto(Tb_Nombre.Text, Tb_Descripcion.Text, Tb_TipoCorte.Text, Tb_Precio.Text, Tb_Stock.Text))
            {
                Producto nuevoProducto = new Producto(Tb_Nombre.Text.Trim(), Tb_Descripcion.Text.Trim(), Tb_TipoCorte.Text.Trim(), Convert.ToDouble(Tb_Precio.Text), Convert.ToDouble(Tb_Stock.Text));
                if (Producto.AgregarProductoALaLista(nuevoProducto, DatosEnMemoria.ObtenerListaProductos()))
                {
                    MessageBox.Show("Producto agregado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Tb_Nombre.Text = string.Empty;
                    Tb_Descripcion.Text = string.Empty;
                    Tb_TipoCorte.Text = string.Empty;
                    Tb_Precio.Text = string.Empty;
                    Tb_Stock.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show($"Lo sentimos, no se pudo agregar el producto intente más tarde.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// No permite ingresarle al usuario caracteres especiales, sólo permite letras y espacios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// No permite ingresarle al usuario caracteres especiales, sólo permite letras y espacios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// No permite ingresarle al usuario caracteres especiales, sólo permite letras y espacios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_TipoCorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// No permite ingresarle al usuario caracteres especiales, sólo permite numeros y un punto para convertirlo en decimal
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
        /// No permite ingresarle al usuario caracteres especiales, sólo permite numeros sin decimales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
