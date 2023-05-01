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
        private Usuario usuario;
        private bool modificarMetodoDePago;
        private double precioFinal;
        public FormVenta()
        {
            InitializeComponent();
            usuario = new Usuario();
            modificarMetodoDePago = false;
            precioFinal = 0;
        }
        public FormVenta(Usuario usuario) : this()
        {
            Lb_BienvenidaCliente.Text = $"¡Hola {usuario.NombreCompleto}!";
            this.usuario = usuario;
            this.modificarMetodoDePago = false;
            this.precioFinal = 0;
        }

        public FormVenta(Usuario usuario, string descripcion, bool modificarMetodoDePago, double precioFinal) : this()
        {
            Lb_BienvenidaCliente.Text = $"¡Hola {usuario.NombreCompleto}!";
            Lb_DescripcionBienvenida.Text = descripcion;
            Btn_CerrarSesion.Visible = false;

            this.usuario = usuario;
            this.modificarMetodoDePago = modificarMetodoDePago;
            this.precioFinal = precioFinal;
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
                usuario.MontoMaximoDeCompra = maximoDeCompra;
                this.Hide();
                if (!modificarMetodoDePago)
                {
                    AgregarAlCarrito agregarAlCarrito = new AgregarAlCarrito(usuario);
                    agregarAlCarrito.Show();
                } else
                {
                    MetodoDePago metodoDePago = new MetodoDePago(precioFinal, usuario);
                    metodoDePago.Show();
                }
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
