using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFMVC.Models
{
    public class ProductoView
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String CantidadPorUnidad { get; set; }
        public Decimal PrecioUnitario { get; set; }

    }
}