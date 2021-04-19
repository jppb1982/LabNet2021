using System;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica
{
    public class Dividir2NrosLogica
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
