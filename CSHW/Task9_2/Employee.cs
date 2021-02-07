using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_2
{
    class Employee
    {

    }

    [AccessLevel(AccessLevelControl.Min)]
    class Manager : Employee
    {

    }

    [AccessLevel(AccessLevelControl.Middle)]
    class Programmer : Employee
    {

    }

    [AccessLevel(AccessLevelControl.Max)]
    class Director : Employee
    {

    }
}
