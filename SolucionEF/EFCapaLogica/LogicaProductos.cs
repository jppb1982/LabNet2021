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
        public Products BuscarProductoPorId(int id)
        {
            Products producto;
            try
            {
                producto = context.Products.Find(id);
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "BuscarProductoPorId()");
            }
            return producto;

        }
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
            List<Products> productos;
            try
            {
                productos = context.Products.ToList();
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "ObtenerTodos()");
            }
            return productos;
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
