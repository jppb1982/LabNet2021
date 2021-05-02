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
        public void ListarProveedores()
        {
            Console.Clear();
            Console.WriteLine("Listado de Proveedores:\n");
            Console.WriteLine($"\nEmpresa\t\t\t\tNombre de contacto\t\t\t\tTeléfono");
            LogicaProveedores logicaProveedores = new LogicaProveedores();

            foreach (Suppliers proveedor in logicaProveedores.ObtenerTodos())
            {
                Console.WriteLine($"{proveedor.CompanyName}\t\t\t\t{proveedor.ContactName}\t\t\t\t{proveedor.Phone}");
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
            LogicaProveedores objLogicaProveedor = new LogicaProveedores();
            Console.Clear();
            if (objLogicaProveedor.Agregar(elProveedor))
            {
                Console.WriteLine("El proveedor fue ingresado con éxito\n");
            }
            else
            {
                Console.WriteLine("No se pudo ingresar la proveedor\n");
            }
        }

    }
}
