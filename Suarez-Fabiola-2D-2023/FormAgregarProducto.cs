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
    public partial class FormAgregarProducto : Form
    {
        public FormAgregarProducto()
        {
            InitializeComponent();
        }

        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAgregarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            ModificarStock modificarStock = (ModificarStock)Application.OpenForms["ModificarStock"];
            modificarStock.CargarItemsProductos();
            modificarStock.Enabled = true;
        }
        public bool ValidarCampos(string nombre, string descripcion, string corte, string precioString, string stockString)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(corte) || string.IsNullOrEmpty(precioString) || string.IsNullOrEmpty(stockString))
            {
                MessageBox.Show("Todos los campos son requeridos y deben ser válidos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(precioString, out double precio))
            {
                MessageBox.Show($"Debe ingresar un precio válido.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(stockString, out double stock))
            {
                MessageBox.Show($"Debe ingresar un stock válido.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (precio < 0)
            {
                MessageBox.Show("Debe ingresar un precio mayor o igual a cero.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (stock < 0)
            {
                MessageBox.Show("Debe ingresar un stock mayor o igual a cero.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Btn_AgregarProducto_Click(object sender, EventArgs e)
        {
            if (ValidarCampos(Tb_Nombre.Text, Tb_Descripcion.Text, Tb_TipoCorte.Text, Tb_Precio.Text, Tb_Stock.Text))
            {
                if (Producto.AgregarProductoALaLista(Tb_Nombre.Text, Tb_Descripcion.Text, Tb_TipoCorte.Text, Convert.ToDouble(Tb_Precio.Text), Convert.ToDouble(Tb_Stock.Text), DatosEnMemoria.listaProductos))
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

        private void Tb_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void Tb_Descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void Tb_TipoCorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
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

        private void Tb_Stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
