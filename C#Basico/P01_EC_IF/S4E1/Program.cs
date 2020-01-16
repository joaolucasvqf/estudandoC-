using System;

namespace S4E1_POO_e_ER
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------Aplicação de exponenciação de números--------------------");
            Console.WriteLine("Informe um número: ");
            int i = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o expoente: ");
            int j = int.Parse(Console.ReadLine());

            int resultado = Matematica.exponenciacao(i, j);

            Console.WriteLine("O resultado de " + i + " elevado a " + j + " é igual a: " + resultado);

            Console.WriteLine("------------------------------Resultado esperado------------------------------");

            int provaReal = (int) Math.Pow(i, j);
            Console.WriteLine("Prova real:" + provaReal);

            Console.ReadKey();
        }
    }
}
