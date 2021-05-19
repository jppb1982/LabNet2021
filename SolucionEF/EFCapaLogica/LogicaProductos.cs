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
        public void Actualizar(Products elemento)
        {
            try
            {
                Products productoActualizar = context.Products.Find(elemento.ProductID);
                if (productoActualizar == null)
                {
                    throw new ExcepcionPersonalizadaMVC("No se encontro el ID del producto a actualizar ", "Actualizar("+elemento.ProductID+")");
                }
                else
                {
                    productoActualizar.ProductName = elemento.ProductName;
                    productoActualizar.QuantityPerUnit = elemento.QuantityPerUnit;
                    productoActualizar.UnitPrice = elemento.UnitPrice;
                    context.SaveChanges();                   
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "Actualizar(" + elemento.ProductID + ")");
            }
        }

        public void Agregar(Products elemento)
        {
            elemento.ProductID = OtenerProximoId();
            try
            {
                context.Products.Add(elemento);
                context.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "Agregar(" + elemento.ProductID + ")");

            }
        }

        public void Borrar(int id)
        {
            try
            {
                Products productoEliminar = context.Products.Find(id);
                if (productoEliminar == null)
                {
                    throw new ExcepcionPersonalizadaMVC("No se encontro el producto a eliminar", "Borrar(" + id + ")");
                }
                else
                {
                    context.Products.Remove(productoEliminar);
                    context.SaveChanges();
                   
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "Borrar(" + id + ")");
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
