namespace dotNetChart
{
    partial class SecondBattery
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondBattery));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart2Btn = new System.Windows.Forms.Button();
            this.BoxPanel1 = new System.Windows.Forms.Panel();
            this.CPValueText = new System.Windows.Forms.Label();
            this.MeanValue = new System.Windows.Forms.Label();
            this.SigmaValue = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PCAText = new System.Windows.Forms.Label();
            this.AQLText = new System.Windows.Forms.Label();
            this.LOTTEXT = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.FirstPanel = new System.Windows.Forms.Panel();
            this.stepProgressBarItem1 = new DevExpress.XtraEditors.StepProgressBarItem();
            this.stepProgressBarItem2 = new DevExpress.XtraEditors.StepProgressBarItem();
            this.stepProgressBarItem3 = new DevExpress.XtraEditors.StepProgressBarItem();
            this.stepProgressBarItem4 = new DevExpress.XtraEditors.StepProgressBarItem();
            this.stepProgressBarItem5 = new DevExpress.XtraEditors.StepProgressBarItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.BoxPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.FirstPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea5.AxisX.Title = "Horizontal";
            chartArea5.AxisY.Title = "Count";
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(57, 122);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.DarkOrchid;
            series7.Legend = "Legend1";
            series7.Name = "치수값분포";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(523, 524);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(586, 122);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(318, 212);
            this.listBox1.TabIndex = 1;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseBtn.BackgroundImage")));
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("배달의민족 주아", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CloseBtn.Location = new System.Drawing.Point(1254, 658);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CloseBtn.Size = new System.Drawing.Size(128, 128);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "종료하기";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.Transparent;
            this.ConnectBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConnectBtn.BackgroundImage")));
            this.ConnectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConnectBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ConnectBtn.FlatAppearance.BorderSize = 0;
            this.ConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectBtn.Font = new System.Drawing.Font("배달의민족 주아", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConnectBtn.ForeColor = System.Drawing.Color.Black;
            this.ConnectBtn.Location = new System.Drawing.Point(673, 682);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(96, 72);
            this.ConnectBtn.TabIndex = 5;
            this.ConnectBtn.Text = "접속";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(338, 722);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(297, 23);
            this.PortBox.TabIndex = 6;
            this.PortBox.TextChanged += new System.EventHandler(this.PortBox_TextChanged);
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(338, 682);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(297, 23);
            this.IPBox.TabIndex = 7;
            this.IPBox.TextChanged += new System.EventHandler(this.IPBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(246, 685);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F);
            this.label2.Location = new System.Drawing.Point(246, 722);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // chart2
            // 
            this.chart2.BorderlineColor = System.Drawing.Color.Maroon;
            this.chart2.BorderlineWidth = 3;
            chartArea6.AxisX.Title = "Warping";
            chartArea6.AxisY.Title = "Frequency";
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(910, 122);
            this.chart2.Name = "chart2";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "정규분포Bar";
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "Line";
            series9.YValuesPerPoint = 2;
            this.chart2.Series.Add(series8);
            this.chart2.Series.Add(series9);
            this.chart2.Size = new System.Drawing.Size(700, 524);
            this.chart2.TabIndex = 11;
            this.chart2.Text = "chart2";
            title3.DockedToChartArea = "ChartArea1";
            title3.Name = "CP 정규분포 차트";
            this.chart2.Titles.Add(title3);
            // 
            // Chart2Btn
            // 
            this.Chart2Btn.BackColor = System.Drawing.Color.Transparent;
            this.Chart2Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Chart2Btn.BackgroundImage")));
            this.Chart2Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Chart2Btn.FlatAppearance.BorderSize = 0;
            this.Chart2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Chart2Btn.Font = new System.Drawing.Font("배달의민족 주아", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Chart2Btn.Location = new System.Drawing.Point(1083, 658);
            this.Chart2Btn.Name = "Chart2Btn";
            this.Chart2Btn.Size = new System.Drawing.Size(128, 128);
            this.Chart2Btn.TabIndex = 12;
            this.Chart2Btn.Text = "정규분포";
            this.Chart2Btn.UseVisualStyleBackColor = false;
            this.Chart2Btn.Click += new System.EventHandler(this.Chart2Btn_Click);
            // 
            // BoxPanel1
            // 
            this.BoxPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BoxPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoxPanel1.Controls.Add(this.CPValueText);
            this.BoxPanel1.Controls.Add(this.MeanValue);
            this.BoxPanel1.Controls.Add(this.SigmaValue);
            this.BoxPanel1.Controls.Add(this.textBox6);
            this.BoxPanel1.Controls.Add(this.textBox5);
            this.BoxPanel1.Controls.Add(this.textBox4);
            this.BoxPanel1.Controls.Add(this.textBox3);
            this.BoxPanel1.Controls.Add(this.textBox2);
            this.BoxPanel1.Controls.Add(this.textBox1);
            this.BoxPanel1.Controls.Add(this.PCAText);
            this.BoxPanel1.Controls.Add(this.AQLText);
            this.BoxPanel1.Controls.Add(this.LOTTEXT);
            this.BoxPanel1.Location = new System.Drawing.Point(586, 340);
            this.BoxPanel1.Name = "BoxPanel1";
            this.BoxPanel1.Size = new System.Drawing.Size(318, 306);
            this.BoxPanel1.TabIndex = 16;
            // 
            // CPValueText
            // 
            this.CPValueText.AutoSize = true;
            this.CPValueText.Font = new System.Drawing.Font("굴림", 15F);
            this.CPValueText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CPValueText.Location = new System.Drawing.Point(201, 270);
            this.CPValueText.Name = "CPValueText";
            this.CPValueText.Size = new System.Drawing.Size(20, 20);
            this.CPValueText.TabIndex = 30;
            this.CPValueText.Text = "0";
            // 
            // MeanValue
            // 
            this.MeanValue.AutoSize = true;
            this.MeanValue.Font = new System.Drawing.Font("굴림", 15F);
            this.MeanValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.MeanValue.Location = new System.Drawing.Point(201, 218);
            this.MeanValue.Name = "MeanValue";
            this.MeanValue.Size = new System.Drawing.Size(20, 20);
            this.MeanValue.TabIndex = 29;
            this.MeanValue.Text = "0";
            // 
            // SigmaValue
            // 
            this.SigmaValue.AutoSize = true;
            this.SigmaValue.Font = new System.Drawing.Font("굴림", 15F);
            this.SigmaValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SigmaValue.Location = new System.Drawing.Point(201, 163);
            this.SigmaValue.Name = "SigmaValue";
            this.SigmaValue.Size = new System.Drawing.Size(20, 20);
            this.SigmaValue.TabIndex = 28;
            this.SigmaValue.Text = "0";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("배달의민족 주아", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox6.Location = new System.Drawing.Point(7, 17);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(175, 28);
            this.textBox6.TabIndex = 27;
            this.textBox6.Text = "LOT";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("배달의민족 주아", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox5.Location = new System.Drawing.Point(7, 62);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(175, 28);
            this.textBox5.TabIndex = 26;
            this.textBox5.Text = "합격품질수준";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("배달의민족 주아", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.Location = new System.Drawing.Point(7, 108);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(175, 28);
            this.textBox4.TabIndex = 25;
            this.textBox4.Text = "공정능력평가";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("배달의민족 주아", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.Location = new System.Drawing.Point(7, 159);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(175, 28);
            this.textBox3.TabIndex = 24;
            this.textBox3.Text = "표준편차";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("배달의민족 주아", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.Location = new System.Drawing.Point(7, 214);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 28);
            this.textBox2.TabIndex = 23;
            this.textBox2.Text = "평균";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("배달의민족 주아", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(7, 268);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 28);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "CP";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PCAText
            // 
            this.PCAText.AutoSize = true;
            this.PCAText.Font = new System.Drawing.Font("굴림", 15F);
            this.PCAText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PCAText.Location = new System.Drawing.Point(201, 112);
            this.PCAText.Name = "PCAText";
            this.PCAText.Size = new System.Drawing.Size(20, 20);
            this.PCAText.TabIndex = 18;
            this.PCAText.Text = "0";
            this.PCAText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AQLText
            // 
            this.AQLText.AutoSize = true;
            this.AQLText.Font = new System.Drawing.Font("굴림", 15F);
            this.AQLText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AQLText.Location = new System.Drawing.Point(201, 67);
            this.AQLText.Name = "AQLText";
            this.AQLText.Size = new System.Drawing.Size(20, 20);
            this.AQLText.TabIndex = 17;
            this.AQLText.Text = "0";
            // 
            // LOTTEXT
            // 
            this.LOTTEXT.AutoSize = true;
            this.LOTTEXT.Font = new System.Drawing.Font("굴림", 15F);
            this.LOTTEXT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LOTTEXT.Location = new System.Drawing.Point(201, 21);
            this.LOTTEXT.Name = "LOTTEXT";
            this.LOTTEXT.Size = new System.Drawing.Size(20, 20);
            this.LOTTEXT.TabIndex = 16;
            this.LOTTEXT.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1080);
            this.panel2.TabIndex = 17;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 5;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("배달의민족 주아", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 80);
            this.button3.TabIndex = 2;
            this.button3.Text = "실시간";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 5;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("배달의민족 주아", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 80);
            this.button2.TabIndex = 1;
            this.button2.Text = "Form2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("배달의민족 주아", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 80);
            this.button1.TabIndex = 0;
            this.button1.Text = "실시간";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FirstPanel
            // 
            this.FirstPanel.Controls.Add(this.Chart2Btn);
            this.FirstPanel.Controls.Add(this.CloseBtn);
            this.FirstPanel.Controls.Add(this.BoxPanel1);
            this.FirstPanel.Controls.Add(this.label2);
            this.FirstPanel.Controls.Add(this.label1);
            this.FirstPanel.Controls.Add(this.chart1);
            this.FirstPanel.Controls.Add(this.IPBox);
            this.FirstPanel.Controls.Add(this.chart2);
            this.FirstPanel.Controls.Add(this.PortBox);
            this.FirstPanel.Controls.Add(this.listBox1);
            this.FirstPanel.Controls.Add(this.ConnectBtn);
            this.FirstPanel.Location = new System.Drawing.Point(221, 121);
            this.FirstPanel.Name = "FirstPanel";
            this.FirstPanel.Size = new System.Drawing.Size(1720, 981);
            this.FirstPanel.TabIndex = 18;
            // 
            // stepProgressBarItem1
            // 
            this.stepProgressBarItem1.ContentBlock2.Caption = "Start";
            this.stepProgressBarItem1.Name = "stepProgressBarItem1";
            this.stepProgressBarItem1.State = DevExpress.XtraEditors.StepProgressBarItemState.Active;
            // 
            // stepProgressBarItem2
            // 
            this.stepProgressBarItem2.ContentBlock2.Caption = "MV_Check";
            this.stepProgressBarItem2.Name = "stepProgressBarItem2";
            this.stepProgressBarItem2.State = DevExpress.XtraEditors.StepProgressBarItemState.Active;
            // 
            // stepProgressBarItem3
            // 
            this.stepProgressBarItem3.ContentBlock2.Caption = "PassCheck";
            this.stepProgressBarItem3.Name = "stepProgressBarItem3";
            this.stepProgressBarItem3.State = DevExpress.XtraEditors.StepProgressBarItemState.Active;
            // 
            // stepProgressBarItem4
            // 
            this.stepProgressBarItem4.ContentBlock2.Caption = "Add_Data";
            this.stepProgressBarItem4.Name = "stepProgressBarItem4";
            // 
            // stepProgressBarItem5
            // 
            this.stepProgressBarItem5.ContentBlock2.Caption = "Finish";
            this.stepProgressBarItem5.Name = "stepProgressBarItem5";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1720, 93);
            this.panel3.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("배달의민족 주아", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(374, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(955, 70);
            this.label3.TabIndex = 0;
            this.label3.Text = "Smart Dimension Measure System";
            // 
            // SecondBattery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.FirstPanel);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("굴림", 10F);
            this.Name = "SecondBattery";
            this.Text = "Smart Dimension Measure System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.BoxPanel1.ResumeLayout(false);
            this.BoxPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.FirstPanel.ResumeLayout(false);
            this.FirstPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button Chart2Btn;
        private System.Windows.Forms.Panel BoxPanel1;
        private System.Windows.Forms.Label PCAText;
        private System.Windows.Forms.Label AQLText;
        private System.Windows.Forms.Label LOTTEXT;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label CPValueText;
        private System.Windows.Forms.Label MeanValue;
        private System.Windows.Forms.Label SigmaValue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel FirstPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem1;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem2;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem3;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem4;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem5;
    }
}

