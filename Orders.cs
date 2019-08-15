using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Orders
    {
        public int date;
        public int checkTotal;
        public int winCount;
        public int loseCount;
        public string rule;

        public ArrayList orderList = new ArrayList();

        public void AddOrder(Order order)
        {
            if (order.status == "F")
            {
                loseCount += 1;
            }
            else
            {
                winCount += 1;
            }
            orderList.Add(order);
        }

        public decimal GetMatchRate()
        {
            return Util.NumberFormat((winCount + loseCount) * 100.0f / checkTotal);
        }

        public decimal GetWinningRate()
        {
            if (winCount + loseCount > 0)
            {
                return Util.NumberFormat(winCount * 100.0f / (winCount + loseCount));
            } else
            {
                return 0;
            }
        }

        public decimal GetTotalProfitRate()
        {
            decimal totalProfit = 0;
            foreach (Order item in orderList)
            {
                totalProfit += item.GetProfit();
            }
            return totalProfit;
        }

        public void Evaluate()
        {
            foreach (Order o in orderList)
            {
                Console.WriteLine(o.GetSummary());
            }
            Console.WriteLine(this.GetSummary());
        }

        public string GetSummary()
        {
            return "==========================\n" +
                "MATCHED      : " + (winCount + loseCount) + "/" + checkTotal + " (" + GetMatchRate() + "%)\n" +
                "WIN/LOSE     : " + winCount + "/" + loseCount + " (" + GetWinningRate() + "%)\n" +
                "TOTAL PROFIT : " + GetTotalProfitRate() + "%";
        }

    }
}
