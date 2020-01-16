using System;

namespace P07_DividirTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomes = "João, Gildo, Rubia e Barbara";

            string[] separador = { ", ", " e " };
            string[] arrayNomes = nomes.Split(separador, StringSplitOptions.None);

            foreach(string nome in arrayNomes)
            {
                Console.WriteLine(nome);
            }

            Console.ReadKey();
        }
    }
}
