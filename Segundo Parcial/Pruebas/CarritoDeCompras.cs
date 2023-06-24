using Entidades;

namespace Test_CarritoDeCompra
{
    [TestClass]
    public class CarritoDeCompras
    {
        [TestMethod]
        public void AgregarProductoAlCarrito_AgregarNuevoProducto_ProductoAgregadoCorrectamente()
        {
            // Arrange
            Producto producto = new Producto(1, "Tofu", "Tofu marinado", "Cuadrado", 900, 4000);
            int cantidadDeseadaEnGramos = 1000;
            List<Producto> listaProductosDelCarrito = new List<Producto>();

            // Act
            bool resultado = Producto.AgregarProductoAlCarrito(producto, cantidadDeseadaEnGramos, listaProductosDelCarrito);

            // Assert
            Assert.IsTrue(resultado);
            Assert.AreEqual(1, listaProductosDelCarrito.Count);
            Assert.AreEqual(1000, producto.CantidadDeseada);
            // Después de agregar el producto, al stock disponible se le resta la cantidad ingresada
            Assert.AreEqual(3000, producto.StockDisponible);

            // Verificar que el producto en la lista tenga las mismas cantidades
             Producto productoEnCarrito = listaProductosDelCarrito[0];
             Assert.AreEqual(1, productoEnCarrito.Id);
             Assert.AreEqual("Tofu", productoEnCarrito.Nombre);
             Assert.AreEqual("Tofu marinado", productoEnCarrito.Descripcion);
             Assert.AreEqual("Cuadrado", productoEnCarrito.TipoCorte);
             Assert.AreEqual(1000, productoEnCarrito.CantidadDeseada);
             // Acá igual, el stock debe ser modificado
             Assert.AreEqual(3000, productoEnCarrito.StockDisponible);          
        }

        [TestMethod]
        public void AgregarProductoAlCarrito_AgregarProductoExistente_ProductoActualizadoCorrectamente()
        {
            // Arrange
            Producto productoExistente = new Producto(1, "Tofu", "Tofu marinado", "Cuadrado", 900, 4000, 1000);
            List<Producto> listaProductosDelCarrito = new List<Producto> { productoExistente };

            Producto productoNuevo = new Producto(1, "Tofu", "Tofu marinado", "Cuadrado", 900, 4000);
            int cantidadDeseada = 1000;

            // Act
            bool resultado = Producto.AgregarProductoAlCarrito(productoNuevo, cantidadDeseada, listaProductosDelCarrito);

            // Assert
            Assert.IsTrue(resultado);
            Assert.AreEqual(1, listaProductosDelCarrito.Count);
            Assert.AreEqual(2000, productoExistente.CantidadDeseada);
            Assert.AreEqual(3000, productoExistente.StockDisponible);
        }

        [TestMethod]
        public void AgregarProductoAlCarrito_ProductoNulo_NoAgregaProducto()
        {
            // Arrange
            Producto producto = null;
            int cantidadDeseada = 5;
            List<Producto> listaProductosDelCarrito = new List<Producto>();

            // Act
            bool resultado = Producto.AgregarProductoAlCarrito(producto, cantidadDeseada, listaProductosDelCarrito);

            // Assert
            Assert.IsFalse(resultado);
            Assert.AreEqual(0, listaProductosDelCarrito.Count);
        }

        [TestMethod]
        public void AgregarProductoAlCarrito_CantidadDeseadaInvalida_NoAgregaProducto()
        {
            // Arrange
            List<Producto> listaProductosDelCarrito = new List<Producto>();
            Producto producto = new Producto(1, "Tofu", "Tofu marinado", "Cuadrado", 900, 4000, 1000);
            int cantidadDeseada = 0;
            // Act
            bool resultado = Producto.AgregarProductoAlCarrito(producto, cantidadDeseada, listaProductosDelCarrito);
            // Assert
            Assert.IsFalse(resultado);
            Assert.AreEqual(0, listaProductosDelCarrito.Count);
        }

