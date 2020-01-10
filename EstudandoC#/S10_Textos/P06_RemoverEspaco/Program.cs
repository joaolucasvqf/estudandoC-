using System;

namespace P06_RemoverEspaco
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "Olá abiguinhos! sejam felizes desgraças!";

            Console.WriteLine(texto.TrimStart());
            Console.WriteLine(texto.TrimEnd());
            Console.WriteLine(texto.Trim());

            Console.ReadLine();
        }
    }
}
