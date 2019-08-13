using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Check
    {
        public static void ThreeDataCheck(ThreeData d, Orders orders)
        {
            orders.checkTotal += 1;
            Order order = null;
            for (int i = d.dayStartIdx; i < d.array.Length; i++)
            {
                int checkIdx = i;

                if (order == null)
                {
                    order = BuyCheck(d, i);
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

            if (lossCutPrice >= data.array[checkIdx].endprice)
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

            return order;
        }

        private static Order BuyCheck(ThreeData data, int checkIdx)
        {
            // rule check and if ng then return null


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
