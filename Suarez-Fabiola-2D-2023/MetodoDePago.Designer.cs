namespace Suarez_Fabiola_2D_2023
{
    partial class MetodoDePago
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
            Gb_MetodoDePago = new GroupBox();
            Lb_PrecioFinal = new Label();
            Lb_Recargo = new Label();
            Rb_MercadoPago = new RadioButton();
            Rb_Credito = new RadioButton();
            Rb_Debito = new RadioButton();
            Gb_MetodoDePago.SuspendLayout();
            SuspendLayout();
            // 
            // Gb_MetodoDePago
            // 
            Gb_MetodoDePago.AccessibleName = "Gb_MetodoDePago";
            Gb_MetodoDePago.BackColor = Color.FromArgb(254, 250, 224);
            Gb_MetodoDePago.Controls.Add(Lb_PrecioFinal);
            Gb_MetodoDePago.Controls.Add(Lb_Recargo);
            Gb_MetodoDePago.Controls.Add(Rb_MercadoPago);
            Gb_MetodoDePago.Controls.Add(Rb_Credito);
            Gb_MetodoDePago.Controls.Add(Rb_Debito);
            Gb_MetodoDePago.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Gb_MetodoDePago.Location = new Point(233, 126);
            Gb_MetodoDePago.Name = "Gb_MetodoDePago";
            Gb_MetodoDePago.Size = new Size(334, 198);
            Gb_MetodoDePago.TabIndex = 12;
            Gb_MetodoDePago.TabStop = false;
            Gb_MetodoDePago.Text = "Seleccione su método de pago";
            // 
            // Lb_PrecioFinal
            // 
            Lb_PrecioFinal.AccessibleName = "Lb_PrecioFinal";
            Lb_PrecioFinal.AutoSize = true;
            Lb_PrecioFinal.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_PrecioFinal.Location = new Point(34, 163);
            Lb_PrecioFinal.Name = "Lb_PrecioFinal";
            Lb_PrecioFinal.Size = new Size(105, 19);
            Lb_PrecioFinal.TabIndex = 9;
            Lb_PrecioFinal.Text = "Precio final: 0";
            // 
            // Lb_Recargo
            // 
            Lb_Recargo.AccessibleName = "Lb_Recargo";
            Lb_Recargo.AutoSize = true;
            Lb_Recargo.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_Recargo.Location = new Point(34, 131);
            Lb_Recargo.Name = "Lb_Recargo";
            Lb_Recargo.Size = new Size(81, 19);
            Lb_Recargo.TabIndex = 8;
            Lb_Recargo.Text = "Recargo: 0";
            // 
            // Rb_MercadoPago
            // 
            Rb_MercadoPago.AccessibleName = "Rb_MercadoPago";
            Rb_MercadoPago.AutoSize = true;
            Rb_MercadoPago.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Rb_MercadoPago.Location = new Point(34, 30);
            Rb_MercadoPago.Name = "Rb_MercadoPago";
            Rb_MercadoPago.Size = new Size(126, 24);
            Rb_MercadoPago.TabIndex = 2;
            Rb_MercadoPago.TabStop = true;
            Rb_MercadoPago.Text = "Mercado Pago";
            Rb_MercadoPago.UseVisualStyleBackColor = true;
            // 
            // Rb_Credito
            // 
            Rb_Credito.AccessibleName = "Rb_Credito";
            Rb_Credito.AutoSize = true;
            Rb_Credito.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Rb_Credito.Location = new Point(34, 90);
            Rb_Credito.Name = "Rb_Credito";
            Rb_Credito.Size = new Size(268, 24);
            Rb_Credito.TabIndex = 1;
            Rb_Credito.TabStop = true;
            Rb_Credito.Text = "Tarjeta de Crédito (Recargo del 5%)";
            Rb_Credito.UseVisualStyleBackColor = true;
            // 
            // Rb_Debito
            // 
            Rb_Debito.AccessibleName = "Rb_Debito";
            Rb_Debito.AutoSize = true;
            Rb_Debito.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Rb_Debito.Location = new Point(34, 60);
            Rb_Debito.Name = "Rb_Debito";
            Rb_Debito.Size = new Size(145, 24);
            Rb_Debito.TabIndex = 0;
            Rb_Debito.TabStop = true;
            Rb_Debito.Text = "Tarjeta de Débito";
            Rb_Debito.UseVisualStyleBackColor = true;
            // 
            // MetodoDePago
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Gb_MetodoDePago);
            Name = "MetodoDePago";
            Text = "MetodoDePago";
            Gb_MetodoDePago.ResumeLayout(false);
            Gb_MetodoDePago.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Gb_MetodoDePago;
        private Label Lb_PrecioFinal;
        private Label Lb_Recargo;
        private RadioButton Rb_MercadoPago;
        private RadioButton Rb_Credito;
        private RadioButton Rb_Debito;
    }
}