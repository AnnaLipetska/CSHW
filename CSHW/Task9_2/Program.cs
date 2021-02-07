using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_2
{
    class Program
    {
        // Используя Visual Studio, создайте проект по шаблону Console Application. 
        // Создайте программу в которой создайте пользовательский атрибут AccessLevelAttribute,
        // позволяющий определить уровень доступа пользователя к системе.
        // Сформируйте состав сотрудников некоторой фирмы в виде набора классов, например, Manager, Programmer, Director.
        // При помощи атрибута AccessLevelAttribute распределите уровни доступа персонала
        // и отобразите на экране реакцию системы на попытку каждого сотрудника получить доступ в защищенную секцию.

        static void Main(string[] args)
        {
            Employee[] employees = new Employee[] { new Manager(), new Programmer(), new Director() };

            foreach (var emp in employees)
            {
                GetAccessToProtectedSection(emp);
            }

            Console.ReadKey();
        }

        static void GetAccessToProtectedSection(Employee emp)
        {
            Type employee = emp.GetType();
            object[] attribute = employee.GetCustomAttributes(typeof(AccessLevelAttribute), false);

            if (attribute.Length == 0)
            {
                return;
            }
            foreach (AccessLevelAttribute item in attribute)
            {
                Console.WriteLine($"This employee is a {employee.Name}, access level: {item.AccessLevel}");
            }

        }
    }
}
