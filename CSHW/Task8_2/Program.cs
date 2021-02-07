using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task8_2
{
    class Program
    {
        // Используя Visual Studio, создайте проект по шаблону Console Application.
        // Создайте программу, которая будет использовать XML файл из предыдущего примера
        // выводить всю информации о данном файле на консоль.

        static void Main(string[] args)
        {
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

            try
            {
                using (FileStream stream = new FileStream(fullName, FileMode.Open))
                {
                    using (XmlTextReader xmlReader = new XmlTextReader(stream))
                    {
                        while (xmlReader.Read())
                        {
                            Console.WriteLine("NodeType: {0,-15}| Name: {1,-15}| Value: {2,-15}",
                                            xmlReader.NodeType,
                                            xmlReader.Name,
                                            xmlReader.Value);
                        }
                    }
                }

                Console.WriteLine(new string('-', 20));

                XmlDocument document = new XmlDocument();
                document.Load(fullName);

                Console.WriteLine(document.InnerText);

                Console.WriteLine(new string('-', 20));

                Console.WriteLine(document.InnerXml);
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так.");
            }

            Console.ReadKey();
        }
    }
}
