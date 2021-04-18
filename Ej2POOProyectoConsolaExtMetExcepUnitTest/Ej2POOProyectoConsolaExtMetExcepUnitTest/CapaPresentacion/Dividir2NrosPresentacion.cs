using Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaPresentacion
{
    class Dividir2NrosPresentacion
    {
        public static void ConsolaDividir2Nros()
        {

            StringBuilder presentacionNrosDividir = new StringBuilder();
            presentacionNrosDividir.AppendLine("¡Bienvenido a la División de 2 números!");
            presentacionNrosDividir.AppendLine("\n\t-> Ingrese su dividendo:");
            Console.WriteLine(presentacionNrosDividir.ToString());
            int dividendo = ObtenerValorValido();

            Console.WriteLine("\t-> Ingrese su divisor");

            int divisor = ObtenerValorValido();
            Double res = 0;
            try
            {
                res = Dividir2NrosLogica.DivideNros(dividendo, divisor);
                Console.WriteLine($"\nResultado de la operación: {res}\n");
            }
            catch (DivideByZeroException divByZerExc)
            {
                Console.WriteLine("\n5Solo Chuck Norris divide por cero!");
                Console.WriteLine(divByZerExc.Message + "\n");
            }

        }

        public static int ObtenerValorValido()
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
