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
        private string nombreUsuario;
        public FormVenta()
        {
            InitializeComponent();
        }
        public FormVenta(string nombreCompleto) : this()
        {
            Lb_BienvenidaCliente.Text = $"¡Hola {nombreCompleto}!";
            nombreUsuario = nombreCompleto;
        }

        private void Tb_MontoMaximoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void Btn_Continuar_Click(object sender, EventArgs e)
        {
            float maximoDeCompra = 0;
            try
            {
                if (!float.TryParse(Tb_MontoMaximoCompra.Text, out maximoDeCompra))
                {
                    MessageBox.Show("Debe ingresar un monto válida", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Debe ingresar un monto válida");
            }
            if (string.IsNullOrEmpty(Tb_MontoMaximoCompra.Text))
            {
                MessageBox.Show("Debe ingresar un monto máximo de compra", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (maximoDeCompra <= 0)
            {
                MessageBox.Show("Debe ingresar un monto máximo de compra mayor a 0", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Usuario usuario = Usuario.ObtenerUsuarioPorNombre(nombreUsuario);
                usuario.MontoMaximoDeCompra = maximoDeCompra;
                this.Hide();
                AgregarAlCarrito agregarAlCarrito = new AgregarAlCarrito(maximoDeCompra);
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
