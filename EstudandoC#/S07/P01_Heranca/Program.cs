using P01_Heranca.Bibliotca;
using System;

namespace P01_Heranca
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
        }
    }
}
