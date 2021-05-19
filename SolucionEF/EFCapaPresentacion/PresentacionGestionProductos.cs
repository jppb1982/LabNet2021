using EFCapaLogica;
using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaPresentacion
{
    public class PresentacionGestionProductos
    {
        private readonly LogicaProductos objLogicaProducto = new LogicaProductos();
        public void ListarProductos(List<Products> listaProductos)
        {
            String nombre = "Nombre".PadRight(40);
            String presentacion = "Presentación".PadRight(20);
            Console.Clear();
            Console.WriteLine("Listado de Productos:\n");


            Console.WriteLine($"\nId\t{nombre}\t{presentacion}\tPrecio\n");

            foreach (Products producto in listaProductos)
            {
                Console.WriteLine($"{producto.ProductID}\t{(producto.ProductName == null ? "-" : producto.ProductName).PadRight(40)}\t{(producto.QuantityPerUnit == null ? "-" : producto.QuantityPerUnit).PadRight(20)}\t{producto.UnitPrice}");
            }


        }
        public void AltaProducto()
        {
            //Ingreso de nombre de producto
            bool valorAceptado;
            String cadenaIngresada;
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del producto.");

            Products elProducto = new Products();
            do
            {
                cadenaIngresada = Console.ReadLine();
                valorAceptado = cadenaIngresada.LongitudValida(40);
                if (valorAceptado == false)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese una cadena con un máximo de 40 caracteres.");
                }

            } while (valorAceptado == false);

            elProducto.ProductName = cadenaIngresada;

            //Ingreso de precio unitario
            Console.Clear();
            Console.WriteLine("Ingrese el precio del producto.");

            elProducto.UnitPrice = HelperValidaciones.ObtenerValorDecimalValido();


            //Se guarda el producto

            Console.Clear();
            try
            {
                objLogicaProducto.Agregar(elProducto);
                Console.WriteLine("El producto fue ingresado con éxito\n");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo ingresar el producto\n");

            }
        }

        public void EliminacionProducto()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del producto (puede ingresar cualquier parte del texto a buscar )");
            String productoEliminar = Console.ReadLine();

            List<Products> listaFiltradaProductoEliminar = objLogicaProducto.EncontrarProductoPorNombre(productoEliminar);
            if (listaFiltradaProductoEliminar != null)
            {

                ListarProductos(listaFiltradaProductoEliminar);
                Console.Write("\n\nIngrese el 'ID' del producto que desea eliminar: ");
                int idProductoEliminar = HelperValidaciones.ObtenerValorEnteroValido();

                Console.Clear();

                try
                {
                    objLogicaProducto.Borrar(idProductoEliminar);
                    Console.WriteLine("El producto fue eliminado con éxito.");
                }
                catch (Exception)
                {

                    Console.WriteLine("No se pudo eliminar el producto");
                }
            }
            else
            {
                Console.WriteLine("No se encontro ningún producto.");
            }
        }

        public void ActualizacionProducto()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del producto (puede ingresar cualquier parte del texto a buscar )");
            String nombreProductoActualizar = Console.ReadLine();

            List<Products> listaFiltradaProductoActualizar = objLogicaProducto.EncontrarProductoPorNombre(nombreProductoActualizar);
            if (listaFiltradaProductoActualizar != null)
            {
                ListarProductos(listaFiltradaProductoActualizar);
                Console.Write("\n\nIngrese el 'ID' del producto que desea actualizar: ");
                int idProductoActualizar = HelperValidaciones.ObtenerValorEnteroValido();
                Products productoActualizar = listaFiltradaProductoActualizar.SingleOrDefault(p => p.ProductID == idProductoActualizar);

                if (productoActualizar == null)
                {
                    Console.Clear();
                    Console.WriteLine("El producto no se encuentra.");
                }
                else
                {
                    //Cargar los valores a actualizar

                    //Ingreso nuevo nombre de producto
                    bool valorAceptado;
                    String cadenaIngresada;

                    Console.Clear();
                    Console.Write("Ingrese el nuevo nombre del producto: ");

                    do
                    {
                        cadenaIngresada = Console.ReadLine();
                        valorAceptado = cadenaIngresada.LongitudValida(40);
                        if (valorAceptado == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Ingrese una cadena con un máximo de 40 caracteres.");
                        }

                    } while (valorAceptado == false);

                    productoActualizar.ProductName = cadenaIngresada;


                    //Ingreso nueva presentación de producto
                    Console.Clear();
                    Console.Write("Ingrese la nueva presentación del producto: ");

                    do
                    {
                        cadenaIngresada = Console.ReadLine();
                        valorAceptado = cadenaIngresada.LongitudValida(20);
                        if (valorAceptado == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Ingrese una cadena con un máximo de 20 caracteres.");
                        }

                    } while (valorAceptado == false);

                    productoActualizar.QuantityPerUnit = cadenaIngresada;


                    //Ingreso nuevo precio de producto
                    Console.Clear();
                    Console.WriteLine("Ingrese el nuevo precio del producto.");

                    productoActualizar.UnitPrice = HelperValidaciones.ObtenerValorDecimalValido();

                    Console.Clear();

                    try
                    {
                        objLogicaProducto.Actualizar(productoActualizar);
                        Console.WriteLine("El producto fue actualizado con éxito\n");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo actualizar el producto\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontro ningún producto.");
            }
        }


    }

}

