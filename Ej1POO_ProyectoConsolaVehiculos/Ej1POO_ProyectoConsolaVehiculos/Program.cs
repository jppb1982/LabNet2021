using System;
using System.Collections.Generic;

namespace Ej1POO_ProyectoConsolaVehiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t|| A continuación deberá ingresar la cantidad de pasajeros para 5 aviones y 5 automóviles. ||\n\n");

            //Concepto aplicado: Modularización
            CargaPasajeros();

            Console.WriteLine("");

            Transporte automovil = new Automovil();

            //Concepto aplicado: Herencia 
            automovil.Avanzar();
            automovil.Detenerse();

            Console.WriteLine("");

            Transporte avion = new Avion();

            //Concepto aplicado: Herencia
            avion.Avanzar();
            avion.Detenerse();
        }

        private static void CargaPasajeros()
        {

            List<Transporte> listaTransportes = new List<Transporte>();

            Transporte elTransporte;

            for (int i = 1; i <= 10; i++)
            {
                if (i < 6)
                {
                    Avion elAvion = new Avion();
                    elTransporte = elAvion;
                }
                else
                {
                    Automovil elAuto = new Automovil();
                    elTransporte = elAuto;
                }

                int cantidadPasajeros;

                Console.WriteLine("Ingrese el número de pasajeros del " + (elTransporte is Avion ? "avión Nº " + i : "auto Nº " + (i - 5)));

                do
                {
                    string ingreso = Console.ReadLine();

                    if (int.TryParse(ingreso, out cantidadPasajeros))
                    {
                        var superaLimite = (elTransporte is Avion ? (elTransporte as Avion).SuperaLimitePasajeros(cantidadPasajeros) : (elTransporte as Automovil).SuperaLimitePasajeros(cantidadPasajeros));

                        if (superaLimite || cantidadPasajeros <= 0)
                        {
                            Console.WriteLine("\n\t\t | Ingrese un valor correcto. Valores máximos aceptados: |\n\t\t | 170 pasajeros para aviones y 5 pasajeros automóviles. |\n");
                            if (cantidadPasajeros != 0)
                            {
                                i--;
                            }
                            else
                            {
                                Console.WriteLine("Ingrese el número de pasajeros del " + (elTransporte is Avion ? "avión Nº " + i : "auto Nº " + (i - 5)));
                            }
                        }
                        else
                        {
                            elTransporte.Pasajeros = cantidadPasajeros;

                            listaTransportes.Add(elTransporte);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\t\t | Ingrese un valor correcto. Valores máximos aceptados: |\n\t\t | 170 pasajeros para aviones y 5 pasajeros automóviles. |\n");
                        Console.WriteLine("Ingrese el número de pasajeros del " + (elTransporte is Avion ? "avión Nº " + i : "auto Nº " + (i - 5)));
                    }

                } while (cantidadPasajeros == 0);
            }

            Console.Clear();

            foreach (Transporte valor in listaTransportes)
            {
                if (listaTransportes.IndexOf(valor) < 5)
                {
                    Console.WriteLine("Avión " + (listaTransportes.IndexOf(valor) + 1) + ": " + valor.Pasajeros + " pasajeros");
                }
                else
                {
                    if (listaTransportes.IndexOf(valor) == 5)
                    {
                        Console.WriteLine("");
                    }

                    Console.WriteLine("Automóvil " + (listaTransportes.IndexOf(valor) - 4) + ": " + valor.Pasajeros + " pasajeros");

                }
            }
        }
    }
}
