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
using Entidades.DAO;

namespace Suarez_Fabiola_2D_2023
{
    public partial class FormMetodoDePago : Form
    {
        private float maximoDeCompra;
        private double precioFinal;
        private double recargo;
        private Cliente cliente;
        private Vendedor vendedor;
        private string metodoDePago;

        public FormMetodoDePago(double precioFinal, Cliente cliente, Vendedor? vendedor)
        {
            InitializeComponent();

            this.maximoDeCompra = cliente.MontoMaximoDeCompra;
            this.precioFinal = precioFinal;
            this.cliente = cliente;
            this.recargo = 0;
            this.vendedor = vendedor;
            this.metodoDePago = string.Empty;

            float montoDeCompra = maximoDeCompra > 0 ? maximoDeCompra : 0;
            Lb_MontoMaximo.Text = $"Monto máximo de compra: ${montoDeCompra}";
        }
        /// <summary>
        /// Cambia los colores del form según el tipo de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMetodoDePago_Load(object sender, EventArgs e)
        {
            if (vendedor != null)
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
            FormVenta formVenta = new FormVenta(cliente, vendedor, false);
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
            metodoDePago = "Tarjeta de crédito";
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
            metodoDePago = "Tarjeta de débito";
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
            metodoDePago = "Mercado Pago";
        }
        /// <summary>
        /// Actualiza el precio de la compra a mostrar
        /// </summary>
        private void ActualizarPrecioFinal()
        {
            double total = precioFinal + recargo;
            Lb_Recargo.Text = $"Recargo: ${recargo.ToString("#0.00")}";
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
                FormVenta formVenta = new FormVenta(cliente, vendedor, false);
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
            bool esVendedor = vendedor != null;
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
                // Actualizamos la lista de productos en la base de datos
                if (ActualizarProductosEnBaseDeDatos() && ActualizarMontoMaximoDeCompra(total))
                {   
                    if (esVendedor)
                    {
                        UsuariosDAO.ModificarVentasRealizadas(vendedor, 1);
                    }
                    MostrarMensajeDeExitoYCrearFacturas(total);
                    FormVenta.LimpiarListaProductosCarrito();
                }
                else
                {
                    MessageBox.Show("Lo sentimos, en este momento no se puede realizar la compra", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                VolverAlFormVenta();
            }
        }
        /// <summary>
        /// Muestra el mensaje de exito al finalizar las compras y agrega las facturas al historial de ventas
        /// </summary>
        /// <param name="total">Total a pagar</param>
        private void MostrarMensajeDeExitoYCrearFacturas(double total)
        {
            StringBuilder mensajeBuilder = new StringBuilder();
            bool esVendedor = vendedor != null;

            string tipoDeVenta = esVendedor ? "En el local" : "Online";

            if (esVendedor)
            {
                mensajeBuilder.AppendLine("Resumen de la venta");
            }
            else
            {
                mensajeBuilder.AppendLine("¡Gracias por su compra!");
                mensajeBuilder.AppendLine("Productos:");
            }

            List<Factura> listaDeFacturas = new List<Factura>();

            foreach (Producto producto in FormVenta.listaProductosDelCarrito)
            {
                mensajeBuilder.AppendFormat("{0} x {1} Gramos = ${2:#0.00}\n",
                    producto.Nombre,
                    producto.CantidadDeseada,
                    Producto.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo));

                // Creamos una instancia de Factura para cada producto
                Factura factura = new Factura(
                    tipoDeVenta,
                    producto.Id,
                    producto.Nombre,
                    cliente.Id,
                    cliente.NombreCompleto,
                    producto.CantidadDeseada,
                    metodoDePago,
                    Producto.CalcularPrecio(producto.CantidadDeseada, producto.PrecioPorKilo),
                    recargo
                );
                listaDeFacturas.Add(factura); // agregamos la factura a la lista de facturas
            }

            mensajeBuilder.AppendFormat("Recargo: ${0:#0.00}\n", recargo);
            mensajeBuilder.AppendFormat("Precio final: ${0:#0.00}", total);

            MessageBox.Show(mensajeBuilder.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Agregamos la factura al historial de ventas
            Factura.AgregarFacturasAlHistorial(listaDeFacturas);
        }
        /// <summary>
        /// Actualiza el monto máximo de compra del cliente
        /// </summary>
        /// <param name="total">Total a pagar de la compra</param>
        /// <returns>Retorna True si se actualizó bien el montoMaximoDeCompra y False si no</returns>
        private bool ActualizarMontoMaximoDeCompra(double total)
        {
            cliente.MontoMaximoDeCompra -= (float)total;
            return UsuariosDAO.ModificarMontoMaximoDeCompra(cliente, cliente.MontoMaximoDeCompra);
        }
        /// <summary>
        /// Actualiza los productos en la base de datos (le resta lo recien comprado)
        /// </summary>
        /// <returns>Retorna True si se actualizó y False si no</returns>
        private bool ActualizarProductosEnBaseDeDatos()
        {
            List<Producto> listaCarrito = FormVenta.listaProductosDelCarrito;
            return ProductosDAO.ModificarStockListaProductos(listaCarrito);
        }
        /// <summary>
        /// Vuelve a FormVenta
        /// </summary>
        private void VolverAlFormVenta()
        {
            this.Hide();
            FormVenta agregarAlCarrito = new FormVenta(cliente, vendedor, false);
            agregarAlCarrito.Show();
        }
    }
}
