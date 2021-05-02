using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFEntities;
using EFCapaLogica;

namespace EFCapaPresentacion
{
    class GestionMenu
    {
        PresentacionGestionCategorias abmPresentacionCategorias = new PresentacionGestionCategorias();
        PresentacionGestionProductos abmPresentacionProductos = new PresentacionGestionProductos();
        PresentacionGestionProveedores abmPresentacionProveedores = new PresentacionGestionProveedores();

        public void DesplegarMenu()
        {
            StringBuilder presentacionMenu = new StringBuilder();
            presentacionMenu.AppendLine("Seleccione con (1-2) para lo que desea realizar, o elija 0 para salir");
            presentacionMenu.AppendLine("\n\t1. Listados.");
            presentacionMenu.AppendLine("\t2. Gestión.");
            presentacionMenu.AppendLine("\t0. Salir.\n");
            Console.WriteLine(presentacionMenu.ToString());

            SeleccionarOpcion();
        }

        private void SeleccionarOpcion()
        {
            int seleccion = HelperValidaciones.ObtenerValorEnteroValido();

            switch (seleccion)
            {
                case 1:
                case 2:
                    Console.Clear();
                    LlamarSubMenu(seleccion);
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
        }

        private static void Salir()
        {
            Environment.Exit(0);
        }

        private void LlamarSubMenu(int eleccion)
        {

            String encabezado = (eleccion == 1) ? "Elija (1-3) para visualizar su reporte" : "Elija (1-3) para realizar sus tareas de gestión";

            StringBuilder presentacionMenu = new StringBuilder();
            presentacionMenu.AppendLine($"{encabezado}, o elija 0 para volver");
            presentacionMenu.AppendLine("\n\t1. Productos.");
            presentacionMenu.AppendLine("\t2. Categorias.");
            presentacionMenu.AppendLine("\t3. Proveedores.");
            presentacionMenu.AppendLine("\t0. Volver.\n");
            Console.WriteLine(presentacionMenu.ToString());

            SeleccionSubMenu(eleccion);
        }

        private void SeleccionSubMenu(int eleccionMenuPrincipal)
        {
            int seleccionSubMenu = HelperValidaciones.ObtenerValorEnteroValido();
            LogicaProductos objLogicaProducto = new LogicaProductos();
            LogicaCategorias objLogicaCategoria = new LogicaCategorias();

            switch (seleccionSubMenu)
            {
                case 1:

                    if (eleccionMenuPrincipal == 1)
                    {
                        abmPresentacionProductos.ListarProductos(objLogicaProducto.ObtenerTodos());
                    }
                    else
                    {
                        SubMenuABM(seleccionSubMenu);
                    }
                    break;
                case 2:
                    if (eleccionMenuPrincipal == 1)
                    {
                        abmPresentacionCategorias.ListarCategorias(objLogicaCategoria.ObtenerTodos());
                    }
                    else
                    {
                        SubMenuABM(seleccionSubMenu);
                    }
                    break;
                case 3:
                    if (eleccionMenuPrincipal == 1)
                    {
                        abmPresentacionProveedores.ListarProveedores();
                    }
                    else
                    {
                        SubMenuABM(seleccionSubMenu);
                    }
                    break;
                case 0:
                    Console.Clear();
                    DesplegarMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Elija entre una de las opciones presentes.");
                    LlamarSubMenu(eleccionMenuPrincipal);
                    break;
            }

            Console.WriteLine("\n\nPresione una tecla para volver al menú principal.");
            Console.ReadLine();
            Console.Clear();
            DesplegarMenu();
        }

        private void SubMenuABM(int seleccionSubMenu)
        {
            Console.Clear();
            StringBuilder presentacionSubMenuABM = new StringBuilder();
            presentacionSubMenuABM.AppendLine($"Elija (1-3) para la acción que desea realizar, o 0 para volver al Menú Principal");
            presentacionSubMenuABM.AppendLine("\n\t1. Agregar.");
            presentacionSubMenuABM.AppendLine("\t2. Eliminar.");
            presentacionSubMenuABM.AppendLine("\t3. Actualizar.");
            presentacionSubMenuABM.AppendLine("\t0. Volver al Menú Principal.\n");
            Console.WriteLine(presentacionSubMenuABM.ToString());

            SeleccionarOpcionSubMenuABM(seleccionSubMenu);
        }

        private void SeleccionarOpcionSubMenuABM(int seleccionSubMenuABM)
        {
            int seleccion = HelperValidaciones.ObtenerValorEnteroValido();

            switch (seleccion)
            {
                case 1: //Creación (Se solicitarán los valores requeridos por practicidad, excepto el ID que será calculado)
                    switch (seleccionSubMenuABM)
                    {
                        case 1: //Producto
                            abmPresentacionProductos.AltaProducto();
                            break;

                        case 2: //Categoría
                            abmPresentacionCategorias.AltaCategoria();
                            break;

                        case 3: //Proveedores
                            abmPresentacionProveedores.AltaProveedor();
                            break;
                    }
                    DesplegarMenu();
                    break;
                case 2: //Eliminación
                    switch (seleccionSubMenuABM)
                    {
                        case 1:
                            abmPresentacionProductos.EliminacionProducto();
                            break;
                        case 2:
                            abmPresentacionCategorias.EliminacionCategoria();
                            break;
                        case 3:
                            //
                            //abmPresentacionProveedores.EliminacionProveedor();
                            break;
                    }
                    break;
                case 3: //Actualización
                    switch (seleccionSubMenuABM)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
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
        }
    }
}
