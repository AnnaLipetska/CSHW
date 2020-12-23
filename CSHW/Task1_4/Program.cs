using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_4
{
    class Program
    {
        //Является ли сравнение time и null в выражении if валидным? Почему?
        static void Main()
        {
            DateTime time;
            //time = null; //DateTime is a non-nullable value

            //if (time == null) // Ругается
            {
                /* do something */
            }
        }

        // По ссылке
        // https://proglib.io/p/8-csharp-questions?action=answer&comment=3a308071-b9fe-40bb-a565-57b5fa5dc628
        // пишут:

        // Можно подумать, что компилятор будет жаловаться, когда переменная DateTime сравнивается с нулем.
        // Однако компилятор действительно допускает это, что может потенциально привести к ошибкам headfake
        // и pull-out-your-hair.

        // Однако это может привести к неожиданному поведению, как это происходит при сравнении DateTime и null.
        // В этом случае, как DateTime, так и null могут перейти к Nullable<DateTime>.
        // Поэтому можно сравнивать два значения, но результат всегда будет ложным.
    }
}
