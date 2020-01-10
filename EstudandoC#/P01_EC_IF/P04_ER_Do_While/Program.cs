using System;

namespace P04_ER_Do_While
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repetir = false;

            while (repetir)
            {
                Console.WriteLine("Entrou no \"Flúxo\" do 'While'");
            }

            do
            {
                Console.WriteLine("Entrou no \"Flúxo\" do 'Do While'");
            } while (repetir);

            Console.ReadKey();
        }
    }
}
