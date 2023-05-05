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
            Btn_Volver.Location = new Point(28, 384);
            Btn_Volver.Name = "Btn_Volver";
            Btn_Volver.Size = new Size(132, 29);
            Btn_Volver.TabIndex = 26;
            Btn_Volver.Text = "Volver";
            Btn_Volver.UseVisualStyleBackColor = true;
            Btn_Volver.Click += Btn_Volver_Click;
            // 
            // Tb_Precio
            // 
            Tb_Precio.BorderStyle = BorderStyle.None;
            Tb_Precio.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Precio.Location = new Point(230, 340);
            Tb_Precio.MaxLength = 4;
            Tb_Precio.Name = "Tb_Precio";
            Tb_Precio.Size = new Size(103, 19);
            Tb_Precio.TabIndex = 25;
            Tb_Precio.Text = "0";
            Tb_Precio.TextAlign = HorizontalAlignment.Center;
            // 
            // Lb_NombreProducto
            // 
            Lb_NombreProducto.AccessibleName = "Lb_NombreProducto";
            Lb_NombreProducto.AutoSize = true;
            Lb_NombreProducto.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_NombreProducto.Location = new Point(28, 71);
            Lb_NombreProducto.Name = "Lb_NombreProducto";
            Lb_NombreProducto.Size = new Size(179, 19);
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
            Lb_FijarPrecio.Location = new Point(28, 110);
            Lb_FijarPrecio.Name = "Lb_FijarPrecio";
            Lb_FijarPrecio.Size = new Size(305, 204);
            Lb_FijarPrecio.TabIndex = 21;
            Lb_FijarPrecio.DrawItem += Lb_FijarPrecio_DrawItem;
            // 
            // Lb_Precio
            // 
            Lb_Precio.AccessibleName = "Lb_Precio";
            Lb_Precio.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Precio.Location = new Point(28, 340);
            Lb_Precio.Name = "Lb_Precio";
            Lb_Precio.Size = new Size(208, 29);
            Lb_Precio.TabIndex = 24;
            Lb_Precio.Text = "Nuevo precio del producto:";
            // 
            // Btn_FijarPrecio
            // 
            Btn_FijarPrecio.AccessibleName = "Btn_FijarPrecio";
            Btn_FijarPrecio.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_FijarPrecio.Location = new Point(181, 384);
            Btn_FijarPrecio.Name = "Btn_FijarPrecio";
            Btn_FijarPrecio.Size = new Size(152, 29);
            Btn_FijarPrecio.TabIndex = 23;
            Btn_FijarPrecio.Text = "Guardar cambios";
            Btn_FijarPrecio.UseVisualStyleBackColor = true;
            // 
            // Lb_Titulo
            // 
            Lb_Titulo.AutoSize = true;
            Lb_Titulo.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Titulo.Location = new Point(28, 34);
            Lb_Titulo.Name = "Lb_Titulo";
            Lb_Titulo.Size = new Size(235, 27);
            Lb_Titulo.TabIndex = 20;
            Lb_Titulo.Text = "Fijar precios por kilo";
            // 
            // FijarPrecios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(138, 121, 104);
            ClientSize = new Size(366, 445);
            ControlBox = false;
            Controls.Add(Btn_Volver);
            Controls.Add(Tb_Precio);
            Controls.Add(Lb_NombreProducto);
            Controls.Add(Lb_FijarPrecio);
            Controls.Add(Lb_Precio);
            Controls.Add(Btn_FijarPrecio);
            Controls.Add(Lb_Titulo);
            FormBorderStyle = FormBorderStyle.Fixed3D;
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