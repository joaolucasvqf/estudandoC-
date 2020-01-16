using System;

namespace P03_ER_While
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            Console.WriteLine("----------------------------------Loop 1----------------------------------");
            while (i < 10)
            {
                Console.WriteLine("Valor da variável: " + i);
                i++;
            }

            bool repetir = true;
            int j = 10;

            Console.WriteLine("----------------------------------Loop 2----------------------------------");
            while (repetir)
            {
                Console.WriteLine("Valor da variável: " + j);
                if (j < 1)
                {
                    Console.WriteLine("FIM!");
                    repetir = false;
                }
                j--;
            }

            Console.ReadKey();
        }
    }
}
