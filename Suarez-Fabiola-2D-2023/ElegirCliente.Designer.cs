namespace Suarez_Fabiola_2D_2023
{
    partial class ElegirCliente
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
            Btn_Continuar = new Button();
            Cb_Clientes = new ComboBox();
            Lb_Titulo = new Label();
            SuspendLayout();
            // 
            // Btn_Volver
            // 
            Btn_Volver.AccessibleName = "Btn_Volver";
            Btn_Volver.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Volver.Location = new Point(80, 207);
            Btn_Volver.Name = "Btn_Volver";
            Btn_Volver.Size = new Size(132, 29);
            Btn_Volver.TabIndex = 28;
            Btn_Volver.Text = "Volver";
            Btn_Volver.UseVisualStyleBackColor = true;
            Btn_Volver.Click += Btn_Volver_Click;
            // 
            // Btn_Continuar
            // 
            Btn_Continuar.AccessibleName = "Btn_Continuar";
            Btn_Continuar.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Continuar.Location = new Point(233, 207);
            Btn_Continuar.Name = "Btn_Continuar";
            Btn_Continuar.Size = new Size(152, 29);
            Btn_Continuar.TabIndex = 27;
            Btn_Continuar.Text = "Continuar";
            Btn_Continuar.UseVisualStyleBackColor = true;
            Btn_Continuar.Click += Btn_Continuar_Click;
            // 
            // Cb_Clientes
            // 
            Cb_Clientes.DropDownStyle = ComboBoxStyle.DropDownList;
            Cb_Clientes.FormattingEnabled = true;
            Cb_Clientes.Location = new Point(80, 129);
            Cb_Clientes.Name = "Cb_Clientes";
            Cb_Clientes.Size = new Size(305, 28);
            Cb_Clientes.TabIndex = 29;
            // 
            // Lb_Titulo
            // 
            Lb_Titulo.AutoSize = true;
            Lb_Titulo.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Titulo.Location = new Point(118, 68);
            Lb_Titulo.Name = "Lb_Titulo";
            Lb_Titulo.Size = new Size(232, 27);
            Lb_Titulo.TabIndex = 30;
            Lb_Titulo.Text = "Seleccione un cliente";
            // 
            // ElegirCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(138, 121, 104);
            ClientSize = new Size(478, 318);
            ControlBox = false;
            Controls.Add(Lb_Titulo);
            Controls.Add(Cb_Clientes);
            Controls.Add(Btn_Volver);
            Controls.Add(Btn_Continuar);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "ElegirCliente";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Volver;
        private Button Btn_Continuar;
        private ComboBox Cb_Clientes;
        private Label Lb_Titulo;
    }
}