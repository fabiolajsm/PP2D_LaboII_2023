using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;

namespace Suarez_Fabiola_2D_2023
{
    public partial class FormHeladera : Form
    {
        public DataGridView dataGridName;
        private Vendedor vendedor;
        private bool mostrarModalBienvenida;
        public FormHeladera(Vendedor vendedor, bool mostrarBienvenida)
        {
            this.vendedor = vendedor;
            this.mostrarModalBienvenida = mostrarBienvenida;
            this.Enabled = true;
            InitializeComponent();
            this.dataGridName = dataGridView;
            CargarListaProductos(dataGridView, DatosEnMemoria.ObtenerListaProductos());
            CargarOpcionesDelComboBox();
        }
        /// <summary>
        /// Carga la lista de productos para que se visualice en el DataGridView
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="listaProductos"></param>
        public void CargarListaProductos(DataGridView dataGridView, List<Producto> listaProductos)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // Agrega las columnas al control
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Kilos en stock", "Kilos en stock");
            dataGridView.Columns.Add("Precio por kilo", "Precio por kilo");
            dataGridView.Columns.Add(new DataGridViewButtonColumn() { Name = "Ver detalle", Text = "Ver detalle" });

            // Agrega las filas al control
            foreach (Producto producto in listaProductos)
            {
                int rowIndex = dataGridView.Rows.Add();
                DataGridViewRow row = dataGridView.Rows[rowIndex];

                row.Cells["Nombre"].Value = producto.Nombre;
                row.Cells["Kilos en stock"].Value = $"{producto.StockDisponible / 1000}";
                row.Cells["Precio por kilo"].Value = $"${producto.PrecioPorKilo.ToString("#0.00")}";

                // Agrega el botón a la celda correspondiente
                DataGridViewButtonCell botonDetalle = (DataGridViewButtonCell)row.Cells["Ver detalle"];
                botonDetalle.Value = "Ver detalle";
                botonDetalle.UseColumnTextForButtonValue = true;
            }
        }
        /// <summary>
        /// Se cargan en el ComboBox las opciones del vendedor
        /// </summary>
        private void CargarOpcionesDelComboBox()
        {
            Cb_Opciones.Items.AddRange(new string[] { "Vender productos", "Modificar stock de los productos", "Fijar precios por kilo", "Fijar tipos de cortes", "Ver historial de ventas" });
            Cb_Opciones.SelectedIndex = 0;
        }
        /// <summary>
        /// Cierra la sesión del usuario y redirecciona al Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
        /// <summary>
        /// Redirecciona a la página de la opción seleccionada en el ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Continuar_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = Cb_Opciones.Text;

            if (opcionSeleccionada.Length > 0)
            {
                switch (opcionSeleccionada)
                {
                    case "Vender productos":
                        ElegirCliente elegirCliente = new ElegirCliente();
                        elegirCliente.ShowDialog();
                        break;
                    case "Modificar stock de los productos":
                        ModificarStock modificarStock = new ModificarStock();
                        modificarStock.ShowDialog();
                        break;
                    case "Fijar precios por kilo":
                        FijarPrecios fijarPrecios = new FijarPrecios();
                        fijarPrecios.ShowDialog();
                        break;
                    case "Fijar tipos de cortes":
                        FijarCortes fijarCortes = new FijarCortes();
                        fijarCortes.ShowDialog();
                        break;
                    case "Ver historial de ventas":
                        HistorialVentas historialVentas = new HistorialVentas();
                        historialVentas.ShowDialog();
                        break;
                }
            }
        }
        /// <summary>
        /// Habilita el botón de Compra si el usuario seleccionó una opción del ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_Opciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Btn_Continuar.Enabled = !string.IsNullOrEmpty(Cb_Opciones.Text);
        }
        /// <summary>
        /// Muestra el detalle del producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["Ver detalle"].Index)
            {
                string nombre = dataGridView.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                Producto? producto = new Producto().ObtenerProductoPorNombre(nombre, DatosEnMemoria.ObtenerListaProductos());
                if (producto != null)
                {
                    MessageBox.Show($"Detalle del producto:\n\nNombre: {producto.Nombre}\nDescripción: {producto.Descripcion}\nTipo de corte: {producto.TipoCorte}\nPrecio por kilo: ${producto.PrecioPorKilo}\nStock disponible: {producto.StockDisponible} gramos");
                }
                else
                {
                    MessageBox.Show("Lo sentimos, en este momento no podemos mostrar el detalle");
                }
            }
        }
        /// <summary>
        /// Cuando termina de cargar la página, muestra un mensaje de bienvenida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormHeladera_Shown(object sender, EventArgs e)
        {
            if (mostrarModalBienvenida)
            {            
                MessageBox.Show(vendedor.ObtenerMensajeBienvenida());               
            }
        }
    }
}
