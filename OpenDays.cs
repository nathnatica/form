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
        private int todayIdx;
        private List<Int32> days = new List<Int32>();

        public OpenDays()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "\\opendays.txt"));
            foreach (string line in lines)
            {
                days.Add(Int32.Parse(line.Trim()));
            }
        }

        public void SetToday(string day)
        {
            this.SetToday(Convert.ToInt32(day));
        }

        public void SetToday(int day)
        {
            todayIdx = days.IndexOf(day);
        }

        public int GetPrevDay(int offset)
        {
            return days[todayIdx - offset];
        }

        public int GetNextDay(int offset)
        {
            return days[todayIdx + offset];
        }

    }
}
