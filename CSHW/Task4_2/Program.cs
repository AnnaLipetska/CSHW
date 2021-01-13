using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_2
{
    // Используя Visual Studio, создайте проект по шаблону Console Application 
    // Создайте программу для автостанции, в которой вам необходимо создать простую коллекцию автомобилей со следующими данными:
    // Марка автомобиля, модель, год выпуска, цвет.А также вторую коллекцию с моделью автомобиля,
    // именем покупателя и его номером телефона.Используя простейший LINQ запрос,
    // выведите на экран информацию о покупателе одного из автомобилей и полную характеристику приобретенной ним? модели.

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }

    public class Customer
    {
        public string Model { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Car {Brand = "Skoda", Model = "Yeti", Year = 2019, Color = "red"},
                new Car {Brand = "Skoda", Model = "Octavia", Year = 2019, Color = "green"},
                new Car {Brand = "Subaru", Model = "Tribeca", Year = 2018, Color = "red"},
                new Car {Brand = "Subaru", Model = "Forester", Year = 2017, Color = "black"},
                new Car {Brand = "Subaru", Model = "Impreza", Year = 2020, Color = "white"}
            };

            var customers = new List<Customer>
            {
                new Customer {Model = "Forester", Name = "Abdurahman Ibn Hattab", Phone = "+380980710223"},
                new Customer {Model = "Impreza", Name = "Harry Potter", Phone = "+380440749338"},
                new Customer {Model = "Yeti", Name = "Mary Poppins", Phone = "+380000000000"}
            };

            var query = from car in cars
                        join customer in customers
                        on car.Model equals customer.Model
                        where customer.Name == "Harry Potter"
                        select new
                        {
                            Brand = car.Brand,
                            Model = car.Model,
                            Year = car.Year,
                            Color = car.Color,
                            Name = customer.Name,
                            Phone = customer.Phone
                        };

            foreach (var x in query)
            {
                Console.WriteLine($"Марка: {x.Brand}\nМодель: {x.Model}\nГод выпуска: {x.Year}\nЦвет: {x.Color}\nПокупатель: {x.Name}\nТелефон:{x.Phone}");
                Console.WriteLine(new string('-', 25));
            }

            Console.ReadKey();
        }
    }
}
