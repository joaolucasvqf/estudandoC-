using Biblioteca.Arquivo;
using Biblioteca.Model;
using P01_ProjetoDeCadastro.Conversores;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_ProjetoDeCadastro.Telas
{
    class ManterFuncionario
    {
        public void CadastrarFuncionario()
        {
            Funcionario funcionario = new Funcionario();

            Console.Clear();

            Console.WriteLine("CADASTRAR FUNCIONARIO");

            Console.WriteLine("Nome: ");
            funcionario.Nome = Console.ReadLine();

            Console.WriteLine("Data de nascimento: ");
            funcionario.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Telefone: ");
            funcionario.Telefone = Console.ReadLine();

            Console.WriteLine("CPF: ");
            funcionario.CPF = Console.ReadLine();

            Console.WriteLine("RG: ");
            funcionario.RG = Console.ReadLine();

            Console.WriteLine("CEP (Apenas números): ");
            funcionario.CEP = int.Parse(Console.ReadLine());

            Console.WriteLine("Cidade: ");
            funcionario.Cidade = Console.ReadLine();

            Console.WriteLine("Estado: ");
            funcionario.Estado = Console.ReadLine();

            Console.WriteLine("Endereco: ");
            funcionario.Endereco = Console.ReadLine();

            Console.WriteLine("Cargo: ");
            funcionario.Cargo = Console.ReadLine();

            Console.WriteLine("Salário: ");
            funcionario.Salario = double.Parse(Console.ReadLine());

            Console.WriteLine("Data de contratação: ");
            funcionario.DataContratacao = DateTime.Parse(Console.ReadLine());

            GerenciadorArquivo.GravarArquivo("funcionario", FuncionarioTexto.ConverterParaTexto(funcionario));
        }
        public void ListarFuncionarios()
        {
            Console.Clear();

            Console.WriteLine("LISTAGEM DE CLIENTES");

            string[] linhas = GerenciadorArquivo.LerArquivo("cliente");

            foreach (var linha in linhas)
            {
                Funcionario funcionario = FuncionarioTexto.ConverterParaFuncionario(linha);

                Console.WriteLine("Nome: " + funcionario.Nome);
                Console.WriteLine("Data de nascimento: " + funcionario.DataNascimento);
                Console.WriteLine("Telefone: " + funcionario.Telefone);
                Console.WriteLine("CPF: " + funcionario.CPF);
                Console.WriteLine("RG: " + funcionario.RG);
                Console.WriteLine("CEP (Apenas números): " + funcionario.CEP);
                Console.WriteLine("Cidade: " + funcionario.Cidade);
                Console.WriteLine("Estado: " + funcionario.Estado);
                Console.WriteLine("Endereco: " + funcionario.Endereco);
                Console.WriteLine("Cargo: " + funcionario.Cargo);
                Console.WriteLine("Salário: " + funcionario.Salario);
                Console.WriteLine("Data de contratação: " + funcionario.DataContratacao);

                Console.WriteLine(linha);
            }
        }
    }
}
