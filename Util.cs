using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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

        public static int GetDateNow()
        {
            DateTime now = DateTime.Now;
            //Console.WriteLine(now.Hour);
            //Console.WriteLine(now.Minute);
            int date = (now.Year * 10000) + (now.Month * 100) + now.Day;
            return date; ;
        }

        public static Int32 GetNotNullInT(int idx, MySqlDataReader reader)
        {
            if (reader.IsDBNull(idx))
            {
                return 0;
            } else
            {
                return reader.GetInt32(idx);
            }
        }
        public static string GetNotNullString(int idx, MySqlDataReader reader)
        {
            if (reader.IsDBNull(idx))
            {
                return "";
            } else
            {
                return reader.GetString(idx);
            }
        }
    }
}
