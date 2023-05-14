namespace Suarez_Fabiola_2D_2023
{
    partial class FormHeladera
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
            Producto = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            dataGridView = new DataGridView();
            Lb_Titulo = new Label();
            Btn_CerrarSesion = new Button();
            Cb_Opciones = new ComboBox();
            Lb_Opciones = new Label();
            Btn_Continuar = new Button();
            Lb_Aclaracion = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 6;
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            Producto.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 125;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.FromArgb(211, 200, 187);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(237, 224, 212);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(237, 224, 212);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.GridColor = Color.BlanchedAlmond;
            dataGridView.Location = new Point(55, 190);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(577, 266);
            dataGridView.TabIndex = 0;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // Lb_Titulo
            // 
            Lb_Titulo.AutoSize = true;
            Lb_Titulo.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Titulo.Location = new Point(55, 151);
            Lb_Titulo.Name = "Lb_Titulo";
            Lb_Titulo.Size = new Size(208, 27);
            Lb_Titulo.TabIndex = 1;
            Lb_Titulo.Text = "Lista de productos";
            // 
            // Btn_CerrarSesion
            // 
            Btn_CerrarSesion.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_CerrarSesion.Location = new Point(55, 482);
            Btn_CerrarSesion.Name = "Btn_CerrarSesion";
            Btn_CerrarSesion.Size = new Size(142, 29);
            Btn_CerrarSesion.TabIndex = 2;
            Btn_CerrarSesion.Text = "Cerrar sesión";
            Btn_CerrarSesion.UseVisualStyleBackColor = true;
            Btn_CerrarSesion.Click += Btn_CerrarSesion_Click;
            // 
            // Cb_Opciones
            // 
            Cb_Opciones.DropDownStyle = ComboBoxStyle.DropDownList;
            Cb_Opciones.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Cb_Opciones.FormattingEnabled = true;
            Cb_Opciones.Location = new Point(55, 76);
            Cb_Opciones.Name = "Cb_Opciones";
            Cb_Opciones.Size = new Size(577, 30);
            Cb_Opciones.TabIndex = 3;
            Cb_Opciones.SelectedIndexChanged += Cb_Opciones_SelectedIndexChanged;
            // 
            // Lb_Opciones
            // 
            Lb_Opciones.AutoSize = true;
            Lb_Opciones.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Opciones.Location = new Point(55, 30);
            Lb_Opciones.Name = "Lb_Opciones";
            Lb_Opciones.Size = new Size(251, 27);
            Lb_Opciones.TabIndex = 4;
            Lb_Opciones.Text = "Seleccione una opción:";
            // 
            // Btn_Continuar
            // 
            Btn_Continuar.Enabled = false;
            Btn_Continuar.Font = new Font("Book Antiqua", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Continuar.Location = new Point(490, 482);
            Btn_Continuar.Name = "Btn_Continuar";
            Btn_Continuar.Size = new Size(142, 29);
            Btn_Continuar.TabIndex = 5;
            Btn_Continuar.Text = "Continuar";
            Btn_Continuar.UseVisualStyleBackColor = true;
            Btn_Continuar.Click += Btn_Continuar_Click;
            // 
            // Lb_Aclaracion
            // 
            Lb_Aclaracion.AutoSize = true;
            Lb_Aclaracion.Font = new Font("Book Antiqua", 9F, FontStyle.Italic, GraphicsUnit.Point);
            Lb_Aclaracion.Location = new Point(230, 119);
            Lb_Aclaracion.Name = "Lb_Aclaracion";
            Lb_Aclaracion.Size = new Size(402, 19);
            Lb_Aclaracion.TabIndex = 6;
            Lb_Aclaracion.Text = "Para ir a la página de la opción seleccionada presione Continuar";
            // 
            // FormHeladera
            // 
            AccessibleName = "FormHeladera";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(211, 200, 187);
            ClientSize = new Size(716, 560);
            Controls.Add(Lb_Aclaracion);
            Controls.Add(Btn_Continuar);
            Controls.Add(Lb_Opciones);
            Controls.Add(Cb_Opciones);
            Controls.Add(Btn_CerrarSesion);
            Controls.Add(Lb_Titulo);
            Controls.Add(dataGridView);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormHeladera";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormHeladera";
            Shown += FormHeladera_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridView dataGridView;
        private Label Lb_Titulo;
        private Button Btn_CerrarSesion;
        private ComboBox Cb_Opciones;
        private Label Lb_Opciones;
        private Button Btn_Continuar;
        private Label Lb_Aclaracion;
    }
}