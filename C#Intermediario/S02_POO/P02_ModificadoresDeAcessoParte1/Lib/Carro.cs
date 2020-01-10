using System;
using System.Collections.Generic;
using System.Text;

namespace P02_ModificadoresDeAcessoParte1.Lib
{
    public class Carro : Veiculo
    {
        byte qtdRodas = 4;

        void infoCarro()
        {
            marca = "VW";
            modelo = "Gol";
        }
    }
}
