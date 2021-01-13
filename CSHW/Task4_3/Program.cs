using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_3
{
    // Используя Visual Studio, создайте проект по шаблону Console Application 
    // Создайте программу в которой создайте целочисленную последовательность размерностью 30 элементов
    // (последовательность заполнить случайными числами), содержащая как положительные, так и отрицательные числа.
    // Вывести ее первый положительный элемент и последний отрицательный элемент.

    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var randoms = new List<int>();

            for (int i = 0; i < 30; i++)
            {
                randoms.Add(random.Next(Int32.MinValue, Int32.MaxValue));
            }

            int firstPositive = randoms.Where(x => x > 0).FirstOrDefault();
            int lastNegative = randoms.Where(x => x < 0).LastOrDefault();

            if (firstPositive != 0)
            {
                Console.WriteLine($"Первый положительный элемент: {firstPositive}");
            }

            if (lastNegative != 0)
            {
                Console.WriteLine($"Последний отрицательный элемент: {lastNegative}");
            }

            Console.ReadKey();
        }
    }
}
