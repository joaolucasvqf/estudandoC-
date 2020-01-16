using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Biblioteca.Arquivo
{
    public class GerenciadorArquivo
    {
        public static void GravarArquivo(string nome, string texto)
        {
            string caminho = "C:\\Projetos\\Joao\\C#Intermediario\\S08_ProjetoDeCadastro" + nome + ".txt";
            
            if (File.Exists(caminho))
            { 
                using(StreamWriter wr = File.AppendText(caminho))
                {
                    wr.WriteLine(texto);
                }
            } 
            else
            {
                using (StreamWriter wr = new StreamWriter(caminho))
                {
                    wr.WriteLine(texto);
                }
            }
        }
        public static string[] LerArquivo(string nome)
        {
            string caminho = "C:\\Projetos\\Joao\\C#Intermediario\\S08_ProjetoDeCadastro" + nome + ".txt";
            return File.ReadAllLines(caminho);        }
    }
}
