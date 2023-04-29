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
        public FormVenta()
        {
            InitializeComponent();
        }
        public FormVenta(string nombreCompleto) : this()
        {
            Lb_BienvenidaCliente.Text = $"¡Hola {nombreCompleto}!";
        }

        private void Tb_MontoMaximoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Btn_Continuar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tb_MontoMaximoCompra.Text))
            {
                MessageBox.Show("Debe ingresar un monto máximo de compra", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                AgregarAlCarrito agregarAlCarrito = new AgregarAlCarrito();
                agregarAlCarrito.Show();
            }
        }

        private void Btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
    }
}
