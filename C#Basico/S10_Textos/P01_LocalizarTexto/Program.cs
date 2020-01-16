using System;

namespace P01_LocalizarTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "Olá mundo, que se exploda. Mas que mundo maravilhoso";
            string palavra = "que";

            Console.WriteLine("Tamanho do texto: " + texto.Length);
            Console.WriteLine("Localizar: " + texto.IndexOf(palavra));
            Console.WriteLine("Localizar ultimo: " + texto.LastIndexOf("mundo"));

            Console.WriteLine(texto.IndexOf("mundo", 10));
            Console.ReadKey();
        }
    }
}
