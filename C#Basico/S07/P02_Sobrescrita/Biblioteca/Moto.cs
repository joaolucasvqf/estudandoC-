using System;
using System.Collections.Generic;
using System.Text;

namespace P02_Heranca.Bibliotca
{
    class Moto : Veiculo
    {
        public int rodas = 4;

        public override void Mover()
        {
            Console.WriteLine("Mover chamado dentro de: Moto.mover");
        }
    }
}
