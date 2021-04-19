using Ej2POOProyectoConsolaExtMetExcepUnitTest.Helpers;
using System;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica
{
    public class ExcepcionPersonalizadaPresentacion
    {
        public static void CargaFallidaArray()
        {
            try
            {
                String[] arrayStrings = new string[4];
                String[] arrayACopiar = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes" };

                for (int i = 0; i < arrayACopiar.Length; i++)
                {
                    arrayStrings[i] = arrayACopiar[i];
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new ExcepcionPersonalizada("Esta es una exceptión personalizada. \n\tSu array está fuera de los límites.");
            }

        }

    }
}