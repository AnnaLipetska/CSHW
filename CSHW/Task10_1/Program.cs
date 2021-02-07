using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task10_1
{
    class Program
    {
        // Используя Visual Studio, создайте проект по шаблону Console Application. 
        // Создайте программу, в которой, создайте пользовательский тип(например, класс)
        // и выполните сериализацию объекта этого типа, всеми известными вас способами.

        static void Main(string[] args)
        {
            Employee emp = new Employee("Anna", 37);

            using (FileStream stream = File.Create("EmpData.data"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, emp);
            }

            //-----------------------------------------------------------------

            using (FileStream stream = new FileStream("EmpData.xml", FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Employee));
                serializer.Serialize(stream, emp);

            }

            //-------------------------------------------------------------------

            using (FileStream stream = new FileStream("EmpDataSOAP.xml", FileMode.Create))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, emp);
            }

            Console.ReadLine();
        }
    }

    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Employee(string name, int speed)
        {
            Name = name;
            Age = speed;
        }
        public Employee()
        {

        }
    }
}
