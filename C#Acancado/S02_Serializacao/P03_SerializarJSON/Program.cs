using System;
using System.IO;
using _00_Biblioteca;
using Newtonsoft;
using Newtonsoft.Json;

namespace P03_SerializarJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario() { Nome = "Maria", CPF = "321.321.321-33", Email = "maria@maria.com" };

            string text = JsonConvert.SerializeObject(usuario);

            StreamWriter stream = new StreamWriter(@"C:\Projetos\Joao\C#Acancado\S02_Serializacao\P03_SerializarJSON\SerializarJSON.json");

            stream.Write(text);
            stream.Close();
            Console.WriteLine("Hello World!");
        }
    }
}
