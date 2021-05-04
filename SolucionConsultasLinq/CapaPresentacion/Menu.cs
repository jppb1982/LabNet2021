using CapaLogica;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    public class Menu
    {
        LogicaConsultasMethodSintax objLogicaConsultasMethodSintax = new LogicaConsultasMethodSintax();
        LogicaConsultasQuerySintax objLogicaConsultasQuerySintax = new LogicaConsultasQuerySintax();
        public void DesplegarMenu()
        {
            StringBuilder presentacionMenu = new StringBuilder();
            presentacionMenu.AppendLine("Seleccione con (1-13) el ejercicio que desea probar, o elija 0 para salir\n");
            presentacionMenu.AppendLine("\t1. Query para devolver objeto customer");
            presentacionMenu.AppendLine("\t2. Query para devolver todos los productos sin stock");
            presentacionMenu.AppendLine("\t3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
            presentacionMenu.AppendLine("\t4. Query para devolver todos los customers de Washington");
            presentacionMenu.AppendLine("\t5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            presentacionMenu.AppendLine("\t6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
            presentacionMenu.AppendLine("\t7. Query para devolver Join entre Customers y Orders donde los customers sean de Washington y la fecha de orden sea mayor a 1/1/1997.");
            presentacionMenu.AppendLine("\t8. Query para devolver los primeros 3 Customers de Washington");
            presentacionMenu.AppendLine("\t9. Query para devolver lista de productos ordenados por nombre");
            presentacionMenu.AppendLine("\t10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.");
            presentacionMenu.AppendLine("\t11. Query para devolver las distintas categorías asociadas a los productos");
            presentacionMenu.AppendLine("\t12. Query para devolver el primer elemento de una lista de productos");
            presentacionMenu.AppendLine("\t13. Query para devolver los customer con la cantidad de ordenes asociadas");
            presentacionMenu.AppendLine("\t0. Salir.\n");
            Console.WriteLine(presentacionMenu.ToString());

            SeleccionarOpcion();
        }

        private void SeleccionarOpcion()
        {
            bool pudoParsear;
            int valor = 0;

            do
            {
                pudoParsear = int.TryParse(Console.ReadLine(), out int value);
                if (!pudoParsear)
                {
                    Console.WriteLine("\nHa ingresado un valor incorrecto. Debe ingresar un número entero. Intente nuevamente.\n");
                }
                else
                {
                    valor = value;
                }
            } while (pudoParsear == false);

            switch (valor)
            {
                case 1:
                    Console.Clear();
                    Customers c = objLogicaConsultasMethodSintax.EncontrarPorId("ANTON");
                    if (c == null)
                    {
                        Console.WriteLine("No se encontró el Customers con ID ANTON.");
                    }
                    else
                    {
                        Console.WriteLine($"Customer con ID ANTON encontrado: Nombre = {c.CompanyName}");
                    }
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine($"Productos sin stock:\n");
                    foreach (Products pss in objLogicaConsultasMethodSintax.EncontarProductosSinStock())
                    {
                        Console.WriteLine(pss.ProductName);
                    }
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Productos en stock con precio superior a 3\n");
                    foreach (Products pes in objLogicaConsultasMethodSintax.EncontarProductosEnStockConPrecioSuperiorA3())
                    {
                        Console.WriteLine(pes.ProductName);
                    }
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Customers de WA.\n");
                    foreach (Customers cus in objLogicaConsultasMethodSintax.EncontrarCustomersDeWashington())
                    {
                        Console.WriteLine(cus.CompanyName);
                    }
                    break;

                case 5:
                    Console.Clear();
                    Products p = objLogicaConsultasMethodSintax.EncontrarPrimerElementoONull();
                    if (p == null)
                    {
                        Console.WriteLine("No hay productos cargados con ID 789.");
                    }
                    else
                    {
                        Console.WriteLine($"Primer producto encontrado: Nombre = {p.ProductName}");
                    }
                    break;

                case 6:
                    Console.Clear();
                    Console.WriteLine("Nombres de compañias en mayúsculas y minúsculas.\n");
                    foreach (String item in objLogicaConsultasMethodSintax.DevolverNombreCompaniaMayusculaMinuscula())
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 7:
                    Console.Clear();
                    Console.WriteLine("Customers de WA con órdenes posteriores a 01/01/1997\n");
                    foreach (var item in objLogicaConsultasQuerySintax.CustomersOrdersWAFecha())
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 8:
                    Console.Clear();
                    Console.WriteLine("Primeros 3 Customers de WA\n");
                    foreach (Customers cus in objLogicaConsultasQuerySintax.CustomersWA())
                    {
                        Console.WriteLine(cus.CompanyName);
                    }
                    break;

                case 9:
                    Console.Clear();
                    Console.WriteLine("Lista de producto ordenado por nombre\n");
                    foreach (Products prod in objLogicaConsultasQuerySintax.ListaProductoOrdenadoNombre())
                    {
                        Console.WriteLine(prod.ProductName);
                    }
                    break;

                case 10:
                    Console.Clear();
                    Console.WriteLine("Lista de productos ordenados por stock\n");
                    foreach (Products pos in objLogicaConsultasQuerySintax.ListaProductoOrdenadoStock())
                    {
                        Console.WriteLine(pos.ProductName);
                    }
                    break;

                case 11:
                    Console.Clear();
                    Console.WriteLine("Categorias de productos\n");
                    foreach (String cat in objLogicaConsultasQuerySintax.CategoriasDeProductos())
                    {
                        Console.WriteLine(cat);
                    }
                    break;

                case 12:
                    Console.Clear();
                    Products primerProducto = objLogicaConsultasQuerySintax.PrimerProducto();
                    if (primerProducto == null)
                    {
                        Console.WriteLine("No hay productos cargados");
                    }
                    else
                    {
                        Console.WriteLine($"Primer producto encontrado: Nombre = {primerProducto.ProductName}");
                    }
                    break;

                case 13:
                    Console.Clear();
                    Console.WriteLine("Cantidad de ordenes por customer\n");
                    foreach (var item in objLogicaConsultasQuerySintax.CantidadOrdenesAsociadasCustomers())
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 0:
                    Salir();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Elija entre una de las opciones presentes.");
                    DesplegarMenu();
                    break;
            }
            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            DesplegarMenu();
        }

        private void Salir()
        {
            Environment.Exit(0);
        }
    }
}
