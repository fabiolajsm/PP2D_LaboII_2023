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
        /// Modifica un producto a partir de su Id.
        /// </summary>
        /// <param name="producto">Producto a modificar</param>
        /// <returns>True si se modificó correctamente, False si ocurrió un error</returns>
        public static bool Modificar(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE PRODUCTOS
                         SET Nombre = @Nombre,
                             Descripcion = @Descripcion,
                             TipoDeCorte = @TipoDeCorte,
                             PrecioPorKilo = @PrecioPorKilo,
                             StockDisponible = @StockDisponible,
                             CantidadDeseada = @CantidadDeseada
                         WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@TipoDeCorte", producto.TipoCorte);
                command.Parameters.AddWithValue("@PrecioPorKilo", producto.PrecioPorKilo);
                command.Parameters.AddWithValue("@StockDisponible", producto.StockDisponible);
                command.Parameters.AddWithValue("@CantidadDeseada", producto.CantidadDeseada);
                command.Parameters.AddWithValue("@Id", producto.Id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al modificar el producto: " + ex.Message);
                    return false;
                }
            }
        }
    }
}

