﻿using System;
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
    public partial class FormHeladera : Form
    {
        public FormHeladera()
        {
            InitializeComponent();
            CargarListaProductos(dataGridView, DatosEnMemoria.listaProductos);
            CargarOpcionesDelComboBox();
        }

        private void CargarListaProductos(DataGridView dataGridView, List<Producto> listaProductos)
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
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)row.Cells["Ver detalle"];
                buttonCell.Value = "Ver detalle";
            }
        }
        private void CargarOpcionesDelComboBox()
        {
            Cb_Opciones.Items.Clear();

            string[] opciones = { "Vender productos", "Modificar stock de los productos", "Fijar precios por kilo", "Fijar tipos de cortes" };
            for (int i = 0; i < opciones.Length; i++)
            {
                Cb_Opciones.Items.Add(opciones[i]);
            }
            Cb_Opciones.SelectedIndex = 0;
        }

        private void Btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void Btn_Continuar_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = Cb_Opciones.Text;

            if (opcionSeleccionada.Length > 0)
            {
                switch (opcionSeleccionada)
                {
                    case "Vender productos":
                        MessageBox.Show("1");
                        break;
                    case "Modificar stock de los productos":
                        this.Enabled = false;
                        ModificarStock modificarStock = new ModificarStock();
                        modificarStock.ShowDialog();
                        break;
                    case "Fijar precios por kilo":
                        this.Enabled = false;
                        FijarPrecios fijarPrecios = new FijarPrecios();
                        fijarPrecios.ShowDialog();
                        break;
                    case "Fijar tipos de cortes":
                        this.Enabled = false;
                        FijarCortes fijarCortes = new FijarCortes();
                        fijarCortes.ShowDialog();
                        break;
                }
            }
        }

        private void HabilitarBotonContinuar()
        {
            string opcionSeleccionada = Cb_Opciones.Text;

            if (!string.IsNullOrEmpty(opcionSeleccionada))
            {
                Btn_Continuar.Enabled = true;
            }
            else
            {
                Btn_Continuar.Enabled = false;
            }
        }

        private void Cb_Opciones_SelectedIndexChanged(object sender, EventArgs e)
        {

            string opcionSeleccionada = Cb_Opciones.Text;

            HabilitarBotonContinuar();

        }
    }
}
