using System;

namespace P02_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número: ");

            try
            {
            int numero = int.Parse(Console.ReadLine());
            } 
            catch (FormatException e)
            {
                Console.WriteLine("Os dados informados estão oncorretos!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Nenhum dado informado!");
            }
            finally
            {
                Console.WriteLine("Finally!");
            }

            Console.ReadKey();
        }
    }
}
