using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task10_3
{
    public class EmployeeAttr
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Age { get; set; }

        public EmployeeAttr(string name, int speed)
        {
            Name = name;
            Age = speed;
        }

        public EmployeeAttr()
        {

        }
    }
}
