using System;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica
{
    public class Logic 
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
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException(e.Message, e);
            }
            
        }
    }
}
