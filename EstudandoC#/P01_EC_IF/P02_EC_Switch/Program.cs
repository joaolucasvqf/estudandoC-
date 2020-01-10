using System;

namespace P02_EC_Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe seu estado civil, sendo S para solteiro e C para casado:");
            string valor = Console.ReadLine();
            switch (valor)
            {
                case "S":
                    Console.WriteLine("Parabéns, bora curtir a vida!");
                    break;

                case "C":
                    Console.WriteLine("Parabéns, agora vai lá que a patroa tá chamando!");
                    break;

                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
