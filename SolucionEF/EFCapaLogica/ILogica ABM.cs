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

        void Agregar(T elemento);
        void Borrar(int id);
        void Actualizar (T elemento);
        int OtenerProximoId();
    }
}
