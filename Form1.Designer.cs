namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inquireButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.startDateTextBox = new System.Windows.Forms.TextBox();
            this.endDateTextBox = new System.Windows.Forms.TextBox();
            this.rebuild = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.ListBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.accountComboBox = new System.Windows.Forms.ComboBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.balanceGridView = new System.Windows.Forms.DataGridView();
            this.종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종목코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.잔고수량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.매입금액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.평가금액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.손익금액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수익률 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.realProfitTextView = new System.Windows.Forms.Label();
            this.totalProfitRateTextView = new System.Windows.Forms.Label();
            this.totalEstimateTextView = new System.Windows.Forms.Label();
            this.totalProfitTextView = new System.Windows.Forms.Label();
            this.totalBuyTextView = new System.Windows.Forms.Label();
            this.RealProfitLabel = new System.Windows.Forms.Label();
            this.totalProfitRateLabel = new System.Windows.Forms.Label();
            this.totalEstimateLabel = new System.Windows.Forms.Label();
            this.totalProfitLabel = new System.Windows.Forms.Label();
            this.totalBuyLabel = new System.Windows.Forms.Label();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.itemGridView = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opt3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.simulateRadioButton = new System.Windows.Forms.RadioButton();
            this.realtimeRadioButton = new System.Windows.Forms.RadioButton();
            this.modePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.targetCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).BeginInit();
            this.modePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // inquireButton
            // 
            this.inquireButton.Location = new System.Drawing.Point(487, 30);
            this.inquireButton.Name = "inquireButton";
            this.inquireButton.Size = new System.Drawing.Size(95, 30);
            this.inquireButton.TabIndex = 16;
            this.inquireButton.Text = "Inquire";
            this.inquireButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(1277, 90);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(103, 46);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1682, 484);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "load file";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1538, 484);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 48);
            this.button3.TabIndex = 2;
            this.button3.Text = "get";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // startDateTextBox
            // 
            this.startDateTextBox.Location = new System.Drawing.Point(1723, 412);
            this.startDateTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.startDateTextBox.Name = "startDateTextBox";
            this.startDateTextBox.Size = new System.Drawing.Size(112, 28);
            this.startDateTextBox.TabIndex = 3;
            // 
            // endDateTextBox
            // 
            this.endDateTextBox.Location = new System.Drawing.Point(1723, 442);
            this.endDateTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.endDateTextBox.Name = "endDateTextBox";
            this.endDateTextBox.Size = new System.Drawing.Size(112, 28);
            this.endDateTextBox.TabIndex = 4;
            // 
            // rebuild
            // 
            this.rebuild.Location = new System.Drawing.Point(1770, 486);
            this.rebuild.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rebuild.Name = "rebuild";
            this.rebuild.Size = new System.Drawing.Size(85, 46);
            this.rebuild.TabIndex = 5;
            this.rebuild.Text = "rebuild";
            this.rebuild.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1407, 459);
            this.button4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 74);
            this.button4.TabIndex = 6;
            this.button4.Text = "Single Simulate";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(35, 34);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(92, 32);
            this.loginButton.TabIndex = 8;
            this.loginButton.Text = "login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // console
            // 
            this.console.FormattingEnabled = true;
            this.console.ItemHeight = 18;
            this.console.Location = new System.Drawing.Point(325, 596);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(999, 184);
            this.console.TabIndex = 9;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(35, 81);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(92, 34);
            this.logoutButton.TabIndex = 10;
            this.logoutButton.Text = "logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // accountComboBox
            // 
            this.accountComboBox.FormattingEnabled = true;
            this.accountComboBox.Location = new System.Drawing.Point(35, 122);
            this.accountComboBox.Name = "accountComboBox";
            this.accountComboBox.Size = new System.Drawing.Size(164, 26);
            this.accountComboBox.TabIndex = 13;
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(378, 32);
            this.codeTextBox.MaxLength = 6;
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(99, 28);
            this.codeTextBox.TabIndex = 14;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(322, 34);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(51, 18);
            this.codeLabel.TabIndex = 15;
            this.codeLabel.Text = "Code";
            // 
            // balanceGridView
            // 
            this.balanceGridView.AllowUserToAddRows = false;
            this.balanceGridView.AllowUserToDeleteRows = false;
            this.balanceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.balanceGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.종목명,
            this.종목코드,
            this.잔고수량,
            this.매입금액,
            this.평가금액,
            this.손익금액,
            this.수익률});
            this.balanceGridView.Location = new System.Drawing.Point(325, 322);
            this.balanceGridView.Name = "balanceGridView";
            this.balanceGridView.RowHeadersVisible = false;
            this.balanceGridView.RowHeadersWidth = 62;
            this.balanceGridView.RowTemplate.Height = 30;
            this.balanceGridView.Size = new System.Drawing.Size(1055, 267);
            this.balanceGridView.TabIndex = 19;
            // 
            // 종목명
            // 
            this.종목명.HeaderText = "종목명";
            this.종목명.MinimumWidth = 8;
            this.종목명.Name = "종목명";
            this.종목명.Width = 150;
            // 
            // 종목코드
            // 
            this.종목코드.HeaderText = "종목코드";
            this.종목코드.MinimumWidth = 8;
            this.종목코드.Name = "종목코드";
            this.종목코드.Width = 80;
            // 
            // 잔고수량
            // 
            this.잔고수량.HeaderText = "잔고수량";
            this.잔고수량.MinimumWidth = 8;
            this.잔고수량.Name = "잔고수량";
            this.잔고수량.Width = 80;
            // 
            // 매입금액
            // 
            this.매입금액.HeaderText = "매입금액";
            this.매입금액.MinimumWidth = 8;
            this.매입금액.Name = "매입금액";
            this.매입금액.Width = 80;
            // 
            // 평가금액
            // 
            this.평가금액.HeaderText = "평가금액";
            this.평가금액.MinimumWidth = 8;
            this.평가금액.Name = "평가금액";
            this.평가금액.Width = 80;
            // 
            // 손익금액
            // 
            this.손익금액.HeaderText = "손익금액";
            this.손익금액.MinimumWidth = 8;
            this.손익금액.Name = "손익금액";
            this.손익금액.Width = 80;
            // 
            // 수익률
            // 
            this.수익률.HeaderText = "수익률";
            this.수익률.MinimumWidth = 8;
            this.수익률.Name = "수익률";
            this.수익률.Width = 80;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.68456F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.31544F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel1.Controls.Add(this.realProfitTextView, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.totalProfitRateTextView, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.totalEstimateTextView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.totalProfitTextView, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.totalBuyTextView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RealProfitLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.totalProfitRateLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.totalEstimateLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.totalProfitLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.totalBuyLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1340, 648);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.57143F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(515, 129);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // realProfitTextView
            // 
            this.realProfitTextView.AutoSize = true;
            this.realProfitTextView.Location = new System.Drawing.Point(390, 78);
            this.realProfitTextView.Name = "realProfitTextView";
            this.realProfitTextView.Size = new System.Drawing.Size(0, 18);
            this.realProfitTextView.TabIndex = 21;
            // 
            // totalProfitRateTextView
            // 
            this.totalProfitRateTextView.AutoSize = true;
            this.totalProfitRateTextView.Location = new System.Drawing.Point(390, 38);
            this.totalProfitRateTextView.Name = "totalProfitRateTextView";
            this.totalProfitRateTextView.Size = new System.Drawing.Size(0, 18);
            this.totalProfitRateTextView.TabIndex = 21;
            // 
            // totalEstimateTextView
            // 
            this.totalEstimateTextView.AutoSize = true;
            this.totalEstimateTextView.Location = new System.Drawing.Point(132, 38);
            this.totalEstimateTextView.Name = "totalEstimateTextView";
            this.totalEstimateTextView.Size = new System.Drawing.Size(0, 18);
            this.totalEstimateTextView.TabIndex = 21;
            // 
            // totalProfitTextView
            // 
            this.totalProfitTextView.AutoSize = true;
            this.totalProfitTextView.Location = new System.Drawing.Point(390, 0);
            this.totalProfitTextView.Name = "totalProfitTextView";
            this.totalProfitTextView.Size = new System.Drawing.Size(0, 18);
            this.totalProfitTextView.TabIndex = 21;
            // 
            // totalBuyTextView
            // 
            this.totalBuyTextView.AutoSize = true;
            this.totalBuyTextView.Location = new System.Drawing.Point(132, 0);
            this.totalBuyTextView.Name = "totalBuyTextView";
            this.totalBuyTextView.Size = new System.Drawing.Size(0, 18);
            this.totalBuyTextView.TabIndex = 21;
            // 
            // RealProfitLabel
            // 
            this.RealProfitLabel.AutoSize = true;
            this.RealProfitLabel.Location = new System.Drawing.Point(247, 78);
            this.RealProfitLabel.Name = "RealProfitLabel";
            this.RealProfitLabel.Size = new System.Drawing.Size(83, 18);
            this.RealProfitLabel.TabIndex = 25;
            this.RealProfitLabel.Text = "RealProfit";
            // 
            // totalProfitRateLabel
            // 
            this.totalProfitRateLabel.AutoSize = true;
            this.totalProfitRateLabel.Location = new System.Drawing.Point(247, 38);
            this.totalProfitRateLabel.Name = "totalProfitRateLabel";
            this.totalProfitRateLabel.Size = new System.Drawing.Size(124, 18);
            this.totalProfitRateLabel.TabIndex = 24;
            this.totalProfitRateLabel.Text = "TotalProfitRate";
            // 
            // totalEstimateLabel
            // 
            this.totalEstimateLabel.AutoSize = true;
            this.totalEstimateLabel.Location = new System.Drawing.Point(3, 38);
            this.totalEstimateLabel.Name = "totalEstimateLabel";
            this.totalEstimateLabel.Size = new System.Drawing.Size(116, 18);
            this.totalEstimateLabel.TabIndex = 23;
            this.totalEstimateLabel.Text = "TotalEstimate";
            // 
            // totalProfitLabel
            // 
            this.totalProfitLabel.AutoSize = true;
            this.totalProfitLabel.Location = new System.Drawing.Point(247, 0);
            this.totalProfitLabel.Name = "totalProfitLabel";
            this.totalProfitLabel.Size = new System.Drawing.Size(88, 18);
            this.totalProfitLabel.TabIndex = 22;
            this.totalProfitLabel.Text = "TotalProfit";
            // 
            // totalBuyLabel
            // 
            this.totalBuyLabel.AutoSize = true;
            this.totalBuyLabel.Location = new System.Drawing.Point(3, 0);
            this.totalBuyLabel.Name = "totalBuyLabel";
            this.totalBuyLabel.Size = new System.Drawing.Size(78, 18);
            this.totalBuyLabel.TabIndex = 21;
            this.totalBuyLabel.Text = "TotalBuy";
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(21, 414);
            this.axKHOpenAPI1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(82, 68);
            this.axKHOpenAPI1.TabIndex = 21;
            // 
            // itemGridView
            // 
            this.itemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.name,
            this.target,
            this.dayStartDate,
            this.dayEndDate,
            this.updDate,
            this.op1,
            this.opt2,
            this.opt3,
            this.update});
            this.itemGridView.Location = new System.Drawing.Point(325, 90);
            this.itemGridView.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.itemGridView.Name = "itemGridView";
            this.itemGridView.RowHeadersVisible = false;
            this.itemGridView.RowHeadersWidth = 62;
            this.itemGridView.RowTemplate.Height = 21;
            this.itemGridView.Size = new System.Drawing.Size(940, 225);
            this.itemGridView.TabIndex = 22;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "code";
            this.code.MinimumWidth = 8;
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 80;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "name";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 80;
            // 
            // target
            // 
            this.target.DataPropertyName = "target";
            this.target.HeaderText = "target";
            this.target.MinimumWidth = 8;
            this.target.Name = "target";
            this.target.Width = 80;
            // 
            // dayStartDate
            // 
            this.dayStartDate.DataPropertyName = "dayStartDate";
            this.dayStartDate.HeaderText = "dayStartDate";
            this.dayStartDate.MinimumWidth = 8;
            this.dayStartDate.Name = "dayStartDate";
            this.dayStartDate.ReadOnly = true;
            this.dayStartDate.Width = 80;
            // 
            // dayEndDate
            // 
            this.dayEndDate.DataPropertyName = "dayEndDate";
            this.dayEndDate.HeaderText = "dayEndDate";
            this.dayEndDate.MinimumWidth = 8;
            this.dayEndDate.Name = "dayEndDate";
            this.dayEndDate.ReadOnly = true;
            this.dayEndDate.Width = 80;
            // 
            // updDate
            // 
            this.updDate.DataPropertyName = "updDate";
            this.updDate.HeaderText = "updDate";
            this.updDate.MinimumWidth = 8;
            this.updDate.Name = "updDate";
            this.updDate.ReadOnly = true;
            this.updDate.Width = 80;
            // 
            // op1
            // 
            this.op1.DataPropertyName = "opt1";
            this.op1.HeaderText = "opt1";
            this.op1.MinimumWidth = 8;
            this.op1.Name = "op1";
            this.op1.Visible = false;
            this.op1.Width = 150;
            // 
            // opt2
            // 
            this.opt2.DataPropertyName = "opt2";
            this.opt2.HeaderText = "opt2";
            this.opt2.MinimumWidth = 8;
            this.opt2.Name = "opt2";
            this.opt2.Visible = false;
            this.opt2.Width = 150;
            // 
            // opt3
            // 
            this.opt3.DataPropertyName = "opt3";
            this.opt3.HeaderText = "opt3";
            this.opt3.MinimumWidth = 8;
            this.opt3.Name = "opt3";
            this.opt3.Visible = false;
            this.opt3.Width = 150;
            // 
            // update
            // 
            this.update.DataPropertyName = "update";
            this.update.HeaderText = "update";
            this.update.MinimumWidth = 8;
            this.update.Name = "update";
            this.update.Text = "update";
            this.update.Width = 80;
            // 
            // simulateRadioButton
            // 
            this.simulateRadioButton.AutoSize = true;
            this.simulateRadioButton.Location = new System.Drawing.Point(15, 18);
            this.simulateRadioButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.simulateRadioButton.Name = "simulateRadioButton";
            this.simulateRadioButton.Size = new System.Drawing.Size(100, 22);
            this.simulateRadioButton.TabIndex = 23;
            this.simulateRadioButton.TabStop = true;
            this.simulateRadioButton.Text = "Simulate";
            this.simulateRadioButton.UseVisualStyleBackColor = true;
            // 
            // realtimeRadioButton
            // 
            this.realtimeRadioButton.AutoSize = true;
            this.realtimeRadioButton.Location = new System.Drawing.Point(15, 50);
            this.realtimeRadioButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.realtimeRadioButton.Name = "realtimeRadioButton";
            this.realtimeRadioButton.Size = new System.Drawing.Size(100, 22);
            this.realtimeRadioButton.TabIndex = 24;
            this.realtimeRadioButton.TabStop = true;
            this.realtimeRadioButton.Text = "Realtime";
            this.realtimeRadioButton.UseVisualStyleBackColor = true;
            // 
            // modePanel
            // 
            this.modePanel.Controls.Add(this.simulateRadioButton);
            this.modePanel.Controls.Add(this.realtimeRadioButton);
            this.modePanel.Location = new System.Drawing.Point(1710, 4);
            this.modePanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.modePanel.Name = "modePanel";
            this.modePanel.Size = new System.Drawing.Size(145, 88);
            this.modePanel.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1667, 417);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 26;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1667, 447);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "End";
            // 
            // targetCheckBox
            // 
            this.targetCheckBox.AutoSize = true;
            this.targetCheckBox.Location = new System.Drawing.Point(588, 30);
            this.targetCheckBox.Name = "targetCheckBox";
            this.targetCheckBox.Size = new System.Drawing.Size(80, 22);
            this.targetCheckBox.TabIndex = 28;
            this.targetCheckBox.Text = "target";
            this.targetCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2015, 812);
            this.Controls.Add(this.targetCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modePanel);
            this.Controls.Add(this.itemGridView);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.balanceGridView);
            this.Controls.Add(this.inquireButton);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.accountComboBox);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.console);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.rebuild);
            this.Controls.Add(this.endDateTextBox);
            this.Controls.Add(this.startDateTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.startButton);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.balanceGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).EndInit();
            this.modePanel.ResumeLayout(false);
            this.modePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox startDateTextBox;
        private System.Windows.Forms.TextBox endDateTextBox;
        private System.Windows.Forms.Button rebuild;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.ListBox console;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.ComboBox accountComboBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label totalBuyLabel;
        private System.Windows.Forms.Label totalProfitLabel;
        private System.Windows.Forms.Label totalEstimateLabel;
        private System.Windows.Forms.Label totalProfitRateLabel;
        private System.Windows.Forms.Label RealProfitLabel;
        private System.Windows.Forms.Label totalBuyTextView;
        private System.Windows.Forms.Label totalProfitTextView;
        private System.Windows.Forms.Label totalEstimateTextView;
        private System.Windows.Forms.Label totalProfitRateTextView;
        private System.Windows.Forms.Label realProfitTextView;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 잔고수량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 매입금액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 평가금액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 손익금액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수익률;
        private System.Windows.Forms.DataGridView balanceGridView;
        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.DataGridView itemGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn target;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn updDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn op1;
        private System.Windows.Forms.DataGridViewTextBoxColumn opt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn opt3;
        private System.Windows.Forms.DataGridViewButtonColumn update;
        private System.Windows.Forms.RadioButton simulateRadioButton;
        private System.Windows.Forms.RadioButton realtimeRadioButton;
        private System.Windows.Forms.Panel modePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox targetCheckBox;
        private System.Windows.Forms.Button inquireButton;
    }
}

