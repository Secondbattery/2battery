using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Batterty2
{
    public partial class frmRealTime : Form
    {

        public bool Is_PassV;
        public bool IS_PassH;
        private int Lot_Real = 0;
        private int FailCount = 0;
        private int LotProcess = 0;
        private string ProcessLabel = "";
        private int LOT = 0;
        private float Degree = 0f;

        private int VPass = 0;
        private int HPass = 0;

        private float VerticalH;
        private float HorizontalH;

        private float VerticalD;
        private float HorizontalD;

        private int HorizonFailCnt =0;
        private int VerticalFailCnt = 0;
        private int HVFailCnt = 0;
        /// <summary>
        //총 불량, 총 양품 변수들
        private int FullCount = 0;
        private int FullUnpassCount = 0;
        /// </summary>
        public void Init()
        {
            ProgressMax = 0;
            ProgressPosition = 0;
            ProgressBarING = 0;
            HorizonFailCnt = 0;
            VerticalFailCnt = 0;
            HVFailCnt = 0;
            LOT = 0;
            Degree = 0;
            LotProcess = 0;
            ProcessLabel = "";
            CountLot = 0;
            LOTHOLD = 0;
            FailCountForm = 0;
            Lot_RealForm = 0;
            AllPassCount = 0;
            AllFailCount = 0;
            logBox.Items.Clear();
        }
        public ListBox logBox
        {
            get { return _LogBox; }
            set { _LogBox = value; }
        }

        private int ProgressMax;
        private int ProgressPosition;
        delegate void ctrl_Invoke(ListBox ctrl, String message, String Netmessage);
        private Image Realimage;

        public void ChongPass()
        {
            AllFailCount = HVFailCnt + HorizonFailCnt + VerticalFailCnt;
            //AllPassCount = LOT - AllFailCount;
        }

        public int AllPassCount
        {
            get { return FullCount; }
            set { FullCount += value;

                Invoke((MethodInvoker)delegate ()
                {
                    PassCount.Text = FullCount.ToString();
                });
            }
        }
        public int AllFailCount
        {
            get { return FullUnpassCount; }
            set { FullUnpassCount = value;
                Invoke((MethodInvoker)delegate ()
                {
                    UnpassCount.Text = FullUnpassCount.ToString();
                });
            }
        }

        public void VisibleIcon(bool a,FontAwesome.Sharp.IconButton b)
        {
            if (a == false)
            {
                b.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
                b.IconColor = Color.Red;
            }
            else
            {
                b.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
                b.IconColor = Color.Lime;
            }
        }
        public bool IS_PASSH_ProPerty
        {
            get { return IS_PassH; }
            set { IS_PassH = value;

                Invoke((MethodInvoker)delegate ()
                {
                    VisibleIcon(IS_PassH, HorizonIcon);
                });


            }
        }

        public bool IS_PASSV_ProPerty
        {
            get { return Is_PassV; }
            set
            {
                Is_PassV = value;

                Invoke((MethodInvoker)delegate ()
                {
                    VisibleIcon(Is_PassV, VerticalIcon);
                });


            }
        }

        public int HVFCnt
        {
            get { return HVFailCnt; }
            set { HVFailCnt = value;

                Invoke((MethodInvoker)delegate ()
                {
                    HVCount.Text = HVFailCnt.ToString();
                });
             
            }
        }
        public void PassOrFail()
        {
            if (IS_PassH == true && Is_PassV == true)
            {
                ProcessLab = "PASS";
                
            }
            else if (IS_PassH == false && Is_PassV == false)
            {
                ProcessLab = "BothFail";
                HVFCnt = HVFCnt + 1;
                CountHorizonFail -= 1;
                CountVerticalFail -= 1;
            }
            else
            {

                ProcessLab = "불합격";
            }

        }

        public int CountHorizonFail
        {
            get { return HorizonFailCnt; }
            set { HorizonFailCnt = value;

                
                Invoke((MethodInvoker)delegate ()
                {
                    HCount.Text = HorizonFailCnt.ToString();

                   // VisibleIcon(, HorizonIcon);
                });
            }
        }

        public int CountVerticalFail
        {
            get { return VerticalFailCnt; }
            set
            {
                VerticalFailCnt = value;


                Invoke((MethodInvoker)delegate ()
                {
                    VCount.Text = VerticalFailCnt.ToString();
                });
            }
        }

        public int ProgressBarING
        {
            get { return ProgressPosition; }
            set
            {
                ProgressPosition = value;
                ProGressBarNow.Position += ProgressPosition;
                ProGressBarNow.Update();
            }
        }
        public int ProgressMaxSet
        {
            get { return ProgressMax; }
            set
            {
                ProgressMax = value;

                ProGressBarNow.Properties.Maximum = ProgressMax;
                ProGressBarNow.Update();
            }
        }
        public void showMessage(ListBox textbox, String message, String netmessage)
        {
            if (textbox.InvokeRequired)
            {
                textbox.Invoke(new ctrl_Invoke(showMessage), textbox, message, netmessage);
            }
            else
            {
                StringBuilder Log = new StringBuilder();
                Log.Append(message + netmessage);
                //  SendDisplay(message + netmessage);
                logBox.Items.Add(Log.ToString());
                // realf..Items.Add(message + netmessage);
            }
        }
        public void SendDisplay(String MessageN)
        {
            StringBuilder Log = new StringBuilder();
            Log.Append(MessageN);
            if (logBox.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    SendDisplay(MessageN);
                });
                // SendDisplay(MessageN);
            }
            else
            {
                logBox.Items.Add(Log.ToString());
            }
            //  Invoke((MethodInvoker)delegate {
            // logBox.Items.Add(Log.ToString());

            //   });

        }
        public Image Realimg
        {

            get { return Realimage; }
            set
            {
                Realimage = value;
                ImgSet();
                // pictureBox1.Image = Realimage;
                //  pictureBox1.Update();
            }
        }
        private void ImgSet()
        {
            if (pictureBox1.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    ImgSet();
                });
            }
            else
            {
                this.pictureBox1.Image = Realimage;
             //   this.pictureBox1.Image = Realimage;

            }
        }
        public float Degree_Propery
        {
            get { return Degree; }
            set
            {
                Degree = value;

                DegreeControl.Text = Degree.ToString();
                DegreeControl.Update();
            }
        }
        public float VerticalH_Property  //규격 세로
        {
            get { return VerticalH; }
            set
            {
                VerticalH = value;
                VerticalHold.Text = VerticalH.ToString();
                //H는 규격값 D는 변화되는 값
            }
        }
        public float HorizontalH_Property  //규격 가로
        {
            get { return HorizontalH; }
            set
            {
                HorizontalH = value;
                HorizonHold.Text = HorizontalH.ToString();
            }
        }
        public float VerticalD_Property  //실시간 세로 치수
        {
            get { return VerticalD; }
            set
            {
                VerticalD = value;
                VerticalDis.Text = VerticalD.ToString();
            }
        }
        public float HorizontalD_Property  //실시간 가로 치수
        {
            get { return HorizontalD; }
            set
            {
                HorizontalD = value;

                HorizonDis.Text = HorizontalD.ToString();
            }

        }
        public string ProcessLab
        {
            get { return ProcessLabel; }
            set
            {
                ProcessLabel = value;

                if (ProcessLabel == "PASS")
                {
                    AllPassCount = 1;
                    passfaillabel.Text = "합격";
                    
                    passfaillabel.BackColor = Color.Lime;
                }
                else if (ProcessLabel == "BothFail")
                {
                    passfaillabel.Text = "불합격";
                   // HVFCnt+=1;
                    passfaillabel.BackColor = Color.Red;
                }
                else
                {
                    passfaillabel.Text = "불합격";
                    passfaillabel.BackColor = Color.Red;
                }
                //passfaillabel.Text = ProcessLabel.ToString();
            }
        }
        public int LOTHOLD
        {
            get { return LOT; }
            set
            {
                LOT = value;
                LotL.Text = LOT.ToString();
            }

        }
        public int CountLot
        {
            get { return LotProcess; }
            set
            {
                LotProcess = value;
                LotCount.Text = LotProcess.ToString();
                if (LotProcess == LOT)
                {
                    ProGressBarNow.Position = ProgressMax;
                   //  MessageBox.Show("Inspection Complete!");
                    //    Thread.Sleep(3000);
                    //    Manager.Instance.Is_Finish = true;
                    //    Manager.Instance.Is_Finish_Root();
                }
            }
        }
        public int Lot_RealForm
        {
            get { return Lot_Real; }
            set { Lot_Real = value; }
        }
        public int FailCountForm
        {
            get { return FailCount; }
            set { FailCount = value; }

        }
        public void makeTempChart(int a, double y)
        {
            float GoProPerty = Convert.ToSingle(y);
            Degree_Propery = GoProPerty;
            Series tChart = DegreeChart.Series[0];
            Invoke((MethodInvoker)delegate
            {
                tChart.Points.AddPoint(a, y);
                if (tChart.Points.Count > 10)
                {
                    tChart.Points.Remove(tChart.Points[0]);
                }
            });
        }
        public frmRealTime()
        {
            //Is_Pass = true;
            InitializeComponent();
            SendDisplay("Ready To Start");
            // pictureBox1.Image = Properties.Resources.vision2;
            Lot_RealForm = 0;
            FailCountForm = 0;
            ProcessLab = "Null";
            ProGressBarNow.Position = 1;
            ProGressBarNow.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            ProGressBarNow.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            
            // ProGressBarNow.Properties.LookAndFeel = FlatStyle.Flat;
            //ProGressBarNow.Properties.LookAndFeel.SkinName = "Pumpkin";
            // CountLot = 0;
            //   LateStart();
        }
        
    }
}
