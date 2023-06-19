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
        public static void SerializarXml(List<Producto> productos, string archivo)
        {
            // se guarda en la carpeta bin/debug del proyecto
            using (TextWriter streamWriter = new StreamWriter(archivo))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Producto>));
                xmlSerializer.Serialize(streamWriter, productos);
            }
        }

        public static List<Producto> DeserializarXml(string archivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Producto>));
            List<Producto>? productosDeserializados = null;
            using (TextReader reader = new StreamReader(archivo))
            {
                productosDeserializados = xmlSerializer.Deserialize(reader) as List<Producto>;
                if(productosDeserializados == null)
                {
                    productosDeserializados = new List<Producto>();
                }
            }
            return productosDeserializados;
        }

        public static void SerializarJson(List<Producto> productos, string archivo)
        {
            // se guarda en la carpeta bin/debug del proyecto
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;
            opciones.PropertyNamingPolicy = null;
            string json = JsonSerializer.Serialize(productos, opciones);

            // Guardo el JSON desde un archivo con codificación UTF-8
            File.WriteAllText(archivo, json, Encoding.UTF8);
        }

        public static List<Producto> DeserializarJson(string archivo)
        {
            string json = File.ReadAllText(archivo);
            List<Producto>? productosDeserializados = JsonSerializer.Deserialize<List<Producto>>(json);

            if (productosDeserializados == null)
            {
                productosDeserializados = new List<Producto>();
            }
            return productosDeserializados;
        }
    }
}
