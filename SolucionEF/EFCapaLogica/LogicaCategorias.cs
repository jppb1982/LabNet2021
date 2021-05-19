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
        public void Actualizar(Categories elemento)
        {
            try
            {
                Categories categoriaActualizar = context.Categories.Find(elemento.CategoryID);
                if (categoriaActualizar == null)
                {
                    throw new ExcepcionPersonalizadaMVC("No se encontro la categoría a actualizar ", "Actualizar(" + elemento.CategoryID + ")");
                }
                else
                {
                    categoriaActualizar.CategoryName = elemento.CategoryName;
                    categoriaActualizar.Description = elemento.Description;
                    context.SaveChanges();

                }
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "Actualizar(" + elemento.CategoryID + ")");
            }
        }

        public void Agregar(Categories elemento)
        {
            elemento.CategoryID = OtenerProximoId();
            try
            {
                context.Categories.Add(elemento);
                context.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "Agregar(" + elemento.CategoryID + ")");
            }
        }

        public void Borrar(int id)
        {

            try
            {
                Categories categoriaEliminar = context.Categories.Find(id);
                if (categoriaEliminar == null)
                {
                    throw new ExcepcionPersonalizadaMVC("No se encontro la categoría a eliminar ", "Borrar(" + id + ")");
                }
                else
                {
                    context.Categories.Remove(categoriaEliminar);
                    context.SaveChanges();

                }
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "Borrar(" + id + ")");
            }

        }

        public List<Categories> ObtenerTodos()
        {
            try
            {
                return context.Categories.ToList();
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC(e.Message, "ObtenerTodos()");
            }

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
