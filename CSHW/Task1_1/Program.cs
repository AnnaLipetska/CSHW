using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Используя Visual Studio, создайте проект по шаблону Console Application.

namespace Task1_1
{
    // Создайте программу в которой создайте обобщенный класс книга (Book).
    class Book<T>
    {
        // Класс Book должен содержать универсальный параметра типа T (Book <T>).
        // В теле класса создайте два закрытых поля:
        // Name – имя книги (private string Name) 
        private string name;
        // и Price – (обобщенныйтип) цена книги (private T Price).
        private T price;
        // Также создайте свойства для доступа к выше описанным полям.
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public T Price
        {
            get { return price; }
            set { price = value; }
        }
        // После чего создайте метод Show() который будет вывод название книги и ее цену.
        public void Show()
        {
            Console.WriteLine($"Название: {Name}, цена: {Price} баксов");
        }
    }

    class Program
    {
        // В методе Main() создайте экземпляры обобщенного типа, где Т это int и где Т это double.
        static void Main(string[] args)
        {
            var book1 = new Book<int>();
            var book2 = new Book<double>();

            book1.Name = "\"Первая книга\"";
            book2.Name = "\"Вторая книга\"";

            book1.Price = 10;
            book2.Price = 29.9;

            book1.Show();
            book2.Show();

            Console.ReadKey();
        }
    }
}
