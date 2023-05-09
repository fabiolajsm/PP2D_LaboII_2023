namespace Suarez_Fabiola_2D_2023
{
    partial class ModificarStock
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
            Lb_ModificarStock = new Label();
            Btn_Volver = new Button();
            Tb_Cantidad = new TextBox();
            Lb_NombreProducto = new Label();
            Lb_ModificarProductos = new ListBox();
            Lb_Cantidad = new Label();
            Btn_ModificarStock = new Button();
            LinkLabel_AgregarProducto = new LinkLabel();
            SuspendLayout();
            // 
            // Lb_ModificarStock
            // 
            Lb_ModificarStock.AutoSize = true;
            Lb_ModificarStock.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_ModificarStock.Location = new Point(40, 36);
            Lb_ModificarStock.Margin = new Padding(4, 0, 4, 0);
            Lb_ModificarStock.Name = "Lb_ModificarStock";
            Lb_ModificarStock.Size = new Size(360, 33);
            Lb_ModificarStock.TabIndex = 0;
            Lb_ModificarStock.Text = "Modificar stock disponible";
            // 
            // Btn_Volver
            // 
            Btn_Volver.AccessibleName = "Btn_Volver";
            Btn_Volver.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Volver.Location = new Point(40, 448);
            Btn_Volver.Margin = new Padding(4);
            Btn_Volver.Name = "Btn_Volver";
            Btn_Volver.Size = new Size(165, 36);
            Btn_Volver.TabIndex = 19;
            Btn_Volver.Text = "Volver";
            Btn_Volver.UseVisualStyleBackColor = true;
            Btn_Volver.Click += Btn_Volver_Click;
            // 
            // Tb_Cantidad
            // 
            Tb_Cantidad.BorderStyle = BorderStyle.None;
            Tb_Cantidad.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Cantidad.Location = new Point(244, 408);
            Tb_Cantidad.Margin = new Padding(4);
            Tb_Cantidad.MaxLength = 6;
            Tb_Cantidad.Name = "Tb_Cantidad";
            Tb_Cantidad.Size = new Size(190, 23);
            Tb_Cantidad.TabIndex = 18;
            Tb_Cantidad.Text = "0";
            Tb_Cantidad.TextAlign = HorizontalAlignment.Center;
            Tb_Cantidad.KeyPress += Tb_Cantidad_KeyPress;
            // 
            // Lb_NombreProducto
            // 
            Lb_NombreProducto.AccessibleName = "Lb_NombreProducto";
            Lb_NombreProducto.AutoSize = true;
            Lb_NombreProducto.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_NombreProducto.Location = new Point(40, 86);
            Lb_NombreProducto.Margin = new Padding(4, 0, 4, 0);
            Lb_NombreProducto.Name = "Lb_NombreProducto";
            Lb_NombreProducto.Size = new Size(323, 22);
            Lb_NombreProducto.TabIndex = 15;
            Lb_NombreProducto.Text = "Nombre / Stock disponible en gramos";
            // 
            // Lb_ModificarProductos
            // 
            Lb_ModificarProductos.AccessibleName = "Lb_ModificarProductos";
            Lb_ModificarProductos.BackColor = Color.FromArgb(237, 237, 233);
            Lb_ModificarProductos.DisplayMember = "Nombre:";
            Lb_ModificarProductos.DrawMode = DrawMode.OwnerDrawFixed;
            Lb_ModificarProductos.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lb_ModificarProductos.FormattingEnabled = true;
            Lb_ModificarProductos.ItemHeight = 20;
            Lb_ModificarProductos.Location = new Point(40, 130);
            Lb_ModificarProductos.Margin = new Padding(4);
            Lb_ModificarProductos.Name = "Lb_ModificarProductos";
            Lb_ModificarProductos.Size = new Size(393, 244);
            Lb_ModificarProductos.TabIndex = 14;
            Lb_ModificarProductos.DrawItem += Lb_ModificarProductos_DrawItem;
            // 
            // Lb_Cantidad
            // 
            Lb_Cantidad.AccessibleName = "Lb_Cantidad";
            Lb_Cantidad.AutoSize = true;
            Lb_Cantidad.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Cantidad.Location = new Point(40, 408);
            Lb_Cantidad.Margin = new Padding(4, 0, 4, 0);
            Lb_Cantidad.Name = "Lb_Cantidad";
            Lb_Cantidad.Size = new Size(181, 22);
            Lb_Cantidad.TabIndex = 17;
            Lb_Cantidad.Text = "Cantidad en gramos:";
            // 
            // Btn_ModificarStock
            // 
            Btn_ModificarStock.AccessibleName = "Btn_ModificarStock";
            Btn_ModificarStock.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_ModificarStock.Location = new Point(244, 448);
            Btn_ModificarStock.Margin = new Padding(4);
            Btn_ModificarStock.Name = "Btn_ModificarStock";
            Btn_ModificarStock.Size = new Size(190, 36);
            Btn_ModificarStock.TabIndex = 16;
            Btn_ModificarStock.Text = "Guardar cambios";
            Btn_ModificarStock.UseVisualStyleBackColor = true;
            Btn_ModificarStock.Click += Btn_ModificarStock_Click;
            // 
            // LinkLabel_AgregarProducto
            // 
            LinkLabel_AgregarProducto.ActiveLinkColor = Color.DarkGray;
            LinkLabel_AgregarProducto.AutoSize = true;
            LinkLabel_AgregarProducto.Font = new Font("Book Antiqua", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            LinkLabel_AgregarProducto.LinkColor = Color.Black;
            LinkLabel_AgregarProducto.Location = new Point(40, 502);
            LinkLabel_AgregarProducto.Margin = new Padding(4, 0, 4, 0);
            LinkLabel_AgregarProducto.Name = "LinkLabel_AgregarProducto";
            LinkLabel_AgregarProducto.Size = new Size(375, 27);
            LinkLabel_AgregarProducto.TabIndex = 20;
            LinkLabel_AgregarProducto.TabStop = true;
            LinkLabel_AgregarProducto.Text = "Si desea agregar un producto presione aquí";
            LinkLabel_AgregarProducto.LinkClicked += LinkLabel_AgregarProducto_LinkClicked;
            // 
            // ModificarStock
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(138, 121, 104);
            CancelButton = Btn_Volver;
            ClientSize = new Size(475, 562);
            ControlBox = false;
            Controls.Add(LinkLabel_AgregarProducto);
            Controls.Add(Btn_Volver);
            Controls.Add(Tb_Cantidad);
            Controls.Add(Lb_NombreProducto);
            Controls.Add(Lb_ModificarProductos);
            Controls.Add(Lb_Cantidad);
            Controls.Add(Btn_ModificarStock);
            Controls.Add(Lb_ModificarStock);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ModificarStock";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += ModificarStock_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lb_ModificarStock;
        private Button Btn_Volver;
        private TextBox Tb_Cantidad;
        private Label Lb_NombreProducto;
        private ListBox Lb_ModificarProductos;
        private Label Lb_Cantidad;
        private Button Btn_ModificarStock;
        private LinkLabel LinkLabel_AgregarProducto;
    }
}