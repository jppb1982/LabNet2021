using EFCapaLogica;
using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaPresentacion
{
    public class PresentacionGestionCategorias
    {
        private readonly LogicaCategorias objLogicaCategoria = new LogicaCategorias();
        public void ListarCategorias(List<Categories> listaCategoria)
        {
            Console.Clear();
            Console.WriteLine("Listado de Categorias:\n");
            Console.WriteLine($"\nID\tNombre\t\t\t\tDescripción");
            
            foreach (Categories categoria in listaCategoria)
            {
                Console.WriteLine($"{categoria.CategoryID}\t{categoria.CategoryName}\t\t\t\t{categoria.Description}");
            }
            Console.ReadLine();
        }

        public void AltaCategoria()
        {
            //Ingreso de nombre de categoría
            bool valorAceptadoCategoria;
            String cadenaIngresadaCategoria;
            Console.Clear();
            Console.WriteLine("Ingrese el nombre de la categoría.");

            Categories laCategoria = new Categories();
            do
            {
                cadenaIngresadaCategoria = Console.ReadLine();
                valorAceptadoCategoria = cadenaIngresadaCategoria.LongitudValida(15);
                if (valorAceptadoCategoria == false)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese una cadena con un máximo de 15 caracteres.");
                }

            } while (valorAceptadoCategoria == false);

            laCategoria.CategoryName = cadenaIngresadaCategoria;

            //Se guarda la categoría
            Console.Clear();
            if (objLogicaCategoria.Agregar(laCategoria))
            {
                Console.WriteLine("La categoría fue ingresada con éxito\n");
            }
            else
            {
                Console.WriteLine("No se pudo ingresar la categoría\n");
            }
        }

        public void EliminacionCategoria()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del Categoria (Puede ingresar las primeras letras solamente)");
            String CategoriaEliminar = Console.ReadLine();

            List<Categories> listaFiltradaCategoriaEliminar = objLogicaCategoria.EncontrarCategoriaPorNombre(CategoriaEliminar);
            if (listaFiltradaCategoriaEliminar != null)
            {

                ListarCategorias(listaFiltradaCategoriaEliminar);
                Console.Write("Ingrese el 'ID' de la Categoria que desea eliminar: ");
                int idCategoriaEliminar = HelperValidaciones.ObtenerValorEnteroValido();

                if (objLogicaCategoria.Borrar(idCategoriaEliminar))
                {
                    Console.WriteLine("El Categoria fue eliminado con éxito\n");
                }
                else
                {
                    Console.WriteLine("No se pudo eliminar el Categoria\n");
                }

            }
            else
            {
                Console.WriteLine("No se encontro ningún Categoria.");
            }
        }
    }
}
