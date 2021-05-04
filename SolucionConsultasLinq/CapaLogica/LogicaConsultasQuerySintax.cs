using CapaDatos;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogicaConsultasQuerySintax
    {

        public readonly NorthwindContext context;

        public LogicaConsultasQuerySintax()
        {
            context = new NorthwindContext();
        }

        //7
        public IQueryable CustomersOrdersWAFecha()
        {
            var consulta = from o in context.Orders
                           join c in context.Customers
                           on o.CustomerID equals c.CustomerID
                           where c.Region.Equals("WA") && o.OrderDate > new DateTime(1997, 1, 1)
                           select new
                           {
                               c.CompanyName,
                               c.Region,
                               o.OrderDate
                           };
            return consulta;
        }

        //8
        public List<Customers> CustomersWA()
        {
            var consulta = (from c in context.Customers
                            where c.Region.Equals("WA")
                            select c).Take(3);
            return consulta.ToList<Customers>();
        }

        //9
        public List<Products> ListaProductoOrdenadoNombre()
        {
            var consulta = from p in context.Products
                           orderby p.ProductName
                           select p;
            return consulta.ToList<Products>();
        }

        //10
        public List<Products> ListaProductoOrdenadoStock()
        {
            var consulta = from p in context.Products
                           orderby p.UnitsInStock descending
                           select p;
            return consulta.ToList<Products>();
        }

        //11
        public List<String> CategoriasDeProductos()
        {
            var consulta = (from p in context.Products
                            join c in context.Categories
                            on p.CategoryID equals c.CategoryID
                            select c.CategoryName).Distinct();
            return consulta.ToList<String>();
        }

        //12
        public Products PrimerProducto()
        {
            var consulta = (from p in context.Products
                            select p).Take(1).SingleOrDefault();
            return consulta;
        }

        //13
        public IQueryable CantidadOrdenesAsociadasCustomers()
        {
            var consulta = from o in context.Orders
                           join c in context.Customers
                           on o.CustomerID equals c.CustomerID
                           group o by o.CustomerID into g
                           select new
                           {
                               CompanyName = g.Key,
                               Total = g.Count()
                           };
            return consulta;
        }
    }
}