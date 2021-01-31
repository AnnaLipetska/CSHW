using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_1
{
    // Создайте приложение в котором создайте свою пользовательскую сборку по примеру сборки CarLibrary из урока,
    // сборка будет использоваться для работы с конвертером температуры.
    public class Temperature
    {
        public double ConvertToFahrenheit(double temperature)
        {
            return temperature * 9 / 5 + 32;
        }
    }
}
