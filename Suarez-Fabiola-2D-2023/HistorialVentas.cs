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
    public partial class HistorialVentas : Form
    {
        public HistorialVentas()
        {
            InitializeComponent();
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            if (DatosEnMemoria.ObtenerHistorialVentas().Count == 0)
            {
                Lb_SinVentas.Visible = true;
            }
            else
            {
                Lb_SinVentas.Visible = false;
                // Agrega las columnas al control
                dataGridView.Columns.Add("TipoDeCompra", "Tipo de compra");
                dataGridView.Columns.Add("NombreCliente", "Nombre Cliente");
                dataGridView.Columns.Add("NombreProducto", "Nombre Producto");
                dataGridView.Columns.Add("CantidadComprada", "Cantidad Comprada");
                dataGridView.Columns.Add("Precio", "Precio");
                dataGridView.Columns.Add("Recargo", "Recargo");
                dataGridView.Columns.Add("PrecioFinal", "Precio Final");

                // Agrega las filas al control
                foreach (Factura factura in DatosEnMemoria.ObtenerHistorialVentas())
                {
                    int rowIndex = dataGridView.Rows.Add();
                    DataGridViewRow row = dataGridView.Rows[rowIndex];

                    row.Cells["TipoDeCompra"].Value = factura.TipoDeCompra;
                    row.Cells["NombreCliente"].Value = factura.NombreCliente;
                    row.Cells["NombreProducto"].Value = factura.NombreProducto;
                    row.Cells["CantidadComprada"].Value = $"{factura.CantidadComprada} gr.";
                    row.Cells["Precio"].Value = $"${factura.Precio.ToString("#0.00")}";
                    row.Cells["Recargo"].Value = $"${factura.Recargo.ToString("#0.00")}";
                    row.Cells["PrecioFinal"].Value = $"${factura.PrecioFinal.ToString("#0.00")}";
                }
            }
        }
        /// <summary>
        /// Cierra la página HistorialVentas y en el evento FormClosed abre/regresa a la página anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
