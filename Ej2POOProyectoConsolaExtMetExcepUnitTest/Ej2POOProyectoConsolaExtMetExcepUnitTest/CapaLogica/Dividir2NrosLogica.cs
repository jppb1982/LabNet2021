using System;
using System.Collections.Generic;
using System.Text;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica
{
    class Dividir2NrosLogica
    {
        public static Double DivideNros(int dividendo, int divisor)
        {
            if (divisor == 0)
            {
                return dividendo / divisor;
            }
            else
            {
                return (double)dividendo / divisor;
            }
        }
    }
}
