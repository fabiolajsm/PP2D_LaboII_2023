using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Carga la lista de clientes como opciones del ComboBox
        /// </summary>
        private void CargarClientes()
        {
            Cb_Clientes.Items.Clear();
            List<Cliente> listaClientes = DatosEnMemoria.listaClientes;

            if(listaClientes.Count > 0 )
            {
                foreach (Cliente cliente in listaClientes)
                {                        
                    Cb_Clientes.Items.Add(cliente.NombreCompleto);                    
                }
                Cb_Clientes.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Cierra la página ElegirCliente y en el evento FormClosed abre/regresa a la página anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            formHeladera.CargarListaProductos(formHeladera.dataGridName, DatosEnMemoria.listaProductos);
        }
        /// <summary>
        /// Si selecciona un cliente y se puede obtener bien de la lista de clientes, redirecciona al FormVenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
