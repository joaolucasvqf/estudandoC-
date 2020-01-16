using Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_ProjetoDeCadastro.Conversores
{
    class ClienteTexto
    {
        public static string ConverterParaTexto(Cliente cliente)
        {
            string texto = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                cliente.Nome,
                cliente.DataNascimento,
                cliente.Telefone,
                cliente.CPF,
                cliente.RG,
                cliente.CEP,
                cliente.Estado,
                cliente.Cidade,
                cliente.Endereco
            );
            return texto;
        }
        public static Cliente ConverterParaCliente(string linha)
        {
            string[] elementos = linha.Split(",");

            Cliente cliente = new Cliente();
            cliente.Nome = elementos[0];
            cliente.DataNascimento = DateTime.Parse(elementos[1]);
            cliente.Telefone = elementos[2];
            cliente.CPF = elementos[3];
            cliente.RG = elementos[4];
            cliente.CEP = int.Parse(elementos[5]);
            cliente.Estado = elementos[6];
            cliente.Cidade = elementos[7];
            cliente.Endereco = elementos[8];

            return cliente;
        }
    }
}
