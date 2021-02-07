using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task8_3
{
    // Используя Visual Studio, создайте проект по шаблону Console Application.
    // Создайте программу, которая будет использовать XML файл из примера 1 и будет выводить на консоль
    // только номера телефонов.

    class Program
    {
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
                            if (xmlReader.HasAttributes)
                            {
                                if (xmlReader.Name.Equals("Contact"))
                                {
                                    Console.WriteLine(xmlReader.GetAttribute("TelephoneNumber"));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так.");
            }

            Console.ReadKey();
        }
    }
}
