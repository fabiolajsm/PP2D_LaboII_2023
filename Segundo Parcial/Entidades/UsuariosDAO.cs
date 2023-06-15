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
        /// Retorna una lista de los usuarios registrados en la base de datos que son clientes
        /// </summary>
        /// <returns>Retorna una lista de clientes</returns>
        /// <exception cref="Exception">Si ocurre un error, lanza una exception</exception>
        public static List<Cliente> ObtenerListaClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT USUARIOS.*, CLIENTES.MontoMaximoDeCompra FROM USUARIOS INNER JOIN CLIENTES ON USUARIOS.Id = CLIENTES.IdUsuario;";

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
                        float montoMaximo = Convert.ToSingle(reader["MontoMaximoDeCompra"]);

                        Cliente cliente = new Cliente(nombre, apellido, email, contrasena, montoMaximo);
                        clientes.Add(cliente);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los clientes: " + ex.Message);
                throw new Exception("Error obteniendo los clientes");
            }

            return clientes;
        }

        public static Cliente ObtenerClientePorId(int id)
        {
            Cliente cliente = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT USUARIOS.*, CLIENTES.MontoMaximoDeCompra FROM USUARIOS INNER JOIN CLIENTES ON USUARIOS.Id = CLIENTES.IdUsuario WHERE USUARIOS.Id = @Id";

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
                        float montoMaximo = Convert.ToSingle(reader["MontoMaximoDeCompra"]);

                        cliente = new Cliente(nombre, apellido, email, contrasena, montoMaximo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener el cliente: " + ex.Message);
                throw new Exception("Error obteniendo el cliente");
            }

            return cliente;
        }
        public static Vendedor ObtenerVendedorPorId(int id)
        {
            Vendedor vendedor = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT USUARIOS.*, VENDEDORES.VentasRealizadas FROM USUARIOS INNER JOIN VENDEDORES ON USUARIOS.Id = VENDEDORES.IdUsuario WHERE USUARIOS.Id = @Id";

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
                        int ventasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]);

                        vendedor = new Vendedor(nombre, apellido, email, contrasena, ventasRealizadas);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener el vendedor: " + ex.Message);
                throw new Exception("Error obteniendo el vendedor");
            }

            return vendedor;
        }


        /// <summary>
        /// Retorna una lista de los usuarios registrados en la base de datos que son vendedores
        /// </summary>
        /// <returns>Retorna una lista de vendedores</returns>
        /// <exception cref="Exception">Si ocurre un error, lanza una exception</exception>
        public static List<Vendedor> ObtenerListaVendedores()
        {
            List<Vendedor> vendedores = new List<Vendedor>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT USUARIOS.*, VENDEDORES.VentasRealizadas FROM USUARIOS INNER JOIN VENDEDORES ON USUARIOS.Id = VENDEDORES.IdUsuario;";

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
                        int ventasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]);

                        Vendedor vendedor = new Vendedor(nombre, apellido, email, contrasena, ventasRealizadas);
                        vendedores.Add(vendedor);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los vendedores: " + ex.Message);
                throw new Exception("Error obteniendo los vendedores");
            }

            return vendedores;
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

                        // Verificar el tipo de usuario por medio de algún indicador, como una columna en la base de datos
                        int tipoDeUsuario = Convert.ToInt32(reader["TipoDeUsuario"]);
                        Usuario usuario;
                        /*Usuario usuario = tipoDeUsuario == 1
                            ? new Vendedor(nombre, apellido, email, contrasena, 0)
                            : new Cliente(nombre, apellido, email, contrasena, 0);*/
                        if (tipoDeUsuario == 1)
                        {
                            usuario = ObtenerVendedorPorId(id);
                        }
                        else
                        {
                            usuario = ObtenerClientePorId(id);
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