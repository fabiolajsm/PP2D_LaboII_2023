using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Suarez_Fabiola_2D_2023
{
    public partial class ModificarStock : Form
    {
        public ModificarStock()
        {
            InitializeComponent();
            Lb_ModificarProductos.DrawMode = DrawMode.OwnerDrawFixed;
            CargarItemsProductos();
        }

        private void CargarItemsProductos()
        {
            if (DatosEnMemoria.listaProductos.Count == 0) return;

            Lb_ModificarProductos.Items.Clear();
            foreach (Producto producto in DatosEnMemoria.listaProductos)
            {
                Lb_ModificarProductos.Items.Add(producto);
            }
        }
        private void Lb_ModificarProductos_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string nombreProducto = ((Producto)Lb_ModificarProductos.Items[e.Index]).Nombre;
            double stockDisponible = ((Producto)Lb_ModificarProductos.Items[e.Index]).StockDisponible;

            Brush brush = SystemBrushes.WindowText;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                brush = SystemBrushes.GradientInactiveCaption;
            }

            // Calcular la posición y tamaño de las dos columnas
            int width = e.Bounds.Width;
            int col1Width = (int)(width * 0.6);
            int col2Width = width - col1Width;
            Rectangle col1Rect = new Rectangle(e.Bounds.X, e.Bounds.Y, col1Width, e.Bounds.Height);
            Rectangle col2Rect = new Rectangle(e.Bounds.X + col1Width, e.Bounds.Y, col2Width, e.Bounds.Height);

            // Dibujar el nombre del producto en la primera columna
            e.Graphics.DrawString(nombreProducto, e.Font, brush, col1Rect);

            // Dibujar el stock Disponible en la segunda columna
            e.Graphics.DrawString(stockDisponible.ToString(), e.Font, brush, col2Rect,
                new StringFormat() { Alignment = StringAlignment.Far });

            e.DrawFocusRectangle();
        }
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHeladera formHeladera = (FormHeladera)Application.OpenForms["FormHeladera"];
            formHeladera.Enabled = true;
        }
    }
}
