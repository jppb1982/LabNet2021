using System;
using System.Collections.Generic;
using System.Text;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.Helpers
{
    class ExcepcionesPersonalizadas:Exception
    {
        public ExcepcionesPersonalizadas() { }
        public ExcepcionesPersonalizadas(string message) : base(message) { }
        public ExcepcionesPersonalizadas(string message, Exception inner) : base(message, inner) { }
        
    }
}
