using Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica;
using Ej2POOProyectoConsolaExtMetExcepUnitTest.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaPresentacion
{
    class ExcepcionPersonalizadaPresentacion
    {
        public static void ConsolaLogicExcepcionPersonalizada()
        {
            StringBuilder presentacionLogic = new StringBuilder();
            presentacionLogic.AppendLine("¡Bienvenido a la carga fallida de un array!");
            presentacionLogic.AppendLine("\nA continuación se mostrará qué sucede cuando se cargar un array con más elementos de los permitidos con excepción personalizada.");
            Console.WriteLine(presentacionLogic.ToString());

            try
            {
                CapaLogica.ExcepcionPersonalizadaPresentacion.CargaFallidaArray();
            }
            catch (ExcepcionPersonalizada e)
            {
                Console.WriteLine($"---> El mensaje de la excepción es: {e.Message}\n---> El tipo de excepción es {e.GetType()}.\n");
            }

        }
    }
}
