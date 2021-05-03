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
        public bool Actualizar(Suppliers elemento)
        {
            try
            {
                Suppliers proveedorActualizar = context.Suppliers.Find(elemento.SupplierID);
                if (proveedorActualizar == null)
                {
                    return false;
                }
                else
                {
                    proveedorActualizar.CompanyName = elemento.CompanyName;
                    proveedorActualizar.ContactName = elemento.ContactName;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Agregar(Suppliers elemento)
        {
            elemento.SupplierID = OtenerProximoId();
            try
            {
                context.Suppliers.Add(elemento);
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
                Suppliers proveedorEliminar = context.Suppliers.Find(id);
                if (proveedorEliminar == null)
                {
                    return false;
                }
                else
                {
                    context.Suppliers.Remove(proveedorEliminar);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Suppliers> ObtenerTodos()
        {
            return context.Suppliers.ToList();
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
