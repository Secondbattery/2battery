using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms.DataVisualization.Charting;
using System.Timers;
using System.Threading;
using System.Linq.Expressions;



namespace dotNetChart
{
    public partial class Form1 : Form
    {
        // var normal = new NormalDis
        private float resultCP = 0.75f;
        private int resultAQL = 0;
        private int resultLOT = 0;
        private float resultSigma = 1.24f;

        //private float[] nums = { };
        private List<float> numsman = new List<float>();
        //여기서부터 프로토콜
        Socket client_socket = null;
        private List<StringBuilder> m_Display = null;
        bool isConnected;
        byte[] bytes = new byte[1024];
        string data;
        public float average = 9f;
        float Sum = 0f;
        //여기까지 프로토콜
        int count = 0;
        public int[] Test = { };
        List<int> Sample = new List<int>();

        List<float> DistanceObject = new List<float>();
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            isConnected = false;
            DistanceObject.Clear();
        }
        public void SendDisplay(String nMessage)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append(nMessage);

            Invoke((MethodInvoker)delegate
            {
                listBox1.Items.Add(buffer.ToString());
                //이부분에서 각데이터별 함수로 위치 나누어주도록 할것
            });
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            for(float i = 4.0f; i < 13.1f; i += 0.1f)
            {
                numsman.Add(i);
            }
            
            Sample.Clear();
            /* for(int i=0;i<100;i++)
             {
                 int a = r.Next(0, 5);
                 Sample.Add(a);
             }
             for(int i=0;i<100;i++)
             {
                 int b = r.Next(0, 3);
             }*/
            chart2.Series[1].Color = Color.Red;
            //chart1.Series[0].ChartType = SeriesChartType.Bar;
        }
        private string WhatData(string data)
        {
            string str = data;
            if (data.Contains("CP"))
            {
                str = str.Substring(2);
                //CP를 제외한 값을 저장
                try
                {
                    float a = Convert.ToSingle(str);

                }
                catch (Exception e)
                {
                    listBox1.Items.Add("Error Cp Calculate");
                }



            }
            else if (data.Contains("AQL"))
            {
                str = str.Substring(3);

                try
                {
                    int aql = Convert.ToInt32(str);
                    if (aql == 1)
                    {
                        //합격
                        resultAQL = 1;
                    }
                    else if (aql == 0)
                    {
                        //불합격
                        resultAQL = 0;
                    }
                    else
                    {
                        //에러처리
                        resultAQL = -1;
                    }
                }
                catch (Exception e)
                {
                    listBox1.Items.Add("Error AQL Calculate");
                }
                //AQL을 제외한 값을 저장  1 True , 0 False(불합)
            }
            else if (data.Contains("Distance"))
            {
                str = str.Substring(8);
                //Distance를 제외한 값을 저장
                try
                {
                    float a = Convert.ToSingle(str);
                    DistanceObject.Add(a);

                }
                catch (System.IndexOutOfRangeException e)
                {
                    System.Console.WriteLine(e.Message);
                    throw new System.ArgumentOutOfRangeException("index parameter is out");

                }


            }
            else if (data.Contains("Average"))
            {
                str = str.Substring(7);
            }
            else if (data.Contains("Sigma"))
            {
                str = str.Substring(5);
            }
            else
                return str;

            return str;
        }
        private void DelaySystem(int MS)
        {
            DateTime dtAfter = DateTime.Now;
            TimeSpan dtDuration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime dtThis = dtAfter.Add(dtDuration);
            while (dtThis >= dtAfter)
            {
                System.Windows.Forms.Application.DoEvents();
                dtAfter = DateTime.Now;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 100; j++)
            {
                int a = r.Next(0, 5);
                Sample.Add(a);
                if (count > 99)
                {
                    return;
                }
                int x = Sample[count];
                int xx = 0;
                for (int i = 0; i < Sample.Count(); i++)
                {
                    if (Sample[i] == x)
                    {
                        xx++;
                    }
                }
                //int x = Sample[count];
                chart1.Series[0].Points.AddXY(Sample[count], xx);
                string test = string.Format("치수 : {0}  현재개수 : {1}  검사횟수 : {2}", Sample[count], xx, count);
                listBox1.Items.Add(test);
                count++;
                LOTTEXT.Text = count.ToString();
                DelaySystem(200);

            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
               // client_socket.Close();
                Application.Exit();
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PortBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IPBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            string Pbox = PortBox.Text;
            int portnum = Convert.ToInt32(Pbox);
            if (isConnected == true)
                return;
            try
            {
                client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client_socket.Connect(new IPEndPoint(IPAddress.Parse(IPBox.Text), portnum));
                listBox1.Items.Add(String.Format("소켓 연결 완료 {0}", client_socket.RemoteEndPoint.ToString()));
                isConnected = true;
                Thread listen_thread = new Thread(do_receive);
                listen_thread.Start();

            }
            catch (Exception ex)
            {
                listBox1.Items.Add(String.Format("연결 실패", ex.Message));
            }
        }
        void do_receive()
        {
            try
            {
                while (true)
                {
                    byte[] bytes = new byte[1024];
                    int bytesRec = client_socket.Receive(bytes);
                    string data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    string data2 = WhatData(data);

                    listBox1.Items.Add(data2);
                }
            }
            catch (InvalidOperationException e)
            {
                listBox1.Items.Add("Receive Error");
            }
        }

      /*  private void resultbtn_Click(object sender, EventArgs e)
        {
           
        }*/
    
        #region y좌표구하기 - GetY(x, oneOver2PI,mean,standardDeviation, variance)



        private float GetY(float x, float oneOver2PI, float mean, float standardDeviation, float variance)
        {
            return (float)(oneOver2PI * Math.Exp(-(x - mean) * (x - mean) / (2 * variance)));

        }
        #endregion
        private double Calculman(double x, float mean, float sigma)
        {
            double y = 0f;

            y = (1 / (Math.Sqrt(2 * Math.PI) * sigma)) * Math.Pow(Math.E, -1 * (Math.Pow(x - mean, 2)) / (2 * Math.Pow(sigma, 2)));


            return y;

        }
        private string CPCheck(float cp)
        {
            string pca = "";
            if (cp >= 2f)
            {
                pca = "매우 탁월함";
            }
            else if(cp <2f )
            {
                pca = "매우 우수함";
            }
            else if(cp < 1.67f)
            {
                pca = "우수함";
            }
            else if (cp < 1.33f)
            {
                pca = "보통";

            }
            else if (cp < 1.0f)
            {
                pca = "저조함";
            }
            else if (cp < 0.67f)
            {
                pca = "불량함";
            }
            else
            {
                pca = "매우 불량함";
            }
            return pca;
        }
        private void Chart2Btn_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<numsman.Count;i++)
            {
                chart2.Series[0].Points.AddXY(numsman[i], Calculman(numsman[i], average, resultSigma));
                chart2.Series[1].Points.AddXY(numsman[i], Calculman(numsman[i], average, resultSigma));
                DelaySystem(100);
            }
            //LOTTEXT.Text = count.ToString();
            string datacp = CPCheck(resultCP);
            PCAText.Text = datacp;
            if(resultAQL == 1)
            {
                AQLText.Text = "합격";
            }
            else if(resultAQL == 0)
            {
                AQLText.Text = "불합격";

            }
            else
            {
                AQLText.Text = "에러발생";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
