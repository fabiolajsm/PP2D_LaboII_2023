using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suarez_Fabiola_2D_2023
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoCorte { get; set; }
        public decimal PrecioPorKilo { get; set; }
        public decimal StockDisponible { get; set; }

        public Producto(string nombre, string descripcion, string tipoCorte, decimal precioPorKilo, decimal stockDisponible)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            TipoCorte = tipoCorte;
            PrecioPorKilo = precioPorKilo;
            StockDisponible = stockDisponible;
        }
    }
}
