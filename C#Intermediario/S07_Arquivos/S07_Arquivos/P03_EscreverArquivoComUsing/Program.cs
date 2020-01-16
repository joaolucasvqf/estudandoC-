using System;
using System.IO;

namespace P03_EscreverArquivoComUsing
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter arquivo = new StreamWriter("C:\\Projetos\\Joao\\C#Intermediario\\S07_Arquivos\\texto.txt"))
            {
                arquivo.WriteLine("Olá, este é o meu primeiro arquivo");
                arquivo.WriteLine("Bem vindo a 2020! \n Agora já pode me deixar em paz");
            }

            Console.WriteLine("Arquivo gravado");

            Console.ReadKey();
        }
    }
}
