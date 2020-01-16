using System;

namespace P03_VerificarExiste
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "Olá amigos da onça!";

            Console.WriteLine("Verificar existencia no inicio: " + texto.StartsWith("Olá"));

            Console.WriteLine("Verificar existencia no final: " + texto.EndsWith("!"));

            Console.WriteLine("Verificar existência: " + texto.Contains("onça"));
        }
    }
}
