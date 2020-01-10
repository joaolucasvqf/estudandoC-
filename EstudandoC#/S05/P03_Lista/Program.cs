using System;
using System.Collections.Generic;

namespace P03_Lista
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> marcas = new List<string>();

            marcas.Add("FIAT");
            marcas.Add("Chevrolet");
            marcas.Add("Renoutl");
            marcas.Add("Pegeout");
            marcas.Add("Volkswagen");

            Console.WriteLine("Primeira marca: " + marcas[0]);

            Console.WriteLine("-----------------Lista de marcas forEach----------------");
            foreach (string marca in marcas)
            {
                Console.WriteLine(marca);
            }

            Console.ReadKey();
        }
    }
}
