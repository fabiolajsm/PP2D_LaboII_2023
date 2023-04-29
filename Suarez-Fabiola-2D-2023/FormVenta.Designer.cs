namespace Suarez_Fabiola_2D_2023
{
    partial class FormVenta
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
            Lb_BienvenidaCliente = new Label();
            Lb_DescripcionBienvenida = new Label();
            Tb_MontoMaximoCompra = new TextBox();
            Btn_Continuar = new Button();
            Btn_CerrarSesion = new Button();
            SuspendLayout();
            // 
            // Lb_BienvenidaCliente
            // 
            Lb_BienvenidaCliente.AccessibleName = "Lb_BienvenidaCliente";
            Lb_BienvenidaCliente.AccessibleRole = AccessibleRole.TitleBar;
            Lb_BienvenidaCliente.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_BienvenidaCliente.Location = new Point(207, 79);
            Lb_BienvenidaCliente.Name = "Lb_BienvenidaCliente";
            Lb_BienvenidaCliente.Size = new Size(344, 37);
            Lb_BienvenidaCliente.TabIndex = 0;
            Lb_BienvenidaCliente.Text = "¡Bienvenido!";
            Lb_BienvenidaCliente.TextAlign = ContentAlignment.TopCenter;
            // 
            // Lb_DescripcionBienvenida
            // 
            Lb_DescripcionBienvenida.AccessibleName = "Lb_DescripcionBienvenida";
            Lb_DescripcionBienvenida.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Lb_DescripcionBienvenida.Location = new Point(242, 127);
            Lb_DescripcionBienvenida.Name = "Lb_DescripcionBienvenida";
            Lb_DescripcionBienvenida.Size = new Size(288, 89);
            Lb_DescripcionBienvenida.TabIndex = 1;
            Lb_DescripcionBienvenida.Text = "Especifica tu monto máximo de gasto para empezar a explotar nuestros productos";
            Lb_DescripcionBienvenida.TextAlign = ContentAlignment.TopCenter;
            // 
            // Tb_MontoMaximoCompra
            // 
            Tb_MontoMaximoCompra.Location = new Point(268, 219);
            Tb_MontoMaximoCompra.MaxLength = 6;
            Tb_MontoMaximoCompra.Name = "Tb_MontoMaximoCompra";
            Tb_MontoMaximoCompra.PlaceholderText = "Monto máximo de compra:";
            Tb_MontoMaximoCompra.Size = new Size(249, 27);
            Tb_MontoMaximoCompra.TabIndex = 2;
            Tb_MontoMaximoCompra.KeyPress += Tb_MontoMaximoCompra_KeyPress;
            // 
            // Btn_Continuar
            // 
            Btn_Continuar.AccessibleName = "Btn_Continuar";
            Btn_Continuar.Location = new Point(402, 261);
            Btn_Continuar.Name = "Btn_Continuar";
            Btn_Continuar.Size = new Size(94, 29);
            Btn_Continuar.TabIndex = 3;
            Btn_Continuar.Text = "Continuar";
            Btn_Continuar.UseVisualStyleBackColor = true;
            Btn_Continuar.Click += Btn_Continuar_Click;
            // 
            // Btn_CerrarSesion
            // 
            Btn_CerrarSesion.AccessibleName = "Btn_CerrarSesion";
            Btn_CerrarSesion.Location = new Point(286, 261);
            Btn_CerrarSesion.Name = "Btn_CerrarSesion";
            Btn_CerrarSesion.Size = new Size(94, 29);
            Btn_CerrarSesion.TabIndex = 4;
            Btn_CerrarSesion.Text = "Salir";
            Btn_CerrarSesion.UseVisualStyleBackColor = true;
            Btn_CerrarSesion.Click += Btn_CerrarSesion_Click;
            // 
            // FormVenta
            // 
            AccessibleName = "FormVenta";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 250, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(Btn_CerrarSesion);
            Controls.Add(Btn_Continuar);
            Controls.Add(Tb_MontoMaximoCompra);
            Controls.Add(Lb_DescripcionBienvenida);
            Controls.Add(Lb_BienvenidaCliente);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Especificar Monto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lb_BienvenidaCliente;
        private Label Lb_DescripcionBienvenida;
        private TextBox Tb_MontoMaximoCompra;
        private Button Btn_Continuar;
        private Button Btn_CerrarSesion;
    }
}