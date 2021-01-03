using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3
{
    // Используя Visual Studio, создайте проект по шаблону Console Application. 
    // Создайте программу, в которой создайте анонимный метод,
    // который принимает в качестве аргумента массив делегатов и возвращает среднее арифметическое
    // возвращаемых значений методов сообщенных с делегатами в массиве.
    // Методы, сообщенные с делегатами из массива, возвращают случайное значение типа int.

    delegate int DelegateRandom();
    delegate double DelegateAVG(params DelegateRandom[] delegateRandoms);
    class MyClass
    {
        Random random = new Random();

        public int RandomMethod()
        {
            int result = random.Next();
            Console.WriteLine($"число {result}");
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass my = new MyClass();

            DelegateRandom random1 = new DelegateRandom(my.RandomMethod);
            DelegateRandom random2 = new DelegateRandom(my.RandomMethod);
            DelegateRandom random3 = new DelegateRandom(my.RandomMethod);

            DelegateAVG avg = delegate (DelegateRandom[] delegateRandoms)
            {
                double sum = 0.0;
                foreach (var del in delegateRandoms)
                {
                    sum += del.Invoke();
                }

                return sum / delegateRandoms.Length;
            };

            Console.WriteLine($"Среднее арифметическое этих чисел = {avg.Invoke(random1, random2, random3)}");

            Console.ReadKey();
        }
    }
}
