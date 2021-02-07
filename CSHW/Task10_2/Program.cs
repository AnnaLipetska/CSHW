using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task10_2
{
    // Используя Visual Studio, создайте проект по шаблону Console Application. 
    // Создайте программу, в которой создайте класс, поддерживающий сериализацию.
    // Выполните сериализацию объекта этого класса в формате XML.
    // Сначала используйте формат по умолчанию, а затем измените его таким образом,
    // чтобы значения полей сохранились в виде атрибутов элементов XML.
    class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee("Anna", 37);
            var empAttr = new EmployeeAttr("Vova", 40);

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            XmlSerializer serializerAttr = new XmlSerializer(typeof(EmployeeAttr));

            using (FileStream stream = new FileStream("Emp.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, emp);
            }

            using (FileStream stream = new FileStream("EmpAttr.xml", FileMode.Create, FileAccess.Write))
            {
                serializerAttr.Serialize(stream, empAttr);
            }
        }
    }
}
