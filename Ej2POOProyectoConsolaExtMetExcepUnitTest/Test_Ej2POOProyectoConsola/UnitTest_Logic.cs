using Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test_Ej2POOProyectoConsola
{
    [TestClass]
    public class UnitTest_Logic
    {
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void CargaFallidaArray()
        {
            //Ejecución de los métodos
            Logic.CargaFallidaArray();

            //Validación
            Assert.Fail("Se intentó cargar un array con más elementos de su capacidad.");

        }

    }
}
