using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Util
    {
        public static int ConvertTimetoIndex(int time)
        {
            int hour = time / 100;
            int minute = time - (hour * 100);
            return (hour - 9) * 20 + (minute / 3);
        }

        public static decimal NumberFormat(float f)
        {
            return Math.Round(Convert.ToDecimal(f), 2);
        }
    }
}
