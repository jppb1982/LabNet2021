using System;
using System.Collections.Generic;

namespace Ej1POO_ProyectoConsolaVehiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("A continuación deberá ingresar la cantidad de pasajeros para 5 aviones");
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("**********************************************************************");

            Console.WriteLine("");
            CargaPasajeros();

        }

        private static void CargaPasajeros()
        {

            List<Transporte> listaTransportes = new List<Transporte>();
            
            for (int i = 1; i <= 10; i++)
            {
                Transporte elTransporte;
                if(i < 6)
                {
                    Avion elAvion = new Avion();
                    elTransporte = elAvion;
                }
                else
                {
                    Automovil elAuto = new Automovil();
                    elTransporte = elAuto;
                }
                
                int cantidadPasajeros = 0;
                Console.WriteLine("Ingrese el número de pasajeros del " + (elTransporte is Avion ? "avión" : "auto" ));
                do
                {
                    string ingreso = Console.ReadLine();

                    if (int.TryParse(ingreso, out cantidadPasajeros))
                    {
                        elTransporte.Pasajeros = cantidadPasajeros;
                        listaTransportes.Add(elTransporte);
                        
                    }
                    else
                    {
                        Console.WriteLine("Error. Vuelva a intentarlo.");
                    }

                } while (cantidadPasajeros == 0);
            }
        }
    }
}
