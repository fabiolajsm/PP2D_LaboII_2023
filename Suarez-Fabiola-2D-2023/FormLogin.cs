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
                error_email.Text = $"⚠ Email no existente. Por favor ingresar un Email válido (Ej: lola@gmail.com)";
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

        /// <summary>
        /// Valida que el usuario exista en la lista de usuarios existentes
        /// </summary>
        /// <param name="usuarioIngresado">Usuario a validar</param>
        /// <returns>Retorna True si existe en la lista de usuario y False si no</returns>
        public static bool ValidarExistenciaDeUsuario(Usuario usuarioIngresado)
        {
            return DatosEnMemoria.listaUsuarios.Any(usuario => usuario == usuarioIngresado);
        }
        /// <summary>
        /// Obtiene todos los datos del usuario ingresado
        /// </summary>
        /// <param name="usuarioIngresado">Usuario a obtener</param>
        /// <returns>Retorna el Usuario desde la lista de usuarios si lo encuentra y el usuario ingresado si no</returns>
        public static Usuario? ObtenerUsuario(string email, string contrasena)
        {
            foreach (Usuario usuario in DatosEnMemoria.listaUsuarios)
            {
                if (usuario.Email == email && usuario.Contrasena == contrasena)
                {
                    return usuario;
                }
            }

            return null;
        }
        /// <summary>
        /// Valida el ingreso de un usuario y si este es válido abre una nueva página segun el TipoUsuario que sea.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            string email = Tb_Email.Text.Trim();
            string contrasena = Tb_Contrasena.Text.Trim();
            Usuario? usuarioIngresado = null;

            if (ValidarEmail(email) & ValidarContraseña(contrasena))
            {
                usuarioIngresado = ObtenerUsuario(email, contrasena);
                if (usuarioIngresado == null)
                {
                    MessageBox.Show("Usuario y/o contraseña inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Hide();
                    if(usuarioIngresado.TipoDeUsuario == eTipoUsuario.TipoUsuario.Cliente)
                    {                        
                        Cliente cliente = new Cliente(usuarioIngresado.Nombre, usuarioIngresado.Apellido, usuarioIngresado.Email, usuarioIngresado.Contrasena, usuarioIngresado.TipoDeUsuario, 0);
                        FormMonto formMonto = new FormMonto(cliente);
                        formMonto.Show();
                    }
                    else if(usuarioIngresado.TipoDeUsuario == eTipoUsuario.TipoUsuario.Vendedor)
                    {
                        Vendedor vendedor = new Vendedor(usuarioIngresado.Nombre, usuarioIngresado.Apellido, usuarioIngresado.Email, usuarioIngresado.Contrasena, usuarioIngresado.TipoDeUsuario); 
                        FormHeladera formHeladera = new FormHeladera(vendedor);
                        formHeladera.Show();
                    } 
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}