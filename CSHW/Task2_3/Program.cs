using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3
{
    class Program
    {
        // Используя Visual Studio, создайте проект по шаблону Console Application. 
        // Создайте программу в которой используя класс SortedList,
        // создайте небольшую коллекцию и выведите на экран значения пар «ключ- значение»
        // сначала в алфавитном порядке, а затем в обратном.

        static void Main(string[] args)
        {
            var sortedList = new SortedList();
            sortedList["cat"] = "кот";
            sortedList["sun"] = "солнце";
            sortedList["dog"] = "собака";
            PrintAllEntries(sortedList);

            Console.WriteLine(new string('+', 30));

            var reversedSortedList = new SortedList(sortedList, new DescendingComparer());
            PrintAllEntries(reversedSortedList);

            Console.ReadKey();
        }

        private static void PrintAllEntries(SortedList sortedList)
        {
            foreach (DictionaryEntry de in sortedList)
            {
                Console.WriteLine($"{de.Key} - {de.Value}");
            }
        }
    }

    public class DescendingComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Comparer comparer = new Comparer(CultureInfo.InvariantCulture);
            return comparer.Compare(y, x);
        }
    }
}
