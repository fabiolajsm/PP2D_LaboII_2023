namespace Suarez_Fabiola_2D_2023
{
    partial class FormVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            Btn_CerrarSesion = new Button();
            Btn_AgregarAlCarrito = new Button();
            Lb_Cantidad = new Label();
            Lb_Total = new Label();
            Gb_ListaDeProductos = new GroupBox();
            dataGridViewProductos = new DataGridView();
            Cb_FiltrarPorCorte = new ComboBox();
            Btn_EliminarDelCarrito = new Button();
            Lb_Recordatorio = new Label();
            Btn_Comprar = new Button();
            Tb_Cantidad = new TextBox();
            dataGridViewCarrito = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Gb_CarritoDeCompra = new GroupBox();
            Btn_VolverVendedor = new Button();
            Btn_ModificarMonto = new Button();
            Lb_MontoMaximo = new Label();
            Gb_ListaDeProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).BeginInit();
            Gb_CarritoDeCompra.SuspendLayout();
            SuspendLayout();
            // 
            // Btn_CerrarSesion
            // 
            Btn_CerrarSesion.AccessibleName = "Btn_CerrarSesion";
            Btn_CerrarSesion.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_CerrarSesion.Location = new Point(1030, 548);
            Btn_CerrarSesion.Margin = new Padding(4);
            Btn_CerrarSesion.Name = "Btn_CerrarSesion";
            Btn_CerrarSesion.Size = new Size(134, 36);
            Btn_CerrarSesion.TabIndex = 4;
            Btn_CerrarSesion.Text = "Cerrar sesión";
            Btn_CerrarSesion.UseVisualStyleBackColor = true;
            Btn_CerrarSesion.Click += Btn_CerrarSesion_Click;
            // 
            // Btn_AgregarAlCarrito
            // 
            Btn_AgregarAlCarrito.AccessibleName = "Btn_AgregarAlCarrito";
            Btn_AgregarAlCarrito.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_AgregarAlCarrito.Location = new Point(325, 401);
            Btn_AgregarAlCarrito.Margin = new Padding(4);
            Btn_AgregarAlCarrito.Name = "Btn_AgregarAlCarrito";
            Btn_AgregarAlCarrito.Size = new Size(217, 36);
            Btn_AgregarAlCarrito.TabIndex = 5;
            Btn_AgregarAlCarrito.Text = "Agregar";
            Btn_AgregarAlCarrito.UseVisualStyleBackColor = true;
            Btn_AgregarAlCarrito.Click += Btn_AgregarAlCarrito_Click;
            // 
            // Lb_Cantidad
            // 
            Lb_Cantidad.AccessibleName = "Lb_Cantidad";
            Lb_Cantidad.AutoSize = true;
            Lb_Cantidad.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Cantidad.Location = new Point(118, 357);
            Lb_Cantidad.Margin = new Padding(4, 0, 4, 0);
            Lb_Cantidad.Name = "Lb_Cantidad";
            Lb_Cantidad.Size = new Size(242, 22);
            Lb_Cantidad.TabIndex = 7;
            Lb_Cantidad.Text = "Ingrese cantidad en gramos:";
            // 
            // Lb_Total
            // 
            Lb_Total.AccessibleName = "Lb_Total";
            Lb_Total.AutoSize = true;
            Lb_Total.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Total.Location = new Point(100, 503);
            Lb_Total.Margin = new Padding(4, 0, 4, 0);
            Lb_Total.Name = "Lb_Total";
            Lb_Total.Size = new Size(137, 22);
            Lb_Total.TabIndex = 9;
            Lb_Total.Text = "Total a pagar: 0";
            // 
            // Gb_ListaDeProductos
            // 
            Gb_ListaDeProductos.AccessibleName = "Gb_ListaDeProductos";
            Gb_ListaDeProductos.BackColor = Color.FromArgb(176, 190, 169);
            Gb_ListaDeProductos.Controls.Add(dataGridViewProductos);
            Gb_ListaDeProductos.Controls.Add(Cb_FiltrarPorCorte);
            Gb_ListaDeProductos.Controls.Add(Btn_EliminarDelCarrito);
            Gb_ListaDeProductos.Controls.Add(Lb_Recordatorio);
            Gb_ListaDeProductos.Controls.Add(Btn_Comprar);
            Gb_ListaDeProductos.Controls.Add(Tb_Cantidad);
            Gb_ListaDeProductos.Controls.Add(Lb_Total);
            Gb_ListaDeProductos.Controls.Add(Lb_Cantidad);
            Gb_ListaDeProductos.Controls.Add(Btn_AgregarAlCarrito);
            Gb_ListaDeProductos.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Gb_ListaDeProductos.Location = new Point(38, 32);
            Gb_ListaDeProductos.Margin = new Padding(4);
            Gb_ListaDeProductos.Name = "Gb_ListaDeProductos";
            Gb_ListaDeProductos.Padding = new Padding(4);
            Gb_ListaDeProductos.Size = new Size(637, 558);
            Gb_ListaDeProductos.TabIndex = 10;
            Gb_ListaDeProductos.TabStop = false;
            Gb_ListaDeProductos.Text = "Lista de productos";
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.AllowUserToAddRows = false;
            dataGridViewProductos.AllowUserToDeleteRows = false;
            dataGridViewProductos.AllowUserToResizeColumns = false;
            dataGridViewProductos.AllowUserToResizeRows = false;
            dataGridViewProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductos.BackgroundColor = Color.FromArgb(237, 237, 233);
            dataGridViewProductos.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 247, 238);
            dataGridViewCellStyle1.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(237, 237, 233);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewProductos.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(237, 237, 233);
            dataGridViewCellStyle2.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(237, 237, 233);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewProductos.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewProductos.GridColor = Color.FromArgb(241, 247, 238);
            dataGridViewProductos.Location = new Point(24, 79);
            dataGridViewProductos.Margin = new Padding(4);
            dataGridViewProductos.MultiSelect = false;
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewProductos.RowHeadersWidth = 51;
            dataGridViewProductos.RowTemplate.Height = 29;
            dataGridViewProductos.ScrollBars = ScrollBars.None;
            dataGridViewProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProductos.Size = new Size(586, 253);
            dataGridViewProductos.TabIndex = 12;
            // 
            // Cb_FiltrarPorCorte
            // 
            Cb_FiltrarPorCorte.AccessibleName = "Cb_FiltrarPorCorte";
            Cb_FiltrarPorCorte.DropDownStyle = ComboBoxStyle.DropDownList;
            Cb_FiltrarPorCorte.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Cb_FiltrarPorCorte.FormattingEnabled = true;
            Cb_FiltrarPorCorte.Location = new Point(24, 41);
            Cb_FiltrarPorCorte.Margin = new Padding(4);
            Cb_FiltrarPorCorte.Name = "Cb_FiltrarPorCorte";
            Cb_FiltrarPorCorte.Size = new Size(352, 30);
            Cb_FiltrarPorCorte.TabIndex = 13;
            Cb_FiltrarPorCorte.SelectedIndexChanged += Cb_FiltrarPorCorte_SelectedIndexChanged;
            // 
            // Btn_EliminarDelCarrito
            // 
            Btn_EliminarDelCarrito.AccessibleName = "Btn_EliminarDelCarrito";
            Btn_EliminarDelCarrito.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_EliminarDelCarrito.Location = new Point(100, 401);
            Btn_EliminarDelCarrito.Margin = new Padding(4);
            Btn_EliminarDelCarrito.Name = "Btn_EliminarDelCarrito";
            Btn_EliminarDelCarrito.Size = new Size(217, 36);
            Btn_EliminarDelCarrito.TabIndex = 13;
            Btn_EliminarDelCarrito.Text = "Eliminar ";
            Btn_EliminarDelCarrito.UseVisualStyleBackColor = true;
            Btn_EliminarDelCarrito.Click += Btn_EliminarDelCarrito_Click;
            // 
            // Lb_Recordatorio
            // 
            Lb_Recordatorio.AccessibleName = "Lb_Recordatorio";
            Lb_Recordatorio.Font = new Font("Book Antiqua", 9F, FontStyle.Italic, GraphicsUnit.Point);
            Lb_Recordatorio.Location = new Point(165, 452);
            Lb_Recordatorio.Margin = new Padding(4, 0, 4, 0);
            Lb_Recordatorio.Name = "Lb_Recordatorio";
            Lb_Recordatorio.Size = new Size(359, 31);
            Lb_Recordatorio.TabIndex = 12;
            Lb_Recordatorio.Text = "Si quiere finalizar la compra presione Comprar";
            // 
            // Btn_Comprar
            // 
            Btn_Comprar.AccessibleName = "Btn_Comprar";
            Btn_Comprar.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Comprar.Location = new Point(424, 495);
            Btn_Comprar.Margin = new Padding(4);
            Btn_Comprar.Name = "Btn_Comprar";
            Btn_Comprar.Size = new Size(118, 36);
            Btn_Comprar.TabIndex = 11;
            Btn_Comprar.Text = "Comprar";
            Btn_Comprar.UseVisualStyleBackColor = true;
            Btn_Comprar.Click += Btn_Comprar_Click;
            // 
            // Tb_Cantidad
            // 
            Tb_Cantidad.BorderStyle = BorderStyle.None;
            Tb_Cantidad.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Cantidad.Location = new Point(368, 357);
            Tb_Cantidad.Margin = new Padding(4);
            Tb_Cantidad.MaxLength = 4;
            Tb_Cantidad.Name = "Tb_Cantidad";
            Tb_Cantidad.Size = new Size(156, 23);
            Tb_Cantidad.TabIndex = 10;
            Tb_Cantidad.Text = "0";
            Tb_Cantidad.TextAlign = HorizontalAlignment.Center;
            Tb_Cantidad.KeyPress += Tb_Cantidad_KeyPress;
            // 
            // dataGridViewCarrito
            // 
            dataGridViewCarrito.AllowUserToAddRows = false;
            dataGridViewCarrito.AllowUserToDeleteRows = false;
            dataGridViewCarrito.AllowUserToResizeColumns = false;
            dataGridViewCarrito.AllowUserToResizeRows = false;
            dataGridViewCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCarrito.BackgroundColor = Color.FromArgb(237, 237, 233);
            dataGridViewCarrito.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(241, 247, 238);
            dataGridViewCellStyle4.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(237, 237, 233);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCarrito.ColumnHeadersHeight = 29;
            dataGridViewCarrito.Columns.AddRange(new DataGridViewColumn[] { Nombre, Cantidad, Precio });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(237, 237, 233);
            dataGridViewCellStyle5.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(237, 237, 233);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridViewCarrito.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCarrito.GridColor = Color.FromArgb(241, 247, 238);
            dataGridViewCarrito.Location = new Point(8, 58);
            dataGridViewCarrito.Margin = new Padding(4);
            dataGridViewCarrito.MultiSelect = false;
            dataGridViewCarrito.Name = "dataGridViewCarrito";
            dataGridViewCarrito.ReadOnly = true;
            dataGridViewCarrito.RowHeadersVisible = false;
            dataGridViewCarrito.RowHeadersWidth = 51;
            dataGridViewCarrito.RowTemplate.Height = 29;
            dataGridViewCarrito.ScrollBars = ScrollBars.None;
            dataGridViewCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCarrito.Size = new Size(444, 357);
            dataGridViewCarrito.TabIndex = 11;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            // 
            // Gb_CarritoDeCompra
            // 
            Gb_CarritoDeCompra.BackColor = Color.FromArgb(176, 190, 169);
            Gb_CarritoDeCompra.Controls.Add(dataGridViewCarrito);
            Gb_CarritoDeCompra.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Gb_CarritoDeCompra.Location = new Point(704, 32);
            Gb_CarritoDeCompra.Margin = new Padding(4);
            Gb_CarritoDeCompra.Name = "Gb_CarritoDeCompra";
            Gb_CarritoDeCompra.Padding = new Padding(4);
            Gb_CarritoDeCompra.Size = new Size(460, 451);
            Gb_CarritoDeCompra.TabIndex = 12;
            Gb_CarritoDeCompra.TabStop = false;
            Gb_CarritoDeCompra.Text = "Detalle de compra";
            // 
            // Btn_VolverVendedor
            // 
            Btn_VolverVendedor.AccessibleName = "Btn_VolverVendedor";
            Btn_VolverVendedor.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_VolverVendedor.Location = new Point(917, 548);
            Btn_VolverVendedor.Margin = new Padding(4);
            Btn_VolverVendedor.Name = "Btn_VolverVendedor";
            Btn_VolverVendedor.Size = new Size(105, 36);
            Btn_VolverVendedor.TabIndex = 13;
            Btn_VolverVendedor.Text = "Volver";
            Btn_VolverVendedor.UseVisualStyleBackColor = true;
            Btn_VolverVendedor.Visible = false;
            Btn_VolverVendedor.Click += Btn_VolverVendedor_Click;
            // 
            // Btn_ModificarMonto
            // 
            Btn_ModificarMonto.AccessibleName = "Btn_ModificarMonto";
            Btn_ModificarMonto.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_ModificarMonto.Location = new Point(704, 548);
            Btn_ModificarMonto.Margin = new Padding(4);
            Btn_ModificarMonto.Name = "Btn_ModificarMonto";
            Btn_ModificarMonto.Size = new Size(319, 36);
            Btn_ModificarMonto.TabIndex = 14;
            Btn_ModificarMonto.Text = "Modificar monto máximo de compra";
            Btn_ModificarMonto.UseVisualStyleBackColor = true;
            Btn_ModificarMonto.Visible = false;
            Btn_ModificarMonto.Click += Btn_ModificarMonto_Click;
            // 
            // Lb_MontoMaximo
            // 
            Lb_MontoMaximo.AccessibleName = "Lb_MontoMaximo";
            Lb_MontoMaximo.Font = new Font("Book Antiqua", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            Lb_MontoMaximo.Location = new Point(704, 500);
            Lb_MontoMaximo.Margin = new Padding(4, 0, 4, 0);
            Lb_MontoMaximo.Name = "Lb_MontoMaximo";
            Lb_MontoMaximo.Size = new Size(381, 31);
            Lb_MontoMaximo.TabIndex = 15;
            Lb_MontoMaximo.Text = "Su monto máximo de compra es de $0";
            // 
            // FormVenta
            // 
            AccessibleName = "Agregar al carrito";
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 247, 238);
            ClientSize = new Size(1177, 618);
            Controls.Add(Lb_MontoMaximo);
            Controls.Add(Btn_ModificarMonto);
            Controls.Add(Btn_VolverVendedor);
            Controls.Add(Gb_CarritoDeCompra);
            Controls.Add(Gb_ListaDeProductos);
            Controls.Add(Btn_CerrarSesion);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVenta";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += FormVenta_FormClosed;
            Load += FormVenta_Load;
            Shown += FormVenta_Shown;
            Gb_ListaDeProductos.ResumeLayout(false);
            Gb_ListaDeProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).EndInit();
            Gb_CarritoDeCompra.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button Btn_CerrarSesion;
        private Button Btn_AgregarAlCarrito;
        private Label Lb_Cantidad;
        private Label Lb_Total;
        private GroupBox Gb_ListaDeProductos;
        private TextBox Tb_Cantidad;
        private Label Lb_Recordatorio;
        private Button Btn_EliminarDelCarrito;
        private DataGridView dataGridViewCarrito;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Precio;
        private Button Btn_Comprar;
        private GroupBox Gb_CarritoDeCompra;
        private ComboBox Cb_FiltrarPorCorte;
        private Button Btn_VolverVendedor;
        private Button Btn_ModificarMonto;
        private Label Lb_MontoMaximo;
        private DataGridView dataGridViewProductos;
    }
}