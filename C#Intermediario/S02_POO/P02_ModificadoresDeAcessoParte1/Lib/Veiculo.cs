using System;
using System.Collections.Generic;
using System.Text;

namespace P02_ModificadoresDeAcessoParte1.Lib
{
    public class Veiculo
    {
        public string marca;
        protected string modelo;
        private DateTime anoFabricacao;
        internal DateTime anoModelo;

        void InfoVeiculo()
        {
            marca = "FIAT";
            Console.WriteLine(marca);

            modelo = "Palio";

            anoFabricacao = new DateTime(0, 0, 2000);
            anoModelo = new DateTime(0, 0, 2000);
        }
    }
}
