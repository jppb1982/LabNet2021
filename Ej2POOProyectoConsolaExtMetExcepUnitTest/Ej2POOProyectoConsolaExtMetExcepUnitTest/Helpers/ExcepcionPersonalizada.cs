using System;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.Helpers
{
    public class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada() { }
        public ExcepcionPersonalizada(string message) : base("\n\tHello! Llamando a clase base desde excepción personalizada ============> " + message) { }

        public ExcepcionPersonalizada(string message, Exception inner) : base(message, inner) { }
        
    }
}
