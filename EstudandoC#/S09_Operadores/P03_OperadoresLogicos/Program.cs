using System;

namespace P03_OperadoresLogicos
{
    class Program
    {
        static void Main(string[] args)
        {
            string sexo = "M";
            int idade = 18;

            if (sexo == "M" & idade == 18)
            {
                Console.WriteLine("Deve se alistar");
            }

            if (10 == 10 & 10 > 9)
            {

            }

            if (10 == 10 | 10 == 9)
            {

            }

            if (10 == 10 && 10 > 9)
            {

            }

            if (10 == 10 || 10 == 9)
            {

            }
        }
    }
}
