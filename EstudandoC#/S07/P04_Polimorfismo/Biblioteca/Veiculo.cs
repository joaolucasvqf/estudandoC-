using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Polimorfismo.Biblioteca
{
    class Veiculo
    {
        public string marca, modelo, ano;

        public virtual void Mover()
        {
            Console.WriteLine("Veículo se movendo!!!");
        }
    }
}
