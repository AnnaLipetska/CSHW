using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    // Используя Visual Studio, создайте проект по шаблону Console Application. 
    // Создайте программу, в которой используя подход Code First создайте две сущности с произвольными именами.
    // Свяжите две сущности связью один ко многим.Заполните сущности данными.
    // Выполните операцию Select(), Find() к данным. Выведите данные в консоль.

    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PhonesDB>());

            using (PhonesDB db = new PhonesDB())
            {
                PhoneModel pm1 = new PhoneModel { Name = "Lumia 930", Price = 9000 };
                PhoneModel pm2 = new PhoneModel { Name = "Lumia 830", Price = 6000 };
                PhoneModel pm3 = new PhoneModel { Name = "Galaxy S5", Price = 10000 };
                PhoneModel pm4 = new PhoneModel { Name = "Galaxy S4", Price = 6000 };

                db.PhoneModels.AddRange(new List<PhoneModel> { pm1, pm2, pm3, pm4 });
                db.SaveChanges();

                PhoneBrand pb1 = new PhoneBrand { Name = "Nokia", PhoneModels = new List<PhoneModel> { pm1, pm2 } };
                PhoneBrand pb2 = new PhoneBrand { Name = "Samsung", PhoneModels = new List<PhoneModel> { pm3, pm4 } };

                db.PhoneBrands.AddRange(new List<PhoneBrand> { pb1, pb2 });
                db.SaveChanges();

                var phoneModels = db.PhoneModels;

                Show(phoneModels);

                Console.WriteLine(new string('-', 50));
                Console.ReadKey();
                Console.WriteLine();

                var phoneBrands = db.PhoneBrands;

                foreach (var phoneBrand in phoneBrands)
                {
                    Console.WriteLine("{0}.{1}", phoneBrand.Id, phoneBrand.Name);

                    if (phoneBrand.PhoneModels == null) continue;
                    Show(phoneBrand.PhoneModels);
                }

                Console.WriteLine(new string('-', 50));
                Console.ReadKey();
                Console.WriteLine();

                var expensivePhones = db.PhoneModels.Where(m => m.Price > 8000).Select(m => new { m.Name, m.Price, Brand = m.PhoneBrand.Name});
                Console.WriteLine("Дорогие телефоны:");
                foreach (var phone in expensivePhones)
                {
                    Console.WriteLine("\t{0} - {1}. Цена: {2}", phone.Brand, phone.Name, phone.Price);
                }

                Console.WriteLine(new string('-', 50));

                int Id = 3;
                Console.Write($"Поиск по Id = {Id}:  ");
                PhoneModel phoneModel = db.PhoneModels.Find(Id);
                if (phoneModel != null)
                {
                    Console.WriteLine("{0}.{1} - {2}", phoneModel.Id, phoneModel.Name, phoneModel.Price);
                }
                else
                {
                    Console.WriteLine("ничего не найдено");
                }

                Console.ReadKey();
            }
        }

        private static void ShowPhoneInfo(PhoneModel phoneModel)
        {
            Console.WriteLine("\t{0}.{1} - {2} ({3})", phoneModel.Id, phoneModel.Name, phoneModel.Price, phoneModel.PhoneBrand != null ? phoneModel.PhoneBrand.Name : "Unknown Brand");
        }

        private static void Show(IEnumerable<PhoneModel> phoneModels)
        {
            foreach (var phoneModel in phoneModels)
            {
                ShowPhoneInfo(phoneModel);
            }
            Console.WriteLine();
        }
    }
}
