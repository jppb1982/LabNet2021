using System;
using System.Collections.Generic;
using System.Text;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.Helpers
{
    class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada() { }
        public ExcepcionPersonalizada(string message) : base("\n\tHello! Llamando a clase base ============> " + message) { }

        public ExcepcionPersonalizada(string message, Exception inner) : base(message, inner) { }
        
    }
}
