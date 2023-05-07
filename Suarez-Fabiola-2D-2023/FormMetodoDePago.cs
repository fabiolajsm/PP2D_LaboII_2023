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
    public partial class FormMetodoDePago : Form
    {
        private float maximoDeCompra;
        private double precioFinal;
        private double recargo;
        private Cliente cliente;
        private bool esVendedor;

        public FormMetodoDePago(double precioFinal, Cliente cliente, bool esVendedor)
        {
            InitializeComponent();

            this.maximoDeCompra = cliente.MontoMaximoDeCompra;
            this.precioFinal = precioFinal;
            this.cliente = cliente;
            this.recargo = 0;
            this.esVendedor = esVendedor;
            if (Lb_MontoMaximo != null)
            {
                Lb_MontoMaximo.Text = $"Monto máximo de compra: ${maximoDeCompra}";
            }
            else
            {
                Lb_MontoMaximo.Text = "Monto máximo de compra: $0";
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormVenta formVenta = new FormVenta(cliente, esVendedor);
            formVenta.Show();
        }

        private void Rb_Credito_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Credito.Checked)
            {
                recargo = precioFinal * 0.05;
                Lb_Recargo.Text = $"Recargo: ${recargo}";
                Lb_PrecioFinal.Text = $"Precio sin recago: ${precioFinal}. Precio final: ${precioFinal + recargo}";
            }
            else
            {
                recargo = 0;
                Lb_Recargo.Text = $"Recargo: ${recargo}";
                Lb_PrecioFinal.Text = $"Precio final: ${precioFinal}";
            }
        }

        private void Rb_Debito_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Debito.Checked)
            {
                recargo = 0;
                Lb_Recargo.Text = $"Recargo: ${recargo}";
                Lb_PrecioFinal.Text = $"Precio final: ${precioFinal}";
            }
        }

        private void Rb_MercadoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_MercadoPago.Checked)
            {
                recargo = 0;
                Lb_Recargo.Text = $"Recargo: ${recargo}";
                Lb_PrecioFinal.Text = $"Precio final: ${precioFinal}";
            }
        }

        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            double total = Rb_Credito.Checked ? precioFinal + recargo : precioFinal;
            if (total > maximoDeCompra && !esVendedor)
            {
                DialogResult result = MessageBox.Show("El precio supera el monto máximo de compra. ¿Desea modificar su monto máximo?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    this.Hide();
                    FormMonto formMonto = new FormMonto(cliente, $"Su monto actual es de ${maximoDeCompra}. Ingrese el nuevo monto máximo de compra:", true, precioFinal);
                    formMonto.ShowDialog();
                }
            }
            else if(total > maximoDeCompra && esVendedor)
            {
                DialogResult result = MessageBox.Show("El precio supera el monto máximo de compra. ¿Desea cancelar la venta?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Venta cancelada", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    this.Hide();
                    FormVenta formVenta = new FormVenta(cliente, esVendedor);
                    formVenta.Show();
                }
            }
            else
            {
                string mensaje = "¡Gracias por su compra!\n\nProductos:\n";
                if (esVendedor)
                {
                    mensaje = "Resumen de la venta\n";
                }

                foreach (Producto producto in DatosEnMemoria.listaProductosDelCarrito)
                {
                    mensaje += $"{producto.Nombre} x {producto.CantidadDeseada / 1000} Kilos =  ${Producto.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo).ToString("#0.00")}\n";
                }

                mensaje += $"\nRecargo: {recargo.ToString("#0.00")}\nPrecio final: ${total.ToString("#0.00")}";

                MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cliente.MontoMaximoDeCompra -= (float)total;
                Cliente.ModificarMontoMaximoDeCompra(cliente, DatosEnMemoria.listaClientes, cliente.MontoMaximoDeCompra);
                DatosEnMemoria.listaProductosDelCarrito.Clear();
                this.Hide();
                FormVenta agregarAlCarrito = new FormVenta(cliente, esVendedor);
                agregarAlCarrito.Show();
            }
        }

        private void FormMetodoDePago_Load(object sender, EventArgs e)
        {
            if (esVendedor)
            {
                this.BackColor = Color.FromArgb(138, 121, 104);
                Gb_MetodoDePago.BackColor = Color.FromArgb(211, 200, 187);
            }
            else
            {
                this.BackColor = Color.FromArgb(241, 247, 238);
                Gb_MetodoDePago.BackColor = Color.FromArgb(176, 190, 169);
            }
        }
    }
}
