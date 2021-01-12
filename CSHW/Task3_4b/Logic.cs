using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_4b
{
    class Logic
    {
        private int sec;
        public string Tick()
        {
            sec++;
            var outputStringBuilder = new StringBuilder();

            if ((sec / 60).ToString().Length == 1)
            {
                outputStringBuilder.Append("0");
            }

            outputStringBuilder.Append(sec / 60).Append(" : ");

            if ((sec % 60).ToString().Length == 1)
            {
                outputStringBuilder.Append("0");
            }

            outputStringBuilder.Append(sec % 60);

            return outputStringBuilder.ToString();
        }
        public void Reset()
        {
            sec = 0;
        }
    }
}

