using System;
using System.Threading;

namespace P04_ThreadAutoReset
{
    class Program
    {
        static ManualResetEvent ResetManual;
        static AutoResetEvent ResetAutomatico;
        static void Main(string[] args)
        {
            ResetManual = new ManualResetEvent(false);
            ResetAutomatico = new AutoResetEvent(false);
            Thread t1 = new Thread(Executar01);
            t1.Start();
            
            Thread t2 = new Thread(Executar01);
            t2.Start();

            Thread.Sleep(5000);
            ResetManual.Set();
            ResetAutomatico.Set();
            
            Thread.Sleep(5000);
            ResetManual.Set();
            ResetAutomatico.Set();
            
            Console.ReadKey();
        }
        static void Executar01 ()
        {
            Console.WriteLine("01 - iniciando Executar01");
            ResetManual.WaitOne();
            Console.WriteLine("02 - Em execução 01 Executar01");
            Console.WriteLine("03 - Em execução 02 Executar01");
            ResetManual.WaitOne();

            Console.WriteLine("04 - Finalizado Executar01");
        }
        static void Executar02 ()
        {
            Console.WriteLine("01 - iniciando Executar02");
            ResetAutomatico.WaitOne();
            Console.WriteLine("02 - Em execução 01 Executar02");
            Console.WriteLine("03 - Em execução 02 Executar02");
            ResetAutomatico.WaitOne();
            Console.WriteLine("04 - Finalizado Executar02");
        }
    }
}
