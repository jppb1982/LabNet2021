using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaLogica
{
    public static class HelperValidaciones
    {
        public static int ObtenerValorEnteroValido()
        {
            bool pudoParsear;
            int valor = 0;

            do
            {
                pudoParsear = int.TryParse(Console.ReadLine(), out int value);
                if (!pudoParsear)
                {
                    Console.WriteLine("\nHa ingresado un valor incorrecto. Debe ingresar un número entero. Intente nuevamente.\n");
                }
                else
                {
                    valor = value;
                }
            } while (pudoParsear == false);

            return valor;

        }

        public static decimal ObtenerValorDecimalValido()
        {
            bool pudoParsear;
            decimal valor = 0;

            do
            {
                pudoParsear = decimal.TryParse(Console.ReadLine(), out decimal value);
                if (!pudoParsear)
                {
                    Console.WriteLine("\nHa ingresado un valor incorrecto. Debe ingresar un número decimal. Intente nuevamente.\n");
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
