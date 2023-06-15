namespace Suarez_Fabiola_2D_2023
{
    partial class FijarPrecios
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
            Btn_Volver = new Button();
            Tb_Precio = new TextBox();
            Lb_NombreProducto = new Label();
            Lb_FijarPrecio = new ListBox();
            Lb_Precio = new Label();
            Btn_FijarPrecio = new Button();
            Lb_Titulo = new Label();
            SuspendLayout();
            // 
            // Btn_Volver
            // 
            Btn_Volver.AccessibleName = "Btn_Volver";
            Btn_Volver.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Volver.Location = new Point(35, 480);
            Btn_Volver.Margin = new Padding(4);
            Btn_Volver.Name = "Btn_Volver";
            Btn_Volver.Size = new Size(165, 36);
            Btn_Volver.TabIndex = 26;
            Btn_Volver.Text = "Volver";
            Btn_Volver.UseVisualStyleBackColor = true;
            Btn_Volver.Click += Btn_Volver_Click;
            // 
            // Tb_Precio
            // 
            Tb_Precio.BorderStyle = BorderStyle.None;
            Tb_Precio.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Precio.Location = new Point(288, 425);
            Tb_Precio.Margin = new Padding(4);
            Tb_Precio.MaxLength = 6;
            Tb_Precio.Name = "Tb_Precio";
            Tb_Precio.Size = new Size(129, 23);
            Tb_Precio.TabIndex = 25;
            Tb_Precio.Text = "0";
            Tb_Precio.TextAlign = HorizontalAlignment.Center;
            Tb_Precio.KeyPress += Tb_Precio_KeyPress;
            // 
            // Lb_NombreProducto
            // 
            Lb_NombreProducto.AccessibleName = "Lb_NombreProducto";
            Lb_NombreProducto.AutoSize = true;
            Lb_NombreProducto.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_NombreProducto.Location = new Point(35, 89);
            Lb_NombreProducto.Margin = new Padding(4, 0, 4, 0);
            Lb_NombreProducto.Name = "Lb_NombreProducto";
            Lb_NombreProducto.Size = new Size(215, 22);
            Lb_NombreProducto.TabIndex = 22;
            Lb_NombreProducto.Text = "Nombre / Precio por kilo";
            // 
            // Lb_FijarPrecio
            // 
            Lb_FijarPrecio.AccessibleName = "Lb_FijarPrecio";
            Lb_FijarPrecio.BackColor = Color.FromArgb(237, 237, 233);
            Lb_FijarPrecio.DisplayMember = "Nombre:";
            Lb_FijarPrecio.DrawMode = DrawMode.OwnerDrawFixed;
            Lb_FijarPrecio.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lb_FijarPrecio.FormattingEnabled = true;
            Lb_FijarPrecio.ItemHeight = 20;
            Lb_FijarPrecio.Location = new Point(35, 138);
            Lb_FijarPrecio.Margin = new Padding(4);
            Lb_FijarPrecio.Name = "Lb_FijarPrecio";
            Lb_FijarPrecio.Size = new Size(380, 244);
            Lb_FijarPrecio.TabIndex = 21;
            Lb_FijarPrecio.DrawItem += Lb_FijarPrecio_DrawItem;
            // 
            // Lb_Precio
            // 
            Lb_Precio.AccessibleName = "Lb_Precio";
            Lb_Precio.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Precio.Location = new Point(35, 425);
            Lb_Precio.Margin = new Padding(4, 0, 4, 0);
            Lb_Precio.Name = "Lb_Precio";
            Lb_Precio.Size = new Size(260, 36);
            Lb_Precio.TabIndex = 24;
            Lb_Precio.Text = "Nuevo precio del producto:";
            // 
            // Btn_FijarPrecio
            // 
            Btn_FijarPrecio.AccessibleName = "Btn_FijarPrecio";
            Btn_FijarPrecio.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_FijarPrecio.Location = new Point(226, 480);
            Btn_FijarPrecio.Margin = new Padding(4);
            Btn_FijarPrecio.Name = "Btn_FijarPrecio";
            Btn_FijarPrecio.Size = new Size(190, 36);
            Btn_FijarPrecio.TabIndex = 23;
            Btn_FijarPrecio.Text = "Guardar cambios";
            Btn_FijarPrecio.UseVisualStyleBackColor = true;
            Btn_FijarPrecio.Click += Btn_FijarPrecio_Click;
            // 
            // Lb_Titulo
            // 
            Lb_Titulo.AutoSize = true;
            Lb_Titulo.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Titulo.Location = new Point(35, 42);
            Lb_Titulo.Margin = new Padding(4, 0, 4, 0);
            Lb_Titulo.Name = "Lb_Titulo";
            Lb_Titulo.Size = new Size(286, 33);
            Lb_Titulo.TabIndex = 20;
            Lb_Titulo.Text = "Fijar precios por kilo";
            // 
            // FijarPrecios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(138, 121, 104);
            ClientSize = new Size(458, 556);
            ControlBox = false;
            Controls.Add(Btn_Volver);
            Controls.Add(Tb_Precio);
            Controls.Add(Lb_NombreProducto);
            Controls.Add(Lb_FijarPrecio);
            Controls.Add(Lb_Precio);
            Controls.Add(Btn_FijarPrecio);
            Controls.Add(Lb_Titulo);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FijarPrecios";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += FijarPrecios_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Volver;
        private TextBox Tb_Precio;
        private Label Lb_NombreProducto;
        private ListBox Lb_FijarPrecio;
        private Label Lb_Precio;
        private Button Btn_FijarPrecio;
        private Label Lb_Titulo;
    }
}