using System;
using System.Collections.Generic;
using System.Text;

namespace P02_Heranca.Bibliotca
{
    class Carro : Veiculo
    {
        public int rodas = 4;

        public void Mover()
        {
            Console.WriteLine("Mover chamado dentro de: Carro.mover");
        }
    }
}
