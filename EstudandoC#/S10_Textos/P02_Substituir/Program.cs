using System;

namespace P02_Substituir
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "Olá amigos do João";
            Console.WriteLine("Texto original antes do replace" + texto);
            string textoSub = texto.Replace("João", "Gil");
            Console.WriteLine("Texto substituido: " + textoSub);
            Console.WriteLine("Texto original" + texto);
        }
    }
}
