using System;
using System.Threading;

namespace P02_MultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data inicio: " + DateTime.Now);
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(ThreadRepeticao);
                thread.Start();
            }
        }
        static void ThreadRepeticao()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Num: " + i);
            }
            Console.WriteLine("Data fim thread: " + DateTime.Now);
        }
    }
}
