namespace Suarez_Fabiola_2D_2023
{
    partial class AgregarAlCarrito
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
            Lb_Productos = new ListBox();
            Lb_NombreProducto = new Label();
            Btn_CerrarSesion = new Button();
            Btn_AgregarAlCarrito = new Button();
            NumericUpDown = new NumericUpDown();
            Lb_Cantidad = new Label();
            Btn_Continuar = new Button();
            Lb_Total = new Label();
            Gb_ListaDeProductos = new GroupBox();
            Gb_MetodoDePago = new GroupBox();
            Lb_PrecioFinal = new Label();
            Lb_Recargo = new Label();
            Rb_MercadoPago = new RadioButton();
            Rb_Credito = new RadioButton();
            Rb_Debito = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown).BeginInit();
            Gb_ListaDeProductos.SuspendLayout();
            Gb_MetodoDePago.SuspendLayout();
            SuspendLayout();
            // 
            // Lb_Productos
            // 
            Lb_Productos.AccessibleName = "Lb_Productos";
            Lb_Productos.DisplayMember = "Nombre:";
            Lb_Productos.DrawMode = DrawMode.OwnerDrawFixed;
            Lb_Productos.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lb_Productos.FormattingEnabled = true;
            Lb_Productos.ItemHeight = 20;
            Lb_Productos.Location = new Point(19, 58);
            Lb_Productos.Name = "Lb_Productos";
            Lb_Productos.Size = new Size(305, 164);
            Lb_Productos.TabIndex = 1;
            Lb_Productos.DrawItem += Lb_Productos_DrawItem;
            // 
            // Lb_NombreProducto
            // 
            Lb_NombreProducto.AccessibleName = "Lb_NombreProducto";
            Lb_NombreProducto.AutoSize = true;
            Lb_NombreProducto.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_NombreProducto.Location = new Point(19, 36);
            Lb_NombreProducto.Name = "Lb_NombreProducto";
            Lb_NombreProducto.Size = new Size(182, 19);
            Lb_NombreProducto.TabIndex = 3;
            Lb_NombreProducto.Text = "Nombre / Precio por Kilo";
            // 
            // Btn_CerrarSesion
            // 
            Btn_CerrarSesion.AccessibleName = "Btn_CerrarSesion";
            Btn_CerrarSesion.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_CerrarSesion.Location = new Point(492, 311);
            Btn_CerrarSesion.Name = "Btn_CerrarSesion";
            Btn_CerrarSesion.Size = new Size(94, 29);
            Btn_CerrarSesion.TabIndex = 4;
            Btn_CerrarSesion.Text = "Salir";
            Btn_CerrarSesion.UseVisualStyleBackColor = true;
            // 
            // Btn_AgregarAlCarrito
            // 
            Btn_AgregarAlCarrito.AccessibleName = "Btn_AgregarAlCarrito";
            Btn_AgregarAlCarrito.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_AgregarAlCarrito.Location = new Point(19, 281);
            Btn_AgregarAlCarrito.Name = "Btn_AgregarAlCarrito";
            Btn_AgregarAlCarrito.Size = new Size(305, 29);
            Btn_AgregarAlCarrito.TabIndex = 5;
            Btn_AgregarAlCarrito.Text = "Agregar al carrito";
            Btn_AgregarAlCarrito.UseVisualStyleBackColor = true;
            // 
            // NumericUpDown
            // 
            NumericUpDown.AccessibleName = "NumericUpDown Cantidad";
            NumericUpDown.BorderStyle = BorderStyle.None;
            NumericUpDown.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NumericUpDown.Location = new Point(174, 235);
            NumericUpDown.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            NumericUpDown.Name = "NumericUpDown";
            NumericUpDown.Size = new Size(150, 22);
            NumericUpDown.TabIndex = 6;
            NumericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // Lb_Cantidad
            // 
            Lb_Cantidad.AccessibleName = "Lb_Cantidad";
            Lb_Cantidad.AutoSize = true;
            Lb_Cantidad.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Cantidad.Location = new Point(19, 235);
            Lb_Cantidad.Name = "Lb_Cantidad";
            Lb_Cantidad.Size = new Size(152, 19);
            Lb_Cantidad.TabIndex = 7;
            Lb_Cantidad.Text = "Cantidad en gramos:";
            // 
            // Btn_Continuar
            // 
            Btn_Continuar.AccessibleName = "Btn_Continuar";
            Btn_Continuar.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Continuar.Location = new Point(603, 311);
            Btn_Continuar.Name = "Btn_Continuar";
            Btn_Continuar.Size = new Size(94, 29);
            Btn_Continuar.TabIndex = 8;
            Btn_Continuar.Text = "Continuar";
            Btn_Continuar.UseVisualStyleBackColor = true;
            // 
            // Lb_Total
            // 
            Lb_Total.AccessibleName = "Lb_Total";
            Lb_Total.AutoSize = true;
            Lb_Total.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Total.Location = new Point(263, 336);
            Lb_Total.Name = "Lb_Total";
            Lb_Total.Size = new Size(61, 19);
            Lb_Total.TabIndex = 9;
            Lb_Total.Text = "Total: 0";
            // 
            // Gb_ListaDeProductos
            // 
            Gb_ListaDeProductos.AccessibleName = "Gb_ListaDeProductos";
            Gb_ListaDeProductos.Controls.Add(Lb_NombreProducto);
            Gb_ListaDeProductos.Controls.Add(Lb_Total);
            Gb_ListaDeProductos.Controls.Add(Lb_Productos);
            Gb_ListaDeProductos.Controls.Add(Lb_Cantidad);
            Gb_ListaDeProductos.Controls.Add(Btn_AgregarAlCarrito);
            Gb_ListaDeProductos.Controls.Add(NumericUpDown);
            Gb_ListaDeProductos.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Gb_ListaDeProductos.Location = new Point(28, 30);
            Gb_ListaDeProductos.Name = "Gb_ListaDeProductos";
            Gb_ListaDeProductos.Size = new Size(342, 372);
            Gb_ListaDeProductos.TabIndex = 10;
            Gb_ListaDeProductos.TabStop = false;
            Gb_ListaDeProductos.Text = "Lista de productos";
            // 
            // Gb_MetodoDePago
            // 
            Gb_MetodoDePago.AccessibleName = "Gb_MetodoDePago";
            Gb_MetodoDePago.Controls.Add(Lb_PrecioFinal);
            Gb_MetodoDePago.Controls.Add(Lb_Recargo);
            Gb_MetodoDePago.Controls.Add(Rb_MercadoPago);
            Gb_MetodoDePago.Controls.Add(Rb_Credito);
            Gb_MetodoDePago.Controls.Add(Rb_Debito);
            Gb_MetodoDePago.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Gb_MetodoDePago.Location = new Point(428, 89);
            Gb_MetodoDePago.Name = "Gb_MetodoDePago";
            Gb_MetodoDePago.Size = new Size(334, 198);
            Gb_MetodoDePago.TabIndex = 11;
            Gb_MetodoDePago.TabStop = false;
            Gb_MetodoDePago.Text = "Seleccione su método de pago";
            // 
            // Lb_PrecioFinal
            // 
            Lb_PrecioFinal.AccessibleName = "Lb_PrecioFinal";
            Lb_PrecioFinal.AutoSize = true;
            Lb_PrecioFinal.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_PrecioFinal.Location = new Point(34, 163);
            Lb_PrecioFinal.Name = "Lb_PrecioFinal";
            Lb_PrecioFinal.Size = new Size(105, 19);
            Lb_PrecioFinal.TabIndex = 9;
            Lb_PrecioFinal.Text = "Precio final: 0";
            // 
            // Lb_Recargo
            // 
            Lb_Recargo.AccessibleName = "Lb_Recargo";
            Lb_Recargo.AutoSize = true;
            Lb_Recargo.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Recargo.Location = new Point(34, 131);
            Lb_Recargo.Name = "Lb_Recargo";
            Lb_Recargo.Size = new Size(81, 19);
            Lb_Recargo.TabIndex = 8;
            Lb_Recargo.Text = "Recargo: 0";
            // 
            // Rb_MercadoPago
            // 
            Rb_MercadoPago.AccessibleName = "Rb_MercadoPago";
            Rb_MercadoPago.AutoSize = true;
            Rb_MercadoPago.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Rb_MercadoPago.Location = new Point(34, 30);
            Rb_MercadoPago.Name = "Rb_MercadoPago";
            Rb_MercadoPago.Size = new Size(126, 24);
            Rb_MercadoPago.TabIndex = 2;
            Rb_MercadoPago.TabStop = true;
            Rb_MercadoPago.Text = "Mercado Pago";
            Rb_MercadoPago.UseVisualStyleBackColor = true;
            // 
            // Rb_Credito
            // 
            Rb_Credito.AccessibleName = "Rb_Credito";
            Rb_Credito.AutoSize = true;
            Rb_Credito.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Rb_Credito.Location = new Point(34, 90);
            Rb_Credito.Name = "Rb_Credito";
            Rb_Credito.Size = new Size(268, 24);
            Rb_Credito.TabIndex = 1;
            Rb_Credito.TabStop = true;
            Rb_Credito.Text = "Tarjeta de Crédito (Recargo del 5%)";
            Rb_Credito.UseVisualStyleBackColor = true;
            // 
            // Rb_Debito
            // 
            Rb_Debito.AccessibleName = "Rb_Debito";
            Rb_Debito.AutoSize = true;
            Rb_Debito.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Rb_Debito.Location = new Point(34, 60);
            Rb_Debito.Name = "Rb_Debito";
            Rb_Debito.Size = new Size(145, 24);
            Rb_Debito.TabIndex = 0;
            Rb_Debito.TabStop = true;
            Rb_Debito.Text = "Tarjeta de Débito";
            Rb_Debito.UseVisualStyleBackColor = true;
            // 
            // AgregarAlCarrito
            // 
            AccessibleName = "Agregar al carrito";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 250, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(Gb_MetodoDePago);
            Controls.Add(Gb_ListaDeProductos);
            Controls.Add(Btn_Continuar);
            Controls.Add(Btn_CerrarSesion);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarAlCarrito";
            ((System.ComponentModel.ISupportInitialize)NumericUpDown).EndInit();
            Gb_ListaDeProductos.ResumeLayout(false);
            Gb_ListaDeProductos.PerformLayout();
            Gb_MetodoDePago.ResumeLayout(false);
            Gb_MetodoDePago.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ListBox Lb_Productos;
        private Label Lb_NombreProducto;
        private Button Btn_CerrarSesion;
        private Button Btn_AgregarAlCarrito;
        private NumericUpDown NumericUpDown;
        private Label Lb_Cantidad;
        private Button Btn_Continuar;
        private Label Lb_Total;
        private GroupBox Gb_ListaDeProductos;
        private GroupBox Gb_MetodoDePago;
        private RadioButton Rb_MercadoPago;
        private RadioButton Rb_Credito;
        private RadioButton Rb_Debito;
        private Label Lb_PrecioFinal;
        private Label Lb_Recargo;
    }
}