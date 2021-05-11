using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWebApi.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public String Nombre { get; set; }

        public String CantidadPorUnidad { get; set; }

        public decimal? PrecioUnitario { get; set; }
    }
}