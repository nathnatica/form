using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Check
    {
        public static void CheckThreeData(ThreeData d, String buyRule, Orders orders)
        {
            if (d.array == null)
            {
                return;
            }

            orders.checkTotal += 1;
            Order order = null;
            for (int i = d.dayStartIdx; i < d.array.Length; i++)
            {
                int checkIdx = i;

                if (order == null)
                {
                    order = BuyCheck(d, i, buyRule);
                }
                else
                {
                    order = SellCheck(d, i, order);

                    if (order.status != "S")
                    {
                        orders.AddOrder(order);
                        order = null;
                    }
                }
            }
        }

        private static Order SellCheck(ThreeData data, int checkIdx, Order order)
        {
            float lossCut = 3;
            float lossCutPrice = order.buyPrice - (order.buyPrice * lossCut / 100);

            float profitCut = 3;
            float profitCutPrice = order.buyPrice + (order.buyPrice * profitCut / 100);

            if (data.array[checkIdx] != null)
            {
                int currentPrice = (data.array[checkIdx].startprice + data.array[checkIdx].endprice) / 2;
                if (lossCutPrice >= currentPrice)
                {
                    //Console.WriteLine("LOSSCUT CURRENT PRICE : " + lossCutPrice);
                    order.status = "F";
                    order.sellDate = data.array[checkIdx].date;
                    order.sellTime = data.array[checkIdx].time;
                    order.sellPrice = currentPrice;
                }
                else if (lossCutPrice >= data.array[checkIdx].endprice)
                {
                    order.status = "F";
                    order.sellDate = data.array[checkIdx].date;
                    order.sellTime = data.array[checkIdx].time;
                    order.sellPrice = data.array[checkIdx].endprice;
                }
                else if (lossCutPrice >= data.array[checkIdx].lowprice)
                {
                    order.status = "F";
                    order.sellDate = data.array[checkIdx].date;
                    order.sellTime = data.array[checkIdx].time;
                    order.sellPrice = data.array[checkIdx].lowprice;
                }
                else if (profitCutPrice <= data.array[checkIdx].startprice)
                {
                    order.status = "W";
                    order.sellDate = data.array[checkIdx].date;
                    order.sellTime = data.array[checkIdx].time;
                    order.sellPrice = data.array[checkIdx].startprice;
                }
                else if (profitCutPrice <= data.array[checkIdx].endprice)
                {
                    order.status = "W";
                    order.sellDate = data.array[checkIdx].date;
                    order.sellTime = data.array[checkIdx].time;
                    order.sellPrice = data.array[checkIdx].endprice;
                }
                else if (profitCutPrice <= data.array[checkIdx].startprice)
                {
                    order.status = "W";
                    order.sellDate = data.array[checkIdx].date;
                    order.sellTime = data.array[checkIdx].time;
                    order.sellPrice = data.array[checkIdx].highprice;
                }
            }
            return order;
        }

        private static Order BuyCheck(ThreeData data, int checkIdx, string ruleString)
        {
            if (BuyRule.Judge(data, checkIdx, ruleString) == false)
            {
                return null;
            } else
            {
                Order order = new Order();
                order.status = "S";
                order.code = data.array[checkIdx].code;
                order.buyDate = data.array[checkIdx].date;
                order.buyTime = data.array[checkIdx].time;
                order.buyPrice = data.array[checkIdx].endprice;
                return order;
            }
        }
    }
}
