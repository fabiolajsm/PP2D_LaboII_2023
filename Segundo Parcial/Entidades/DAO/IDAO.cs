using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DAO
{
    public interface IDAO<T>
    {
        bool Eliminar(int id);
        bool Insertar(T objeto);
        T ObtenerPorId(int id);
        List<T> ObtenerLista();
    }
}
