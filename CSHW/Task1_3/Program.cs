using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_3
{
    // Используя Visual Studio, создайте проект по шаблону Console Application.
    // Создайте программу в которой создайте класс калькулятор (Calculator).
    // Класс Calculator должен содержать два универсальных параметра типа T1, T2 (Calculator<T1, T2>).
    public class Calculator<T1, T2>
    {
        // В теле класса создайте методы для сложения (Add), вычитания (Subtract) и умножения (Multiply),
        // которые в качестве аргументов должны принимать T1, T2, и возвращать тип double
        // (можно использовать класс Convert или приведение типов)
        public double Add(T1 operand1, T2 operand2)
        {
            if (typeof(T1) == typeof(int) && typeof(T2) == typeof(int))
            {
                return (double)((int)(object)operand1 + (int)(object)operand2);
            }

            else if (typeof(T1) == typeof(double) && typeof(T2) == typeof(double))
            {
                return (double)((double)(object)operand1 + (double)(object)operand2);
            }

            else if (typeof(T1) == typeof(int) && typeof(T2) == typeof(double))
            {
                return (double)((int)(object)operand1 + (double)(object)operand2);
            }

            else if (typeof(T1) == typeof(double) && typeof(T2) == typeof(int))
            {
                return (double)((double)(object)operand1 + (int)(object)operand2);
            }

            return default(double);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Calculator<int, int> ii = new Calculator<int, int>();
            double doubleSum = ii.Add(2, 3);
            Console.WriteLine(doubleSum);

            Calculator<double, double> dd = new Calculator<double, double>();
            doubleSum = dd.Add(2.2, 3.3);
            Console.WriteLine(doubleSum);

            Calculator<int, double> id = new Calculator<int, double>();
            doubleSum = dd.Add(2, 3.3);
            Console.WriteLine(doubleSum);

            Calculator<double, int> di = new Calculator<double, int>();
            doubleSum = dd.Add(2.2, 3);
            Console.WriteLine(doubleSum);

            Console.ReadKey();
        }
    }
}
