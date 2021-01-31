using System;
using System.Reflection;

namespace Task6_2
{
    class Program
    {
        // Используя Visual Studio, создайте проект по шаблону Console Application.
        // Создайте программу, в которой предоставьте пользователю доступ к сборке из Задания 1.
        // Реализуйте использование метода конвертации значения температуры из шкалы Цельсия в шкалу Фаренгейта.
        // Выполняя задание используйте только рефлексию.

        static void Main()
        {
            Assembly assembly = Assembly.Load("Task6_1");

            dynamic instance = Activator.CreateInstance(assembly.GetType("Task6_1.Temperature"));

            double tC = 21;
            Console.WriteLine("{0} °C равно {1} по °F", tC, instance.ConvertToFahrenheit(tC));

            Console.ReadKey();
        }
    }
}
