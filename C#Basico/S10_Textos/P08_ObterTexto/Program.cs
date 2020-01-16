using System;

namespace P08_ObterTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "Olá pessoas, cuidado com a invasão dos alienigenas!";

            Console.WriteLine(texto.Substring(13));
            Console.WriteLine(texto.Substring(13, 7));

            Console.ReadKey();
        }
    }
}
