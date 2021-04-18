using Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaLogica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ej2POOProyectoConsolaExtMetExcepUnitTest.CapaPresentacion
{
    class MenuApp
    {
        public static void DesplegarMenu()
        {
            StringBuilder presentacionMenu = new StringBuilder();
            presentacionMenu.AppendLine("Seleccione con (1-4) la funcionalidad que desea probar, o elija 0 para salir");
            presentacionMenu.AppendLine("\n\t1. Dividir un número a su elección por cero.");
            presentacionMenu.AppendLine("\t2. Dividir dos números a su elección entre si.");
            presentacionMenu.AppendLine("\t3. Ejecutar Logic Method.");
            presentacionMenu.AppendLine("\t4. Excepción personalizada.");
            presentacionMenu.AppendLine("\t0. Salir.\n");
            Console.WriteLine(presentacionMenu.ToString());

            SeleccionarOpcion();
        }

        private static void SeleccionarOpcion()
        {
            try
            {
                int seleccion = int.Parse(Console.ReadLine());

                switch (seleccion)
                {
                    case 1:
                        Console.Clear();
                        DivisionDeNumeroUnicoPresentacion.ConsolaDivideNumero();
                        break;
                    case 2:
                        Console.Clear();
                        Dividir2NrosPresentacion.ConsolaDividir2Nros();
                        break;
                    case 3:
                        Console.Clear();
                        LogicPresentacion.ConsolaLogic();
                        break;
                    case 4:
                        Console.Clear();
                        //ExcepcionPersonalizada();
                        break;
                    case 0:
                        Salir();        //Ver si hay alguna otra opción de cómo salir
                        break;
                    default:
                        Console.WriteLine("Elija entre una de las opciones presentes.");
                        break;
                }
            }

            catch (FormatException formatExc)
            {
                Console.Clear();
                Console.WriteLine("Ingreso un caracter incorrecto.");
                Console.WriteLine(formatExc.Message);
                Console.WriteLine("Vuelva a intentarlo.\n" +
                    "***********************************************************************************");

            }
            catch (OverflowException overflowExc)
            {
                Console.Clear();
                Console.WriteLine("Ingreso un valor fuera de los parámetros esperados.");
                Console.WriteLine(overflowExc.Message);
                Console.WriteLine("Vuelva a intentarlo.\n" +
                    "***********************************************************************************");

            }
            finally
            {
                DesplegarMenu();
            }


        }

        private static void Salir()
        {

            Console.Clear();
            Console.WriteLine("¡Adios!\n\tPresione una tecla para salir");
            Environment.Exit(0);
        }
    }
}

