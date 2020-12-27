using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
    //    Используя Visual Studio, создайте проект по шаблону Console Application.
    // Создайте програму в которой реализуйте коллекцию MyList<T>.
    // Реализуйте в простейшем приближении возможность использования ее экземпляра аналогично экземпляру класса List<T>. 
    // Для данной задачи создайте обобщенный интерфейс IMyList<T>, интерфейс должен содержать следующие методы и свойства:
    public interface IMyLIst<T>
    {
        // 1)  Метод void Add(T a); - для добавления элемента в коллекцию;
        void Add(T a);
        // 2)	T this[int index] { get; }
        //    свойство – для получения элемента массива из коллекции по индексу;
        T this[int index] { get; }
        // 3)	int Count { get; }
        //    свойство которое возвращает количество элементов массива;
        int Count { get; }
        // 4)	Метод void Clear(); - удаляет из коллекции все элементы;
        void Clear();
        // 5)	Метод bool Contains(T item); - определяет содержится ли элемент в коллекции.
        bool Contains(T item);
    }

    // Далее создайте обобщенный класс MyList<T> (экземпляр которой и будет использоватся аналогично экземпляру List<T>.),
    public class MyList<T> : IMyLIst<T>
    {
        // в котором реализуйте интерфейс IMyList<T> 
        // также в теле класса создайте закрытий массив элементов
        // типа Т - private T[] array 
        private T[] array = null;
        // и конструктор класса public MyList() в котором инициализируйте массив элементов.
        public MyList()
        {
            array = new T[0];
        }

        public int Count => array.Length;

        public void Add(T a)
        {
            var tempArr = new T[array.Length + 1];
            array.CopyTo(tempArr, 0);
            tempArr[array.Length] = a;
            array = tempArr;
        }

        public void Clear()
        {
            array = new T[0];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public T this[int index] => array[index];

        #region Foreach Members

        int position = -1;

        public void Reset()
        {
            position = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                if (position < array.Length - 1)
                {
                    position++;
                    yield return array[position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Далее в методе Main создайте экземпляр коллекции MyList<T>
            var list = new MyList<int>();

            Console.WriteLine("Длина списка: " + list.Count);

            // и циклом добавьте в него 20 элементов,
            var totalElements = 20;
            for (int i = 0; i < totalElements; i++)
            {
                list.Add(i);
            }
            Console.WriteLine($"Длина списка после добавления {totalElements} элементов: {list.Count}");

            Console.WriteLine("Последний элемент списка: " + list[list.Count - 1]);

            int a = 15, b = 25;
            Console.WriteLine($"Список содержит число {a}: " + list.Contains(a));
            Console.WriteLine($"Список содержит число {b}: " + list.Contains(b));

            // после чего в цикле переберите все его элементы и выведите их значение на консоль.
            Console.WriteLine(new string('-', 30));
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Clear();
            Console.WriteLine("Длина списка после использования метода Clear(): " + list.Count);

            Console.ReadKey();
        }
    }
}
