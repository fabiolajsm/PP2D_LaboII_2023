using System;
using System.Windows.Forms;
using Entidades;

namespace Suarez_Fabiola_2D_2023
{
    public partial class FormMonto : Form
    {
        private readonly Cliente cliente;
        private readonly bool modificarMetodoDePago;
        private readonly double precioFinal;

        public FormMonto(Cliente cliente, string descripcion = "", bool modificarMetodoDePago = false, double precioFinal = 0)
        {
            InitializeComponent();

            this.cliente = cliente ?? new Cliente(); // Si el cliente es null, se crea una nueva instancia de Cliente
            Lb_BienvenidaCliente.Text = $"¡Hola {this.cliente.NombreCompleto}!";

            Lb_DescripcionBienvenida.Text = string.IsNullOrEmpty(descripcion) ? "Especifica tu monto máximo de gasto para empezar a explotar nuestros productos" : descripcion;
            Btn_CerrarSesion.Visible = string.IsNullOrEmpty(descripcion);
            Btn_Volver.Visible = !string.IsNullOrEmpty(descripcion);

            this.modificarMetodoDePago = modificarMetodoDePago;
            this.precioFinal = precioFinal;
        }
        /// <summary>
        /// Al momento de ingresar un monto máximo de compra, no permite ingresar caracteres especiales, espacios y decimales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_MontoMaximoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Valida el monto ingresado y de ser correcto, actualiza y abre una página dependiendo de las condiciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Continuar_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(Tb_MontoMaximoCompra.Text, out var maximoDeCompra))
            {
                MessageBox.Show("Debe ingresar un monto válido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (maximoDeCompra == cliente.MontoMaximoDeCompra)
            {
                MessageBox.Show("El monto ingresado es igual al monto máximo actual", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (maximoDeCompra <= 0)
            {
                MessageBox.Show("Debe ingresar un monto máximo de compra mayor a 0 y sin decimales", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cliente.ModificarMontoMaximoDeCompra(cliente, DatosEnMemoria.ObtenerListaClientes(), maximoDeCompra);
            this.Hide();
            var form = modificarMetodoDePago ? (Form)new FormMetodoDePago(precioFinal, cliente, false) : new FormVenta(cliente, false);
            form.Show();
        }

        /// <summary>
        /// Cierra la sesión del usuario y redirecciona al Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formLogin = new FormLogin();
            formLogin.Show();
        }
        /// <summary>
        /// Cierra el FormMonto y en el evento FormClosed abre/regresa a la página anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Al momento de cerrar el FormMonto, abre la página abierta anteriormente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMonto_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = modificarMetodoDePago ? (Form)new FormMetodoDePago(precioFinal, cliente, false) : new FormVenta(cliente, false);
            form.Show();
        }
    }
}
