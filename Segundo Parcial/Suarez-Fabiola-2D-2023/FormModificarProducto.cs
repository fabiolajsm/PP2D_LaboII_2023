using Entidades;
using Entidades.DAO;
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
    public partial class FormModificarProducto : Form
    {
        private string nombreAtributoAModificar;
        private List<Producto> listaProductos;

        public FormModificarProducto(string nombreAtributoAModificar)
        {
            InitializeComponent();
            this.nombreAtributoAModificar = nombreAtributoAModificar;
            this.listaProductos = new List<Producto>();
            Lb_Ingresar.Text = $"Ingresar {nombreAtributoAModificar} a modificar: ";
            CargarListaProductos();
        }
        /// <summary>
        /// Carga la lista de productos a mostrar en el dataGridView
        /// </summary>
        public void CargarListaProductos()
        {
            IDAO<Producto> productoDAO = new ProductosDAO();
            listaProductos = productoDAO.ObtenerLista();
            // Limpiar las columnas y filas existentes en el DataGridView
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // Agrega las columnas al control
            dataGridView.Columns.Add("Id", "");
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Tipo de corte", "Tipo de corte");
            dataGridView.Columns.Add("Kilos en stock", "Kilos en stock");
            dataGridView.Columns.Add("Precio por kilo", "Precio por kilo");
            dataGridView.Columns["Id"].Visible = false;
            // Agrega las filas al control
            foreach (Producto producto in listaProductos)
            {
                int indexFila = dataGridView.Rows.Add();
                DataGridViewRow fila = dataGridView.Rows[indexFila];

                fila.Cells["Id"].Value = producto.Id;
                fila.Cells["Nombre"].Value = producto.Nombre;
                fila.Cells["Tipo de corte"].Value = producto.TipoCorte;
                fila.Cells["Kilos en stock"].Value = $"{producto.StockDisponible / 1000}";
                fila.Cells["Precio por kilo"].Value = $"${producto.PrecioPorKilo.ToString("#0.00")}";
            }
        }
        /// <summary>
        /// Cierra la página ModificarProducto y en el evento FormClosed abre/regresa a la página anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Segun el tipo de atributo a modificar, permite o no ingresar ciertos caracteres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Atributo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nombreAtributoAModificar == "precio")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // Permite sólo un punto decimal
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
            if (nombreAtributoAModificar == "stock")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
            if (nombreAtributoAModificar == "tipo de corte")
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// Si lo ingresado es correcto modifica el producto en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModificarProducto_Click(object sender, EventArgs e)
        {
            var nuevoValor = Tb_Atributo.Text;
            if (nuevoValor != null && dataGridView.SelectedRows.Count > 0)
            {
                int indiceFilaSeleccionada = dataGridView.SelectedRows[0].Index;
                int idSeleccionado = Convert.ToInt32(dataGridView.Rows[indiceFilaSeleccionada].Cells["Id"].Value);
                Producto? productoSeleccionado = Producto.ObtenerProductoPorId(idSeleccionado, listaProductos);

                if (productoSeleccionado != null && Validadores.ValidarCampoAModificar(nombreAtributoAModificar, nuevoValor, productoSeleccionado))
                {
                    if (ProductosDAO.ModificarAtributo(productoSeleccionado, nombreAtributoAModificar, nuevoValor))
                    {
                        CargarListaProductos();
                        MessageBox.Show($"Producto modificado exitosamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lo sentimos, no se pudo modificar el producto. Intente más tarde.");
                    }
                }
            }
            else
            {
                MessageBox.Show($"Debe ingresar un nuevo {nombreAtributoAModificar}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Cuando se cierra el form carga de nuevo la lista de productos del form heladera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormModificarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            if (formHeladera != null)
            {
                formHeladera.CargarListaProductos();
            }
        }
    }
}
