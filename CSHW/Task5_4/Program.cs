using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_4
{
    // Используя Visual Studio, создайте проект по шаблону Console Application.
    // Создайте программу, в которой используя подход Code First создайте две сущности с произвольными именами. 
    // Свяжите две сущности связью многие ко многим.Заполните сущности данными.Выведите данные в консоль


    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LanguageSchool>());

            using (LanguageSchool db = new LanguageSchool())
            {
                Language en = new Language { Name = "English" };
                Language sp = new Language { Name = "Spanish" };
                Language fr = new Language { Name = "French" };
                Language ch = new Language { Name = "Chinese" };

                db.Languages.AddRange(new List<Language> { en, sp, fr, ch });
                db.SaveChanges();

                var languages = db.Languages.ToList();

                Show(languages);

                Console.WriteLine(new string('-', 50));
                Console.ReadKey();
                Console.WriteLine();

                Student st1 = new Student { FirstName = "Harry", LastName = "Potter", Languages = new List<Language> { en, ch } };
                Student st2 = new Student { FirstName = "Anna", LastName = "Lipetska", Languages = new List<Language> { en, sp } };
                Student st3 = new Student { FirstName = "Alice", LastName = "Morgan"};


                db.Students.AddRange(new List<Student> { st1, st2 });
                db.SaveChanges();

                languages = db.Languages.ToList();

                Show(languages);

                Console.WriteLine(new string('-', 50));
                Console.ReadKey();
                Console.WriteLine();

                var students = db.Students;

                foreach (var student in students)
                {
                    Console.WriteLine("{0}.{1} {2} - {3}", 
                        student.Id, 
                        student.FirstName, 
                        student.LastName, 
                        student.Languages.Any() ? "number of languages learning: " + student.Languages.Count() : " not learning any language");
                    if (student.Languages.Any())
                    {
                        foreach (var language in student.Languages)
                        {
                            Console.WriteLine("\t{0}. {1}", language.Id, language.Name);
                        }
                    }
                }
                Console.ReadKey();
            }
        }

        private static void Show(ICollection<Language> languages)
        {
            foreach (var language in languages)
            {
                Console.WriteLine("\t{0}.{1} - {2}", language.Id, language.Name, language.Students.Any() ? "number of students: " + language.Students.Count() : "no students");
                if (language.Students.Any())
                {
                    foreach (var student in language.Students)
                    {
                        Console.WriteLine("{0}. {1} {2}", student.Id, student.FirstName, student.LastName);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
