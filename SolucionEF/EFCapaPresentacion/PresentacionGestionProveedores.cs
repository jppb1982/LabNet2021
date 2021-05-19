using EFCapaLogica;
using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCapaPresentacion
{
    public class PresentacionGestionProveedores
    {
        String nombre = "Empresa".PadRight(40);
        String contacto = "Nombre de contacto".PadRight(30);
        private readonly LogicaProveedores objLogicaProveedores = new LogicaProveedores();
        public void ListarProveedores(List<Suppliers> listaProveedores)
        {
            Console.Clear();
            Console.WriteLine("Listado de Proveedores:\n");
            Console.WriteLine($"\nID\t{nombre}\t{contacto}\tTeléfono\n");


            foreach (Suppliers proveedor in listaProveedores)
            {
                Console.WriteLine($"{proveedor.SupplierID}\t{proveedor.CompanyName.PadRight(40)}\t{(proveedor.ContactName == null ? "-" : proveedor.ContactName).PadRight(30)}\t{proveedor.Phone}");
            }

        }

        public void AltaProveedor()
        {
            //Ingreso de nombre del proveedor
            bool valorAceptadoProveedor;
            String cadenaIngresadaProveedor;
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del proveedor.");

            Suppliers elProveedor = new Suppliers();
            do
            {
                cadenaIngresadaProveedor = Console.ReadLine();
                valorAceptadoProveedor = cadenaIngresadaProveedor.LongitudValida(15);
                if (valorAceptadoProveedor == false)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese una cadena con un máximo de 15 caracteres.");
                }

            } while (valorAceptadoProveedor == false);

            elProveedor.CompanyName = cadenaIngresadaProveedor;

            //Se guarda la proveedor
            Console.Clear();
            try
            {
                objLogicaProveedores.Agregar(elProveedor);
                Console.WriteLine("El proveedor fue ingresado con éxito\n");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo ingresar la proveedor\n");
            }
            
        }

        public void EliminacionProveedor()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del Proveedor (puede ingresar cualquier parte del texto a buscar )");
            String ProveedorEliminar = Console.ReadLine();

            List<Suppliers> listaFiltradaProveedorEliminar = objLogicaProveedores.EncontrarProveedoresPorNombre(ProveedorEliminar);
            if (listaFiltradaProveedorEliminar != null)
            {

                ListarProveedores(listaFiltradaProveedorEliminar);
                Console.Write("Ingrese el 'ID' del Proveedor que desea eliminar: ");
                int idProveedorEliminar = HelperValidaciones.ObtenerValorEnteroValido();

                Console.Clear();
                try
                {
                    objLogicaProveedores.Borrar(idProveedorEliminar);
                    Console.WriteLine("El Proveedor fue eliminado con éxito");
                }
                catch (Exception)
                {
                    Console.WriteLine("No se pudo eliminar el Proveedor");
                }
                
            }
            else
            {
                Console.WriteLine("No se encontro ningún Proveedor.");
            }
        }




        public void ActualizacionProveedor()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del Proveedor (puede ingresar cualquier parte del texto a buscar )");
            String nombreProveedorActualizar = Console.ReadLine();

            List<Suppliers> listaFiltradaProveedorActualizar = objLogicaProveedores.EncontrarProveedoresPorNombre(nombreProveedorActualizar);
            if (listaFiltradaProveedorActualizar != null)
            {
                ListarProveedores(listaFiltradaProveedorActualizar);
                Console.Write("\n\nIngrese el 'ID' del Proveedor que desea actualizar: ");
                int idProveedorActualizar = HelperValidaciones.ObtenerValorEnteroValido();
                Suppliers ProveedorActualizar = listaFiltradaProveedorActualizar.SingleOrDefault(p => p.SupplierID == idProveedorActualizar);

                if (ProveedorActualizar == null)
                {
                    Console.Clear();
                    Console.WriteLine("El Proveedor no se encuentra.");
                }
                else
                {
                    //Cargar los valores a actualizar

                    //Ingreso nuevo nombre de Proveedor
                    bool valorAceptado;
                    String cadenaIngresada;

                    Console.Clear();
                    Console.Write("Ingrese el nuevo nombre del Proveedor: ");

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

                    ProveedorActualizar.CompanyName = cadenaIngresada;


                    //Ingreso nuevo contacto de Proveedor
                    Console.Clear();
                    Console.Write("Ingrese el nuevo contacto del Proveedor: ");

                    do
                    {
                        cadenaIngresada = Console.ReadLine();
                        valorAceptado = cadenaIngresada.LongitudValida(30);
                        if (valorAceptado == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Ingrese una cadena con un máximo de 30 caracteres.");
                        }

                    } while (valorAceptado == false);

                    ProveedorActualizar.ContactName = cadenaIngresada;



                    Console.Clear();

                    try
                    {
                        objLogicaProveedores.Actualizar(ProveedorActualizar);
                        Console.WriteLine("El Proveedor fue actualizado con éxito\n");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo actualizar el Proveedor\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontro ningún Proveedor.");
            }
        }
    }
}
