using _00_Biblioteca;
using System;
using System.IO;
using System.Xml.Serialization;

namespace P01_Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario() { Nome = "João Lucas", CPF = "123.123.123.11", Email = "joao@joao.com"};

            //XmlSerializer serializer = new XmlSerializer(usuario.GetType());
            XmlSerializer serializer = new XmlSerializer(typeof(Usuario));

            StreamWriter stream = new StreamWriter(@"C:\Users\User\source\repos\S02_Serializacao\P01_Xml\serializarcaoXML.xml");

            serializer.Serialize(stream , usuario);
        }
    }
}
