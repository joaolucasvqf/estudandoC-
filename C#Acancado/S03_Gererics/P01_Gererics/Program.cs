using P01_Gererics.Modelo;
using System;

namespace P01_Gererics
{
    class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro() { Marca = "FIAT", Modelo = "Uno" };
            Casa casa = new Casa() { Cidade = "Beltrão", Endereco = "Centro " };
            Usuario usuario = new Usuario() { Nome = "João", Email = "joao@joao.com", Senha = "****" };

            Serializador.Serializar(carro);
            Serializador.Serializar(casa);
            Serializador.Serializar(usuario);

            Carro carro2 = Serializador.Deserializar<Carro>();
            Casa casa2 = Serializador.Deserializar<Casa>();
            Usuario usuario2 = Serializador.Deserializar<Usuario>();

            Console.WriteLine("Carro 2: " + carro2.Marca + " - " + carro2.Modelo);
            Console.WriteLine("Casa 2: " + casa2.Cidade + " - " + casa2.Endereco);
            Console.WriteLine("Usuario 2: " + usuario2.Nome + " - " + usuario2.Email);

            Console.ReadKey();
        }
    }
}
