using System;
using System.Collections.Generic;
using System.Text;

namespace Ej1POO_ProyectoConsolaVehiculos
{
    //Concepto aplicado: Clase abstracta
    public abstract class Transporte : IValidacónTransporte
    {
        //Concepto aplicado: variable privada
        private int pasajeros;

        //Concepto aplicado: properties publicas (variables)
        public int Pasajeros {
            get { return pasajeros; }
            set { pasajeros = value; } 
        }

        //Concepto aplicado: métodos publicos abstractos
        public abstract void Avanzar();

        public abstract void Detenerse();

        //Implementación de interface
        public abstract bool SuperaLimitePasajeros(int numeroPasajeros);
        
    }
}
