using System;
using System.Collections.Generic;
using System.Text;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica
{
    public static class DivisionDeNumeroUnicoLogicaExtensions
    {
        public static double DividePor(this int dividendo, int divisor)
        {
            if (divisor != 0)
            {
                return (double)dividendo / divisor;
            }
            else
            {
                return dividendo / divisor;
            }
        }
    }
}
