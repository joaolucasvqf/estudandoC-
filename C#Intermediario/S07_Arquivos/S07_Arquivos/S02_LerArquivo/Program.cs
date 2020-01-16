using System;
using System.IO;

namespace S02_LerArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = File.ReadAllText("C:\\Projetos\\Joao\\C#Intermediario\\S07_Arquivos\\texto.txt");

            Console.WriteLine(texto);

            string[] linhas = File.ReadAllLines("C:\\Projetos\\Joao\\C#Intermediario\\S07_Arquivos\\texto.txt");

            Console.WriteLine("Qtd linhas: " + linhas.Length);

            foreach (var linha in linhas)
            {
                Console.WriteLine("Linhas: " + linha);
            }
        }
    }
}
