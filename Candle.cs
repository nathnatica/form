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
            // current price ???
            return (Math.Abs(startprice - endprice) * 100.0f / startprice) <= target;
        } 

        public Boolean IsAvg5UpperThanAvg20()
        {
            return avg5 > avg20;
        }
        public Boolean IsAvg20UpperThanAvg120()
        {
            return avg20 > avg120;
        }

        public Boolean IsAvgGolden()
        {
            return IsAvg5UpperThanAvg20() && IsAvg20UpperThanAvg120();
        }

        public Boolean IsIncludeTime(int start, int end)
        {
            return start <= time && time <= end;
        }

        public Boolean IsExcludeTime(int start, int end)
        {
            return !IsIncludeTime(start, end);
        }
    }
}
