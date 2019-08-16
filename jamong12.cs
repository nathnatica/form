using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class jamong12
    {
        const int DELAY_TIME = 120;
        private int _scrNum = 5000;
        List<ConditionInfo> conditionList;
        Boolean isAutoTrading = false;

        List<StockBalance> stockBalanceList;

        int realConditionCount = 0;
        public string currentAccount = "";
        private static System.Timers.Timer timer;

        public jamong12()
        {
            InitializeComponent();

            this.axKHOpenAPI1.OnEventConnect += this.axKHOpenAPI_OnEventConnect;

            this.axKHOpenAPI1.OnReceiveConditionVer += this.axKHOpenAPI_OnReceiveConditionVer;
            this.axKHOpenAPI1.OnReceiveTrCondition += this.axKHOpenAPI_OnReceiveTrCondition;
            this.axKHOpenAPI1.OnReceiveRealCondition += this.axKHOpenAPI_OnReceiveRealCondition;
            this.axKHOpenAPI1.OnReceiveTrData += this.axKHOpenAPI_OnReceiveTrData;
            this.axKHOpenAPI1.OnReceiveRealData += this.axKHOpenAPI_OnReceiveRealData;
            this.axKHOpenAPI1.OnReceiveChejanData += this.axKHOpenApi_OnReceiveChejanData;

            this.getConditionButton.Click += this.button_Clicked;
            this.setRealButton.Click += this.button_Clicked;
            this.removeRealButton.Click += this.button_Clicked;
            this.autoTradingbutton.Click += this.button_Clicked;

            this.conditionGridView.SelectionChanged += this.DataGridView_SelectionChanged;

            if (axKHOpenAPI1.CommConnect() != 0)
                System.Windows.Forms.MessageBox.Show("로그인 실패");
        }


        private void axKHOpenAPI_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                //로그인 성공
                string[] acountArray = axKHOpenAPI1.GetLoginInfo("ACCNO").Split(';');
                this.accountComboBox.Items.AddRange(acountArray);
                this.accountComboBox.SelectedIndex = 0;

                if (accountComboBox.SelectedItem.ToString().Length > 0)
                {
                    currentAccount = accountComboBox.SelectedItem.ToString();
                    requestAccountInfo();
                    requestProfitInfo();

                    timer = new System.Timers.Timer(2000);
                    timer.Elapsed += new ElapsedEventHandler(timeEvent);
                    timer.Start();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("로그인 실패");
            }
        }

        private void timeEvent(Object source, ElapsedEventArgs e)
        {
            requestAccountInfo();
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            if (sender.Equals(getConditionButton))
            {
                int result = axKHOpenAPI1.GetConditionLoad();
                if (result > 0)
                    getConditionButton.Visible = false;
            }
            else if (sender.Equals(setRealButton))
            {
                if (conditionGridView.SelectedCells.Count > 0)
                {
                    int index = conditionGridView.SelectedCells[0].RowIndex;

                    if (getCurrentTime() - conditionList[index].lastRequestTime < DELAY_TIME)
                    {
                        System.Windows.Forms.MessageBox.Show(DELAY_TIME - (getCurrentTime() - conditionList[index].lastRequestTime) + "초 뒤에 가능");
                    }
                    else
                    {
                        int result = axKHOpenAPI1.SendCondition( GetScrNum(),
                        conditionGridView[1, index].Value.ToString(),
                        int.Parse(conditionGridView[0, index].Value.ToString()), 1 );

                        if (result > 0)
                        {
                            conditionList[index].stockItemList = new List<StockItemInfo>();
                            conditionList[index].실시간등록여부 = true;
                            setRealButton.Visible = false;
                            removeRealButton.Visible = true;
                            realConditionCount++;
                            countLabel.Text = realConditionCount + "";
                            conditionList[index].lastRequestTime = getCurrentTime();

                            conditionGridView.Rows[index].DefaultCellStyle.BackColor = Color.OrangeRed;
                        }
                    }
                }
            }
            else if (sender.Equals(removeRealButton))
            {
                if (conditionGridView.SelectedCells.Count > 0)
                {
                    int index = conditionGridView.SelectedCells[0].RowIndex;
                    axKHOpenAPI1.SendConditionStop(
                      GetScrNum(),
                      conditionGridView[1, index].Value.ToString(),
                      int.Parse(conditionGridView[0, index].Value.ToString())
                    );

                    conditionList[index].실시간등록여부 = false;
                    removeRealButton.Visible = false;
                    setRealButton.Visible = true;
                    realConditionCount--;
                    countLabel.Text = realConditionCount + "";
                    conditionGridView.Rows[index].DefaultCellStyle.BackColor = Color.White;
                }
            }
            else if (sender.Equals(autoTradingbutton))
            {
                if (isAutoTrading)
                {
                    autoTradingbutton.Text = "자동매매 시작";
                    isAutoTrading = false;
                }
                else
                {
                    autoTradingbutton.Text = "자동매매중...";
                    isAutoTrading = true;
                }
            }
        }

        private void axKHOpenAPI_OnReceiveConditionVer(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
        {
            conditionList = new List<ConditionInfo>();

            String conditionNameList = axKHOpenAPI1.GetConditionNameList();
            String[] conditionNameArray = conditionNameList.Split(';');

            for (int i = 0; i < conditionNameArray.Length; i++)
            {
                String[] conditionInfo = conditionNameArray[i].Split('^');
                if (conditionInfo.Length == 2)
                {
                    conditionList.Add(new ConditionInfo()
                    {
                        조건식번호 = int.Parse(conditionInfo[0].Trim()),
                        조건식이름 = conditionInfo[1].Trim()
                    });
                }
            }
            conditionGridView.DataSource = conditionList;
            conditionGridView.ReadOnly = true;
        }


        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.Equals(this.conditionGridView))
            {
                if (dataGridView.SelectedCells.Count > 0)
                {
                    int index = dataGridView.SelectedCells[0].RowIndex;

                    if (dataGridView.ColumnCount == 2)
                    {
                        stockItemGridView.Rows.Clear();

                        if (conditionList[index].실시간등록여부)
                        {
                            setRealButton.Visible = false;
                            removeRealButton.Visible = true;
                        }
                        else
                        {
                            setRealButton.Visible = true;
                            removeRealButton.Visible = false;
                        }

                        if (conditionList[index].stockItemList != null)
                        {
                            List<StockItemInfo> stockItemInfo = conditionList[index].stockItemList;
                            for (int i = 0; i < stockItemInfo.Count; i++)
                            {
                                stockItemGridView.Rows.Add();
                                stockItemGridView["종목명", stockItemGridView.RowCount - 2].Value = stockItemInfo[i].종목명;
                                stockItemGridView["현재가", stockItemGridView.RowCount - 2].Value = stockItemInfo[i].현재가;
                                stockItemGridView["전일대비", stockItemGridView.RowCount - 2].Value = stockItemInfo[i].전일대비;
                                stockItemGridView["등락률", stockItemGridView.RowCount - 2].Value = stockItemInfo[i].등락률;
                                stockItemGridView["거래량", stockItemGridView.RowCount - 2].Value = stockItemInfo[i].거래량;
                                stockItemGridView["시가", stockItemGridView.RowCount - 2].Value = stockItemInfo[i].시가;
                                stockItemGridView["고가", stockItemGridView.RowCount - 2].Value = stockItemInfo[i].고가;
                                stockItemGridView["저가", stockItemGridView.RowCount - 2].Value = stockItemInfo[i].저가;
                            }
                        }
                        else
                        {
                            int result = axKHOpenAPI1.SendCondition(
                            GetScrNum(),
                            dataGridView[1, index].Value.ToString(),
                            int.Parse(dataGridView[0, index].Value.ToString()),
                            0
                            );

                            if (result > 0)
                            {
                                Console.WriteLine("조건검색 성공");
                                conditionList[index].stockItemList = new List<StockItemInfo>();
                                conditionList[index].lastRequestTime = getCurrentTime();
                            }
                            else
                            {
                                Console.WriteLine("조건검색 실패");
                            }
                        }
                    }
                }
            }
        }

        private void axKHOpenAPI_OnReceiveTrCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
        {
            String codeList = e.strCodeList.Trim();
            if (codeList.Length > 0)
                codeList = codeList.Remove(codeList.Length - 1);
            int nCodeCount = codeList.Trim().Split(';').Length;

            if (e.nNext == 2)    //추가 종목 정보
            {
                axKHOpenAPI1.SendCondition( e.sScrNo, e.strConditionName, e.nIndex, 2 );
            }
            axKHOpenAPI1.CommKwRqData(codeList, 0, nCodeCount, 0, "관심종목정보", GetScrNum());

        }

        private void axKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName == "관심종목정보")
            {
                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);

                for (int i = 0; i < nCnt; i++)
                {
                    String _종목명 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "종목명").Trim();
                    String _현재가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim();
                    String _전일대비 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "전일대비").Trim();
                    String _등락율 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "등락율").Trim();
                    String _거래량 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "거래량").Trim();
                    String _시가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "시가").Trim();
                    String _고가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "고가").Trim();
                    String _저가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "저가").Trim();

                    int index = conditionGridView.SelectedCells[0].RowIndex;
                    conditionList[index].stockItemList.Add(new StockItemInfo()
                    {
                        종목명 = _종목명,
                        현재가 = _현재가,
                        전일대비 = _전일대비,
                        등락률 = _등락율,
                        거래량 = _거래량,
                        시가 = _시가,
                        고가 = _고가,
                        저가 = _저가
                    });

                    stockItemGridView.Rows.Add();
                    stockItemGridView["종목명", stockItemGridView.RowCount - 2].Value = _종목명;
                    stockItemGridView["현재가", stockItemGridView.RowCount - 2].Value = _현재가;
                    stockItemGridView["전일대비", stockItemGridView.RowCount - 2].Value = _전일대비;
                    stockItemGridView["등락률", stockItemGridView.RowCount - 2].Value = _등락율;
                    stockItemGridView["거래량", stockItemGridView.RowCount - 2].Value = _거래량;
                    stockItemGridView["시가", stockItemGridView.RowCount - 2].Value = _시가;
                    stockItemGridView["고가", stockItemGridView.RowCount - 2].Value = _고가;
                    stockItemGridView["저가", stockItemGridView.RowCount - 2].Value = _저가;
                }
            }
            else if (e.sRQName == "계좌평가내역요청")
            {
                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                stockBalanceList = new List<StockBalance>();

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

                    if (수익률 > 1)
                    {
                        sellOrder(종목코드, 잔고수량);
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
            else if (e.sRQName.Length > 8)
            {
                if (e.sRQName.Substring(0, 8).Equals("주식기본정보요청"))
                {
                    String[] str = e.sRQName.Split(';');
                    if (str.Length == 2)
                    {
                        String 조건명인덱스 = str[1];
                        String _종목코드 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();
                        String _종목명 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목명").Trim();
                        String _현재가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim();
                        String _전일대비 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "전일대비").Trim();
                        String _등락율 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "등락율").Trim();
                        String _거래량 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래량").Trim();
                        String _시가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "시가").Trim();
                        String _고가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "고가").Trim();
                        String _저가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "저가").Trim();

                        try
                        {
                            buyOrder(_종목코드, 100000 / int.Parse(_현재가));

                            int index = conditionGridView.SelectedCells[0].RowIndex;
                            if (int.Parse(조건명인덱스) == int.Parse(conditionGridView["조건식번호", index].Value.ToString()))
                            {
                                stockItemGridView.Rows.Add();
                                stockItemGridView["종목명", stockItemGridView.RowCount - 2].Value = _종목명;
                                stockItemGridView["현재가", stockItemGridView.RowCount - 2].Value = _현재가;
                                stockItemGridView["전일대비", stockItemGridView.RowCount - 2].Value = _전일대비;
                                stockItemGridView["등락률", stockItemGridView.RowCount - 2].Value = _등락율;
                                stockItemGridView["거래량", stockItemGridView.RowCount - 2].Value = _거래량;
                                stockItemGridView["시가", stockItemGridView.RowCount - 2].Value = _시가;
                                stockItemGridView["고가", stockItemGridView.RowCount - 2].Value = _고가;
                                stockItemGridView["저가", stockItemGridView.RowCount - 2].Value = _저가;
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message.ToString());
                        }

                    }
                }
            }

        }

        private void axKHOpenAPI_OnReceiveRealCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
        {
            String 종목코드 = e.sTrCode;
            String 조건식이름 = e.strConditionName;
            String 조건명인덱스 = e.strConditionIndex;
            if (e.strType.Equals("I"))  //종목편입
            {
                itemInsertListBox.Items.Insert(0, "[" + 조건명인덱스 + "." + 조건식이름 + "] : " + 종목코드);

                axKHOpenAPI1.SetInputValue("종목코드", 종목코드);
                axKHOpenAPI1.CommRqData("주식기본정보요청;" + 조건명인덱스, "opt10001", 0, GetScrNum());
            }
            else if (e.strType.Equals("D")) //종목이탈
            {
                itemDeleteListBox.Items.Insert(0, "[" + 조건명인덱스 + "." + 조건식이름 + "] : " + 종목코드);
            }
            Console.WriteLine(e.strConditionIndex + " 종목명:" + e.sTrCode + " -" + e.strType);
        }

        private void axKHOpenAPI_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {

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
                    requestAccountInfo();
                    requestProfitInfo();
                }
            }
        }

        private string GetScrNum()
        {
            if (_scrNum < 9999)
                _scrNum++;
            else
                _scrNum = 5000;
            return _scrNum.ToString();
        }

        private void buyOrder(String 종목코드, int 수량)
        {
            if (isAutoTrading)
            {
                //계좌 선택 여부 확인
                if (accountComboBox.Text.Length != 10)
                {
                    System.Windows.Forms.MessageBox.Show("계좌를 선택해주세요.");
                    return;
                }
                else
                {
                    //주문하기
                    int lRet = axKHOpenAPI1.SendOrder("주식주문", GetScrNum(), this.accountComboBox.Text.Trim(), 1, 종목코드, 수량, 0, "03", "");

                    if (lRet == 0)
                    {
                        Console.WriteLine("주문이 전송 되었습니다");
                    }
                    else
                    {
                        Console.WriteLine("주문이 전송 실패 하였습니다.");
                    }
                }
            }
        }
        private void sellOrder(String 종목코드, int 수량)
        {
            if (isAutoTrading)
            {
                //계좌 선택 여부 확인
                if (accountComboBox.Text.Length != 10)
                {
                    System.Windows.Forms.MessageBox.Show("계좌를 선택해주세요.");
                    return;
                }
                else
                {
                    //주문하기
                    int lRet = axKHOpenAPI1.SendOrder("주식주문", GetScrNum(), this.accountComboBox.Text.Trim(), 2, 종목코드, 수량, 0, "03", "");

                    if (lRet == 0)
                    {
                        Console.WriteLine("주문이 전송 되었습니다");
                    }
                    else
                    {
                        Console.WriteLine("주문이 전송 실패 하였습니다.");
                    }
                }
            }
        }

        private void requestAccountInfo()
        {
            axKHOpenAPI1.SetInputValue("계좌번호", currentAccount);
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");

            int result = axKHOpenAPI1.CommRqData("계좌평가내역요청", "opw00018", 0, GetScrNum());
        }
        private void requestProfitInfo()
        {
            axKHOpenAPI1.SetInputValue("계좌번호", currentAccount);
            axKHOpenAPI1.SetInputValue("시작일자", DateTime.Now.ToString("yyyyMMdd"));
            axKHOpenAPI1.SetInputValue("종료일자", DateTime.Now.ToString("yyyyMMdd"));

            int result = axKHOpenAPI1.CommRqData("일자별실현손익요청", "opt10074", 0, GetScrNum());
        }

        private double getCurrentTime()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
            return double.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
        }

    }

    class ConditionInfo
    {
        public int 조건식번호 { get; set; }
        public String 조건식이름 { get; set; }
        public Boolean 실시간등록여부 = false;
        public double lastRequestTime;

        public List<StockItemInfo> stockItemList;
    }

    class StockItemInfo
    {
        public String 종목명 { get; set; }
        public String 현재가 { get; set; }
        public String 전일대비 { get; set; }
        public String 등락률 { get; set; }
        public String 거래량 { get; set; }
        public String 시가 { get; set; }
        public String 고가 { get; set; }
        public String 저가 { get; set; }
    }

    class StockBalance
    {
        public String 종목명 { get; set; }
        public String 종목코드 { get; set; }
        public String 잔고수량 { get; set; }
        public String 매입금액 { get; set; }
        public String 평가금액 { get; set; }
        public String 손익금액 { get; set; }
        public String 수익률 { get; set; }
    }
}
 

