using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2
{
    // Используя Visual Studio, создайте проект по шаблону Console Application.
    // Создайте программу в которой создайте класс MyClass<T>,
    public class MyClass<T> where T : new()
    {
        // содержащий статический фабричный метод - T FactoryMethod(),
        // который будет порождать экземпляры типа,
        // указанного в качестве параметра типа (указателя места заполнения типом – Т). 
        public static T FactoryMethod()
        {
            return new T();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int number = MyClass<int>.FactoryMethod();

            Console.WriteLine(number.GetType().Name);

            Random random = MyClass<Random>.FactoryMethod();

            Console.WriteLine(random.GetType().Name);

            Console.ReadKey();
        }
    }
}
