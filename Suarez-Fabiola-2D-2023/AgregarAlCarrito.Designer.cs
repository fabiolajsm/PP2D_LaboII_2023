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
            Lb_Cantidad = new Label();
            Btn_Continuar = new Button();
            Lb_Total = new Label();
            Gb_ListaDeProductos = new GroupBox();
            Lb_Recordatorio = new Label();
            Btn_Comprar = new Button();
            Tb_Cantidad = new TextBox();
            Btn_EliminarDelCarrito = new Button();
            Gb_ListaDeProductos.SuspendLayout();
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
            Lb_Productos.Location = new Point(17, 62);
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
            Lb_NombreProducto.Location = new Point(17, 40);
            Lb_NombreProducto.Name = "Lb_NombreProducto";
            Lb_NombreProducto.Size = new Size(182, 19);
            Lb_NombreProducto.TabIndex = 3;
            Lb_NombreProducto.Text = "Nombre / Precio por Kilo";
            // 
            // Btn_CerrarSesion
            // 
            Btn_CerrarSesion.AccessibleName = "Btn_CerrarSesion";
            Btn_CerrarSesion.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_CerrarSesion.Location = new Point(494, 373);
            Btn_CerrarSesion.Name = "Btn_CerrarSesion";
            Btn_CerrarSesion.Size = new Size(94, 29);
            Btn_CerrarSesion.TabIndex = 4;
            Btn_CerrarSesion.Text = "Salir";
            Btn_CerrarSesion.UseVisualStyleBackColor = true;
            Btn_CerrarSesion.Click += Btn_CerrarSesion_Click;
            // 
            // Btn_AgregarAlCarrito
            // 
            Btn_AgregarAlCarrito.AccessibleName = "Btn_AgregarAlCarrito";
            Btn_AgregarAlCarrito.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_AgregarAlCarrito.Location = new Point(168, 265);
            Btn_AgregarAlCarrito.Name = "Btn_AgregarAlCarrito";
            Btn_AgregarAlCarrito.Size = new Size(132, 29);
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
            Lb_Cantidad.Location = new Point(17, 233);
            Lb_Cantidad.Name = "Lb_Cantidad";
            Lb_Cantidad.Size = new Size(152, 19);
            Lb_Cantidad.TabIndex = 7;
            Lb_Cantidad.Text = "Cantidad en gramos:";
            // 
            // Btn_Continuar
            // 
            Btn_Continuar.AccessibleName = "Btn_Continuar";
            Btn_Continuar.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Continuar.Location = new Point(603, 373);
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
            Lb_Total.Location = new Point(17, 333);
            Lb_Total.Name = "Lb_Total";
            Lb_Total.Size = new Size(61, 19);
            Lb_Total.TabIndex = 9;
            Lb_Total.Text = "Total: 0";
            // 
            // Gb_ListaDeProductos
            // 
            Gb_ListaDeProductos.AccessibleName = "Gb_ListaDeProductos";
            Gb_ListaDeProductos.BackColor = Color.FromArgb(254, 250, 224);
            Gb_ListaDeProductos.Controls.Add(Btn_EliminarDelCarrito);
            Gb_ListaDeProductos.Controls.Add(Lb_Recordatorio);
            Gb_ListaDeProductos.Controls.Add(Btn_Comprar);
            Gb_ListaDeProductos.Controls.Add(Tb_Cantidad);
            Gb_ListaDeProductos.Controls.Add(Lb_NombreProducto);
            Gb_ListaDeProductos.Controls.Add(Lb_Total);
            Gb_ListaDeProductos.Controls.Add(Lb_Productos);
            Gb_ListaDeProductos.Controls.Add(Lb_Cantidad);
            Gb_ListaDeProductos.Controls.Add(Btn_AgregarAlCarrito);
            Gb_ListaDeProductos.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Gb_ListaDeProductos.Location = new Point(23, 12);
            Gb_ListaDeProductos.Name = "Gb_ListaDeProductos";
            Gb_ListaDeProductos.Size = new Size(342, 392);
            Gb_ListaDeProductos.TabIndex = 10;
            Gb_ListaDeProductos.TabStop = false;
            Gb_ListaDeProductos.Text = "Lista de productos";
            // 
            // Lb_Recordatorio
            // 
            Lb_Recordatorio.AccessibleName = "Lb_Recordatorio";
            Lb_Recordatorio.Font = new Font("Book Antiqua", 9F, FontStyle.Italic, GraphicsUnit.Point);
            Lb_Recordatorio.Location = new Point(17, 297);
            Lb_Recordatorio.Name = "Lb_Recordatorio";
            Lb_Recordatorio.Size = new Size(305, 25);
            Lb_Recordatorio.TabIndex = 12;
            Lb_Recordatorio.Text = "Si quiere finalizar la compra presione Comprar";
            // 
            // Btn_Comprar
            // 
            Btn_Comprar.AccessibleName = "Btn_Comprar";
            Btn_Comprar.Enabled = false;
            Btn_Comprar.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Comprar.Location = new Point(228, 346);
            Btn_Comprar.Name = "Btn_Comprar";
            Btn_Comprar.Size = new Size(94, 29);
            Btn_Comprar.TabIndex = 11;
            Btn_Comprar.Text = "Comprar";
            Btn_Comprar.UseVisualStyleBackColor = true;
            Btn_Comprar.Click += Btn_Comprar_Click;
            // 
            // Tb_Cantidad
            // 
            Tb_Cantidad.BorderStyle = BorderStyle.None;
            Tb_Cantidad.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Cantidad.Location = new Point(175, 232);
            Tb_Cantidad.MaxLength = 4;
            Tb_Cantidad.Name = "Tb_Cantidad";
            Tb_Cantidad.Size = new Size(125, 19);
            Tb_Cantidad.TabIndex = 10;
            Tb_Cantidad.Text = "0";
            Tb_Cantidad.TextAlign = HorizontalAlignment.Center;
            // 
            // Btn_EliminarDelCarrito
            // 
            Btn_EliminarDelCarrito.AccessibleName = "Btn_EliminarDelCarrito";
            Btn_EliminarDelCarrito.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_EliminarDelCarrito.Location = new Point(27, 265);
            Btn_EliminarDelCarrito.Name = "Btn_EliminarDelCarrito";
            Btn_EliminarDelCarrito.Size = new Size(132, 29);
            Btn_EliminarDelCarrito.TabIndex = 13;
            Btn_EliminarDelCarrito.Text = "Eliminar ";
            Btn_EliminarDelCarrito.UseVisualStyleBackColor = true;
            Btn_EliminarDelCarrito.Click += Btn_EliminarDelCarrito_Click;
            // 
            // AgregarAlCarrito
            // 
            AccessibleName = "Agregar al carrito";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 78, 65);
            ClientSize = new Size(800, 450);
            Controls.Add(Gb_ListaDeProductos);
            Controls.Add(Btn_Continuar);
            Controls.Add(Btn_CerrarSesion);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarAlCarrito";
            StartPosition = FormStartPosition.CenterScreen;
            Gb_ListaDeProductos.ResumeLayout(false);
            Gb_ListaDeProductos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ListBox Lb_Productos;
        private Label Lb_NombreProducto;
        private Button Btn_CerrarSesion;
        private Button Btn_AgregarAlCarrito;
        private Label Lb_Cantidad;
        private Button Btn_Continuar;
        private Label Lb_Total;
        private GroupBox Gb_ListaDeProductos;
        private TextBox Tb_Cantidad;
        private Button Btn_Comprar;
        private Label Lb_Recordatorio;
        private Button Btn_EliminarDelCarrito;
    }
}