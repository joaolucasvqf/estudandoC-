using P04_Polimorfismo.Biblioteca.Derivada;
using P04_Polimorfismo.Biblioteca;
using System;


namespace P04_Polimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro();
            Moto moto = new Moto();
            Onibus onibus = new Onibus();
            Veiculo veiculo = new Veiculo();

            MoverVeiculo(carro);

            Console.ReadKey();

        }
        public static void MoverVeiculo(Veiculo veiculo)
        {
            veiculo.Mover();
        }
    }
}
