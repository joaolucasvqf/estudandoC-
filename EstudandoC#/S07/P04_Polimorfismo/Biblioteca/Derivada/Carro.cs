using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Polimorfismo.Biblioteca.Derivada
{
    class Carro : Veiculo
    {
        public override void Mover()
        {
            Console.WriteLine("Carro se movendo!!!");
        }
    }
}
