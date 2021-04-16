using System;
using System.Collections.Generic;
using System.Text;

namespace Ej1POO_ProyectoConsolaVehiculos
{
    class Automovil : Transporte
    {
        //Implementación métodos públicos de la clase abstracta
        public override void Avanzar()
        {
            Console.WriteLine("Implementación método avanzar en auto.");
        }

        //Implementación métodos públicos de la clase abstracta

        public override void Detenerse()
        {
            Console.WriteLine("Implementación método detenerse en auto.");
        }

        //Implementación métodos públicos de la clase abstracta
        public override bool SuperaLimitePasajeros(int numeroPasajeros)
        {
            return numeroPasajeros > 5;
        }
    }
}
