using System.Text;
using System.Text.RegularExpressions;
using Entidades;

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
        /// Autocompleta en los textbox la información del usuario, eligiendo  a un usuario tipo Cliente de manera aleatoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AutocompletarCliente_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<Usuario> listaClientes = UsuariosDAO.ObtenerUsuariosPorTipo(TipoUsuario.Cliente);
            int index = rnd.Next(listaClientes.Count);

            Cliente usuario = (Cliente)listaClientes[index];

            Tb_Email.Text = usuario.Email;
            Tb_Contrasena.Text = usuario.Contrasena;
        }
        /// <summary>
        /// Autocompleta en los textbox la información del usuario, eligiendo a un usuario tipo Vendedor de manera aleatoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AutocompletarVendedor_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<Usuario> listaVendedores = UsuariosDAO.ObtenerUsuariosPorTipo(TipoUsuario.Vendedor);
            int index = rnd.Next(listaVendedores.Count);

            Vendedor usuario = (Vendedor)listaVendedores[index];

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
            bool emailValido = Validadores.ValidarFormatoEmail(email, error_email);
            bool contrasenaValida = Validadores.ValidarFormatoContraseña(contrasena, error_contraseña);

            return emailValido && contrasenaValida;
        }
        /// <summary>
        /// Valida la información del login del usuario y dependiendo de su tipo abre una página diferente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Tb_Email.Text.Trim();
                string contrasena = Tb_Contrasena.Text.Trim();
                if (!ValidarFormatoEmailYContraseña(email, contrasena)) return;

                Usuario? usuarioIngresado = UsuariosDAO.ObtenerUsuarioPorEmailYContraseña(email, contrasena);
                if (usuarioIngresado == null)
                {
                    throw new CredencialesInvalidasException();
                }

                this.Hide();
                // Si es Vendedor va al formHeladera y si es Cliente va al formMonto
                if (usuarioIngresado is Vendedor)
                {
                    FormHeladera formHeladera = new FormHeladera(usuarioIngresado as Vendedor, true);
                    formHeladera.Show();
                }
                else
                {
                    FormMonto formMonto = new FormMonto(usuarioIngresado as Cliente);
                    formMonto.Show();
                }
            }
            catch (CredencialesInvalidasException ex)
            {
                MessageBox.Show(ex.Message, "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}