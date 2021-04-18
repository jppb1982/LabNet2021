using System;
using System.Collections.Generic;
using System.Text;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.Helpers
{
    class IngresoNumericoDatosHelper
    {
        public static int ObtenerValorEnteroValido()
        {
            bool pudoParsear = false;
            int valor = 0;

            do
            {
                pudoParsear = int.TryParse(Console.ReadLine(), out int value);
                if (!pudoParsear)
                {
                    Console.WriteLine("\nSeguro Ingreso una letra o no ingreso nada!\n");
                }
                else
                {
                    valor = value;
                }
            } while (pudoParsear == false);

            return valor;

        }
    }
}
