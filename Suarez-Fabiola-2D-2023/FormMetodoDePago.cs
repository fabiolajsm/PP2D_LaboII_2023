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
        /// <summary>
        /// Cambia los colores del form según el tipo de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Cierra el Form de Metodo de pago y te devuelve al FormVenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormVenta formVenta = new FormVenta(cliente, esVendedor);
            formVenta.Show();
        }
        /// <summary>
        /// Actualiza el precio si la opción Tarjeta de crédito está seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb_Credito_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Credito.Checked)
            {
                recargo = precioFinal * 0.05;
            }
            else
            {
                recargo = 0;
            }
            ActualizarPrecioFinal();
        }
        /// <summary>
        /// Actualiza el precio si la opción Tarjeta de débito está seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb_Debito_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Debito.Checked)
            {
                recargo = 0;
                ActualizarPrecioFinal();
            }
        }
        /// <summary>
        /// Actualiza el precio si la opción Mercado pago está seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb_MercadoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_MercadoPago.Checked)
            {
                recargo = 0;
                ActualizarPrecioFinal();
            }
        }
        /// <summary>
        /// Actualiza el precio de la compra a mostrar
        /// </summary>
        private void ActualizarPrecioFinal()
        {
            double total = precioFinal + recargo;
            Lb_Recargo.Text = $"Recargo: ${recargo}";
            Lb_PrecioFinal.Text = $"Precio final: ${total.ToString("#0.00")}";
        }
        /// <summary>
        /// Se muestra este mensaje cuando no alcanzan los fondos del cliente, permite cancelar la operación. Sólo se muestra para el usuario de tipo Vendedor
        /// </summary>
        private void MostrarMensajeDeCancelarVenta()
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
        /// <summary>
        /// Se muestra este mensaje cuando no alcanzan los fondos del cliente, da la opción de ir a modificar el monto máximo de compra
        /// </summary>
        private void MostrarMensajeDeModificarMontoMaximo()
        {
            DialogResult result = MessageBox.Show("El precio supera el monto máximo de compra. ¿Desea modificar su monto máximo?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Hide();
                FormMonto formMonto = new FormMonto(cliente, $"Su monto actual es de ${maximoDeCompra}. Ingrese el nuevo monto máximo de compra:", true, precioFinal);
                formMonto.ShowDialog();
            }
        }
        /// <summary>
        /// Realiza la compra de los productos si los fondos(monto maximo de compra) son suficientes, de no serlos el Cliente puede actualizar su monto máximo de compra y el Vendedor, cancelar la operación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            double total = Rb_Credito.Checked ? precioFinal + recargo : precioFinal;
            if (total > maximoDeCompra && !esVendedor)
            {
                MostrarMensajeDeModificarMontoMaximo();
            }
            else if(total > maximoDeCompra && esVendedor)
            {
                MostrarMensajeDeCancelarVenta();
            }
            else
            {
                StringBuilder mensajeBuilder = new StringBuilder();

                if (esVendedor)
                {
                    mensajeBuilder.AppendLine("Resumen de la venta");
                }
                else
                {
                    mensajeBuilder.AppendLine("¡Gracias por su compra!");
                    mensajeBuilder.AppendLine("Productos:");
                }

                foreach (Producto producto in DatosEnMemoria.listaProductosDelCarrito)
                {
                    mensajeBuilder.AppendFormat("{0} x {1} Kilos = ${2:#0.00}\n",
                        producto.Nombre,
                        producto.CantidadDeseada / 1000,
                        Utilidades.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo));
                }

                mensajeBuilder.AppendFormat("Recargo: {0:#0.00}\n", recargo);
                mensajeBuilder.AppendFormat("Precio final: {0:#0.00}", total);

                MessageBox.Show(mensajeBuilder.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cliente.MontoMaximoDeCompra -= (float)total;
                Cliente.ModificarMontoMaximoDeCompra(cliente, DatosEnMemoria.listaClientes, cliente.MontoMaximoDeCompra);
                DatosEnMemoria.listaProductosDelCarrito.Clear();
                this.Hide();
                FormVenta agregarAlCarrito = new FormVenta(cliente, esVendedor);
                agregarAlCarrito.Show();
            }
        }
    }
}
