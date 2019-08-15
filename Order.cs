
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Order
    {
        public string status;
        public string code;
        public string name;
        public int buyPrice;
        public int buyDate;
        public int buyTime;
        public int sellPrice;
        public int sellDate;
        public int sellTime;

        public decimal GetProfit()
        {
            return Util.NumberFormat((sellPrice - buyPrice) * 100.0f / buyPrice);
        }


        public string GetSummary()
        {
            return "[ ] CODE : " + code + ", BUY  : " + buyPrice + ", AT " + buyDate + " " + buyTime + "\n" + 
                "[" + status + "] CODE : " + code + ", SELL : " + sellPrice + ", AT " + sellDate + " " + sellTime + "\t" + GetProfit() + "%";
        }

    }
}
