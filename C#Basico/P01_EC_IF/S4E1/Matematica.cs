using System;
using System.Collections.Generic;
using System.Text;

namespace S4E1_POO_e_ER
{
    class Matematica
    {
        public static int exponenciacao(int i, int j)
        {
            int resultado = i;
            if (j == 0)
            {
                resultado = 1;
            }

            for (int l = 1; l < j; l++)
            {
                resultado = resultado * i;
            }

            return resultado;
        }
    }
}
