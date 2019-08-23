using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Dao dao = new Dao();

        Control control = new Control();
        ControlAccount account = new ControlAccount();
        ControlOrder order = new ControlOrder();
        ControlStock stock = new ControlStock();

        public Form1()
        {
            InitializeComponent();

            this.button2.Click += this.ThreeAddClick;
            this.button3.Click += this.ThreeGetClick;
            this.rebuild.Click += this.Rebuild;
            this.button4.Click += this.Simulate;

            this.axKHOpenAPI1.OnReceiveTrData += this.axKHOpenAPI_OnReceiveTrData;
            this.axKHOpenAPI1.OnReceiveRealData += this.axKHOpenAPI_OnReceiveRealData;
            this.axKHOpenAPI1.OnReceiveChejanData += this.axKHOpenApi_OnReceiveChejanData;

            this.loginButton.Click += account.LoginClick;
            this.logoutButton.Click += account.LogoutClick;
            this.axKHOpenAPI1.OnEventConnect += account.axKHOpenAPI_OnEventConnect;
            this.accountComboBox.SelectedIndexChanged += account.accountComboBox_SelectedIndexChanged;

            this.refresh.Click += control.ItemRefreshClick;
            this.itemGridView.CellContentClick += control.ItemGridView_CellContentClick;

            Util.GetDateNow(); // TODO 

            this.simulateRadioButton.CheckedChanged += control.SimulateRadioButton_CheckedChanged;
            this.realtimeRadioButton.CheckedChanged += control.RealtimeRadioButton_CheckedChanged;

            // init control
            control.console = this.console;
            control.itemGridView = this.itemGridView;
            control.accountComboBox = this.accountComboBox;
            control.dao = this.dao;

            // init account
            account.axKHOpenAPI1 = this.axKHOpenAPI1;
            account.control = this.control;

            // init order
            order.axKHOpenAPI1 = this.axKHOpenAPI1;
            order.control = this.control;
            order.account = this.account;


            // init screen data
            this.simulateRadioButton.Checked = true;
            this.codeTextBox.Text = "0001";
            this.startDateTextBox.Text = Convert.ToString(20190814);
            this.endDateTextBox.Text = Convert.ToString(20190814);


        }

        private void ThreeAddClick(object sender, EventArgs e)
        {
            for (int i = 1; i <= 4; i++) {
                ArrayList array = new ArrayList();
                string[] lines = File.ReadAllLines("C:\\TEMP\\" + i + ".txt");
                foreach (string line in lines)
                {
                    string[] sp = line.Split('\t');
                    Candle three = new Candle();
                    three.code = sp[0];
                    three.date = Int32.Parse(sp[1]);
                    three.time = Int32.Parse(sp[2]);
                    three.startprice = Int32.Parse(sp[3]);
                    three.endprice = Int32.Parse(sp[4]);
                    three.highprice = Int32.Parse(sp[5]);
                    three.lowprice = Int32.Parse(sp[6]);
                    three.volume = Int32.Parse(sp[7]);
                    array.Add(three);
                }
                dao.InsertThreeData(array);
            }
        }

        private void ThreeGetClick(object sender, EventArgs e)
        {
            //ThreeData d = this.GetThreeData("0001", Int32.Parse(this.textBox1.Text), Int32.Parse(this.textBox2.Text));
            string code = "0001";
            int checkDate = 20190814;
            ThreeData d = GetThreeData(code, checkDate, 2);
            d.Print(); // TODO for check

            //string buyRule = "IsPlus&IsAvgGolden&IsIncludeTime 930,1430&IsUpperThanDayStartPrice&IsAvg5ChangeToUp&IsAvg120Rising -10,-5";

            ArrayList ordersArray = new ArrayList();

            HashSet<string> ruleSet = BuyRule.Pattern.GetMassRule();
            Console.WriteLine("[CHECK] RULE TOTAL : " + ruleSet.Count());

            foreach (string buyRule in ruleSet)
            {
                Orders orders = new Orders();
                Check.CheckThreeData(d, buyRule, orders);
                if (orders.orderList.Count > 0)
                {
                    orders.rule = buyRule;
                    orders.date = Util.GetDateNow();
                    ordersArray.Add(orders);
                    //orders.Evaluate();
                }
            }

            Console.WriteLine("INSERT TO EVALUATE START");
            dao.InsertEvaluateData(ordersArray);
            Console.WriteLine("INSERT TO EVALUATE END");
        }

        private void Simulate(object sender, EventArgs e)
        {
            string code = "0001";
            int start = Int32.Parse(this.startDateTextBox.Text);
            int end = Int32.Parse(this.endDateTextBox.Text);
            string rule = "IsAvg5Rising -1,0&IsAvg20Rising -2,0";

            Orders orders = new Orders();

            ArrayList codeList = new ArrayList();
            codeList.Add(code);
            SingleRuleSimulate(start, end, codeList, rule, orders);

            if (orders.orderList.Count > 0)
            {
                orders.rule = rule;
                orders.date = Util.GetDateNow();
                orders.Evaluate();
            }
        }

        private void SingleRuleSimulate(int startDate, int endDate, ArrayList codeList, string buyRule, Orders orders)
        {
            foreach (string code in codeList)
            {
                SingleRuleSimulate(startDate, endDate, code, buyRule, orders);
            }
        }

        private void SingleRuleSimulate(int startDate, int endDate, string code, string buyRule, Orders orders)
        {
            ThreeData d = GetThreeData(code, startDate, 2);
            Check.CheckThreeData(d, buyRule, orders);
            if (d.endDate < endDate)
            {
                SingleRuleSimulate(d.endDate, endDate, code, buyRule, orders);
            }
        }

        private void Rebuild(object sender, EventArgs e)
        {
            this.UpdateAvgData(this.codeTextBox.Text, Int32.Parse(this.startDateTextBox.Text), Int32.Parse(this.endDateTextBox.Text));
        }

        private void UpdateAvgData(string code, int startDate, int endDate)
        {
            ThreeData d = GetThreeData(code, startDate, 2);
            if (d.array != null)
            {
                control.Print("Updated average data from " + startDate + " to " + endDate, code);
                dao.InsertThreeData(new ArrayList(d.array));
                if (d.endDate != 0 && d.startDate != d.endDate && d.endDate <= endDate)
                {
                    UpdateAvgData(code, d.endDate, endDate);
                }
            }
        }

        private ThreeData GetThreeData(string code, int date, int dayCount)
        {
            ThreeData d = new ThreeData();
            Candle[] dbData = dao.GetThreeDataFromDB(code, date, dayCount);
            if (dbData != null && dbData.Length > 0)
            {
                d.AddThreeArray(dbData);
                d.CreateAvgData(0);
            }
            return d;
        }


        private void InquireDayInfo(object sender, EventArgs e)
        {
            string code = this.codeTextBox.Text.Trim();
            string endDate = this.endDateTextBox.Text.Trim();
            stock.InquireDayInfo(code, endDate);
        }


        private void axKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName == "주식일봉차트조회")
            {
                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);

                List<Candle> list = new List<Candle>();
                for (int i = 0; i < nCnt; i++)
                {
                    string code = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();
                    String date = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "일자").Trim();
                    String price = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim();
                    String volume = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래량").Trim();
                    String startPrice = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "시가").Trim();
                    String highPrice = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "고가").Trim();
                    String lowPrice = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "저가").Trim();

                    // TODO

                }
            } else if (e.sRQName == "계좌평가현황요청")
            {
                String profit = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당일투자손익").Trim();
                String profitRate = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당일손익율").Trim();

                // TODO
            }
            else if (e.sRQName == "계좌평가내역요청")
            {
                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                List<StockBalance> stockBalanceList = new List<StockBalance>();

                for (int nIdx = 0; nIdx < nCnt; nIdx++)
                {
                    Double 수익률 = double.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "수익률(%)"));
                    Double 평가손익 = double.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "평가손익").Trim());
                    Double 매입금액 = double.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "매입금액").Trim());
                    Double 손익금액 = 평가손익 - (int)(매입금액 * 0.01);
                    수익률 += -1;

                    String 종목코드 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "종목번호").Trim();
                    int 잔고수량 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "보유수량").Trim());

                    stockBalanceList.Add(new StockBalance()
                    {
                        종목명 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "종목명").Trim(),
                        종목코드 = 종목코드,
                        잔고수량 = 잔고수량.ToString(),
                        매입금액 = 매입금액.ToString(),
                        평가금액 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "평가금액").Trim()) + "",
                        손익금액 = 손익금액.ToString(),
                        수익률 = 수익률.ToString() + "%"
                    });

                    // TODO
                    if (수익률 > 1)
                    {
                        order.Sell(종목코드, 잔고수량);
                    }
                }

                balanceGridView.DataSource = stockBalanceList;
                for (int i = 0; i < stockBalanceList.Count; i++)
                {
                    if (stockBalanceList[i].수익률[0] == '-')
                        balanceGridView["수익률", i].Style.ForeColor = Color.Blue;
                    else if (!stockBalanceList[i].수익률.Equals("0"))
                        balanceGridView["수익률", i].Style.ForeColor = Color.Red;
                }

                totalBuyTextView.Text = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액").TrimStart('0');
                totalEstimateTextView.Text = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총평가금액").TrimStart('0');
                totalProfitTextView.Text = double.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총평가손익금액")).ToString();
                //totalProfitRateTextView.Text = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총수익률(%)").TrimStart('0');
            }
            else if (e.sRQName == "일자별실현손익요청")
            {
                Double 실현손익 = double.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "실현손익"));
                realProfitTextView.Text = 실현손익.ToString();
                if (실현손익 > 0)
                    realProfitTextView.ForeColor = Color.Red;
                else if (실현손익 < 0)
                    realProfitTextView.ForeColor = Color.Blue;
                else
                    realProfitTextView.ForeColor = Color.Black;
            }

        }
        private void axKHOpenAPI_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if (e.sRealType == "주식체결")
            {
                // TODO
            }
        }

        private void axKHOpenApi_OnReceiveChejanData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
            if (e.sGubun == "0")
            {
                string 종목명 = axKHOpenAPI1.GetChejanData(302); //종목명
                string 체결시간 = axKHOpenAPI1.GetChejanData(908); //체결시간
                string 체결가 = axKHOpenAPI1.GetChejanData(910); //체결가
                int 체결량 = 0;
                if (axKHOpenAPI1.GetChejanData(911).Length > 0)
                    체결량 = Int32.Parse(axKHOpenAPI1.GetChejanData(911).Trim()); //체결량

                if (체결량 > 0)
                {
                    account.SendRequestAccountInfo();
                    account.SendRequestProfitInfo();
                }
            }
        }

    }

}
