using System;
using System.Collections.Generic;
using System.Text;

namespace P05_Construtor
{
    class Carro
    {
        public string marca, modelo;
        public int ano;
        public Carro()
        {
            marca = "FIAT";
            modelo = "Uno";
        }
        public Carro(string marca, string modelo, int ano)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.ano = ano;
        }
    }
}
