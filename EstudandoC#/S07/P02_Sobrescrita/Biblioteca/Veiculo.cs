using System;
using System.Collections.Generic;
using System.Text;

namespace P02_Heranca.Bibliotca
{
    class Veiculo
    {
        public string marca, modelo;
        public int qtdMaxPassageiros, ano;

        public virtual void Mover()
        {
            Console.WriteLine("Mover chamado dentro de: Veiculo.mover");
        }
    }
}