        [TestMethod]
        public void AgregarProductoAlCarrito_ListaProductosDelCarritoNula_NoAgregaProducto()
        {
            // Arrange
            Producto producto = new Producto(1, "Tofu", "Tofu marinado", "Cuadrado", 900, 4000, 1000);
            int cantidadDeseada = 500;
            List<Producto> listaProductosDelCarrito = null;
            // Act
            bool resultado = Producto.AgregarProductoAlCarrito(producto, cantidadDeseada, listaProductosDelCarrito);
            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void EliminarProductoDelCarrito_EliminarProductoExistente_ProductoEliminadoCorrectamente()
        {
            // Arrange
            Producto producto = new Producto(1, "Tofu", "Tofu marinado", "Cuadrado", 900, 4000, 1000);
            List<Producto> listaProductosDelCarrito = new List<Producto> { producto };
            int cantidad = 1000;

            // Act
            bool resultado = Producto.EliminarProductoDelCarrito(producto, cantidad, listaProductosDelCarrito);

            // Assert
            Assert.IsTrue(resultado);
            Assert.AreEqual(0, listaProductosDelCarrito.Count);
            Assert.AreEqual(5000, producto.StockDisponible);
            Assert.AreEqual(1000, producto.CantidadDeseada);
        }

        [TestMethod]
        public void EliminarProductoDelCarrito_ProductoNoExistente_NoEliminaProducto()
        {
            // Arrange
            Producto productoExistente = new Producto(1, "Tofu", "Tofu marinado", "Cuadrado", 900, 4000, 1000);
            List<Producto> listaProductosDelCarrito = new List<Producto> { productoExistente };
            Producto productoNoExistente = new Producto(2, "Producto 2", "Producto que no existe", "inexistente", 900, 4000);
            int cantidad = 1000;

            // Act
            bool resultado = Producto.EliminarProductoDelCarrito(productoNoExistente, cantidad, listaProductosDelCarrito);

            // Assert
            Assert.IsFalse(resultado);
            Assert.AreEqual(1, listaProductosDelCarrito.Count);
        }

        [TestMethod]
        public void EliminarProductoDelCarrito_CantidadInvalida_NoEliminaProducto()
        {
            // Arrange
            Producto producto = new Producto { Id = 1, Nombre = "Producto 1", StockDisponible = 10, CantidadDeseada = 5 };
            int cantidad = 0;
            List<Producto> listaProductosDelCarrito = new List<Producto> { producto };
            // Act
            bool resultado = Producto.EliminarProductoDelCarrito(producto, cantidad, listaProductosDelCarrito);
            // Assert
            Assert.IsFalse(resultado);
            Assert.AreEqual(1, listaProductosDelCarrito.Count);
        }

        [TestMethod]
        public void EliminarProductoDelCarrito_ListaProductosDelCarritoNula_NoEliminaProducto()
        {
            // Arrange
            Producto producto = new Producto(1, "Tofu", "Tofu marinado", "Cuadrado", 900, 4000, 1000);
            int cantidad = 1000;
            List<Producto> listaProductosDelCarrito = null;
            // Act
            bool resultado = Producto.EliminarProductoDelCarrito(producto, cantidad, listaProductosDelCarrito);
            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void EliminarProductoDelCarrito_ListaProductosDelCarritoVacia_NoEliminaProducto()
        {
            // Arrange
            Producto producto = new Producto(1, "Tofu", "Tofu marinado", "Cuadrado", 900, 4000, 1000);
            int cantidad = 5;
            List<Producto> listaProductosDelCarrito = new List<Producto>();
            // Act
            bool resultado = Producto.EliminarProductoDelCarrito(producto, cantidad, listaProductosDelCarrito);
            // Assert
            Assert.IsFalse(resultado);
        }
    }
}