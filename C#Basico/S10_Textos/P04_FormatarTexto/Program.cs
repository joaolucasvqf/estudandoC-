using System;

namespace P04_FormatarTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome = "João Lucas";
            string texto = "Bem vindo " + nome;

            string textoFormatado = string.Format("Bem vindo {0}! feliz natal{0}", nome);

            Console.WriteLine(textoFormatado);
        }
    }
}
