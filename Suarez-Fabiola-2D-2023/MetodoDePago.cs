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
        private float precioFinal;

        public MetodoDePago()
        {
            InitializeComponent();
        }

        public MetodoDePago(float maximoDeCompra, float precioFinal)
        {
            this.maximoDeCompra = maximoDeCompra;
            this.precioFinal = precioFinal;
            Lb_PrecioFinal.Text = $"Precio final : {precioFinal}";
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Btn_ModificarMonto_Click(object sender, EventArgs e)
        {

        }

        private void Rb_Credito_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Credito.Checked)
            {
                Lb_Recargo.Text = $"Recargo: {precioFinal * 0.5}";
                Lb_PrecioFinal.Text = $"Precio sin recago: {precioFinal}. Precio final{precioFinal * 1.5}";
            }
        }

        private void Rb_Debito_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Debito.Checked)
            {
                Lb_Recargo.Text = "Recargo: 0";
                Lb_PrecioFinal.Text = $"Precio final{precioFinal}";
            }
        }

        private void Rb_MercadoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_MercadoPago.Checked)
            {
                Lb_Recargo.Text = "Recargo: 0";
                Lb_PrecioFinal.Text = $"Precio final{precioFinal}";
            }
        }
    }
}
