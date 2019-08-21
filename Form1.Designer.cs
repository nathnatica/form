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
            System.Windows.Forms.Button inquireButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.refresh = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rebuild = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.ListBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.accountComboBox = new System.Windows.Forms.ComboBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.dataLabel = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
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
            inquireButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // inquireButton
            // 
            inquireButton.Location = new System.Drawing.Point(384, 19);
            inquireButton.Margin = new System.Windows.Forms.Padding(2);
            inquireButton.Name = "inquireButton";
            inquireButton.Size = new System.Drawing.Size(57, 20);
            inquireButton.TabIndex = 16;
            inquireButton.Text = "Inquire";
            inquireButton.UseVisualStyleBackColor = true;
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(782, 60);
            this.refresh.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(62, 31);
            this.refresh.TabIndex = 0;
            this.refresh.Text = "refresh";
            this.refresh.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1003, 322);
            this.button2.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "load file";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1003, 276);
            this.button3.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "get";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1062, 276);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 19);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1062, 296);
            this.textBox2.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 19);
            this.textBox2.TabIndex = 4;
            // 
            // rebuild
            // 
            this.rebuild.Location = new System.Drawing.Point(1062, 324);
            this.rebuild.Name = "rebuild";
            this.rebuild.Size = new System.Drawing.Size(51, 31);
            this.rebuild.TabIndex = 5;
            this.rebuild.Text = "rebuild";
            this.rebuild.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(888, 305);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 49);
            this.button4.TabIndex = 6;
            this.button4.Text = "Single Simulate";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(21, 23);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(55, 21);
            this.loginButton.TabIndex = 8;
            this.loginButton.Text = "login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // console
            // 
            this.console.FormattingEnabled = true;
            this.console.ItemHeight = 12;
            this.console.Location = new System.Drawing.Point(195, 397);
            this.console.Margin = new System.Windows.Forms.Padding(2);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(601, 124);
            this.console.TabIndex = 9;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(21, 54);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(55, 23);
            this.logoutButton.TabIndex = 10;
            this.logoutButton.Text = "logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(19, 124);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(34, 12);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Name";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(19, 145);
            this.idLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(16, 12);
            this.idLabel.TabIndex = 12;
            this.idLabel.Text = "ID";
            // 
            // accountComboBox
            // 
            this.accountComboBox.FormattingEnabled = true;
            this.accountComboBox.Location = new System.Drawing.Point(21, 167);
            this.accountComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.accountComboBox.Name = "accountComboBox";
            this.accountComboBox.Size = new System.Drawing.Size(74, 20);
            this.accountComboBox.TabIndex = 13;
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(227, 21);
            this.codeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.codeTextBox.MaxLength = 6;
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(61, 19);
            this.codeTextBox.TabIndex = 14;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(193, 23);
            this.codeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(31, 12);
            this.codeLabel.TabIndex = 15;
            this.codeLabel.Text = "Code";
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(291, 23);
            this.dataLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(29, 12);
            this.dataLabel.TabIndex = 17;
            this.dataLabel.Text = "Date";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(321, 21);
            this.dateTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.dateTextBox.MaxLength = 8;
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(61, 19);
            this.dateTextBox.TabIndex = 18;
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
            this.balanceGridView.Location = new System.Drawing.Point(195, 215);
            this.balanceGridView.Margin = new System.Windows.Forms.Padding(2);
            this.balanceGridView.Name = "balanceGridView";
            this.balanceGridView.RowHeadersVisible = false;
            this.balanceGridView.RowHeadersWidth = 62;
            this.balanceGridView.RowTemplate.Height = 30;
            this.balanceGridView.Size = new System.Drawing.Size(633, 178);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(804, 432);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.57143F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 86);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // realProfitTextView
            // 
            this.realProfitTextView.AutoSize = true;
            this.realProfitTextView.Location = new System.Drawing.Point(238, 52);
            this.realProfitTextView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.realProfitTextView.Name = "realProfitTextView";
            this.realProfitTextView.Size = new System.Drawing.Size(0, 12);
            this.realProfitTextView.TabIndex = 21;
            // 
            // totalProfitRateTextView
            // 
            this.totalProfitRateTextView.AutoSize = true;
            this.totalProfitRateTextView.Location = new System.Drawing.Point(238, 25);
            this.totalProfitRateTextView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalProfitRateTextView.Name = "totalProfitRateTextView";
            this.totalProfitRateTextView.Size = new System.Drawing.Size(0, 12);
            this.totalProfitRateTextView.TabIndex = 21;
            // 
            // totalEstimateTextView
            // 
            this.totalEstimateTextView.AutoSize = true;
            this.totalEstimateTextView.Location = new System.Drawing.Point(81, 25);
            this.totalEstimateTextView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalEstimateTextView.Name = "totalEstimateTextView";
            this.totalEstimateTextView.Size = new System.Drawing.Size(0, 12);
            this.totalEstimateTextView.TabIndex = 21;
            // 
            // totalProfitTextView
            // 
            this.totalProfitTextView.AutoSize = true;
            this.totalProfitTextView.Location = new System.Drawing.Point(238, 0);
            this.totalProfitTextView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalProfitTextView.Name = "totalProfitTextView";
            this.totalProfitTextView.Size = new System.Drawing.Size(0, 12);
            this.totalProfitTextView.TabIndex = 21;
            // 
            // totalBuyTextView
            // 
            this.totalBuyTextView.AutoSize = true;
            this.totalBuyTextView.Location = new System.Drawing.Point(81, 0);
            this.totalBuyTextView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalBuyTextView.Name = "totalBuyTextView";
            this.totalBuyTextView.Size = new System.Drawing.Size(0, 12);
            this.totalBuyTextView.TabIndex = 21;
            // 
            // RealProfitLabel
            // 
            this.RealProfitLabel.AutoSize = true;
            this.RealProfitLabel.Location = new System.Drawing.Point(152, 52);
            this.RealProfitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RealProfitLabel.Name = "RealProfitLabel";
            this.RealProfitLabel.Size = new System.Drawing.Size(56, 12);
            this.RealProfitLabel.TabIndex = 25;
            this.RealProfitLabel.Text = "RealProfit";
            // 
            // totalProfitRateLabel
            // 
            this.totalProfitRateLabel.AutoSize = true;
            this.totalProfitRateLabel.Location = new System.Drawing.Point(152, 25);
            this.totalProfitRateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalProfitRateLabel.Name = "totalProfitRateLabel";
            this.totalProfitRateLabel.Size = new System.Drawing.Size(77, 24);
            this.totalProfitRateLabel.TabIndex = 24;
            this.totalProfitRateLabel.Text = "TotalProfitRate";
            // 
            // totalEstimateLabel
            // 
            this.totalEstimateLabel.AutoSize = true;
            this.totalEstimateLabel.Location = new System.Drawing.Point(2, 25);
            this.totalEstimateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalEstimateLabel.Name = "totalEstimateLabel";
            this.totalEstimateLabel.Size = new System.Drawing.Size(70, 24);
            this.totalEstimateLabel.TabIndex = 23;
            this.totalEstimateLabel.Text = "TotalEstimate";
            // 
            // totalProfitLabel
            // 
            this.totalProfitLabel.AutoSize = true;
            this.totalProfitLabel.Location = new System.Drawing.Point(152, 0);
            this.totalProfitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalProfitLabel.Name = "totalProfitLabel";
            this.totalProfitLabel.Size = new System.Drawing.Size(59, 12);
            this.totalProfitLabel.TabIndex = 22;
            this.totalProfitLabel.Text = "TotalProfit";
            // 
            // totalBuyLabel
            // 
            this.totalBuyLabel.AutoSize = true;
            this.totalBuyLabel.Location = new System.Drawing.Point(2, 0);
            this.totalBuyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalBuyLabel.Name = "totalBuyLabel";
            this.totalBuyLabel.Size = new System.Drawing.Size(51, 12);
            this.totalBuyLabel.TabIndex = 21;
            this.totalBuyLabel.Text = "TotalBuy";
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(21, 414);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(55, 45);
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
            this.itemGridView.Location = new System.Drawing.Point(195, 60);
            this.itemGridView.Name = "itemGridView";
            this.itemGridView.RowHeadersVisible = false;
            this.itemGridView.RowTemplate.Height = 21;
            this.itemGridView.Size = new System.Drawing.Size(564, 150);
            this.itemGridView.TabIndex = 22;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "code";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 80;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 80;
            // 
            // target
            // 
            this.target.DataPropertyName = "target";
            this.target.HeaderText = "target";
            this.target.Name = "target";
            this.target.Width = 80;
            // 
            // dayStartDate
            // 
            this.dayStartDate.DataPropertyName = "dayStartDate";
            this.dayStartDate.HeaderText = "dayStartDate";
            this.dayStartDate.Name = "dayStartDate";
            this.dayStartDate.ReadOnly = true;
            this.dayStartDate.Width = 80;
            // 
            // dayEndDate
            // 
            this.dayEndDate.DataPropertyName = "dayEndDate";
            this.dayEndDate.HeaderText = "dayEndDate";
            this.dayEndDate.Name = "dayEndDate";
            this.dayEndDate.ReadOnly = true;
            this.dayEndDate.Width = 80;
            // 
            // updDate
            // 
            this.updDate.DataPropertyName = "updDate";
            this.updDate.HeaderText = "updDate";
            this.updDate.Name = "updDate";
            this.updDate.ReadOnly = true;
            this.updDate.Width = 80;
            // 
            // op1
            // 
            this.op1.DataPropertyName = "opt1";
            this.op1.HeaderText = "opt1";
            this.op1.Name = "op1";
            this.op1.Visible = false;
            // 
            // opt2
            // 
            this.opt2.DataPropertyName = "opt2";
            this.opt2.HeaderText = "opt2";
            this.opt2.Name = "opt2";
            this.opt2.Visible = false;
            // 
            // opt3
            // 
            this.opt3.DataPropertyName = "opt3";
            this.opt3.HeaderText = "opt3";
            this.opt3.Name = "opt3";
            this.opt3.Visible = false;
            // 
            // update
            // 
            this.update.DataPropertyName = "update";
            this.update.HeaderText = "update";
            this.update.Name = "update";
            this.update.Text = "update";
            this.update.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 551);
            this.Controls.Add(this.itemGridView);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.balanceGridView);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(inquireButton);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.accountComboBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.console);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.rebuild);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.refresh);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.balanceGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button rebuild;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.ListBox console;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.ComboBox accountComboBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.TextBox dateTextBox;
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
    }
}

