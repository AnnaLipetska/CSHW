using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task10_3
{
    class Program
    {
        // Используя Visual Studio, создайте проект по шаблону Console Application. 
        // Создайте программу, в которой выполните десериализацию объекта из предыдущего примера.
        // Отобразите состояние объекта на экране

        static void Main(string[] args)
        {
            //var emp = new Employee("Anna", 37);
            //var empAttr = new EmployeeAttr("Vova", 40);

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            XmlSerializer serializerAttr = new XmlSerializer(typeof(EmployeeAttr));

            //using (FileStream stream = new FileStream("Emp.xml", FileMode.Create, FileAccess.Write))
            //{
            //    serializer.Serialize(stream, emp);
            //}

            //using (FileStream stream = new FileStream("EmpAttr.xml", FileMode.Create, FileAccess.Write))
            //{
            //    serializerAttr.Serialize(stream, empAttr);
            //}

            //----------------------------------------------------------

            Employee emp1;
            EmployeeAttr empAttr1;

            using (FileStream stream = new FileStream("Emp.xml", FileMode.Open, FileAccess.Read))
            {
                emp1 = (Employee)serializer.Deserialize(stream);
            }

            using (FileStream stream = new FileStream("EmpAttr.xml", FileMode.Open, FileAccess.Read))
            {
                empAttr1 = (EmployeeAttr)serializerAttr.Deserialize(stream);
            }

            Console.WriteLine($"{emp1.Name} - {emp1.Age}");
            Console.WriteLine($"{empAttr1.Name} - {empAttr1.Age}");

            Console.ReadKey();
        }
    }
}
