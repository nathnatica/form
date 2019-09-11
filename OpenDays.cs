using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class OpenDays
    {
        private static int todayIdx;
        private static List<Int32> days = new List<Int32>();

        public OpenDays()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "\\opendays.txt"));
            foreach (string line in lines)
            {
                days.Add(Int32.Parse(line.Trim()));
            }
        }

        public static void SetToday(string day)
        {
            SetToday(Convert.ToInt32(day));
        }

        public static void SetToday(int day)
        {
            todayIdx = days.IndexOf(day);
        }

        public static int GetToday()
        {
            return days[todayIdx];
        }

        public static int GetPrevDay(int offset)
        {
            return days[todayIdx - offset];
        }

        public static int GetNextDay(int offset)
        {
            return days[todayIdx + offset];
        }

    }
}
