using EFCapaDatos;
using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaLogica
{
    public class LogicaProveedores : LogicaBase, ILogica_ABM<Suppliers>
    {
        public void Actualizar(Suppliers elemento)
        {
            try
            {
                Suppliers proveedorActualizar = context.Suppliers.Find(elemento.SupplierID);
                if (proveedorActualizar == null)
                {
                    throw new ExcepcionPersonalizadaMVC("No se encontro el proveedor a actualizar ", "Actualizar(" + elemento.SupplierID + ")");
                }
                else
                {
                    proveedorActualizar.CompanyName = elemento.CompanyName;
                    proveedorActualizar.ContactName = elemento.ContactName;
                    context.SaveChanges();
                 
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "Actualizar(" + elemento.SupplierID + ")");
            }
        }

        public void Agregar(Suppliers elemento)
        {
            elemento.SupplierID = OtenerProximoId();
            try
            {
                context.Suppliers.Add(elemento);
                context.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "Agregar(" + elemento.SupplierID + ")");
            }
        }

        public void Borrar(int id)
        {
            try
            {
                Suppliers proveedorEliminar = context.Suppliers.Find(id);
                if (proveedorEliminar == null)
                {
                    throw new ExcepcionPersonalizadaMVC("No se encontro el proveedor a eliminar ", "Borrar(" + id + ")");
                }
                else
                {
                    context.Suppliers.Remove(proveedorEliminar);
                    context.SaveChanges();
                    
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "Borrar(" + id + ")");
            }
        }

        public List<Suppliers> ObtenerTodos()
        {

            try
            {
                return context.Suppliers.ToList();
            }
            catch (Exception e)
            {

                throw new ExcepcionPersonalizadaMVC(e.Message, "ObtenerTodos()");
            }            
        }

        public int OtenerProximoId()
        {
            Suppliers obtenerMaxID = context.Suppliers.OrderByDescending(p => p.SupplierID).FirstOrDefault();
            if (obtenerMaxID != null)
            {
                return obtenerMaxID.SupplierID + 1;
            }
            else
            {
                return 1;
            }
        }

        public List<Suppliers> EncontrarProveedoresPorNombre(String proveedor)
        {
            return context.Suppliers.Where(p => p.CompanyName.Contains(proveedor)).ToList();
        }
    }
}
