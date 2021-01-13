using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    // Используя Visual Studio, создайте проект по шаблону Console Application. 
    // Создайте программу в которой создайте класс Calculator,
    // методы которого принимают аргументы и возвращают значения типа dynamic.

    class Calculator
    {
        static string errorMessage = "Не получается произвести действие над данными аргументами";
        public static dynamic Add(dynamic a, dynamic b)
        {
            try
            {
                return a + b;
            }
            catch (Exception)
            {
                return errorMessage;
            }

        }
        public static dynamic Sub(dynamic a, dynamic b)
        {
            try
            {
                return a - b;
            }
            catch (Exception)
            {
                return errorMessage;
            }

        }
        public static dynamic Mul(dynamic a, dynamic b)
        {
            try
            {
                return a * b;
            }
            catch (Exception)
            {

                return errorMessage;
            }

        }
        public static dynamic Div(dynamic a, dynamic b)
        {
            try
            {
                return a / b;
            }
            catch (Exception)
            {
                return errorMessage;
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator.Add("Hello", " world!!!"));
            Console.WriteLine(Calculator.Sub("Hi", 4));
            Console.WriteLine(Calculator.Mul(5.5, 10));
            Console.WriteLine(Calculator.Div(4, 0));

            Console.ReadKey();
        }
    }
}
