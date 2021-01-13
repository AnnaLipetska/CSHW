using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_4
{
    // Используя Visual Studio, создайте проект по шаблону Console Application
    // Создайте программу в которой создайте последовательность, которая содержит сведения о клиентах фитнес-центра.
    // Каждый элемент последовательности включает следующие целочисленные поля:
    // «Код клиента», «Год», «Номер месяца», «Продолжительность занятий(в часах)».

    public class Client
    {
        public int ClientId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Hours { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var clients = new List<Client>
            {
                new Client {ClientId = 1, Year = 1980, Month = 5, Hours = 2},
                new Client {ClientId = 2, Year = 2000, Month = 7, Hours = 1},
                new Client {ClientId = 3, Year = 2005, Month = 3, Hours = 3},
                new Client {ClientId = 4, Year = 1990, Month = 12, Hours = 1},
                new Client {ClientId = 5, Year = 1983, Month = 1, Hours = 2}
            };

            // Найти элемент последовательности с минимальной продолжительностью занятий.
            // Вывести эту продолжительность, а также соответствующие ей год и номер месяца(в указанном порядке на той же строке).
            // Если имеется несколько элементов с минимальной продолжительностью, то вывести данные того из них,
            // который является последним в исходной последовательности.

            var minHoursClients = clients.Where(x => x.Hours == clients.Min(y => y.Hours)).Last();

            Console.WriteLine($"Hours: {minHoursClients.Hours}, year: {minHoursClients.Year}, month: {minHoursClients.Month}");

            Console.ReadKey();
        }
    }
}
