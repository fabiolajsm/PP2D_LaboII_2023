using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ArchivoHistorialVentas
    {
        private static string ruta;

        static ArchivoHistorialVentas()
        {
            ruta = "HistorialDeVentas.txt";
        }

        public static List<Factura> LeerHistorialVentas()
        {
            List<Factura> historialVentas = new List<Factura>();

            try
            {
                if (string.IsNullOrEmpty(ruta) || !File.Exists(ruta))
                {
                    throw new FileNotFoundException();
                }

                string[] lineas = File.ReadAllLines(ruta);

                foreach (string linea in lineas)
                {
                    string[] elementos = linea.Split('|');

                    string tipoDeCompra = elementos[0];
                    string nombreProducto = elementos[2];
                    string nombreCliente = elementos[4];
                    string metodoDePago = elementos[6]; 

                    int idProducto, idCliente, cantidadComprada;
                    double precio, recargo;

                    if (!int.TryParse(elementos[1], out idProducto) ||
                        !int.TryParse(elementos[3], out idCliente) ||
                        !int.TryParse(elementos[5], out cantidadComprada) ||
                        !double.TryParse(elementos[7], out precio) ||
                        !double.TryParse(elementos[8], out recargo))
                    {
                        throw new Exception("Error al leer los valores.");
                    }
                    Factura factura = new Factura(tipoDeCompra, idProducto, nombreProducto, idCliente, nombreCliente, cantidadComprada, metodoDePago, precio, recargo);
                    historialVentas.Add(factura);
                }
            }
            catch (FileNotFoundException ex)
            {
                // El archivo no se encontró
                Console.WriteLine("El archivo de historial de ventas no existe.");
            }
            catch (Exception ex)
            {
                // Ocurrió una excepción general
                Console.WriteLine("Error al leer el historial de ventas: " + ex.Message);
            }

            return historialVentas;
        }


        public static bool EscribirHistorialVentas(List<Factura> historialVentas)
        {
            bool exito = false;
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(ruta, true);

                foreach (Factura factura in historialVentas)
                {
                    string linea = $"{factura.TipoDeCompra}|{factura.IdProducto}|{factura.NombreProducto}|{factura.IdCliente}|{factura.NombreCliente}|{factura.CantidadComprada}|{factura.MetodoDePago}|{factura.Precio}|{factura.Recargo}";
                    streamWriter.WriteLine(linea);
                }

                exito = true;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error al escribir en el archivo: " + ex.Message);
            }
            finally
            {
                if (streamWriter is not null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }

            return exito;
        }
    }
}
