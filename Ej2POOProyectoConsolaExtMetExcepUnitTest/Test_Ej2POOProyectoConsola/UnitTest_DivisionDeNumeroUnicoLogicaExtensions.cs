using Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test_Ej2POOProyectoConsola
{
    [TestClass]
    public class UnitTest_DivisionDeNumeroUnicoLogicaExtensions
    {
        [TestMethod]
        public void DividePor()
        {
            //Definición de variables
            int divisor = 5;
            int dividendo = 25;
            double resultadoEsperado = 5;

            //Ejecución de los métodos
            double resutadoReal = dividendo.DividePor(divisor);

            //Validación
            Assert.AreEqual(resultadoEsperado, resutadoReal);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividePorZero()
        {
            //Definición de variables
            int divisor = 0;
            int dividendo = 25;


            //Ejecución de los métodos
            dividendo.DividePor(divisor);

            //Validación
            Assert.Fail("División por cero.");
        }
    }
}
