using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxKHOpenAPILib;

namespace WindowsFormsApp1
{
    class ControlOrder
    {
        public AxKHOpenAPI axKHOpenAPI1;
        public Control control;
        public ControlAccount account;

        public void Buy(String code, int count)
        {
            if (control.IsRealtimeMode())
            {
                //계좌 선택 여부 확인
                if (account.currentAccount.Length != 10)
                {
                    MessageBox.Show("계좌를 선택해주세요.");
                    return;
                }
                else
                {
                    //주문하기
                    int lRet = axKHOpenAPI1.SendOrder("주식주문", "7001", account.currentAccount.Trim(), 1, code, count, 0, "03", "");

                    if (lRet == 0)
                    {
                        control.Print("Buy 주문이 전송 되었습니다");
                    }
                    else
                    {
                        control.Print("Buy 주문이 전송 실패 하였습니다.");
                    }
                }
            }
        }

        public void Sell(String code, int count)
        {
            if (control.IsRealtimeMode())
            {
                //계좌 선택 여부 확인
                if (account.currentAccount.Length != 10)
                {
                    MessageBox.Show("계좌를 선택해주세요.");
                    return;
                }
                else
                {
                    //주문하기
                    int lRet = axKHOpenAPI1.SendOrder("주식주문", "7001", account.currentAccount.Trim(), 2, code, count, 0, "03", "");

                    if (lRet == 0)
                    {
                        control.Print("Sell 주문이 전송 되었습니다");
                    }
                    else
                    {
                        control.Print("Sell 주문이 전송 실패 하였습니다.");
                    }
                }
            }
        }


    }
}
