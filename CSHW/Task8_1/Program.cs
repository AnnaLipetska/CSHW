using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task8_1
{
    // Используя Visual Studio, создайте проект по шаблону Console Application.

    class Program
    {
        static void Main(string[] args)
        {
            // Создайте программу в которой создайте XML файл, который соответствовал бы следующим требованиям:
            // 1. имя файла: TelephoneBook.xml

            DriveInfo[] drives = DriveInfo.GetDrives();

            string lastDriveName = string.Empty;
            for (int i = drives.Count() - 1; i >= 0; i--)
            {
                if (drives[i].DriveType == DriveType.CDRom)
                {
                    continue;
                }
                lastDriveName = (drives[i]).Name;
                break;
            }

            var fullName = lastDriveName + "TelephoneBook.xml";

            using (var xmlWriter = new XmlTextWriter(fullName, null))
            {
                xmlWriter.Formatting = Formatting.Indented;
                // 2. корневой элемент: “MyContacts”
                // 3. тег “Contact”, и в нем должно быть записано имя контакта и атрибут “TelephoneNumber”
                // со значением номера телефона.
                // (* использовать программное создание XML файла)

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("MyContacts");
                xmlWriter.WriteStartElement("Contact");
                xmlWriter.WriteStartAttribute("TelephoneNumber");
                xmlWriter.WriteString("(098)0710223");
                xmlWriter.WriteEndAttribute();
                xmlWriter.WriteString("Anna Lipetska");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
            }

            Console.WriteLine($"Файл {fullName} успешно создан.");
            Console.ReadKey();
        }
    }
}
