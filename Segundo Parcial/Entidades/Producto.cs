namespace Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoCorte { get; set; }
        public double PrecioPorKilo { get; set; }
        public double StockDisponible { get; set; } // en gramos
        public int CantidadDeseada { get; set; }

        public Producto()
        {
            Id = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            TipoCorte = string.Empty;
            PrecioPorKilo = 0;
            StockDisponible = 0;
            CantidadDeseada = 0;
        }

        public Producto(int id, string nombre, string descripcion, string tipoCorte, double precioPorKilo, double stockDisponible)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            TipoCorte = tipoCorte;
            PrecioPorKilo = precioPorKilo;
            StockDisponible = stockDisponible;
            CantidadDeseada = 0;
        }

        public Producto(int id, string nombre, string descripcion, string tipoCorte, double precioPorKilo, double stockDisponible, int cantidadDeseada)
            : this(id, nombre, descripcion, tipoCorte, precioPorKilo, stockDisponible)
        {
            CantidadDeseada = cantidadDeseada;
        }

        /// <summary>
        /// Obtiene un producto buscándolo por Id en la lista de productos
        /// </summary>
        /// <param name="id">Id del producto a buscar</param>
        /// <param name="listaProductos">Lista productos</param>
        /// <returns>Retorna el producto según el nombre ingresado</returns>
        public static Producto? ObtenerProductoPorId(int id, List<Producto> listaProductos)
        {
            if (id < 1 || listaProductos.Count < 0) return null;
            foreach (Producto producto in listaProductos)
            {
                if (producto.Id == id)
                {
                    return producto;
                }
            }
            return null;
        }

        /// <summary>
        /// Busca si existe un producto en la lista de productos del carrito
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>Retorna True si existe y False si no</returns>
        public static bool ExisteProductoEnELCarrito(int id, List<Producto> listaProductosDelCarrito)
        {
            if (id < 1 || listaProductosDelCarrito.Count == 0)
            {
                return false;
            }

            return listaProductosDelCarrito.Any(prod => prod.Id == id);
        }

        /// <summary>
        /// Obtiene la cantidad deseada de un producto de a lista de productos del carrito
        /// </summary>
        /// <param name="producto">Producto al que se le obtendrá la cantidad deseada</param>
        /// <returns>Retorna la cantidad deseada del producto ingresado</returns>
        public static int ObtenerCantidadProductoDelCarrito(Producto producto, List<Producto> listaProductosCarrito)
        {
            if (producto == null || listaProductosCarrito.Count == 0) return 0;
            Producto? productoSeleccionado = ObtenerProductoPorId(producto.Id, listaProductosCarrito);
            return productoSeleccionado != null ? productoSeleccionado.CantidadDeseada : 0;
        }

        /// <summary>
        /// Agrega un producto al carrito
        /// </summary>
        /// <param name="producto">Producto a agregar</param>
        /// <param name="cantidadDeseada">Cantidad del producto a agregar</param>
        /// <param name="listaProductosDelCarrito">Lista a la que se le agregará el nuevo producto</param>
        /// <returns>Retorna True si se pudo agregar y False si no</returns>
        public static bool AgregarProductoAlCarrito(Producto producto, int cantidadDeseada, List<Producto> listaProductosDelCarrito)
        {
            if (producto == null || cantidadDeseada <= 0 || listaProductosDelCarrito == null) return false;
            else {
                Producto productoEnCarrito = listaProductosDelCarrito.Find(p => p.Id == producto.Id);

                if (productoEnCarrito != null)
                {
                    productoEnCarrito.CantidadDeseada += cantidadDeseada;
                    productoEnCarrito.StockDisponible -= cantidadDeseada;
                }
                else
                {
                    producto.StockDisponible -= cantidadDeseada;
                    producto.CantidadDeseada = cantidadDeseada;
                    listaProductosDelCarrito.Add(producto);
                }

                return true;
            }            
        }

        /// <summary>
        /// Elimina un producto del carrito
        /// </summary>
        /// <param name="producto">Producto a eliminar</param>
        /// <param name="cantidad">Cantidad de producto a eliminar</param>
        /// <param name="listaProductosDelCarrito">Lista a la que se le va a eliminar el producto</param>
        /// <returns>Retorna True si se pudo eliminar y False si no</returns>
        public static bool EliminarProductoDelCarrito(Producto producto, int cantidad, List<Producto> listaProductosDelCarrito)
        {
            if (producto == null || cantidad <= 0 || listaProductosDelCarrito == null|| listaProductosDelCarrito.Count < 1) return false;
            Producto productoEnCarrito = listaProductosDelCarrito.Find(p => p.Id == producto.Id);

            if (productoEnCarrito != null)
            {
                if (cantidad == productoEnCarrito.CantidadDeseada)
                {
                    producto.StockDisponible += cantidad;
                    listaProductosDelCarrito.Remove(productoEnCarrito);
                }
                else
                {
                    productoEnCarrito.StockDisponible += cantidad;
                    productoEnCarrito.CantidadDeseada -= cantidad;
                    producto.StockDisponible = productoEnCarrito.StockDisponible;
                    producto.CantidadDeseada = productoEnCarrito.CantidadDeseada;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calcula el precio final de un producto segun la cantidad del producto y su precio por kilo
        /// </summary>
        /// <param name="cantidadIngresadaEnGramos">Cantidad del producto en gramos</param>
        /// <param name="precioPorKilo">Precio por kilo del producto</param>
        /// <returns>Retorna el precio del producto según la cantidad ingresada en gramos</returns>
        public static double CalcularPrecio(int cantidadIngresadaEnGramos, double precioPorKilo)
        {
            double cantidadEnKilos = (double)cantidadIngresadaEnGramos / 1000; // Convertir la cantidad a kilos
            double precioTotal = 0;
            if (cantidadIngresadaEnGramos > 0 & precioPorKilo > 0)
            {
                precioTotal = cantidadEnKilos * precioPorKilo;
            }
            return precioTotal;
        }
        /// <summary>
        /// Obtiene la propiedad stockDisponible o PrecioPorKilo o TipoDeCorte según el nombre de propiedad indicado
        /// </summary>
        /// <typeparam name="T">Puede ser int o string</typeparam>
        /// <param name="producto">Producto que contiene las propiedades</param>
        /// <param name="nombrePropiedad">Nombre de la propiedad a retornar del producto</param>
        /// <returns>Retorna la propiedad stockDisponible o PrecioPorKilo o TipoDeCorte según el nombre de propiedad indicado</returns>
        public static T ObtenerPropiedad<T>(Producto producto, string nombrePropiedad)
        {
            if (producto == null || string.IsNullOrEmpty(nombrePropiedad)) return default(T);

            switch (nombrePropiedad)
            {
                case "stock":
                    return (T)Convert.ChangeType(producto.StockDisponible, typeof(T));

                case "corte":
                    return (T)Convert.ChangeType(producto.TipoCorte, typeof(T));

                case "precio":
                    return (T)Convert.ChangeType(producto.PrecioPorKilo, typeof(T));

                default:
                    return default(T);
            }
        }
    }
}