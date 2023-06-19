namespace Suarez_Fabiola_2D_2023
{
    partial class FormAgregarProducto
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
            Tb_Precio = new TextBox();
            Tb_Stock = new TextBox();
            Tb_TipoCorte = new TextBox();
            Tb_Descripcion = new TextBox();
            Tb_Nombre = new TextBox();
            Lb_Titulo = new Label();
            Btn_Volver = new Button();
            Btn_AgregarProducto = new Button();
            SuspendLayout();
            // 
            // Tb_Precio
            // 
            Tb_Precio.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Precio.Location = new Point(99, 379);
            Tb_Precio.Margin = new Padding(4);
            Tb_Precio.MaxLength = 15;
            Tb_Precio.Name = "Tb_Precio";
            Tb_Precio.PlaceholderText = "Precio por kilo:";
            Tb_Precio.Size = new Size(343, 33);
            Tb_Precio.TabIndex = 49;
            Tb_Precio.KeyPress += Tb_Precio_KeyPress;
            // 
            // Tb_Stock
            // 
            Tb_Stock.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Stock.Location = new Point(99, 447);
            Tb_Stock.Margin = new Padding(4);
            Tb_Stock.MaxLength = 5;
            Tb_Stock.Name = "Tb_Stock";
            Tb_Stock.PlaceholderText = "Stock disponible en gramos:";
            Tb_Stock.Size = new Size(343, 33);
            Tb_Stock.TabIndex = 48;
            Tb_Stock.KeyPress += Tb_Stock_KeyPress;
            // 
            // Tb_TipoCorte
            // 
            Tb_TipoCorte.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_TipoCorte.Location = new Point(99, 307);
            Tb_TipoCorte.Margin = new Padding(4);
            Tb_TipoCorte.MaxLength = 20;
            Tb_TipoCorte.Name = "Tb_TipoCorte";
            Tb_TipoCorte.PlaceholderText = "Tipo de corte:";
            Tb_TipoCorte.Size = new Size(343, 33);
            Tb_TipoCorte.TabIndex = 47;
            Tb_TipoCorte.KeyPress += Tb_TipoCorte_KeyPress;
            // 
            // Tb_Descripcion
            // 
            Tb_Descripcion.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Descripcion.Location = new Point(99, 237);
            Tb_Descripcion.Margin = new Padding(4);
            Tb_Descripcion.MaxLength = 100;
            Tb_Descripcion.Name = "Tb_Descripcion";
            Tb_Descripcion.PlaceholderText = "Descripción:";
            Tb_Descripcion.Size = new Size(343, 33);
            Tb_Descripcion.TabIndex = 46;
            Tb_Descripcion.KeyPress += Tb_Descripcion_KeyPress;
            // 
            // Tb_Nombre
            // 
            Tb_Nombre.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Nombre.Location = new Point(99, 166);
            Tb_Nombre.Margin = new Padding(4);
            Tb_Nombre.MaxLength = 20;
            Tb_Nombre.Name = "Tb_Nombre";
            Tb_Nombre.PlaceholderText = "Nombre:";
            Tb_Nombre.Size = new Size(343, 33);
            Tb_Nombre.TabIndex = 45;
            Tb_Nombre.KeyPress += Tb_Nombre_KeyPress;
            // 
            // Lb_Titulo
            // 
            Lb_Titulo.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Titulo.Location = new Point(125, 61);
            Lb_Titulo.Margin = new Padding(4, 0, 4, 0);
            Lb_Titulo.Name = "Lb_Titulo";
            Lb_Titulo.Size = new Size(296, 75);
            Lb_Titulo.TabIndex = 44;
            Lb_Titulo.Text = "Ingrese los datos del producto a ingresar";
            // 
            // Btn_Volver
            // 
            Btn_Volver.AccessibleName = "Btn_Volver";
            Btn_Volver.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Volver.Location = new Point(99, 519);
            Btn_Volver.Margin = new Padding(4);
            Btn_Volver.Name = "Btn_Volver";
            Btn_Volver.Size = new Size(142, 36);
            Btn_Volver.TabIndex = 43;
            Btn_Volver.Text = "Volver";
            Btn_Volver.UseVisualStyleBackColor = true;
            Btn_Volver.Click += Btn_Volver_Click;
            // 
            // Btn_AgregarProducto
            // 
            Btn_AgregarProducto.AccessibleName = "Btn_AgregarProducto";
            Btn_AgregarProducto.AutoSize = true;
            Btn_AgregarProducto.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_AgregarProducto.Location = new Point(285, 519);
            Btn_AgregarProducto.Margin = new Padding(4);
            Btn_AgregarProducto.Name = "Btn_AgregarProducto";
            Btn_AgregarProducto.Size = new Size(166, 36);
            Btn_AgregarProducto.TabIndex = 42;
            Btn_AgregarProducto.Text = "Agregar producto";
            Btn_AgregarProducto.UseVisualStyleBackColor = true;
            Btn_AgregarProducto.Click += Btn_AgregarProducto_Click;
            // 
            // FormAgregarProducto
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(138, 121, 104);
            ClientSize = new Size(570, 627);
            ControlBox = false;
            Controls.Add(Tb_Precio);
            Controls.Add(Tb_Stock);
            Controls.Add(Tb_TipoCorte);
            Controls.Add(Tb_Descripcion);
            Controls.Add(Tb_Nombre);
            Controls.Add(Lb_Titulo);
            Controls.Add(Btn_Volver);
            Controls.Add(Btn_AgregarProducto);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "FormAgregarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += FormAgregarProducto_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Tb_Precio;
        private TextBox Tb_Stock;
        private TextBox Tb_TipoCorte;
        private TextBox Tb_Descripcion;
        private TextBox Tb_Nombre;
        private Label Lb_Titulo;
        private Button Btn_Volver;
        private Button Btn_AgregarProducto;
    }
}