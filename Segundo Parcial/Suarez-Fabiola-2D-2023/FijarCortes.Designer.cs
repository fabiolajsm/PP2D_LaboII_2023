namespace Suarez_Fabiola_2D_2023
{
    partial class FijarCortes
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
            Lb_NombreProducto = new Label();
            Lb_FijarCorte = new ListBox();
            Lb_Corte = new Label();
            Btn_FijarCorte = new Button();
            Lb_Titulo = new Label();
            Tb_Corte = new TextBox();
            SuspendLayout();
            // 
            // Btn_Volver
            // 
            Btn_Volver.AccessibleName = "Btn_Volver";
            Btn_Volver.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Volver.Location = new Point(42, 525);
            Btn_Volver.Margin = new Padding(4);
            Btn_Volver.Name = "Btn_Volver";
            Btn_Volver.Size = new Size(165, 36);
            Btn_Volver.TabIndex = 33;
            Btn_Volver.Text = "Volver";
            Btn_Volver.UseVisualStyleBackColor = true;
            Btn_Volver.Click += Btn_Volver_Click;
            // 
            // Lb_NombreProducto
            // 
            Lb_NombreProducto.AccessibleName = "Lb_NombreProducto";
            Lb_NombreProducto.AutoSize = true;
            Lb_NombreProducto.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_NombreProducto.Location = new Point(42, 85);
            Lb_NombreProducto.Margin = new Padding(4, 0, 4, 0);
            Lb_NombreProducto.Name = "Lb_NombreProducto";
            Lb_NombreProducto.Size = new Size(316, 22);
            Lb_NombreProducto.TabIndex = 29;
            Lb_NombreProducto.Text = "Nombre Producto / Nombre del corte";
            // 
            // Lb_FijarCorte
            // 
            Lb_FijarCorte.AccessibleName = "Lb_FijarCorte";
            Lb_FijarCorte.BackColor = Color.FromArgb(237, 237, 233);
            Lb_FijarCorte.DisplayMember = "Nombre:";
            Lb_FijarCorte.DrawMode = DrawMode.OwnerDrawFixed;
            Lb_FijarCorte.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lb_FijarCorte.FormattingEnabled = true;
            Lb_FijarCorte.ItemHeight = 20;
            Lb_FijarCorte.Location = new Point(42, 134);
            Lb_FijarCorte.Margin = new Padding(4);
            Lb_FijarCorte.Name = "Lb_FijarCorte";
            Lb_FijarCorte.Size = new Size(380, 244);
            Lb_FijarCorte.TabIndex = 28;
            Lb_FijarCorte.DrawItem += Lb_FijarCorte_DrawItem;
            // 
            // Lb_Corte
            // 
            Lb_Corte.AccessibleName = "Lb_Corte";
            Lb_Corte.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Corte.Location = new Point(42, 421);
            Lb_Corte.Margin = new Padding(4, 0, 4, 0);
            Lb_Corte.Name = "Lb_Corte";
            Lb_Corte.Size = new Size(330, 36);
            Lb_Corte.TabIndex = 31;
            Lb_Corte.Text = "Ingrese el nombre del corte a fijar:";
            // 
            // Btn_FijarCorte
            // 
            Btn_FijarCorte.AccessibleName = "Btn_FijarCorte";
            Btn_FijarCorte.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_FijarCorte.Location = new Point(234, 525);
            Btn_FijarCorte.Margin = new Padding(4);
            Btn_FijarCorte.Name = "Btn_FijarCorte";
            Btn_FijarCorte.Size = new Size(190, 36);
            Btn_FijarCorte.TabIndex = 30;
            Btn_FijarCorte.Text = "Guardar cambios";
            Btn_FijarCorte.UseVisualStyleBackColor = true;
            Btn_FijarCorte.Click += Btn_FijarCorte_Click;
            // 
            // Lb_Titulo
            // 
            Lb_Titulo.AutoSize = true;
            Lb_Titulo.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Titulo.Location = new Point(42, 39);
            Lb_Titulo.Margin = new Padding(4, 0, 4, 0);
            Lb_Titulo.Name = "Lb_Titulo";
            Lb_Titulo.Size = new Size(333, 33);
            Lb_Titulo.TabIndex = 27;
            Lb_Titulo.Text = "Fijar cortes del producto";
            // 
            // Tb_Corte
            // 
            Tb_Corte.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Corte.Location = new Point(42, 461);
            Tb_Corte.Margin = new Padding(4);
            Tb_Corte.MaxLength = 20;
            Tb_Corte.Name = "Tb_Corte";
            Tb_Corte.PlaceholderText = "Ejemplo: \"Filete\"";
            Tb_Corte.Size = new Size(380, 30);
            Tb_Corte.TabIndex = 34;
            Tb_Corte.KeyPress += Tb_Corte_KeyPress;
            // 
            // FijarCortes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(138, 121, 104);
            ClientSize = new Size(458, 611);
            ControlBox = false;
            Controls.Add(Tb_Corte);
            Controls.Add(Btn_Volver);
            Controls.Add(Lb_NombreProducto);
            Controls.Add(Lb_FijarCorte);
            Controls.Add(Lb_Corte);
            Controls.Add(Btn_FijarCorte);
            Controls.Add(Lb_Titulo);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "FijarCortes";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += FijarCortes_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Volver;
        private TextBox Tb_Precio;
        private Label Lb_NombreProducto;
        private ListBox Lb_FijarCorte;
        private Label Lb_Corte;
        private Button Btn_FijarCorte;
        private Label Lb_Titulo;
        private TextBox Tb_Corte;
    }
}