using System;
using System.Collections.Generic;
using System.Text;

namespace Ej1POO_ProyectoConsolaVehiculos
{
    class Avion : Transporte
    {

        //Implementación métodos públicos de la clase abstracta
        public override void Avanzar()
        {
            Console.WriteLine("Implementación método avanzar en avión.");
        }

        //Implementación métodos públicos de la clase abstracta
        public override void Detenerse()
        {
            Console.WriteLine("Implementación método detener en avión.");
        }

        //Implementación métodos públicos de la clase abstracta
        public override bool SuperaLimitePasajeros(int numeroPasajeros)
        {
            return numeroPasajeros > 170;
        }
    }
}
