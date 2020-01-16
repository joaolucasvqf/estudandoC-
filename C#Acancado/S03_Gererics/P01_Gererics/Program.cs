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

            Serializador.Serializar(Carro);
            Serializador.Serializar(Casa);
            Serializador.Serializar(Usuario);

            Carro carro2 = Serializador.Deserializar();
            Casa casa2 = Serializador.Deserializar();
            Usuario usuario2 = Serializador.Deserializar();
        }
    }
}
