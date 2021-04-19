using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace UnitTest_Ej2POOProyectoConsola
{
    [TestClass]
    public class UnitTest_DivideNros
    {
        [TestMethod]
        public void TestDivideNros()
        {
            //Inicializar variables
            int dividendo = 52;
            int divisor = 4;

            //Ejecutar
            double resultado = Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica.Dividir2NrosLogica;

            //Assert
        }

        [TestMethod]
        public void TestDivideNrosByZero()
        {
            //Inicializar variables
            int dividendo = 52;
            int divisor = 0;

            //Ejecutar

            //Assert
        }

    }
}
