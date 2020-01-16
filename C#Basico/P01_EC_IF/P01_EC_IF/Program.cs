using System;

namespace P01_EC_IF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o valor que você possui em conta: ");
            float valorEmConta = float.Parse(Console.ReadLine());

            if (valorEmConta > 100000)
            {
                Console.WriteLine("Parabéns, você tá rico!");
            } else if (valorEmConta > 1000)
            {
                Console.WriteLine("Você é pobre!");
            } else
            {
                Console.WriteLine("Vixe, tá falido amigo!");
            }
            Console.ReadKey();
        }
    }
}
