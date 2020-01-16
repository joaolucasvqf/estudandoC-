using Biblioteca.Arquivo;
using Biblioteca.Model;
using P01_ProjetoDeCadastro.Conversores;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_ProjetoDeCadastro.Telas
{
    class ManterCliente
    {
        public void CadastrarCliente()
        {
            Cliente cliente = new Cliente();

            Console.Clear();

            Console.WriteLine("CADASTRAR CLIENTE");

            Console.WriteLine("Nome: ");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Data de nascimento: ");
            cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Telefone: ");
            cliente.Telefone = Console.ReadLine();

            Console.WriteLine("CPF: ");
            cliente.CPF = Console.ReadLine();

            Console.WriteLine("RG: ");
            cliente.RG = Console.ReadLine();

            Console.WriteLine("CEP (Apenas números): ");
            cliente.CEP = int.Parse(Console.ReadLine());

            Console.WriteLine("Cidade: ");
            cliente.Cidade = Console.ReadLine();

            Console.WriteLine("Estado: ");
            cliente.Estado = Console.ReadLine();

            Console.WriteLine("Endereco: ");
            cliente.Endereco = Console.ReadLine();

            GerenciadorArquivo.GravarArquivo("cliente", ClienteTexto.ConverterParaTexto(cliente));
        }
        public void ListarClientes()
        {
            Console.Clear();

            Console.WriteLine("LISTAGEM DE CLIENTES");

            string[] linhas = GerenciadorArquivo.LerArquivo("cliente");

            foreach(var linha in linhas)
            {
                Cliente cliente = ClienteTexto.ConverterParaCliente(linha);

                Console.WriteLine("Nome: " + cliente.Nome);
                Console.WriteLine("Data de nascimento: " + cliente.DataNascimento);
                Console.WriteLine("Telefone: " + cliente.Telefone);
                Console.WriteLine("CPF: " + cliente.CPF);
                Console.WriteLine("RG: " + cliente.RG);
                Console.WriteLine("CEP (Apenas números): " + cliente.CEP);
                Console.WriteLine("Cidade: " + cliente.Cidade);
                Console.WriteLine("Estado: " + cliente.Estado);
                Console.WriteLine("Endereco: " + cliente.Endereco);

                Console.WriteLine(linha);
            }
        }
    }
}
