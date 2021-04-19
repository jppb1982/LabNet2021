using Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica;
using System;
using System.Text;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaPresentacion
{
    class LogicPresentacion
    {
        public static void ConsolaLogic()
        {
            StringBuilder presentacionLogic = new StringBuilder();
            presentacionLogic.AppendLine("¡Bienvenido a la carga fallida de un array!");
            presentacionLogic.AppendLine("\nA continuación se mostrará qué sucede cuando se carga un array con más elementos de los permitidos.");
            Console.WriteLine(presentacionLogic.ToString());

            try
            {
                Logic.CargaFallidaArray();
            }
            catch (Exception e)
            {
                 Console.WriteLine($"---> El mensaje de la excepción es: {e.Message}\n---> El tipo de excepción es: {e.GetType()}.\n");
            }    
        }
    }
}
