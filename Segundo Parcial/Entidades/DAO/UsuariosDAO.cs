using System.Data.SqlClient;

namespace Entidades.DAO
{
    public class UsuariosDAO : IDAO<Usuario>
    {
        private static string connectionString;

        static UsuariosDAO()
        {
            connectionString = @"Data Source = localhost; Database = Ecomoo; Trusted_Connection = True;";
        }
        /// <summary>
        /// Eliminará un usuario de la base de datos a partir de su ID
        /// </summary>
        /// <param name="id">id del usuario a borrar</param>
        /// <returns>Retorna True si se eliminó y False si no</returns>
        public bool Eliminar(int id)
        {
            if (id == 0 || connectionString == null) return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                   
                    string queryClientes = "DELETE FROM CLIENTES WHERE IdUsuario = @IdUsuario;";
                    using (SqlCommand commandClientes = new SqlCommand(queryClientes, connection))
                    {
                        commandClientes.Parameters.AddWithValue("@IdUsuario", id);
                        commandClientes.ExecuteNonQuery();
                    }

                    string queryVendedores = "DELETE FROM VENDEDORES WHERE IdUsuario = @IdUsuario;";
                    using (SqlCommand commandVendedores = new SqlCommand(queryVendedores, connection))
                    {
                        commandVendedores.Parameters.AddWithValue("@IdUsuario", id);
                        commandVendedores.ExecuteNonQuery();
                    }

                    string queryUsuario = "DELETE FROM USUARIOS WHERE Id = @Id;";
                    using (SqlCommand commandUsuario = new SqlCommand(queryUsuario, connection))
                    {
                        commandUsuario.Parameters.AddWithValue("@Id", id);
                        commandUsuario.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al borrar el usuario: " + ex.Message);
                    return false;
                }
            }
        }
        /// <summary>
        /// Agrega un usuario a la base de datos
        /// </summary>
        /// <param name="usuario">Usuario a agregar</param>
        /// <returns>Retorna True si se agregó y False si no</returns>
        public bool Insertar(Usuario usuario)
        {
            if(usuario  == null) return false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {                   
                    connection.Open();                    
                    string queryUsuario = "INSERT INTO USUARIOS (Nombre, Apellido, Email, Contraseña, TipoDeUsuario) " +
                                               "VALUES (@Nombre, @Apellido, @Email, @Contraseña, @TipoDeUsuario)";

                       
                    using (SqlCommand commandUsuario = new SqlCommand(queryUsuario, connection))                 
                    {                    
                        commandUsuario.Parameters.AddWithValue("@Nombre", usuario.Nombre);                        
                        commandUsuario.Parameters.AddWithValue("@Apellido", usuario.Apellido);                        
                        commandUsuario.Parameters.AddWithValue("@Email", usuario.Email);                        
                        commandUsuario.Parameters.AddWithValue("@Contraseña", usuario.Contrasena);                        
                        commandUsuario.Parameters.AddWithValue("@TipoDeUsuario", (int)usuario.TipoDeUsuario);                        
                        commandUsuario.ExecuteNonQuery();                        
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
                    return true;
                }
                catch (Exception ex)
                {
                    Console.Write($"Error al agregar usuarios: {ex.Message}");
                    return false;
                }
            }
        }
        /// <summary>
        /// Obtiene un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario a obtener</param>
        /// <returns>Retorna Usuario si lo encuentra y Null si no</returns>
        /// <exception cref="Exception">Si ocurre un error en la conexión con la base de datos, lanza una exception</exception>
        public Usuario ObtenerPorId(int id)
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
                        int idUsuario = Convert.ToInt32(reader["Id"]);
                        string nombre = reader["Nombre"].ToString();
                        string apellido = reader["Apellido"].ToString();
                        string email = reader["Email"].ToString();
                        string contrasena = reader["Contraseña"].ToString();

                        Usuario? usuario = null;

                        if (reader["MontoMaximoDeCompra"] != DBNull.Value)
                        {
                            float montoMaximo = Convert.ToSingle(reader["MontoMaximoDeCompra"]);
                            usuario = new Cliente(idUsuario, nombre, apellido, email, contrasena, montoMaximo);
                        }
                        else if (reader["VentasRealizadas"] != DBNull.Value)
                        {
                            int ventasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]);
                            usuario = new Vendedor(idUsuario, nombre, apellido, email, contrasena, ventasRealizadas);
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
        public List<Usuario> ObtenerLista()
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

                        IDAO<Usuario> usuariosDAO = new UsuariosDAO();
                        Usuario? usuario = usuariosDAO.ObtenerPorId(id);
                        if (usuario != null)
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
                        int idUsuario = Convert.ToInt32(reader["Id"]);
                        string nombre = reader["Nombre"].ToString();
                        string apellido = reader["Apellido"].ToString();
                        string email = reader["Email"].ToString();
                        string contrasena = reader["Contraseña"].ToString();

                        Usuario usuario = null;

                        if (tipoUsuario == TipoUsuario.Cliente)
                        {
                            float montoMaximo = Convert.ToSingle(reader["MontoMaximoDeCompra"]);
                            usuario = new Cliente(idUsuario, nombre, apellido, email, contrasena, montoMaximo);
                        }
                        else if (tipoUsuario == TipoUsuario.Vendedor)
                        {
                            int ventasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]);
                            usuario = new Vendedor(idUsuario, nombre, apellido, email, contrasena, ventasRealizadas);
                        }
                        if (usuario != null)
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
            IDAO<Usuario> usuariosDAO = new UsuariosDAO();
            List<Usuario> listaUsuarios = usuariosDAO.ObtenerLista();
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
        /// <summary>
        /// Modifica en la base de datos el monto máximo de compra del cliente
        /// </summary>
        /// <param name="cliente">Cliente a modificar</param>
        /// <param name="monto">Nuevo monto a asignar</param>
        /// <returns>Retorna True si se modificó y False si no</returns>
        public static bool ModificarMontoMaximoDeCompra(Cliente cliente, float monto)
        {
            if (cliente == null || monto < 1) return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE CLIENTES SET MontoMaximoDeCompra = @monto WHERE IdUsuario = @id;";

                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@monto", monto);
                    comando.Parameters.AddWithValue("@id", cliente.Id);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0) return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Actualiza la cantidad de Ventas realizadas por un vendedor
        /// </summary>
        /// <param name="vendedor">Vendedor a actualizar</param>
        /// <param name="cantidadDeVentas">Cantidad de ventas nuevas</param>
        /// <returns>Retorna True si se actualizó y False si no</returns>
        public static bool ModificarVentasRealizadas(Vendedor vendedor, int cantidadDeVentas)
        {
            if (vendedor == null || cantidadDeVentas < 1) return false;

            int cantidadFinal = vendedor.VentasRealizadas + cantidadDeVentas;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE VENDEDORES SET VentasRealizadas = @cantidad WHERE IdUsuario = @id;";

                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@cantidad", cantidadFinal);
                    comando.Parameters.AddWithValue("@id", vendedor.Id);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0) return true;
                }
            }

            return false;
        }
    }
}