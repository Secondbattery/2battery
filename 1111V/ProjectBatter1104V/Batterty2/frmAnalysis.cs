using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batterty2
{
    public partial class frmAnalysis : Form
    {
        Random random = new Random();

        public List<float> vPointnum = new List<float>();
        public List<float> hPointnum = new List<float>();

        public List<float> CalCulY = new List<float>();
        public string Result = "";
        /// <text함수들>
        private float vAverage = 9.0f;
        private float hAverage = 9.0f;
        private string vCP;
        private float vCPfloat;
        private float hCPfloat;
        private string hCP;
        private int vPass;
        private int hPass;
        private float hsigma = 1.1f;
        private float vsigma = 1.1f;
        private int HorizonFailCnt = 0;
        private int VerticalFailCnt = 0;
        private int HVFailCnt = 0;

        private float HorizonChangeNeeds = 0f;
        private float VerticalChangeNeeds = 0f;
        private float SumWhere = 0f;
        //불량률 그래프용 변수
        private int LOT; //총 개수
                         // private float VerticalDefect;
                         //  private float HorizontalDefect;
                         //
        private string[] ResultString = new string[20];
        // private char testman = ",";
        public async void DoSplit(string result)
        {

            result = result.Replace("Last", "");
            ResultString = result.Split(new string[] { "," }, StringSplitOptions.None);
          
            for (int i = 0; i < ResultString.Length; i++)
            {
                ResultDataShow(ResultString[i]);
                await Task.Delay(100);
            }
            var taskresult = Task.Run(() => ShowResultText());
            await taskresult;
            

        }
        string Final = "TOCAQL_hpass1.8,AQL_vpass1.8,Sigmah1.8,Sigmav1.8,Meanh1.8,Meanv1.8,Cph1.8,Cpv1.8,hpassCount1.8,vpassCount1.8,hDefectrate1.8,vDefectrate1.8";

        private async void ResultDataShow(string res)
        {
            var task1 = Task.Run(() => DataResult(res));
            string result = await task1;
            //이하 표시
        }
        async Task<string> DataR(string data)
        {

            return data;
        }
        private string DataResult(string data)
        {
            if (data.Contains("AQL_hpass"))
            {
                data = data.Substring(9);
                try
                {
                    h_Pass = Convert.ToInt32(data);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (data.Contains("AQL_vpass"))
            {
                data = data.Substring(9);
                try
                {
                    v_Pass = Convert.ToInt32(data);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (data.Contains("Sigmah"))
            {
                data = data.Substring(6);
                try
                {
                    H_sigma = Convert.ToSingle(data);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (data.Contains("Sigmav"))
            {
                data = data.Substring(6);
                try
                {
                    V_sigma = Convert.ToSingle(data);

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (data.Contains("Meanh"))
            {
                data = data.Substring(5);
                try
                {
                    h_Average = Convert.ToSingle(data);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }


            }
            else if (data.Contains("Meanv"))
            {
                data = data.Substring(5);
                try
                {
                    v_Average = Convert.ToSingle(data);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (data.Contains("Cph"))
            {
                data = data.Substring(3);
                try
                {
                    float fdata = Convert.ToSingle(data);
                    h_Cp = CPCheck(fdata);
                    Task.Delay(100);
                    h_Cpfloat = fdata;
                }
                catch { }
            }
            else if (data.Contains("Cpv"))
            {
                data = data.Substring(3);
                try
                {
                    float fdata = Convert.ToSingle(data);

                    v_Cp = CPCheck(fdata);
                    Task.Delay(100);
                    v_Cpfloat = fdata;
                }
                catch { }
            }
            else if (data.Contains("hunpassCount"))
            {
                //data = data.Substring(12);
                data = data.Replace("hunpassCount", "");
                try
                {
                    int hp = Convert.ToInt32(data);
                    HorizonFailCntProperty = hp;
                }
                catch (Exception e)
                {
                    MessageBox.Show(data + " hun error");
                    HorizonFailCntProperty = 1;
                }
            }
            else if (data.Contains("vunpassCount"))
            {
                //data = data.Substring(13);
                data = data.Replace("vunpassCount", "");
                try
                {
                    int vp = Convert.ToInt32(data);
                    VerticalFailCntProperty = vp;
                }
                catch (Exception e)
                {//
                    MessageBox.Show(data + "vun Error 입니다");
                    VerticalFailCntProperty = 1;
                }
            }
            else if (data.Contains("TotalunpassCount"))
            {
                // data = data.Substring(13);
                data = data.Replace("TotalunpassCount", "");
                try
                {
                    int hvp = Convert.ToInt32(data);
                    HVFailCntProPerty = hvp;
                }
                catch (Exception e)
                {
                    // MessageBox.Show(e.ToString()+data);
                    MessageBox.Show(data + "total Error 입니다");
                    HVFailCntProPerty = 1;
                }
            }
            else if (data.Contains("hDefectrate"))
            {
                data = data.Substring(11);
            }
            else if (data.Contains("vDefectrate"))
            {
                data = data.Substring(11);
            }
            else if(data.Contains("Hadjust"))
            {
                data = data.Substring(7);
                try
                {
                    float fdata = Convert.ToSingle(data);
                    HorizonChangeProPerty = fdata;
                }
                catch
                {
                    MessageBox.Show("Horizon Hadjust Error!");
                }
            }
            else if(data.Contains("Vadjust"))
            {
                data = data.Substring(7);
                try
                {
                    float fdata = Convert.ToSingle(data);
                    VerticalChangeProPerty = fdata;
                }
                catch {
                    MessageBox.Show("Vertical Vadjust Error!");
                }
            }

            return data;
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
                //  pca = "매우 탁월함";
                pca = "매우 탁월함";
            }
            else if (1.67f<cp && cp < 2f)
            {
                //pca = "매우 우수함";
                pca = "매우 우수함";
            }
            else if (1.33f<cp && cp < 1.67f)
            {
                // pca = "우수함";
                pca = "우수함";
            }
            else if (1.0f<cp && cp < 1.33f)
            {
                // pca = "보통";
                pca = "보통";
            }
            else if (0.67f<cp && cp < 1.0f)
            {
                // pca = "저조함";
                pca = "저조함";
            }
            else if (0.33<cp && cp < 0.67f)
            {
                // pca = "불량함";
                pca = "불량함";
            }
            else
            {
                // pca = "매우 불량함";
                pca = "매우불량함";
            }


            return pca;
        }

        #region 프로퍼티들
        public float VerticalChangeProPerty
        {
            get { return VerticalChangeNeeds; }
            set { VerticalChangeNeeds = value;
                Invoke((MethodInvoker)delegate ()
                {
                    VerticalChange.Text = VerticalChangeNeeds.ToString();
                    VerticalChange.Update();
                });
            }
        }
        public float HorizonChangeProPerty
        {
            get { return HorizonChangeNeeds; }
            set { HorizonChangeNeeds = value;
                Invoke((MethodInvoker)delegate ()
                {
                    HorizonChange.Text = HorizonChangeNeeds.ToString();
                    HorizonChange.Update();
                  //  VerticalAver.Text = vAverage.ToString();
                  //  VerticalAver.Update();
                });
            }

        }
        public int LOTProperty
        {
            get { return LOT; }
            set
            {
                LOT = value;

            }
        }
        public int HVFailCntProPerty
        {
            get { return HVFailCnt; }
            set
            {
                HVFailCnt = value;
            }
        }
        public int HorizonFailCntProperty
        {
            get { return HorizonFailCnt; }
            set
            {
                HorizonFailCnt = value;

            }
        }
        public int VerticalFailCntProperty
        {
            get { return VerticalFailCnt; }
            set
            {
                VerticalFailCnt = value;
            }
        }
        /// </summary>
        /// text프로퍼티public int VerticalFailCntProperty
        /// p
        public float H_sigma
        {
            get { return hsigma; }
            set
            {
                hsigma = value;
            }
        }
        public float V_sigma
        {
            get { return vsigma; }
            set { vsigma = value; }
        }
        public float v_Average
        {
            get { return vAverage; }
            set
            {
                vAverage = value;
                Invoke((MethodInvoker)delegate ()
                {
                    VerticalAver.Text = vAverage.ToString();
                    VerticalAver.Update();
                });
               
            }
        }
        public float h_Average
        {
            get { return hAverage; }
            set
            {
                hAverage = value;
               
                Invoke((MethodInvoker)delegate ()
                {
                    HorizonAver.Text = hAverage.ToString();
                    HorizonAver.Update();
                });
            }

        }
        public float v_Cpfloat
        {
            get { return vCPfloat; }
            set
            {
                vCPfloat = value;
                Invoke((MethodInvoker)delegate ()
                {
                    VerticalCP.Text = vCPfloat.ToString();
                    VerticalCP.Update();
                });
            
            }
        }
        public float h_Cpfloat
        {
            get { return hCPfloat; }
            set
            {
                hCPfloat = value;
                Invoke((MethodInvoker)delegate ()
                {
                    HorizonCP.Text = hCPfloat.ToString();
                    HorizonCP.Update();
                });
                
            }
        }
        public string v_Cp
        {
            get { return vCP; }
            set
            {
                vCP = value;
                Invoke((MethodInvoker)delegate ()
                {
                    VerticalCPS.Text = vCP.ToString();
                    VerticalCPS.Update();
                });
             //   VerticalCPS.Text = vCP.ToString();
             //   VerticalCPS.Update();
            }
        }
        public string h_Cp
        {
            get { return hCP; }
            set
            {
                hCP = value;
                Invoke((MethodInvoker)delegate ()
                {
                    HorizonCPS.Text = hCP.ToString();


                    HorizonCPS.Update();
                });
              //  HorizonCPS.Text = hCP.ToString();


               // HorizonCPS.Update();
            }
        }
        public int v_Pass
        {
            get { return vPass; }
            set
            {
                vPass = value;
                if (vPass == 1)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        VerticalPass.Text = "합격";
                    });
                   
                }
                else if (vPass == 0)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        VerticalPass.Text = "불합격";
                    });
                }
                else
                    Invoke((MethodInvoker)delegate ()
                    {
                        VerticalPass.Text = "오류";
                    });

                VerticalPass.Update();
            }


        }
        public int h_Pass
        {
            get { return hPass; }
            set
            {
                hPass = value;
                if (hPass == 1)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        HorizonPass.Text = "합격";
                    });
                   // HorizonPass.Text = "Pass";
                }
                else if (hPass == 0)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        HorizonPass.Text = "불합격";
                    });
                }
                else
                    Invoke((MethodInvoker)delegate ()
                    {
                        HorizonPass.Text = "오류";
                    });

                HorizonPass.Update();
            }

        }

        ///프로퍼티 끝
        #endregion
        public void Init()
        {
           // InitializeComponent();
            InitText();
            vPointnum.Clear();
            hPointnum.Clear();
            ClearChart();
            HorizonChangeProPerty = 0f;
            VerticalChangeProPerty = 0f;

              vAverage = 9.0f;
       hAverage = 9.0f;
        vCP ="";
         vCPfloat = 0f;
       hCPfloat = 0f;
        hCP="";
       vPass=0;
         hPass=0;
        hsigma = 1.1f;
         vsigma = 1.1f;
        HorizonFailCnt = 0;
       VerticalFailCnt = 0;
        HVFailCnt = 0;

        HorizonChangeNeeds = 0f;
        VerticalChangeNeeds = 0f;
    }

        public frmAnalysis()
        {
            //Xtest.Clear();
            InitializeComponent();
            InitText();
            //  DrawChartFake();
            // ChartChart();
        }
        private void InitText()
        {
            HorizonAver.Text = "null";
            VerticalAver.Text = "null";
            HorizonPass.Text = "Null";
            VerticalPass.Text = "Null";
            HorizonCP.Text = "null";
            VerticalCP.Text = "null";
            HorizonCPS.Text = "Null";
            VerticalCPS.Text = "Null";
        }
       
        public void MakeNormalDistributionChart()
        {
            Series normal = chartControl4.Series[0];
            Series normalH = chartControl4.Series[1];
            for (float i = vAverage - 5.0f; i < vAverage + 5.0f; i += 0.1f)
            {
                vPointnum.Add(i);
            }
            for (float h = hAverage - 5.0f; h < hAverage + 5.0f; h += 0.1f)
            {
                hPointnum.Add(h);
            }
            int cnt = vPointnum.Count();
            for (int i = 0; i < cnt; i++)
            {
                normal.Points.AddPoint(vPointnum[i], Calculman(vPointnum[i], v_Average, V_sigma));
                normalH.Points.AddPoint(hPointnum[i], Calculman(hPointnum[i], h_Average, H_sigma));
                //  Thread.Sleep(100);
            }
        }
        public async void ShowResultText()
        {
            var task1 = Task.Run(() => MakeCircleChart());
            await task1;
            var task2 = Task.Run(() => MakeNormalDistributionChart());
        }
        private void ClearChart()
        {
            Series Horizon = Horizonchart.Series[0];
            Series Vertical = Verticalchart.Series[0];
            Series HVChart = AllChart.Series[0];

            for(int i = 0; i < 2; i++)
            {
                Horizon.Points.Remove(Horizon.Points[0]);
                Vertical.Points.Remove(Vertical.Points[0]);
                HVChart.Points.Remove(HVChart.Points[0]);
            }
        }
        public void MakeCircleChart()
        {
            Series Horizon = Horizonchart.Series[0];
            Series Vertical = Verticalchart.Series[0];
            Series HVChart = AllChart.Series[0];
            double FailH = Convert.ToDouble(HorizonFailCntProperty);
            double FailV = Convert.ToDouble(VerticalFailCntProperty);
            double FailHV = Convert.ToDouble(HVFailCntProPerty);
            Horizon.Points.AddPoint(1, LOTProperty - FailH);
            Horizon.Points.AddPoint(0, FailH);
            

            Vertical.Points.AddPoint(1, LOTProperty - FailV);
            Vertical.Points.AddPoint(0, FailV);

            HVChart.Points.AddPoint(1, LOTProperty - FailHV);
            HVChart.Points.AddPoint(0, FailHV);

          //  Horizonchart.Update();
          //  Verticalchart.Update();
          //  AllChart.Update();
        }
        string[] allman = new string[11];
      
        private void iconButton2_Click(object sender, EventArgs e)
        {
          //  DoSplit2(Final);
                MakeCircleChart();
               MakeNormalDistributionChart();
            // MakeCircleChart();
        }

        private void VerticalCP_Click(object sender, EventArgs e)
        {

        }
    }
}
