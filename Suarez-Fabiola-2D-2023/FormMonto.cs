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
    public partial class FormMonto : Form
    {
        private Cliente cliente;
        private bool modificarMetodoDePago;
        private double precioFinal;
        public FormMonto()
        {
            InitializeComponent();
            cliente = new Cliente();
            modificarMetodoDePago = false;
            precioFinal = 0;
        }
        public FormMonto(Cliente cliente) : this()
        {
            Lb_BienvenidaCliente.Text = $"¡Hola {cliente.NombreCompleto}!";
            this.cliente = cliente;
            this.modificarMetodoDePago = false;
            this.precioFinal = 0;
        }
        public FormMonto(Cliente cliente, string descripcion) : this()
        {
            Lb_BienvenidaCliente.Text = $"¡Hola {cliente.NombreCompleto}!";
            Lb_DescripcionBienvenida.Text = descripcion;
            Btn_CerrarSesion.Visible = false;
            Btn_Volver.Visible = true;

            this.cliente = cliente;
            this.modificarMetodoDePago = false;
            this.precioFinal = 0;
        }
        public FormMonto(Cliente cliente, string descripcion, bool modificarMetodoDePago, double precioFinal) : this()
        {
            Lb_BienvenidaCliente.Text = $"¡Hola {cliente.NombreCompleto}!";
            Lb_DescripcionBienvenida.Text = descripcion;
            Btn_CerrarSesion.Visible = false;
            Btn_Volver.Visible = true;

            this.cliente = cliente;
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
            float maximoDeCompra;

            if (!float.TryParse(Tb_MontoMaximoCompra.Text, out maximoDeCompra))
            {
                MessageBox.Show("Debe ingresar un monto válido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(Tb_MontoMaximoCompra.Text))
            {
                MessageBox.Show("Debe ingresar un monto máximo de compra", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (maximoDeCompra <= 0)
            {
                MessageBox.Show("Debe ingresar un monto máximo de compra mayor a 0 y sin decimales", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Cliente.ModificarMontoMaximoDeCompra(cliente, DatosEnMemoria.listaClientes, maximoDeCompra);
                this.Hide();
                if (!modificarMetodoDePago)
                {
                    FormVenta formVenta = new FormVenta(cliente, false);
                    formVenta.Show();
                }
                else
                {
                    FormMetodoDePago metodoDePago = new FormMetodoDePago(precioFinal, cliente);
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

        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMonto_FormClosed(object sender, FormClosedEventArgs e)
        {           
            if (modificarMetodoDePago)
            {
                FormMetodoDePago metodoDePago = new FormMetodoDePago(precioFinal, cliente);
                metodoDePago.Show();
            } 
            else
            {
                FormVenta formVenta = new FormVenta(cliente, false);
                formVenta.Show();
            }
        }
    }
}
