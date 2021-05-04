using CapaDatos;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogicaConsultasMethodSintax
    {
        public readonly NorthwindContext context;

        public LogicaConsultasMethodSintax()
        {
            context = new NorthwindContext();
        }

        //1
        public Customers EncontrarPorId(String id)
        {
            return context.Customers.SingleOrDefault(c => c.CustomerID.Equals(id));
        }
        //2
        public List<Products> EncontarProductosSinStock()
        {
            return context.Products.Where(p => p.UnitsInStock == 0).ToList();
        }
        //3
        public List<Products> EncontarProductosEnStockConPrecioSuperiorA3()
        {
            return context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).ToList();
        }
        //4
        public List<Customers> EncontrarCustomersDeWashington()
        {
            return context.Customers.Where(c => c.Region.Equals("WA")).ToList();
        }
        //5
        public Products EncontrarPrimerElementoONull()
        {
            return context.Products.Where(p => p.SupplierID == 789).FirstOrDefault();
        }
        //6
        public List<String> DevolverNombreCompaniaMayusculaMinuscula()
        {
            return context.Customers.Select(c => c.CompanyName.ToUpper() + " - " + c.CompanyName.ToLower()).ToList();
        }

    }
}
