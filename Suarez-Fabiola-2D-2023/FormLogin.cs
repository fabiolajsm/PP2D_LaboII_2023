using System.Text;
using System.Text.RegularExpressions;
using static Suarez_Fabiola_2D_2023.eTipoUsuario;
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
        ///  Muestra u oculta la contraseña en un TextBox dependiendo del estado de un CheckBox
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
        /// Autocompleta en los textbox la información del usuario, eligiendo a un usuario de manera aleatoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AutocompletarUsuario_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<Usuario> listaUsuarios = DatosEnMemoria.listaUsuarios;
            int index = rnd.Next(listaUsuarios.Count);

            Usuario usuario = listaUsuarios[index];

            Tb_Email.Text = usuario.Email;
            Tb_Contrasena.Text = usuario.Contrasena;
        }
        /// <summary>
        /// Valida el formato del Email y la Contraseña
        /// </summary>
        /// <param name="email">Email a validar</param>
        /// <param name="contrasena">Contraseña a validar</param>
        /// <returns>Retorna True si son válidos y False de lo contrario</returns>
        private bool ValidarFormatoEmailYContraseña(string email, string contrasena)
        {
            bool emailValido = ValidadorLoginUsuario.ValidarFormatoEmail(email, error_email);
            bool contrasenaValida = ValidadorLoginUsuario.ValidarFormatoContraseña(contrasena, error_contraseña);

            return emailValido && contrasenaValida;
        }
        /// <summary>
        /// Valida la información del login del usuario y dependiendo de su tipo abre una página diferente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            string email = Tb_Email.Text.Trim();
            string contrasena = Tb_Contrasena.Text.Trim();

            if (!ValidarFormatoEmailYContraseña(email, contrasena)) return;

            Usuario? usuarioIngresado = ValidadorLoginUsuario.BuscarUsuarioPorEmailYContraseña(email, contrasena);
            if (usuarioIngresado == null)
            {
                MessageBox.Show("Usuario y/o contraseña inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            if (usuarioIngresado.TipoDeUsuario == eTipoUsuario.TipoUsuario.Cliente)
            {
                Cliente cliente = new Cliente(usuarioIngresado.Nombre, usuarioIngresado.Apellido, usuarioIngresado.Email, usuarioIngresado.Contrasena, usuarioIngresado.TipoDeUsuario, 0);
                FormMonto formMonto = new FormMonto(cliente);
                formMonto.Show();
            }
            else if (usuarioIngresado.TipoDeUsuario == eTipoUsuario.TipoUsuario.Vendedor)
            {
                Vendedor vendedor = new Vendedor(usuarioIngresado.Nombre, usuarioIngresado.Apellido, usuarioIngresado.Email, usuarioIngresado.Contrasena, usuarioIngresado.TipoDeUsuario);
                FormHeladera formHeladera = new FormHeladera(vendedor);
                formHeladera.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }       
    }
}