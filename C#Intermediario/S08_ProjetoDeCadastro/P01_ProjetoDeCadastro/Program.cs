using P01_ProjetoDeCadastro.Telas;
using System;

namespace P01_ProjetoDeCadastro
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcoes = 0;
            while (opcoes != 5)
            {
                Console.WriteLine(
                    "O que deseja fazer? \n" +
                    "(1 - Cadastrar cliente, 2 - Listar clientes, 3 - Cadastrar funcionário, 4 - Listar funcionários 5 - Fechar programa)"
                );
                opcoes = int.Parse(Console.ReadLine());

                ManterCliente telaCliente = new ManterCliente();
                ManterFuncionario telaFuncionario = new ManterFuncionario();

                switch(opcoes)
                {
                    case 1:
                        telaCliente.CadastrarCliente();
                        break;
                    case 2:
                        telaCliente.ListarClientes();
                        break;
                    case 3:
                        telaFuncionario.CadastrarFuncionario();
                        break;
                    case 4:
                        telaFuncionario.ListarFuncionarios();
                        break;
                    case 5:
                        Console.WriteLine("Encerrando programa!!!");
                        break;
                    default:
                        Console.WriteLine("Comando incorreto ou não encontrado!");
                        break;
                }
            }
        }
    }
}
