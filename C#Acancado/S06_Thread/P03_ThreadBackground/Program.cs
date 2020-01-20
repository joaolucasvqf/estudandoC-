using System;
using System.Threading;

namespace P03_ThreadBackground
{
    class Program
    {
        static int Recurso = 0;
        static object VariavelControle = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Data inicio: " + DateTime.Now);
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(ThreadRepeticao);
                thread.IsBackground = true;
                thread.Start(i);
            }
            Console.ReadKey();
        }
        static void ThreadRepeticao(Object j)
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (VariavelControle)
                {
                    Console.WriteLine("Thread: " + j + "Num: " + i);
                    Recurso++;
                }
            }
            Console.WriteLine("Data fim thread: " + DateTime.Now);
        }
    }
}
