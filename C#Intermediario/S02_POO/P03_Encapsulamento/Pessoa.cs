using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Encapsulamento
{
    class Pessoa
    {
        private string nome;
        string CEP, endereco, CPF;

        public void SetNome(string nome)
        {
            this.nome = nome.Trim().ToUpper();
        }
        public string GetNome()
        {
            return nome;
        }
    }
}
