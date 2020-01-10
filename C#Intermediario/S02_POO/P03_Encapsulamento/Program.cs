using System;

namespace P03_Encapsulamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.SetNome("João Lucas");
            Console.WriteLine(pessoa.GetNome());
        }
    }
}
