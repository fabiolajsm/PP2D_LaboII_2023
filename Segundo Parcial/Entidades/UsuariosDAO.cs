using System.Data.SqlClient;

namespace Entidades
{
    public class UsuariosDAO
    {
        private static string connectionString;

        static UsuariosDAO()
        {
            connectionString = @"Data Source = localhost; Database = Ecomoo; Trusted_Connection = True;";
        }

        /// <summary>
        /// Agrega una lista de usuarios a la base de datos
        /// </summary>
        /// <param name="usuarios">Lista de usuarios a agregar</param>
        /// <exception cref="Exception">Si ocurre un error, lanza una exception</exception>
        public static void AgregarUsuarios(List<Usuario> usuarios)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (Usuario usuario in usuarios)
                    {
                        string queryUsuarios = "INSERT INTO USUARIOS (Nombre, Apellido, Email, Contraseña, TipoDeUsuario) " +
                                               "VALUES (@Nombre, @Apellido, @Email, @Contraseña, @TipoDeUsuario)";

                        using (SqlCommand commandUsuarios = new SqlCommand(queryUsuarios, connection))
                        {
                            commandUsuarios.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                            commandUsuarios.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                            commandUsuarios.Parameters.AddWithValue("@Email", usuario.Email);
                            commandUsuarios.Parameters.AddWithValue("@Contraseña", usuario.Contrasena);
                            commandUsuarios.Parameters.AddWithValue("@TipoDeUsuario", (int)usuario.TipoDeUsuario);

                            commandUsuarios.ExecuteNonQuery();
                        }

                        // Obtener el ID del usuario recién insertado
                        string queryIdUsuario = "SELECT IDENT_CURRENT('USUARIOS') AS LastId";
                        using (SqlCommand commandIdUsuario = new SqlCommand(queryIdUsuario, connection))
                        {
                            int idUsuario = Convert.ToInt32(commandIdUsuario.ExecuteScalar());

                            if (usuario.TipoDeUsuario == TipoUsuario.Vendedor)
                            {
                                string queryVendedor = "INSERT INTO VENDEDORES (IdUsuario, VentasRealizadas) " +
                                                      "VALUES (@IdUsuario, @VentasRealizadas)";

                                using (SqlCommand commandVendedor = new SqlCommand(queryVendedor, connection))
                                {
                                    commandVendedor.Parameters.AddWithValue("@IdUsuario", idUsuario);
                                    commandVendedor.Parameters.AddWithValue("@VentasRealizadas", 0);

                                    commandVendedor.ExecuteNonQuery();
                                }
                            }
                            else if (usuario.TipoDeUsuario == TipoUsuario.Cliente)
                            {
                                // Insertar el cliente en la tabla CLIENTES
                                string queryCliente = "INSERT INTO CLIENTES (IdUsuario, MontoMaximoDeCompra) " +
                                                      "VALUES (@IdUsuario, @MontoMaximoCompra)";

                                using (SqlCommand commandCliente = new SqlCommand(queryCliente, connection))
                                {
                                    commandCliente.Parameters.AddWithValue("@IdUsuario", idUsuario);
                                    commandCliente.Parameters.AddWithValue("@MontoMaximoCompra", 0);

                                    commandCliente.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al agregar usuarios: {ex.Message}");
                }
            }
        }
        /// <summary>
        /// Obtiene un usuario por TipoUsuario
        /// </summary>
        /// <param name="tipoUsuario">TipoUsuario del usuario a obtener</param>
        /// <returns>Retorna una lista de usuarios según su tipo</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Usuario> ObtenerUsuariosPorTipo(TipoUsuario tipoUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "";
                    switch (tipoUsuario)
                    {
                        case TipoUsuario.Cliente:
                            query = "SELECT USUARIOS.*, CLIENTES.MontoMaximoDeCompra FROM USUARIOS INNER JOIN CLIENTES ON USUARIOS.Id = CLIENTES.IdUsuario;";
                            break;
                        case TipoUsuario.Vendedor:
                            query = "SELECT USUARIOS.*, VENDEDORES.VentasRealizadas FROM USUARIOS INNER JOIN VENDEDORES ON USUARIOS.Id = VENDEDORES.IdUsuario;";
                            break;
                        default:
                            throw new ArgumentException("Tipo de usuario inválido.");
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string nombre = reader["Nombre"].ToString();
                        string apellido = reader["Apellido"].ToString();
                        string email = reader["Email"].ToString();
                        string contrasena = reader["Contraseña"].ToString();

                        Usuario usuario = null;

                        if (tipoUsuario == TipoUsuario.Cliente)
                        {
                            float montoMaximo = Convert.ToSingle(reader["MontoMaximoDeCompra"]);
                            usuario = new Cliente(nombre, apellido, email, contrasena, montoMaximo);
                        }
                        else if (tipoUsuario == TipoUsuario.Vendedor)
                        {
                            int ventasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]);
                            usuario = new Vendedor(nombre, apellido, email, contrasena, ventasRealizadas);
                        }

