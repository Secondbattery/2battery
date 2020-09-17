namespace dotNetChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart2Btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PCAText = new System.Windows.Forms.Label();
            this.AQLText = new System.Windows.Forms.Label();
            this.LOTTEXT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(14, 13);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(523, 524);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(543, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(318, 212);
            this.listBox1.TabIndex = 1;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(1192, 674);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(151, 65);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "CloseBtn";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(827, 674);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 65);
            this.button3.TabIndex = 4;
            this.button3.Text = "실시간치수";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(196, 674);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(151, 65);
            this.ConnectBtn.TabIndex = 5;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(129, 600);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(297, 23);
            this.PortBox.TabIndex = 6;
            this.PortBox.TextChanged += new System.EventHandler(this.PortBox_TextChanged);
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(129, 560);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(297, 23);
            this.IPBox.TabIndex = 7;
            this.IPBox.TextChanged += new System.EventHandler(this.IPBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(37, 563);
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
            this.label2.Location = new System.Drawing.Point(37, 600);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // chart2
            // 
            this.chart2.BorderlineColor = System.Drawing.Color.Maroon;
            this.chart2.BorderlineWidth = 3;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(867, 13);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Line";
            this.chart2.Series.Add(series2);
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(476, 524);
            this.chart2.TabIndex = 11;
            this.chart2.Text = "chart2";
            // 
            // Chart2Btn
            // 
            this.Chart2Btn.Location = new System.Drawing.Point(1010, 674);
            this.Chart2Btn.Name = "Chart2Btn";
            this.Chart2Btn.Size = new System.Drawing.Size(151, 65);
            this.Chart2Btn.TabIndex = 12;
            this.Chart2Btn.Text = "정규분포";
            this.Chart2Btn.UseVisualStyleBackColor = true;
            this.Chart2Btn.Click += new System.EventHandler(this.Chart2Btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15F);
            this.label3.Location = new System.Drawing.Point(4, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "공정능력평가 :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 15F);
            this.label4.Location = new System.Drawing.Point(3, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "합격품질수준(AQL) :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 15F);
            this.label5.Location = new System.Drawing.Point(3, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "전체 검사수 :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PCAText);
            this.panel1.Controls.Add(this.AQLText);
            this.panel1.Controls.Add(this.LOTTEXT);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(543, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 164);
            this.panel1.TabIndex = 16;
            // 
            // PCAText
            // 
            this.PCAText.AutoSize = true;
            this.PCAText.Font = new System.Drawing.Font("굴림", 15F);
            this.PCAText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PCAText.Location = new System.Drawing.Point(224, 117);
            this.PCAText.Name = "PCAText";
            this.PCAText.Size = new System.Drawing.Size(20, 20);
            this.PCAText.TabIndex = 18;
            this.PCAText.Text = "0";
            // 
            // AQLText
            // 
            this.AQLText.AutoSize = true;
            this.AQLText.Font = new System.Drawing.Font("굴림", 15F);
            this.AQLText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AQLText.Location = new System.Drawing.Point(224, 71);
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
            this.LOTTEXT.Location = new System.Drawing.Point(224, 19);
            this.LOTTEXT.Name = "LOTTEXT";
            this.LOTTEXT.Size = new System.Drawing.Size(20, 20);
            this.LOTTEXT.TabIndex = 16;
            this.LOTTEXT.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 758);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Chart2Btn);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("굴림", 10F);
            this.Name = "Form1";
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button Chart2Btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PCAText;
        private System.Windows.Forms.Label AQLText;
        private System.Windows.Forms.Label LOTTEXT;
    }
}

