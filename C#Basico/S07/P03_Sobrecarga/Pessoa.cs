using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Sobrecarga
{
    class Pessoa
    {
        public int Andar()
        {
            return 1;
        }
        public int Andar(int lvl)
        {
            return Andar() * lvl;
        }
        public int Correr()
        {
            return Andar() * 2;
        }
        public int Pedalar()
        {
            return Correr() * 2;
        }
    }
}
