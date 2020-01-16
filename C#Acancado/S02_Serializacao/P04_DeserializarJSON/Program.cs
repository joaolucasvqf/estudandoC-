using _00_Biblioteca;
using Newtonsoft.Json;
using System;
using System.IO;

namespace P04_DeserializarJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader(@"C:\Projetos\Joao\C#Acancado\S02_Serializacao\P03_SerializarJSON\SerializarJSON.json");

            Usuario usuario = new Usuario();

            usuario = (Usuario) JsonSerializer.Create().Deserialize(stream, typeof(Usuario));

            Console.WriteLine("Nome" + usuario.Nome + ", CPF: " + usuario.CPF + ", Email: " + usuario.Email);
            Console.ReadKey();
        }
    }
}
