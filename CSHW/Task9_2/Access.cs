using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_2
{
    enum AccessLevelControl
    {
        Max,
        Middle,
        Min
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class AccessLevelAttribute : Attribute
    {
        readonly AccessLevelControl accessLevel;

        public AccessLevelAttribute(AccessLevelControl accessLevel)
        {
            this.accessLevel = accessLevel;
        }

        public AccessLevelControl AccessLevel
        {
            get { return accessLevel; }
        }
    }
}
