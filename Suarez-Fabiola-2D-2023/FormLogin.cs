using System.Text;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Suarez_Fabiola_2D_2023
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Muestra u ocultar la contraseña en un TextBox dependiendo del estado de un CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_mostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (Cb_mostrarContrasena.Checked)
            {
                Tb_Contrasena.PasswordChar = '\0'; // Mostrar 
            }
            else
            {
                Tb_Contrasena.PasswordChar = '*'; // Ocultar
            }
        }
        /// <summary>
        /// Valida si un Email es válido
        /// </summary>
        /// <param name="email">Email a validar</param>
        /// <returns>Retorna True si es válido y False si no</returns>
        private bool ValidarEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(emailPattern);
            if (string.IsNullOrWhiteSpace(email))
            {
                error_email.Text = "⚠ Debe ingresar Email";
                error_email.Visible = true;
                return false;
            }
            else if (!regex.IsMatch(email))
            {
                error_email.Text = $"⚠ Email no existente. Por favor ingresar email válido (Ej: lola@gmail.com)";
                error_email.Visible = true;
                return false;
            }
            else
            {
                error_email.Visible = false;
                return true;
            }
        }
        /// <summary>
        /// Valida si una Contraseña es válida
        /// </summary>
        /// <param name="contraseña">Contraseña a validar</param>
        /// <returns>Retorna True si es válido y False si no</returns>
        private bool ValidarContraseña(string contraseña)
        {
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                error_contraseña.Visible = true;
                return false;
            }
            else
            {
                error_contraseña.Visible = false;
                return true;
            }
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            string email = Tb_Email.Text.Trim();
            string contrasena = Tb_Contrasena.Text.Trim();
            if (ValidarEmail(email) & ValidarContraseña(contrasena))
            {
                Usuario usuarioIngresado = new Usuario(email, contrasena);
                if (!Usuario.ValidarExistenciaDeUsuario(usuarioIngresado))
                {
                    MessageBox.Show("Usuario y/o contraseña inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Entraste!", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }
    }
}