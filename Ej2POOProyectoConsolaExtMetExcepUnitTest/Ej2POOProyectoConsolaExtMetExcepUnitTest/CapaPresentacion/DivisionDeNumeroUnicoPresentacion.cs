using Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica;
using Ej2POOProyectoConsolaExtMetExcepUnitTest.Helpers;
using System;
using System.Text;


namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaPresentacion
{
    class DivisionDeNumeroUnicoPresentacion
    {
        public static void ConsolaDivideNumero()
        {
            StringBuilder presentacion = new StringBuilder();
            presentacion.AppendLine("¡Bienvenido a la división de un único número!");
            presentacion.AppendLine("\nA continuación se le solicitará ingresar un valor numérico, el cual será dividido por los primeros 10 números naturales.");
            presentacion.AppendLine("\n\t-> Ingrese su dividendo:");
            Console.WriteLine(presentacion.ToString());
            
            int dividendo = IngresoNumericoDatosHelper.ObtenerValorEnteroValido();
            Console.Clear();

            
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine($"\n{dividendo} / {i}");
                    Double resultado = dividendo.DividePor(i);
                    Console.WriteLine($"El resultado del cociente es {resultado}.");
                 
                }
                catch (Exception e)
                {
                    Console.WriteLine($"¡Atención! Ha ocurido un error al intentar dividir por {i}.");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine($"División por {i} finalizada.\n");
                }
            }


        }
        
    }
}
