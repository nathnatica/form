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
        public int checkTotal;
        public int winCount;
        public int loseCount;
        public string rule;

        ArrayList orderList = new ArrayList();

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

        public float GetMatchRate()
        {
            return (winCount + loseCount) / checkTotal * 100;
        }

        public float GetWinningRate()
        {
            return winCount / (winCount + loseCount) * 100;
        }

        public float GetTotalProfitRate()
        {
            float totalProfit = 0;
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
                "MATCHED : " + (winCount + loseCount) + "/" + checkTotal + " (" + GetMatchRate() + ")\n" +
                "WIN  : " + winCount + ", LOSE : " + loseCount + " (" + GetWinningRate() + ")\n" +
                "TOTAL PROFIT : " + GetTotalProfitRate();
        }

    }
}
