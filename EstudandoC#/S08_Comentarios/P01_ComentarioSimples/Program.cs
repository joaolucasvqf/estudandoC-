using P01_Comentarios;
using System;

namespace P01_ComentarioSimples
{
    class Program
    {
        static void Main(string[] args)
        {

            Veiculo veiculo = new Veiculo();
            veiculo.mover();
            veiculo.mover("tetinha");

            Console.WriteLine("Texto de exemplo");//Ex de comentário

            /*
             * Ex comentário várias linhas (Com *)
             */

            /*  
            
            Ex comentário várias linhas (Sem *)

             */


        }
    }
}
