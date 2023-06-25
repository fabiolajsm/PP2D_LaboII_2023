﻿namespace Suarez_Fabiola_2D_2023
{
    partial class HistorialVentas
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Btn_Volver = new Button();
            Lb_Titulo = new Label();
            dataGridView = new DataGridView();
            Lb_SinVentas = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Btn_Volver
            // 
            Btn_Volver.AccessibleName = "Btn_Volver";
            Btn_Volver.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Volver.Location = new Point(647, 590);
            Btn_Volver.Margin = new Padding(4);
            Btn_Volver.Name = "Btn_Volver";
            Btn_Volver.Size = new Size(316, 36);
            Btn_Volver.TabIndex = 34;
            Btn_Volver.Text = "Volver";
            Btn_Volver.UseVisualStyleBackColor = true;
            Btn_Volver.Click += Btn_Volver_Click;
            // 
            // Lb_Titulo
            // 
            Lb_Titulo.AutoSize = true;
            Lb_Titulo.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Titulo.Location = new Point(592, 54);
            Lb_Titulo.Margin = new Padding(4, 0, 4, 0);
            Lb_Titulo.Name = "Lb_Titulo";
            Lb_Titulo.Size = new Size(458, 33);
            Lb_Titulo.TabIndex = 35;
            Lb_Titulo.Text = "Historial de ventas / facturaciones";
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(237, 224, 212);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Book Antiqua", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(237, 224, 212);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.GridColor = Color.BlanchedAlmond;
            dataGridView.Location = new Point(39, 122);
            dataGridView.Margin = new Padding(4);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(1548, 390);
            dataGridView.TabIndex = 36;
            // 
            // Lb_SinVentas
            // 
            Lb_SinVentas.AccessibleName = "";
            Lb_SinVentas.AutoSize = true;
            Lb_SinVentas.BackColor = Color.FromArgb(211, 200, 187);
            Lb_SinVentas.Font = new Font("Book Antiqua", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_SinVentas.Location = new Point(63, 156);
            Lb_SinVentas.Margin = new Padding(4, 0, 4, 0);
            Lb_SinVentas.Name = "Lb_SinVentas";
            Lb_SinVentas.Size = new Size(306, 28);
            Lb_SinVentas.TabIndex = 37;
            Lb_SinVentas.Text = "No se han realizado ventas";
            Lb_SinVentas.Visible = false;
            // 
            // HistorialVentas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(138, 121, 104);
            ClientSize = new Size(1681, 676);
            ControlBox = false;
            Controls.Add(Lb_SinVentas);
            Controls.Add(dataGridView);
            Controls.Add(Lb_Titulo);
            Controls.Add(Btn_Volver);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "HistorialVentas";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Volver;
        private Label Lb_Titulo;
        private DataGridView dataGridView;
        private Label Lb_SinVentas;
    }
}