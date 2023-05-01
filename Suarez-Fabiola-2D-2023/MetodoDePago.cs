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
    public partial class MetodoDePago : Form
    {
        private float maximoDeCompra;
        private double precioFinal;
        private Usuario usuario;

        public MetodoDePago(double precioFinal, Usuario usuario)
        {
            InitializeComponent();

            this.maximoDeCompra = usuario.MontoMaximoDeCompra;
            this.precioFinal = precioFinal;
            this.usuario = usuario;
            if (Lb_MontoMaximo != null)
            {
                Lb_MontoMaximo.Text = $"Monto máximo de compra: {maximoDeCompra}";
            }
            else
            {
                Lb_MontoMaximo.Text = "Monto máximo de compra: 0";
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgregarAlCarrito agregarAlCarrito = new AgregarAlCarrito(usuario);
            agregarAlCarrito.Show();
        }

        private void Rb_Credito_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Credito.Checked)
            {
                double recargo = precioFinal * 0.5;
                Lb_Recargo.Text = $"Recargo: {recargo}";
                Lb_PrecioFinal.Text = $"Precio sin recago: {precioFinal}. Precio final: {precioFinal + recargo}";
                precioFinal = precioFinal * 1.5;
            }
        }

        private void Rb_Debito_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Debito.Checked)
            {
                Lb_Recargo.Text = "Recargo: 0";
                Lb_PrecioFinal.Text = $"Precio final: {precioFinal}";
            }
        }

        private void Rb_MercadoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_MercadoPago.Checked)
            {
                Lb_Recargo.Text = "Recargo: 0";
                Lb_PrecioFinal.Text = $"Precio final: {precioFinal}";
            }
        }

        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            if (precioFinal > maximoDeCompra)
            {
                DialogResult result = MessageBox.Show("El precio supera el monto máximo de compra. ¿Desea modificar su monto máximo?", "Guardar cambios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    this.Hide();
                    FormVenta formVenta = new FormVenta(usuario, $"Su monto actual es de ${maximoDeCompra}. Ingrese el nuevo monto máximo de compra:", true, precioFinal);
                    formVenta.Show();
                }
            }
        }
    }
}
