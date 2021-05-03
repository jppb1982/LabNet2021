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
            String nombre = "Nombre".PadRight(15);
            Console.Clear();
            Console.WriteLine("Listado de Categorias:\n");
            Console.WriteLine($"\nID\t{nombre}\tDescripción\n");

            foreach (Categories categoria in listaCategoria)
            {
                Console.WriteLine($"{categoria.CategoryID}\t{categoria.CategoryName.PadRight(15)}\t{categoria.Description}");
            }
            
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
            Console.WriteLine("Ingrese el nombre del Categoria (puede ingresar cualquier parte del texto a buscar )");
            String CategoriaEliminar = Console.ReadLine();

            List<Categories> listaFiltradaCategoriaEliminar = objLogicaCategoria.EncontrarCategoriaPorNombre(CategoriaEliminar);
            if (listaFiltradaCategoriaEliminar != null)
            {

                ListarCategorias(listaFiltradaCategoriaEliminar);
                Console.Write("Ingrese el 'ID' de la Categoria que desea eliminar: ");
                int idCategoriaEliminar = HelperValidaciones.ObtenerValorEnteroValido();

                Console.Clear();
                if (objLogicaCategoria.Borrar(idCategoriaEliminar))
                {
                    Console.WriteLine("El Categoria fue eliminado con éxito");
                }
                else
                {
                    Console.WriteLine("No se pudo eliminar el Categoria");
                }

            }
            else
            {
                Console.WriteLine("No se encontro ningún Categoria.");
            }
        }

        public void ActualizacionCategoria()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre de la categoria (puede ingresar cualquier parte del texto a buscar )");
            String nombreCategoriaActualizar = Console.ReadLine();

            List<Categories> listaFiltradaCategoriaActualizar = objLogicaCategoria.EncontrarCategoriaPorNombre(nombreCategoriaActualizar);
            if (listaFiltradaCategoriaActualizar != null)
            {
                ListarCategorias(listaFiltradaCategoriaActualizar);
                Console.Write("\n\nIngrese el 'ID' de la Categoria que desea actualizar: ");
                int idCategoriaActualizar = HelperValidaciones.ObtenerValorEnteroValido();
                Categories CategoriaActualizar = listaFiltradaCategoriaActualizar.SingleOrDefault(c => c.CategoryID == idCategoriaActualizar);

                if (CategoriaActualizar == null)
                {
                    Console.Clear();
                    Console.WriteLine("El Categoria no se encuentra.");
                }
                else
                {
                    //Cargar los valores a actualizar

                    //Ingreso nuevo nombre de Categoria
                    bool valorAceptado;
                    String cadenaIngresada;

                    Console.Clear();
                    Console.Write("Ingrese el nuevo nombre de la Categoría: ");

                    do
                    {
                        cadenaIngresada = Console.ReadLine();
                        valorAceptado = cadenaIngresada.LongitudValida(15);
                        if (valorAceptado == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Ingrese una cadena con un máximo de 15 caracteres.");
                        }

                    } while (valorAceptado == false);

                    CategoriaActualizar.CategoryName = cadenaIngresada;


                    //Ingreso nueva descripción de Categoría
                    Console.Clear();
                    Console.Write("Ingrese la nueva descripción de la Categoría: ");

                    CategoriaActualizar.Description = Console.ReadLine();



                    Console.Clear();
                    if (objLogicaCategoria.Actualizar(CategoriaActualizar))
                    {
                        Console.WriteLine("La Categoría fue actualizada con éxito\n");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo actualizar la Categoría\n");
                    }
                }

            }
            else
            {
                Console.WriteLine("No se encontro ningún Categoría.");
            }
        }

    }
}
