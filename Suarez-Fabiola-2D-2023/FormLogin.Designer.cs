namespace Suarez_Fabiola_2D_2023
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pictureBoxLogin = new PictureBox();
            Tb_Email = new TextBox();
            Tb_Contrasena = new TextBox();
            Btn_Login = new Button();
            tituloLogin = new Label();
            Cb_mostrarContrasena = new CheckBox();
            error_email = new Label();
            error_contraseña = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogin).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLogin
            // 
            pictureBoxLogin.AccessibleName = "pictureBoxLogin";
            pictureBoxLogin.Image = Properties.Resources.logo1;
            pictureBoxLogin.Location = new Point(90, 76);
            pictureBoxLogin.Name = "pictureBoxLogin";
            pictureBoxLogin.Size = new Size(145, 177);
            pictureBoxLogin.TabIndex = 0;
            pictureBoxLogin.TabStop = false;
            // 
            // Tb_Email
            // 
            Tb_Email.AccessibleName = "Tb_Email";
            Tb_Email.AutoCompleteCustomSource.AddRange(new string[] { "julia@gmail.com", "petunia@gmail.com" });
            Tb_Email.AutoCompleteMode = AutoCompleteMode.Suggest;
            Tb_Email.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Tb_Email.CharacterCasing = CharacterCasing.Lower;
            Tb_Email.Cursor = Cursors.IBeam;
            Tb_Email.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Email.Location = new Point(255, 112);
            Tb_Email.MaxLength = 30;
            Tb_Email.Name = "Tb_Email";
            Tb_Email.PlaceholderText = "Email:";
            Tb_Email.Size = new Size(277, 26);
            Tb_Email.TabIndex = 1;
            // 
            // Tb_Contrasena
            // 
            Tb_Contrasena.AccessibleName = "Tb_Contrasena";
            Tb_Contrasena.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Tb_Contrasena.Location = new Point(255, 173);
            Tb_Contrasena.MaxLength = 15;
            Tb_Contrasena.Name = "Tb_Contrasena";
            Tb_Contrasena.PasswordChar = '*';
            Tb_Contrasena.PlaceholderText = "Contraseña:";
            Tb_Contrasena.Size = new Size(277, 26);
            Tb_Contrasena.TabIndex = 2;
            // 
            // Btn_Login
            // 
            Btn_Login.AccessibleName = "Btn_Login";
            Btn_Login.BackColor = Color.FromArgb(241, 247, 238);
            Btn_Login.FlatAppearance.BorderColor = Color.FromArgb(176, 190, 169);
            Btn_Login.FlatAppearance.MouseOverBackColor = Color.FromArgb(146, 170, 131);
            Btn_Login.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Login.Location = new Point(326, 269);
            Btn_Login.Name = "Btn_Login";
            Btn_Login.Size = new Size(94, 29);
            Btn_Login.TabIndex = 3;
            Btn_Login.Text = "Entrar";
            Btn_Login.UseVisualStyleBackColor = false;
            Btn_Login.Click += Btn_Login_Click;
            // 
            // tituloLogin
            // 
            tituloLogin.AutoSize = true;
            tituloLogin.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tituloLogin.Location = new Point(255, 76);
            tituloLogin.Name = "tituloLogin";
            tituloLogin.Size = new Size(132, 23);
            tituloLogin.TabIndex = 4;
            tituloLogin.Text = "Iniciar sesión";
            // 
            // Cb_mostrarContrasena
            // 
            Cb_mostrarContrasena.AccessibleName = "Cb_mostrarContrasena";
            Cb_mostrarContrasena.AutoSize = true;
            Cb_mostrarContrasena.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Cb_mostrarContrasena.Location = new Point(255, 229);
            Cb_mostrarContrasena.Name = "Cb_mostrarContrasena";
            Cb_mostrarContrasena.Size = new Size(165, 24);
            Cb_mostrarContrasena.TabIndex = 5;
            Cb_mostrarContrasena.Text = "Mostrar Contraseña";
            Cb_mostrarContrasena.UseVisualStyleBackColor = true;
            Cb_mostrarContrasena.CheckedChanged += Cb_mostrarContrasena_CheckedChanged;
            // 
            // error_email
            // 
            error_email.AccessibleName = "error_email";
            error_email.AutoSize = true;
            error_email.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            error_email.ForeColor = Color.Firebrick;
            error_email.Location = new Point(255, 141);
            error_email.Name = "error_email";
            error_email.Size = new Size(164, 20);
            error_email.TabIndex = 6;
            error_email.Text = "⚠Debe ingresar Email";
            error_email.Visible = false;
            // 
            // error_contraseña
            // 
            error_contraseña.AccessibleName = "error_contraseña";
            error_contraseña.AutoSize = true;
            error_contraseña.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point);
            error_contraseña.ForeColor = Color.Firebrick;
            error_contraseña.Location = new Point(256, 206);
            error_contraseña.Name = "error_contraseña";
            error_contraseña.Size = new Size(207, 20);
            error_contraseña.TabIndex = 7;
            error_contraseña.Text = "⚠ Debe ingresar Contraseña";
            error_contraseña.Visible = false;
            // 
            // FormLogin
            // 
            AccessibleName = "FormLogin";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 247, 238);
            ClientSize = new Size(800, 450);
            Controls.Add(error_contraseña);
            Controls.Add(error_email);
            Controls.Add(Cb_mostrarContrasena);
            Controls.Add(tituloLogin);
            Controls.Add(Btn_Login);
            Controls.Add(Tb_Contrasena);
            Controls.Add(Tb_Email);
            Controls.Add(pictureBoxLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxLogin;
        private TextBox Tb_Email;
        private TextBox Tb_Contrasena;
        private Button Btn_Login;
        private Label tituloLogin;
        private CheckBox Cb_mostrarContrasena;
        private Label error_email;
        private Label error_contraseña;
    }
}