using EFCapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaLogica
{
    public abstract class LogicaBase
    {
        protected readonly NorthwindContext context;
        public LogicaBase()
        {
            context = new NorthwindContext();
        }
    }
}
