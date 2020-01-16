using System;

namespace P06_ER_ForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nomes = { "João", "Gildo", "Bárbara", "Larissinha", "Rúbia" };

            Console.WriteLine("----------------------------------Repetição com For----------------------------------");

            for (int i = 0; i < nomes.Length; i++)
            {
                Console.WriteLine("Nome: " + nomes[i]);
            }

            Console.WriteLine("--------------------------------Repetição com ForEach--------------------------------");

            foreach (string nome in nomes)
            {
                Console.WriteLine("Nome: " + nome);
            }

            Console.ReadKey();
        }
    }
}
