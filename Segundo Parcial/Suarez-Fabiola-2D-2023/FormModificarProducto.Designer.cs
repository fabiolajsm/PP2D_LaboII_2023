namespace Suarez_Fabiola_2D_2023
{
    partial class FormModificarProducto
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
            Lb_Titulo = new Label();
            Btn_Volver = new Button();
            Tb_Atributo = new TextBox();
            Lb_Ingresar = new Label();
            Btn_ModificarProducto = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Lb_Titulo
            // 
            Lb_Titulo.AutoSize = true;
            Lb_Titulo.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Titulo.Location = new Point(54, 42);
            Lb_Titulo.Margin = new Padding(4, 0, 4, 0);
            Lb_Titulo.Name = "Lb_Titulo";
            Lb_Titulo.Size = new Size(253, 33);
            Lb_Titulo.TabIndex = 21;
            Lb_Titulo.Text = "Lista de productos";
            // 
            // Btn_Volver
            // 
            Btn_Volver.AccessibleName = "Btn_Volver";
            Btn_Volver.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Volver.Location = new Point(54, 564);
            Btn_Volver.Margin = new Padding(4);
            Btn_Volver.Name = "Btn_Volver";
            Btn_Volver.Size = new Size(165, 36);
            Btn_Volver.TabIndex = 30;
            Btn_Volver.Text = "Volver";
            Btn_Volver.UseVisualStyleBackColor = true;
            Btn_Volver.Click += Btn_Volver_Click;
            // 
            // Tb_Atributo
            // 
            Tb_Atributo.BorderStyle = BorderStyle.None;
            Tb_Atributo.Font = new Font("Book Antiqua", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Atributo.Location = new Point(54, 501);
            Tb_Atributo.Margin = new Padding(4);
            Tb_Atributo.MaxLength = 25;
            Tb_Atributo.Name = "Tb_Atributo";
            Tb_Atributo.Size = new Size(395, 25);
            Tb_Atributo.TabIndex = 29;
            Tb_Atributo.TextAlign = HorizontalAlignment.Center;
            Tb_Atributo.KeyPress += Tb_Atributo_KeyPress;
            // 
            // Lb_Ingresar
            // 
            Lb_Ingresar.AccessibleName = "Lb_Ingresar";
            Lb_Ingresar.Font = new Font("Book Antiqua", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Ingresar.Location = new Point(54, 461);
            Lb_Ingresar.Margin = new Padding(4, 0, 4, 0);
            Lb_Ingresar.Name = "Lb_Ingresar";
            Lb_Ingresar.Size = new Size(345, 36);
            Lb_Ingresar.TabIndex = 28;
            Lb_Ingresar.Text = "Ingrese nuevo atributo del producto:";
            // 
            // Btn_ModificarProducto
            // 
            Btn_ModificarProducto.AccessibleName = "Btn_ModificarProducto";
            Btn_ModificarProducto.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_ModificarProducto.Location = new Point(566, 564);
            Btn_ModificarProducto.Margin = new Padding(4);
            Btn_ModificarProducto.Name = "Btn_ModificarProducto";
            Btn_ModificarProducto.Size = new Size(209, 36);
            Btn_ModificarProducto.TabIndex = 27;
            Btn_ModificarProducto.Text = "Modificar producto";
            Btn_ModificarProducto.UseVisualStyleBackColor = true;
            Btn_ModificarProducto.Click += Btn_ModificarProducto_Click;
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
            dataGridView.Location = new Point(54, 99);
            dataGridView.Margin = new Padding(4);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(721, 332);
            dataGridView.TabIndex = 31;
            // 
            // FormModificarProducto
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(138, 121, 104);
            ClientSize = new Size(812, 629);
            ControlBox = false;
            Controls.Add(dataGridView);
            Controls.Add(Btn_Volver);
            Controls.Add(Tb_Atributo);
            Controls.Add(Lb_Ingresar);
            Controls.Add(Btn_ModificarProducto);
            Controls.Add(Lb_Titulo);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FormModificarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += FormModificarProducto_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lb_Titulo;
        private Button Btn_Volver;
        private TextBox Tb_Atributo;
        private Label Lb_Ingresar;
        private Button Btn_ModificarProducto;
        private DataGridView dataGridView;
    }
}