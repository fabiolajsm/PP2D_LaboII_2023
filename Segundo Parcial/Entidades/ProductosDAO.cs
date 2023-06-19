using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class ProductosDAO
    {
        private static string connectionString;
        static ProductosDAO()
        {
            connectionString = @"Data Source = localhost; Database = Ecomoo; Trusted_Connection = True;";
        }
        /// <summary>
        /// Eliminará un producto de la base de datos a partir de su ID
        /// </summary>
        /// <param name="id">id del producto a borrar</param>
        /// <returns>Retorna True si se eliminó y False si no</returns>
        public static bool BorrarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PRODUCTOS WHERE Id = @Id;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    int filasModificadas = command.ExecuteNonQuery();
                    return filasModificadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al borrar el producto: " + ex.Message);
                    return false;
                }
            }
        }
        /// <summary>
        /// Guardará un nuevo producto en la base de datos
        /// </summary>
        /// <param name="producto">Producto a guardar</param>
        /// <returns>Retorna True si se agregó y False si no</returns>
        public static bool GuardarProducto(Producto producto)
        {
            if (producto == null) return false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Productos (Nombre, Descripcion, TipoDeCorte, PrecioPorKilo, StockDisponible, CantidadDeseada) " +
                               "VALUES (@Nombre, @Descripcion, @TipoDeCorte, @PrecioPorKilo, @StockDisponible, @CantidadDeseada)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@TipoDeCorte", producto.TipoCorte);
                command.Parameters.AddWithValue("@PrecioPorKilo", producto.PrecioPorKilo);
                command.Parameters.AddWithValue("@StockDisponible", producto.StockDisponible);
                command.Parameters.AddWithValue("@CantidadDeseada", producto.CantidadDeseada);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al guardar el producto: " + ex.Message);
                    return false;
                }
            }
        }
        /// <summary>
        /// Traerá un producto, filtrando por ID
        /// </summary>
        /// <param name="id">Id del producto a traer</param>
        /// <returns>Retorna el prodcuto si lo encuentra y si no, retorna null</returns>
        public static Producto? LeerPorID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PRODUCTOS WHERE Id = @Id;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Producto producto = new Producto(
                            Convert.ToInt32(reader["Id"]),
                            reader["Nombre"].ToString(),
                            reader["Descripcion"].ToString(),
                            reader["TipoDeCorte"].ToString(),
                            Convert.ToDouble(reader["PrecioPorKilo"]),
                            Convert.ToDouble(reader["StockDisponible"]),
                            Convert.ToInt32(reader["CantidadDeseada"])
                        );
                        return producto;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al leer el producto por ID: " + ex.Message);
                    throw new Exception("Error obteniendo el producto");
                }
            }

            return null;
        }
        /// <summary>
        /// Retorna la lista de productos registrados en la base de datos
        /// </summary>
        /// <returns>Retorna la lista de productos</returns>
        public static List<Producto> LeerProductos()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM PRODUCTOS;";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Producto producto = new Producto(Convert.ToInt32(reader["Id"]), reader["Nombre"].ToString(), reader["Descripcion"].ToString(), reader["TipoDeCorte"].ToString(), Convert.ToDouble(reader["PrecioPorKilo"]), Convert.ToDouble(reader["StockDisponible"]), Convert.ToInt32(reader["CantidadDeseada"]));
                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los productos: " + ex.Message);
                throw new Exception("Error obteniendo los productos");
            }

            return productos;
        }
        /// <summary>
        /// Modifica un atributo del producto ingresado a partir de su Id.
        /// </summary>
        /// <param name="producto">Producto a modificar</param>
        /// <param name="nombreAtributo">Nombre del atributo a modificar</param>
        /// <param name="nuevoValor">Nuevo valor a asignarle al atributo</param>
        /// <returns>True si se modificó correctamente, False si ocurrió un error</returns>
        public static bool ModificarAtributo<T>(Producto producto, string nombreAtributo, T nuevoValor)
        {
            if (producto == null || string.IsNullOrEmpty(nombreAtributo) || nuevoValor == null) return false;
            string atributo;
            dynamic valor = null;
            switch (nombreAtributo)
            {
                case "precio":
                    atributo = "PrecioPorKilo";
                    if (!double.TryParse(nuevoValor.ToString(), out double parsedDouble))
                    {
                        return false;
                    }
                    valor = parsedDouble;
                    break;
                case "stock":
                    atributo = "StockDisponible";
                    if (!double.TryParse(nuevoValor.ToString(), out parsedDouble))
                    {
                        return false;
                    }
                    valor = parsedDouble;
                    break;
                case "tipo de corte":
                    atributo = "TipoDeCorte";
                    valor = nuevoValor.ToString().Trim().Capitalize();
                    break;
                default: return false;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"UPDATE PRODUCTOS SET {atributo} = @valor WHERE Id = @id;";

                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@valor", valor);
                    comando.Parameters.AddWithValue("@id", producto.Id);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0) return true;
                }
            }

            return false;
        }
        public static bool ModificarLista(List<Producto> listaProductos)
        {
            if(listaProductos.Count == 0) return false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (Producto producto in listaProductos)
                    {
                        string query = @"UPDATE PRODUCTOS SET StockDisponible = @StockDisponible WHERE Id = @Id";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@StockDisponible", producto.StockDisponible);
                        command.Parameters.AddWithValue("@Id", producto.Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected <= 0)
                        {
                            Console.WriteLine("No se pudo actualizar el producto con ID: " + producto.Id);
                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al modificar la lista de productos: " + ex.Message);
                    return false;
                }
            }
        }
    }
}

