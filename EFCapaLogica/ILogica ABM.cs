using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaLogica
{
    public interface ILogica_ABM<T>
    {
        List<T> ObtenerTodos();

        Boolean Agregar(T elemento);
        Boolean Borrar(int id);
        Boolean Actualizar(T elemento);
        int OtenerProximoId();
    }
}
