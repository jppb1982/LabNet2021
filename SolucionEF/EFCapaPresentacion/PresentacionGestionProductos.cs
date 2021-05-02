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
        LogicaProductos objLogicaProducto = new LogicaProductos();
        public void ListarProductos(List<Products> listaProductos)
        {
            Console.Clear();
            Console.WriteLine("Listado de Productos:\n");
            Console.WriteLine($"\nId\tNombre\t\t\t\t\tPresentación\t\t\t\tPrecio\n");

            foreach (Products producto in listaProductos)
            {
                Console.WriteLine($"{producto.ProductID}\t{producto.ProductName}\t\t\t\t{producto.QuantityPerUnit}\t\t\t\t{producto.UnitPrice}");
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
            if (objLogicaProducto.Agregar(elProducto))
            {
                Console.WriteLine("El producto fue ingresado con éxito\n");
            }
            else
            {
                Console.WriteLine("No se pudo ingresar el producto\n");
            }
        }

        public void EliminacionProducto()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del producto (Puede ingresar las primeras letras solamente)");
            String productoEliminar = Console.ReadLine();

            List<Products> listaFiltradaProductoEliminar = objLogicaProducto.EncontrarProductoPorNombre(productoEliminar);
            if (listaFiltradaProductoEliminar != null)
            {

                ListarProductos(listaFiltradaProductoEliminar);
                Console.Write("Ingrese el 'ID' del producto que desea eliminar: ");
                int idProductoEliminar = HelperValidaciones.ObtenerValorEnteroValido();

                if (objLogicaProducto.Borrar(idProductoEliminar))
                {
                    Console.WriteLine("El producto fue eliminado con éxito\n");
                }
                else
                {
                    Console.WriteLine("No se pudo eliminar el producto\n");
                }

            }
            else
            {
                Console.WriteLine("No se encontro ningún producto.");
            }
        }
    }

}

