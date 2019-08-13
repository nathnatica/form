using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Candle
    {
        public string code;
        public int date;
        public int time;
        public int startprice;
        public int endprice;
        public int highprice;
        public int lowprice;
        public int volume;

        public int avg5;
        public int avg20;
        public int avg120;

        public Boolean IsPlus()
        {
            return startprice < endprice;
        }

        public Boolean IsMinus()
        {
            return startprice > endprice;
        }

        public Boolean IsBodySizePercent(float target)
        {
            return (Math.Abs(startprice - endprice) * 100 / startprice) <= target;
        } 


    }
}
