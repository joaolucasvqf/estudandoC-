using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace P01_Gererics
{
    public class Serializador
    {
        public static void Serializar(object obj)
        {
            StreamWriter sw = new StreamWriter(@"C:\Projetos\Joao\C#Acancado\S03_Gererics\" + obj.GetType().Name + ".txt");

            string objSerializado = JsonConvert.SerializeObject(obj);

            sw.Write(objSerializado);
            sw.Close();
        }
        public static T Deserializar<T>()
        {
            StreamReader sr = new StreamReader(@"C:\Projetos\Joao\C#Acancado\S03_Gererics\" + typeof(T).Name + ".txt");
            string conteudo = sr.ReadToEnd();

            return JsonConvert.DeserializeObject<T>(conteudo);
        }
    }
}
