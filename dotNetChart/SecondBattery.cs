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
using MaterialSkin.Controls;
using MaterialSkin;


namespace dotNetChart
{
    public partial class SecondBattery : MaterialForm
    {
        // var normal = new NormalDis
        private float resultCP = 0.75f;
        private int resultAQL = 0;
        private int resultLOT = 100;
        private float resultSigma = 1.24f;


        private string Passed = "";

        private float[] SampleDistance = { 91.0f, 87.0f, 95.0f, 90.0f, 90.0f, 92.0f, 91.0f, 91.0f, 90.0f, 89.0f, 92.0f, 88.0f, 94.1f, 89.0f, 90.0f, 92.0f, 91.0f, 91.0f, 93.0f, 89.0f, 91.0f, 90.0f, 91.0f, 89.0f, 90.0f, 90.0f, 91.0f, 91.0f, 90.0f, 91.0f, 91.0f, 87.0f, 95.0f, 90.0f, 90.0f, 92.0f, 91.0f, 91.0f, 90.0f, 89.0f, 92.0f, 88.0f, 94.1f, 89.0f, 90.0f, 92.0f, 91.0f, 91.0f, 93.0f, 89.0f, 91.0f, 90.0f, 91.0f, 89.0f, 90.0f, 90.0f, 91.0f, 91.0f, 90.0f, 91.0f, 91.0f, 87.0f, 95.0f, 90.0f, 90.0f, 92.0f, 91.0f, 91.0f, 90.0f, 89.0f, 92.0f, 88.0f, 94.1f, 89.0f, 90.0f, 92.0f, 91.0f, 91.0f, 93.0f, 89.0f, 91.0f, 90.0f, 91.0f, 89.0f, 90.0f, 90.0f, 91.0f, 91.0f, 90.0f, 91.0f, 91.0f, 92.0f, 89.0f, 88.0f, 90.0f, 89.0f, 90.0f, 91.0f, 92.0f, 88.0f };
        private List<float> SampleDt = new List<float>();
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
        public SecondBattery()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
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
            
            SampleDt.Clear();
            Sample.Clear();
            count = 0;
            
            chart2.Series[1].Color = Color.Red;
            
        }
        private string WhatData(string data)
        {
            string str = data;
            if (data.Contains("Cp"))
            {  
                str = str.Substring(2);
                //CP를 제외한 값을 저장
                try
                {
                    float a = Convert.ToSingle(str);
                    resultCP = a;
                }
                catch (Exception e)
                {
                    listBox1.Items.Add("Error Cp Calculate");
                }



            }
            else if (data.Contains("AQL_pass"))
            {
                str = str.Substring(8);

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
                    Show_Unit_Defect(a);
                 
                }
                catch (Exception e)
                {
                    

                }


            }
         
            else if (data.Contains("Sigma"))
            {
                str = str.Substring(5);
            }
            else if (data.Contains("Mean"))
            {
                str = str.Substring(4);
                float a = 0f;
                try
                {
                    a = Convert.ToSingle(str);
                }
                catch
                {
                    Application.Exit();
                }

                //float a = Convert.ToSingle(str);
                average = a;
            }
            else if (data.Contains("Unit_pass"))
            {
                str = str.Substring(9);
                int a = 0;
                try
                {
                    a = Convert.ToInt32(str);
                }
                catch(Exception e)
                {
                    Application.Exit();
                }
                finally
                {
                    if (a == 0)
                    {
                        Passed = "Fail";
                        listBox1.Items.Add(Passed);
                    }
                    else if (a == 1)
                    {
                        Passed = "Pass";
                        listBox1.Items.Add(Passed);
                    }
                    
                }
                
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
            for (int k = 0; k < 100; k++)
            {
                SampleDt.Add(SampleDistance[k]);
                if (count > 99)
                {
                    return;
                }
                float x = SampleDt[count];
                int xx = 0;
                for(int v=0;v< SampleDt.Count(); v++)
                {
                    if(SampleDt[v]==x)
                    {
                        xx++;
                    }
                }
                chart1.Series[0].Points.AddXY(SampleDt[k], xx);
                string test = string.Format("치수 : {0}  합/불합 : {1}  검사횟수 : {2}", SampleDt[count], Passed, count+1);
                listBox1.Items.Add(test);
                count++;
                LOTTEXT.Text = count.ToString();
                DelaySystem(100);
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
                listBox1.Items.Add(String.Format("Socket Connection Success {0}", client_socket.RemoteEndPoint.ToString()));
                isConnected = true;
                Thread listen_thread = new Thread(Do_receive);
                listen_thread.Start();

            }
            catch (Exception ex)
            {
                listBox1.Items.Add(String.Format("Connection Fail", ex.Message));
            }
        }
        void Do_receive()
        {
            try
            {
                while (true)
                {
                    byte[] bytes = new byte[1024];
                    int bytesRec = client_socket.Receive(bytes);
                    string data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    listBox1.Items.Add(String.Format("New Data is pushed : {0}", data.ToString()));
                    string data2 = WhatData(data);

                   // listBox1.Items.Add(String.Format("New Data is pushed : {0}",data2.ToString()));
                }
            }
            catch (Exception e)
            {
                listBox1.Items.Add(String.Format("실패",e.Message));
            }
        }


      
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
                pca = "Excellent";
            }
            else if(cp >1.67f )
            {
                pca = "Very Good";
            }
            else if(cp > 1.33f)
            {
                pca = "Good";
            }
            else if (cp > 1.0f)
            {
                pca = "Normal";

            }
            else if (cp > 0.67f)
            {
                pca = "Not Good";
            }
            else if (cp > 0f)
            {
                pca = "Bad";
            }
            else
            {
                pca = "Worst";
            }
            return pca;
        }
       
        private void Chart2Btn_Click(object sender, EventArgs e)
        {
          
            Show_Graph_Cil();
            Show_PCA_Result();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void Show_Unit_Defect(float a)
        {
            
            DistanceObject.Add(a);
            count = DistanceObject.Count();
            resultLOT = count;
            LOTTEXT.Text = resultLOT.ToString();
            int x = 0;
            for (int i = 0; i < count; i++)
            {
                if (DistanceObject[i] == a)
                {
                    x++;
                }
            }
            Show_AQL_Result(a, x);
            
        }
        private void Show_AQL_Result(float a,int x)
        {
            chart1.Series[0].Points.AddXY(a, x);
        }
        private void Show_Graph_Cil()
        {
            for (float i = average - 5.0f; i < average + 5.0f; i += 0.1f)
            {
                numsman.Add(i);
            }
            for (int i = 0; i < numsman.Count; i++)
            {
                chart2.Series[0].Points.AddXY(numsman[i], Calculman(numsman[i], average, resultSigma));
                chart2.Series[1].Points.AddXY(numsman[i], Calculman(numsman[i], average, resultSigma));
                DelaySystem(100);
            }
            //LOTTEXT.Text = count.ToString();

            if (resultAQL == 1)
            {
                AQLText.Text = "Pass";
            }
            else if (resultAQL == 0)
            {
                AQLText.Text = "Fail";

            }
            else
            {
                AQLText.Text = "ERROR";
            }
        }
        private void Show_PCA_Result()
        {
            string datacp = CPCheck(resultCP);
            PCAText.Text = datacp;
            CPValueText.Text = resultCP.ToString();
            MeanValue.Text = average.ToString();
            SigmaValue.Text = resultSigma.ToString();
            LOTTEXT.Text = resultLOT.ToString();
        }
    }
}
