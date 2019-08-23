using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxKHOpenAPILib;

namespace WindowsFormsApp1
{
    class ControlAccount
    {
        public AxKHOpenAPI axKHOpenAPI1;
        public Control control;

        public string currentAccount = "";

        public void LoginClick(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.CommConnect() != 0)
            {
                control.Print("로그인 실패");
            }
            else
            {
                control.Print("로그인 시작");
            }
        }
        public void LogoutClick(object sender, EventArgs e)
        {
            axKHOpenAPI1.CommTerminate();
            control.Print("로그아웃");
        }

        public void axKHOpenAPI_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                control.Print("로그인 성공");
                int connectState = axKHOpenAPI1.GetConnectState();
                if (connectState == 1)
                {
                    control.Print("접속상태:연결중");
                }
                else
                {
                    control.Print("접속상태:미연결, status:" + connectState);
                }
                this.RefreshAccountInfo();
            }
            else
            {
                control.Print("로그인 실패");
            }
        }

        private void RefreshAccountInfo()
        {
            control.Print("LOGIN USER ID : " + axKHOpenAPI1.GetLoginInfo("USER_ID"));
            control.Print("LOGIN USER NAME : " + axKHOpenAPI1.GetLoginInfo("USER_NAME"));

            string[] accountArray = axKHOpenAPI1.GetLoginInfo("ACCNO").Split(';');
            control.accountComboBox.Items.AddRange(accountArray);
            control.accountComboBox.SelectedIndex = 0;
            if (control.accountComboBox.SelectedItem.ToString().Length > 0)
            {
                currentAccount = control.accountComboBox.SelectedItem.ToString();
                SendRequestAccountInfo();
                SendRequestProfitInfo();
            }
        }
        public void SendRequestAccountInfo()
        {
            axKHOpenAPI1.SetInputValue("계좌번호", currentAccount);
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");

            int result = axKHOpenAPI1.CommRqData("계좌평가내역요청", "OPW00018", 0, Util.GetScrNum());
        }

        public void SendRequestProfitInfo()
        {
            axKHOpenAPI1.SetInputValue("계좌번호", currentAccount);
            axKHOpenAPI1.SetInputValue("시작일자", DateTime.Now.ToString("yyyyMMdd"));
            axKHOpenAPI1.SetInputValue("종료일자", DateTime.Now.ToString("yyyyMMdd"));

            int result = axKHOpenAPI1.CommRqData("일자별실현손익요청", "OPT10074", 0, Util.GetScrNum());
        }

        public void accountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedAccount = (string)comboBox.SelectedItem;
            currentAccount = selectedAccount.Trim();
            SendRequestAccountEvaluateInfo();
        }

        private void SendRequestAccountEvaluateInfo()
        {
            axKHOpenAPI1.SetInputValue("계좌번호", currentAccount);
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("상장폐지조회구분", "0");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");

            int result = axKHOpenAPI1.CommRqData("계좌평가현황요청", "OPW00004", 0, "6001");
        }
    }
}
