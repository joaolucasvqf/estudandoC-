using P02_Heranca.Bibliotca;
using System;

namespace P02_Sobrescrita
{
    class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro();
            Moto moto = new Moto();
            Veiculo veiculo = new Veiculo();

            carro.marca = "FIAT";
            moto.marca = "Triumph";
            veiculo.marca = "Airbus";

            carro.Mover();
            moto.Mover();
            veiculo.Mover();

            Console.ReadKey();
        }
    }
}
