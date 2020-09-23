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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.BatteryName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Title = "Horizontal";
            chartArea1.AxisY.Title = "Count";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 70);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.DarkOrchid;
            series1.Legend = "Legend1";
            series1.Name = "치수값분포";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(523, 524);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(543, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(318, 212);
            this.listBox1.TabIndex = 1;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.CloseBtn.Font = new System.Drawing.Font("배달의민족 주아", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CloseBtn.Location = new System.Drawing.Point(1171, 690);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CloseBtn.Size = new System.Drawing.Size(151, 65);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "종료하기";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ConnectBtn.Font = new System.Drawing.Font("배달의민족 주아", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConnectBtn.Location = new System.Drawing.Point(196, 674);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(151, 65);
            this.ConnectBtn.TabIndex = 5;
            this.ConnectBtn.Text = "접속";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(129, 640);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(297, 23);
            this.PortBox.TabIndex = 6;
            this.PortBox.TextChanged += new System.EventHandler(this.PortBox_TextChanged);
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(129, 600);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(297, 23);
            this.IPBox.TabIndex = 7;
            this.IPBox.TextChanged += new System.EventHandler(this.IPBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(37, 603);
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
            this.label2.Location = new System.Drawing.Point(37, 640);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            this.chart2.BorderlineColor = System.Drawing.Color.Maroon;
            this.chart2.BorderlineWidth = 3;
            chartArea2.AxisX.Title = "Warping";
            chartArea2.AxisY.Title = "Frequency";
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(867, 70);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "정규분포Bar";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Line";
            series3.YValuesPerPoint = 2;
            this.chart2.Series.Add(series2);
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(525, 524);
            this.chart2.TabIndex = 11;
            this.chart2.Text = "chart2";
            title1.DockedToChartArea = "ChartArea1";
            title1.Name = "CP 정규분포 차트";
            this.chart2.Titles.Add(title1);
            // 
            // Chart2Btn
            // 
            this.Chart2Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Chart2Btn.Font = new System.Drawing.Font("배달의민족 주아", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Chart2Btn.Location = new System.Drawing.Point(986, 690);
            this.Chart2Btn.Name = "Chart2Btn";
            this.Chart2Btn.Size = new System.Drawing.Size(151, 65);
            this.Chart2Btn.TabIndex = 12;
            this.Chart2Btn.Text = "정규분포";
            this.Chart2Btn.UseVisualStyleBackColor = false;
            this.Chart2Btn.Click += new System.EventHandler(this.Chart2Btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CPValueText);
            this.panel1.Controls.Add(this.MeanValue);
            this.panel1.Controls.Add(this.SigmaValue);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.PCAText);
            this.panel1.Controls.Add(this.AQLText);
            this.panel1.Controls.Add(this.LOTTEXT);
            this.panel1.Location = new System.Drawing.Point(543, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 306);
            this.panel1.TabIndex = 16;
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
            // BatteryName
            // 
            this.BatteryName.AutoSize = true;
            this.BatteryName.BackColor = System.Drawing.Color.Transparent;
            this.BatteryName.Font = new System.Drawing.Font("휴먼옛체", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BatteryName.ForeColor = System.Drawing.Color.Salmon;
            this.BatteryName.Location = new System.Drawing.Point(442, 600);
            this.BatteryName.Name = "BatteryName";
            this.BatteryName.Size = new System.Drawing.Size(346, 42);
            this.BatteryName.TabIndex = 17;
            this.BatteryName.Text = "Project : Battery";
            this.BatteryName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("휴먼옛체", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.ForestGreen;
            this.label9.Location = new System.Drawing.Point(442, 645);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(880, 42);
            this.label9.TabIndex = 18;
            this.label9.Text = "2차전지 치수측정을 통한 불량률 산출 및 평가";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SecondBattery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 758);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BatteryName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Chart2Btn);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("굴림", 10F);
            this.Name = "SecondBattery";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PCAText;
        private System.Windows.Forms.Label AQLText;
        private System.Windows.Forms.Label LOTTEXT;
        private System.Windows.Forms.Label BatteryName;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label CPValueText;
        private System.Windows.Forms.Label MeanValue;
        private System.Windows.Forms.Label SigmaValue;
    }
}

