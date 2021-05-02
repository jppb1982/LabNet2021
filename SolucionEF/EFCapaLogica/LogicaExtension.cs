using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaLogica
{
    public static class LogicaExtension
    {
        public static bool LongitudValida(this String cadena, int longitud)
        {
            return cadena.Length <= longitud;
        }
    }
}
