using EFCapaDatos;
using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaLogica
{
    public class LogicaProductos : LogicaBase, ILogica_ABM<Products>
    {
        public bool Actualizar(Products elemento)
        {
            try
            {
                Products productoActualizar = context.Products.Find(elemento.ProductID);
                if (productoActualizar == null)
                {
                    return false;
                }
                else
                {
                    productoActualizar.ProductName = elemento.ProductName;
                    productoActualizar.QuantityPerUnit = elemento.QuantityPerUnit;
                    productoActualizar.UnitPrice = elemento.UnitPrice;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Agregar(Products elemento)
        {
            elemento.ProductID = OtenerProximoId();
            try
            {
                context.Products.Add(elemento);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Borrar(int id)
        {
            try
            {
                Products productoEliminar = context.Products.Find(id);
                if (productoEliminar == null)
                {
                    return false;
                }
                else
                {
                    context.Products.Remove(productoEliminar);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Products> ObtenerTodos()
        {
            return context.Products.ToList();
        }

        public int OtenerProximoId()
        {
            Products obtenerMaxID = context.Products.OrderByDescending(p => p.ProductID).FirstOrDefault();
            if (obtenerMaxID != null)
            {
                return obtenerMaxID.ProductID + 1;
            }
            else
            {
                return 1;
            }
        }

        public List<Products> EncontrarProductoPorNombre(String producto)
        {
            return context.Products.Where(p => p.ProductName.Contains(producto)).ToList();
        }
    }
}
