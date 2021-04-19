using Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica;
using Ej2POOProyectoConsolaExtMetExcepUnitTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Ej2POOProyectoConsola
{
    [TestClass]
    public class UnitTest_LogicExcepcionPersonalizada
    {
        [ExpectedException(typeof(ExcepcionPersonalizada))]
        [TestMethod]
        public void CargaFallidaArray()
        {
            //Ejecución de los métodos
            ExcepcionPersonalizadaPresentacion.CargaFallidaArray();

            //Validación
            Assert.Fail("Se intentó cargar un array con más elementos de su capacidad a lo que se envía un mensaje personalizado.");
        }
    }
}
