using P02_ModificadoresDeAcessoParte1.Lib;
using System;

namespace P02_ModificadoresDeAcessoParte1
{
    class Program
    {
        static void Main(string[] args)
        {
            Veiculo veiculo = new Veiculo();
            Carro carro = new Carro();
            Caminao caminao = new Caminao();

            caminao.marca = "Volvo";
            carro.marca = "Fiat";
            Console.WriteLine(veiculo.marca);

            carro.anoModelo = new DateTime(0, 0, 2000);
        }
    }
}
