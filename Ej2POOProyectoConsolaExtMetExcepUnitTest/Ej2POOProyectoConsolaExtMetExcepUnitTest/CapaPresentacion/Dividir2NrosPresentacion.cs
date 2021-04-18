using Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica;
using Ej2POOProyectoConsolaExtMetExcepUnitTest.Helpers;
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
            presentacionNrosDividir.AppendLine("¡Bienvenido a la división de 2 números!");
            presentacionNrosDividir.AppendLine("\n\t-> Ingrese su dividendo:");
            Console.WriteLine(presentacionNrosDividir.ToString());
            int dividendo = IngresoNumericoDatosHelper.ObtenerValorEnteroValido();

            Console.WriteLine("\t-> Ingrese su divisor");

            int divisor = IngresoNumericoDatosHelper.ObtenerValorEnteroValido();
            Double res = 0;
            try
            {
                res = Dividir2NrosLogica.DivideNros(dividendo, divisor);
                Console.WriteLine($"\nResultado de la operación: {res}\n");
            }
            catch (DivideByZeroException divByZerExc)
            {
                Console.WriteLine("\nSolo Chuck Norris divide por cero!");
                Console.WriteLine(divByZerExc.Message + "\n");
            }
        }
    }
}
