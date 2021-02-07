using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_1
{
    class Program
    {
        // Используя Visual Studio, создайте проект по шаблону Console Application. 
        // Создайте программу в которой создайте класс и примените к его методам атрибут Obsolete сначала в форме,
        // просто выводящей предупреждение, а затем в форме, препятствующей компиляции.
        // Продемонстрируйте работу атрибута на примере вызова данных методов.

        static void Main(string[] args)
        {
            MyClass instance = new MyClass();

            instance.ShowMessage();

            // instance.ShowError();

            Console.ReadKey();
        }
    }
}
