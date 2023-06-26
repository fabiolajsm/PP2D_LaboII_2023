using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using System.IO;

namespace Entidades
{
    public static class SerializadorProducto
    {
        /// <summary>
        /// Serializa una lista de productos en formato Xml
        /// </summary>
        /// <param name="productos">Lista de productos a serializar</param>
        /// <param name="archivo">Archivo en donde se va a escribir la lista serializada</param>
        /// <returns>Retorna True si se pudo serializar y False si no</returns>
        public static bool SerializarXml(List<Producto> productos, string archivo)
        {
            // se guarda en la carpeta bin/debug del proyecto
            try
            {                
                using (TextWriter streamWriter = new StreamWriter(archivo))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Producto>));
                    xmlSerializer.Serialize(streamWriter, productos);
                }
                return true;
            } 
            catch (Exception ex) { 
                Console.WriteLine("Error al serializar en xml", ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Deserializa una lista de productos guardados en formato XML
        /// </summary>
        /// <param name="archivo">Archivo donde se encuentra serializado la lista de productos</param>
        /// <returns>Retorna una lista de productos</returns>
        public static List<Producto> DeserializarXml(string archivo)
        {
            try
            {                
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Producto>));
                List<Producto>? productosDeserializados = null;
                using (TextReader reader = new StreamReader(archivo))
                {
                    productosDeserializados = xmlSerializer.Deserialize(reader) as List<Producto>;
                    if (productosDeserializados == null)
                    {
                        productosDeserializados = new List<Producto>();
                    }
                }
                return productosDeserializados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al deserializar en xml", ex.Message);
                return new List<Producto>();
            }           
        }
        /// <summary>
        /// Serializa una lista de productos en formato Json
        /// </summary>
        /// <param name="productos">Lista de productos a serializar</param>
        /// <param name="archivo">Archivo en donde se va a escribir la lista serializada</param>
        /// <returns>Retorna True si se pudo serializar y False si no</returns>
        public static bool SerializarJson(List<Producto> productos, string archivo)
        {
            // se guarda en la carpeta bin/debug del proyecto
            try
            {
                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;
                opciones.PropertyNamingPolicy = null;
                string json = JsonSerializer.Serialize(productos, opciones);

                // Guardo el JSON desde un archivo con codificación UTF-8
                File.WriteAllText(archivo, json, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al deserializar en xml", ex.Message);
                return false;
            }           
        }
        /// <summary>
        /// Deserializa una lista de productos guardados en formato JSON
        /// </summary>
        /// <param name="archivo">Archivo donde se encuentra serializado la lista de productos</param>
        /// <returns>Retorna una lista de productos</returns>
        public static List<Producto> DeserializarJson(string archivo)
        {
            try
            {
                string json = File.ReadAllText(archivo);
                List<Producto>? productosDeserializados = JsonSerializer.Deserialize<List<Producto>>(json);

                if (productosDeserializados == null)
                {
                    productosDeserializados = new List<Producto>();
                }
                return productosDeserializados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al deserializar en xml", ex.Message);
                return new List<Producto>();
            }
        }
    }
}
