using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_2
{
    // Используя Visual Studio, создайте проект по шаблону Console Application.
    // Создайте программу, в которой создайте файл, запишите в него произвольные данные и закройте файл.
    // Затем снова откройте этот файл, прочитайте из него данные и выведете их на консоль.

    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = File.CreateText("MyFile.txt");
            writer.WriteLine("Произвольные данные");
            writer.Close();

            Console.ReadKey();

            StreamReader reader = File.OpenText("MyFile.txt");
            Console.WriteLine(reader.ReadToEnd());

            Console.ReadKey();
        }
    }
}
