using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_5
{
    // Используя Visual Studio, создайте проект по шаблону Console Application 
    // Создайте программу, в которой, используя динамические и анонимные типы данных,
    // создайте Англо-Русский словарь на 10 слов и выведите на экран его содержание.

    class DictionaryEntry
    {
        public dynamic Key { get; set; }
        public dynamic Value { get; set; }

        public DictionaryEntry(dynamic key, dynamic value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            dynamic dictionary = new Dictionary<dynamic, dynamic>();
            dictionary.Add("sky", "небо");
            dictionary.Add("three", 3);
            dictionary.Add(true, "правдивый");
            dictionary.Add("ten", 10);
            dictionary.Add("two", "два");
            dictionary.Add("hundred", 100);
            dictionary.Add("hyphen", '-');
            dictionary.Add("and", 'и');
            dictionary.Add(new { A = "Mouth", B = "Seal" }, new { C = "маска" });
            dictionary.Add("Alice", "Алиса");

            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
