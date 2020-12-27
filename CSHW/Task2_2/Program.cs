using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    // Используя Visual Studio, создайте проект по шаблону Console Application. 
    // Создайте расширяющий метод: public static T[] GetArray<T>(this MyList<T> list)
    static class MyStaticClass
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] arr = new T[list.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = list[i];
            }
            return arr;
        }
    }
    class Program
    {
        // Примените расширяющий метод к экземпляру типа MyList<T>,
        // разработанному в домашнем задании 1 для данного урока.
        // Выведите на экран значения элементов массива, который вернул расширяющий метод GetArray()

        static void Main(string[] args)
        {
            var list = new MyList<int>();
            var totalElements = 20;
            for (int i = 0; i < totalElements; i++)
            {
                list.Add(i);
            }

            int[] arr = list.GetArray<int>();
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
