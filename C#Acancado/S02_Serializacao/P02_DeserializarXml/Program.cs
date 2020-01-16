using _00_Biblioteca;
using System;
using System.IO;
using System.Xml.Serialization;


namespace P02_DeserializarXml
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader(@"C:\Users\User\source\repos\S02_Serializacao\P01_Xml\serializarcaoXML.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(Usuario));

            Usuario usuario = (Usuario)serializer.Deserialize(stream);

            Console.WriteLine("Nome" + usuario.Nome + ", CPF: " + usuario.CPF + ", Email: " + usuario.Email);
            Console.ReadKey();
        }
    }
}
