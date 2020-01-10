using System;

namespace P04_AutoImplement
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.nome = "João Lucas";
            Console.WriteLine(pessoa.nome);
        }
    }
}
