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
    public partial class ElegirCliente : Form
    {
        public ElegirCliente()
        {
            InitializeComponent();
            CargarClientes();
        }
        private void CargarClientes()
        {
            List<Cliente> listaClientes = DatosEnMemoria.listaClientes;
            Cb_Clientes.Items.Clear();
            if(listaClientes.Count > 0 )
            {
                foreach (Cliente cliente in listaClientes)
                {
                    if( cliente != null )
                    {
                        Cb_Clientes.Items.Add(cliente.NombreCompleto);
                    }
                }
            }
            if (Cb_Clientes.Items.Count > 0) {             
                Cb_Clientes.SelectedIndex = 0;
            }
        }
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ElegirCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            formHeladera.Enabled = true;
        }

        private void Btn_Continuar_Click(object sender, EventArgs e)
        {
            if (Cb_Clientes.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un cliente de la lista para poder empezarle a vender.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                Cliente? cliente = Cliente.ObtenerClientePorNombre(Cb_Clientes.Text, DatosEnMemoria.listaClientes);
                if (cliente != null)
                {
                    this.Enabled = false;
                    FormVenta formVenta = new FormVenta(cliente, true);
                    formVenta.Show();
                }
                else {

                    MessageBox.Show("Lo sentimos! Error en nuestros servicios. Intente de nuevo.");
                }
            }
        }

    }
}
