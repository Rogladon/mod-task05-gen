using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    /// <summary>
    /// Рандомная выдача символов
    /// </summary>
    [Obsolete]
    class CharGenerator 
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGenerator() 
        {
           size = syms.Length;
           data = syms.ToCharArray(); 
        }
        public char getSym() 
        {
           return data[random.Next(0, size)]; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Generator> nameGeneratorsPairs = new Dictionary<string, Generator>() {
                {"chars",new BigrammCharGenerator(utilits.Utilits.GetWeights("..\\..\\..\\bigrammChars.txt")) },
                {"words", new WordGenerator(utilits.Utilits.GetDictionaryStringInt("..\\..\\..\\FrequencyWords.txt")) },
                {"two-words", new BigramWordGenerator(utilits.Utilits.GetDictionaryStringInt("..\\..\\..\\FrequencyTwoWords.txt")) }
            };
            foreach(var i in nameGeneratorsPairs) {
                StreamWriter stream = new StreamWriter($"..\\..\\..\\{i.Key}-output.txt");
                stream.WriteLine(i.Value.GetText(1000));
                stream.Close();
			}
        }
    }
}