                        usuarios.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los usuarios: " + ex.Message);
                throw new Exception("Error obteniendo los usuarios");
            }

            return usuarios;
        }
        /// <summary>
        /// Obtiene un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario a obtener</param>
        /// <returns>Retorna Usuario si lo encuentra y Null si no</returns>
        /// <exception cref="Exception">Si ocurre un error en la conexión con la base de datos, lanza una exception</exception>
        public static Usuario? ObtenerUsuarioPorId(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT USUARIOS.*, CLIENTES.MontoMaximoDeCompra, VENDEDORES.VentasRealizadas " +
                                   "FROM USUARIOS " +
                                   "LEFT JOIN CLIENTES ON USUARIOS.Id = CLIENTES.IdUsuario " +
                                   "LEFT JOIN VENDEDORES ON USUARIOS.Id = VENDEDORES.IdUsuario " +
                                   "WHERE USUARIOS.Id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string nombre = reader["Nombre"].ToString();
                        string apellido = reader["Apellido"].ToString();
                        string email = reader["Email"].ToString();
                        string contrasena = reader["Contraseña"].ToString();

                        Usuario? usuario = null;

                        if (reader["MontoMaximoDeCompra"] != DBNull.Value)
                        {
                            float montoMaximo = Convert.ToSingle(reader["MontoMaximoDeCompra"]);
                            usuario = new Cliente(nombre, apellido, email, contrasena, montoMaximo);
                        }
                        else if (reader["VentasRealizadas"] != DBNull.Value)
                        {
                            int ventasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]);
                            usuario = new Vendedor(nombre, apellido, email, contrasena, ventasRealizadas);
                        }

                        return usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener el usuario: " + ex.Message);
                throw new Exception("Error obteniendo el usuario desde la base de datos");
            }

            return null;
        }
        /// <summary>
        /// Retorna la lista de usuarios registrados en la base de datos
        /// </summary>
        /// <returns>Retorna la lista de usuarios</returns>
        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM USUARIOS;";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string nombre = reader["Nombre"].ToString();
                        string apellido = reader["Apellido"].ToString();
                        string email = reader["Email"].ToString();
                        string contrasena = reader["Contraseña"].ToString();

                        Usuario? usuario = ObtenerUsuarioPorId(id);
                        if(usuario != null)
                        {                        
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los usuarios: " + ex.Message);
                throw new Exception("Error obteniendo los usuarios");
            }

            return usuarios;
        }
        /// <summary>
        /// Obtiene un usuario registrado en la base de dato filtrando por email y contraseña
        /// </summary>
        /// <param name="email">Email a buscar</param>
        /// <param name="contrasena">Contraseña a buscar</param>
        /// <returns>Si no se encontró el usuario retorna Null, de lo contrario retorna el Usuario</returns>
        public static Usuario? ObtenerUsuarioPorEmailYContraseña(string email, string contrasena)
        {
            List<Usuario> listaUsuarios = ObtenerUsuarios();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasena) || listaUsuarios.Count == 0)
            {
                return null;
            }

            foreach (Usuario usuario in listaUsuarios)
            {
                if (usuario.Email == email && usuario.Contrasena == contrasena)
                {
                    return usuario;
                }
            }
            return null;
        }
    }
}