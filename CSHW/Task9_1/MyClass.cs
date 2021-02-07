using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_1
{
    class MyClass
    {
        [Obsolete("This method is obsolete")]
        public void ShowMessage()
        {
            Console.WriteLine("Obsolete method");
        }

        [Obsolete("This method is not used anymore", true)]
        public void ShowError()
        {
            Console.WriteLine("Not used method");
        }
    }
}
