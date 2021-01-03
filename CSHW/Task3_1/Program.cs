using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
{
    // Используя Visual Studio, создайте проект по шаблону Console Application
    // Создайте программу в которой создайте класс делегат, который в качестве параметров
    // принимает три целочисленных аргумента и возвращает целочисленный тип.
    public delegate int Avg(int a, int b, int c);

    // Далее создайте анонимный метод, который также принимает три целочисленных аргумента
    // и возвращает среднее арифметическое этих аргументов. Сообщите данный анонимный метод
    // с экземпляром делегата, который был ранее создан.
    class Program
    {
        static void Main(string[] args)
        {
            Avg avg = delegate (int operand1, int operand2, int operand3) { return (operand1 + operand2 + operand3) / 3; };
            int a = 5, b = 6, c = 6;

            Console.WriteLine($"Average of {a}, {b}, {c}: " + avg.Invoke(a, b, c));

            Console.ReadKey();
        }
    }
}
