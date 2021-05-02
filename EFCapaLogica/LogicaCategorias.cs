using EFCapaDatos;
using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaLogica
{
    public class LogicaCategorias : LogicaBase, ILogica_ABM<Categories>
    {
        public bool Actualizar(Categories elemento)
        {
            try
            {
                Categories categoriaActualizar = context.Categories.Find(elemento.CategoryID);
                if (categoriaActualizar == null)
                {
                    return false;
                }
                else
                {
                    categoriaActualizar.CategoryName = elemento.CategoryName;
                    categoriaActualizar.Description = elemento.Description;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Agregar(Categories elemento)
        {
            elemento.CategoryID = OtenerProximoId();
            try
            {
                context.Categories.Add(elemento);
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
                Categories categoriaEliminar = context.Categories.Find(id);
                if (categoriaEliminar == null)
                {
                    return false;
                }
                else
                {
                    context.Categories.Remove(categoriaEliminar);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Categories> ObtenerTodos()
        {
            return context.Categories.ToList();
        }

        public int OtenerProximoId()
        {
            Categories obtenerMaxID = context.Categories.OrderByDescending(c => c.CategoryID).FirstOrDefault();
            if (obtenerMaxID != null)
            {
                return obtenerMaxID.CategoryID + 1;
            }
            else
            {
                return 1;
            }
        }

        public List<Categories> EncontrarCategoriaPorNombre(String categoria)
        {
            return context.Categories.Where(c => c.CategoryName.Contains(categoria)).ToList();
        }
    }
}
