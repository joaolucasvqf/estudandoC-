using System;
using System.Collections.Generic;

namespace P04_Dicionario
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dicionario = new Dictionary<string, int>();
            dicionario.Add("T1", 128);
            dicionario.Add("T2", 256);

            Console.WriteLine(dicionario["T1"]);

            Console.ReadKey();
        }
    }
}
