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
        private readonly LogicaProveedores objLogicaProveedores = new LogicaProveedores();
        public void ListarProveedores(List<Suppliers> listaProveedores)
        {
            Console.Clear();
            Console.WriteLine("Listado de Proveedores:\n");
            Console.WriteLine($"\nID\tEmpresa\t\t\t\tNombre de contacto\t\t\t\tTeléfono");
            

            foreach (Suppliers proveedor in listaProveedores)
            {
                Console.WriteLine($"{proveedor.SupplierID}\t{proveedor.CompanyName}\t\t\t\t{proveedor.ContactName}\t\t\t\t{proveedor.Phone}");
            }
            Console.ReadLine();
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
            if (objLogicaProveedores.Agregar(elProveedor))
            {
                Console.WriteLine("El proveedor fue ingresado con éxito\n");
            }
            else
            {
                Console.WriteLine("No se pudo ingresar la proveedor\n");
            }
        }

        public void EliminacionProveedor()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del Proveedor (Puede ingresar las primeras letras solamente)");
            String ProveedorEliminar = Console.ReadLine();

            List<Suppliers> listaFiltradaProveedorEliminar = objLogicaProveedores.EncontrarProveedoresPorNombre(ProveedorEliminar);
            if (listaFiltradaProveedorEliminar != null)
            {

                ListarProveedores(listaFiltradaProveedorEliminar);
                Console.Write("Ingrese el 'ID' del Proveedor que desea eliminar: ");
                int idProveedorEliminar = HelperValidaciones.ObtenerValorEnteroValido();

                if (objLogicaProveedores.Borrar(idProveedorEliminar))
                {
                    Console.WriteLine("El Proveedor fue eliminado con éxito\n");
                }
                else
                {
                    Console.WriteLine("No se pudo eliminar el Proveedor\n");
                }

            }
            else
            {
                Console.WriteLine("No se encontro ningún Proveedor.");
            }
        }

    }
}
