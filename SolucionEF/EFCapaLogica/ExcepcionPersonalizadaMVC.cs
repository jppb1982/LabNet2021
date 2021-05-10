using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaLogica
{
    public class ExcepcionPersonalizadaMVC : Exception
    {
        public ExcepcionPersonalizadaMVC() { }
        public ExcepcionPersonalizadaMVC(string message, string method) : base($"Se produjo un error en {method}. Detalle: {message}") { }

        public ExcepcionPersonalizadaMVC(string message, string method, Exception inner) : base($"Se produjo un error en {method}. Detalle: {message}", inner) { }
    }
}
