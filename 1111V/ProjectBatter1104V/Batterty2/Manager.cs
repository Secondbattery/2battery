using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Batterty2
{

    public partial class Manager : DevExpress.XtraEditors.XtraForm
    {
        private static Manager instance;
        //SingleTon Pattern 사용 선언 ; 스크립트 인스턴스화


        // 접속부분
        Socket client_socket;
        //비동기
        private Socket clientSock_async = null;
        private Socket cbSock;
        private byte[] recvBuffer;
        private const int MAXSIZE = 4096;
        private string HOST_async = "127.0.0.1";
        private int PORT_async = 9000;
        private string imgdatastring = "";
        delegate void ctrl_Invoke(ListBox ctrl, String message, String Netmessage);
        //비동기끝

        string data;
        string imgdata;


        Random random = new Random();
        private double resultTemp = 0;
        private bool Is_img = false;

        private string HOST = "";
        private int PORT = 9000;
        public bool is_con = false;
        public bool Is_Finish = false;
        // 접속부분 끝



        int count = 0;
        public int[] Test = { };

        private IconButton currentBtn;
        private Panel leftBorderBtn;

        public float haverage = 9f;


        int temp = 0;


        //class
        frmInput inputf = new frmInput() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmRealTime realf = new frmRealTime() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmAnalysis analf = new frmAnalysis() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmData dataf = new frmData() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        //Constructor
        private Manager()
        {
            InitializeComponent();
            recvBuffer = new byte[MAXSIZE];
            timer1.Start();
            timer1.Interval = 1000;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            lblTitle.Text = "로그인";
            AddForm();
            Invisible();
            this.PnlFormLoader.Controls[0].Visible = true;

            btnLogout.Visible = false;
        }
        public static Manager Instance
        { //싱글톤 리턴부분
            get
            {
                if (instance == null)
                {
                    instance = new Manager();
                }
                return instance;
            }
        }
        public void AllInit()
        {
            realf.Init();
            analf.Init();
            inputf.Init();
        }
        public Image ConvertBase64ToImage(string base64String)
        {
            byte[] imgBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length))
            {
                ms.Write(imgBytes, 0, imgBytes.Length);
                return Image.FromStream(ms, true);
            }
        }
        public void Is_Finish_Root()
        {
            if (Is_Finish == false)
                return;
            //실시간 로트 검사가 끝날시 자동 결과화면 버튼 클릭
            AnalysisBtn.PerformClick();
        }
        public void AddForm()
        {
            this.PnlFormLoader.Controls.Clear();
            //this.PnlFormLoader.Controls.Add(loginf);
            this.PnlFormLoader.Controls.Add(inputf);
            this.PnlFormLoader.Controls.Add(realf);
            this.PnlFormLoader.Controls.Add(analf);
            this.PnlFormLoader.Controls.Add(dataf);
            
        }
        public void Connectscript()
        {
            this.PnlFormLoader.Controls.Clear();
        }
        #region 서버 접속 부분 
        public void DoCon(string host, int port)
        {
            clientSock_async = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.BeginConnect(host, port);
        }
        public void BeginConnect(string host, int port)
        {
            try
            {
                HOST_async = host;
                PORT_async = port;
                clientSock_async.BeginConnect(HOST_async, PORT_async, new AsyncCallback(ConnectCallBack), clientSock_async);
            }
            catch (SocketException se)
            {
                MessageBox.Show("Wrong Input");
            }
        }
        private void FirstConnectForm()
        {
            if (PnlFormLoader.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    FirstConnectForm();
                });
            }
            else
            {
                this.PnlFormLoader.Controls[0].Visible = true;
            }
        }
        private void ConnectCallBack(IAsyncResult IAR)
        {
            try
            {
                Socket tempSocket = (Socket)IAR.AsyncState;
                IPEndPoint svrEP = (IPEndPoint)tempSocket.RemoteEndPoint;
                // showMessage(listBox1, "Server Con Complete", svrEP.Address + "");
                realf.SendDisplay("Server con " + svrEP.Address + "");
                tempSocket.EndConnect(IAR);
                cbSock = tempSocket;
                cbSock.BeginReceive(this.recvBuffer, 0, recvBuffer.Length, SocketFlags.None,
                    new AsyncCallback(OnReceiveCallBack), cbSock);
                is_con = true;
                inputf.isconnected = true;
                // Invisible();
                MessageBox.Show("Connect Success!");
               // FirstConnectForm();
                // btnLogout.Visible = true;
                //  ConLabel.ForeColor = Color.Green;
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.NotConnected)
                {
                    realf.showMessage(realf.logBox, "con Error : ", se.Message);
                    // realf.SendDisplay("Server con Failed" + se.Message);
                    // showMessage(realf.send, "Server con Failed", se.Message);
                    this.BeginConnect(HOST_async, PORT_async);
                }
            }
        }
        public void BeginSend(string message)
        {
            try
            {
                if (clientSock_async.Connected)
                {
                    byte[] buffer = new UTF8Encoding().GetBytes(message);
                    clientSock_async.BeginSend(buffer, 0, buffer.Length, SocketFlags.None,
                        new AsyncCallback(SendCallBack), message);
                }
            }
            catch (SocketException e)
            {
                // showMessage("Send Error");
                realf.showMessage(realf.logBox, "Send Error : ", e.Message);
                // showMessage(listBox1, "Send Error ", e.Message);
            }
        }
        private void SendCallBack(IAsyncResult IAR)
        {
            string message = (string)IAR.AsyncState;
            realf.showMessage(realf.logBox, "Send Complete : ", message);

        }
        public void Receive()
        {
            cbSock.BeginReceive(this.recvBuffer, 0, recvBuffer.Length, SocketFlags.None,
                new AsyncCallback(OnReceiveCallBack), cbSock);

        }
        private void OnReceiveCallBack(IAsyncResult IAR)
        {
            try
            {
                Socket tempSock = (Socket)IAR.AsyncState;
                int nReadSize = tempSock.EndReceive(IAR);
                if (nReadSize != 0)
                {


                    string sData = Encoding.UTF8.GetString(recvBuffer, 0, nReadSize);
                    if (sData.Contains("<sof>"))
                    {
                        Is_img = true;
                    }
                    if (Is_img == true) { 
                        imgdatastring += sData;
                        realf.showMessage(realf.logBox, "Img is ", "Loading...");
                    }
                    // imgdatastring += sData;
                    if (imgdatastring.Contains("<sof>") && imgdatastring.Contains("<eof>"))
                    {
                        Is_img = false;
                        imgdata = imgdatastring;
                        imgdata = imgdata.Replace("<sof>", "");
                      //  realf.showMessage(realf.logBox, "recv : ", imgdata);
                        imgdata = imgdata.Replace("<eof>", "");
                      //  realf.showMessage(realf.logBox, "recv : ", imgdata);
                        realf.showMessage(realf.logBox, "Send Complete img: ", "yes");
                     
                        try
                        {
                            realf.Realimg = ConvertBase64ToImage(imgdata);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        sData = "";
                        imgdatastring = "";
                        imgdata = "";
                    }
                    string data2 = WhatData(sData);
                    realf.showMessage(realf.logBox, "recv : ", data2);
                    
                    data2 = "";

                }

            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.ConnectionReset)
                {
                    MessageBox.Show("연결부터 하세요");
                    //this.BeginConnect();
                }
            }
            this.Receive();
        }
        /*public void DoConnect(string host, int port)
        {
            if (is_con == true)
                return;

            HOST = host;
            PORT = port;
            client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client_socket.Connect(new IPEndPoint(IPAddress.Parse(HOST), PORT));

            is_con = true;
            loginf.isconnected = true;
            Invisible();
            this.PnlFormLoader.Controls[4].Visible = true;
            btnLogout.Visible = true;
            ConLabel.ForeColor = Color.Green;
            Thread listen_thread = new Thread(Do_Receive);
            listen_thread.Start();

            if (is_con == false)
            {
                listen_thread.Join();
                ConLabel.Text = "NConnect";
                ConLabel.ForeColor = Color.Red;
                IS_Con_True_Form();
            }

        }
        */
        private void Do_Receive()
        {
            ConLabel.Text = "Connecting...";
            while (true)
            {
                if (is_con == false)
                {
                    break;
                }
                if (Is_img == true)
                {
                    realf.SendDisplay("Image Loading...");
                    while (true)
                    {
                        byte[] bytes = new byte[1024];
                        int byteRec = client_socket.Receive(bytes);
                        imgdata += Encoding.UTF8.GetString(bytes, 0, byteRec);
                        try
                        {
                            if (imgdata != null && imgdata.Contains("<eof>"))
                            {
                                imgdata = imgdata.Substring(5);
                                imgdata = imgdata.Substring(0, imgdata.Length - 5);
                                realf.Realimg = ConvertBase64ToImage(imgdata);

                                Is_img = false;
                                imgdata = "";
                                realf.SendDisplay("Image Complete. Breaking...");
                                break;
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }

                    Is_img = false;
                    continue;
                }
                else
                {

                    byte[] bytes = new byte[1024];
                    int byteRec = client_socket.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, byteRec);
                    if (data.Contains("<sof>"))
                    {
                        Is_img = true;
                        imgdata = data;
                        data = "";
                        continue;
                    }
                    string data2 = WhatData(data);
                    realf.SendDisplay(data2);
                    data = "";
                }
                imgdata = "";
                data = "";



            }

        }
        private string ZeroOr(string a)
        {
            

            if (Convert.ToInt32(a) < 10)
            {
                a = "0" + a;
            }

            return a;
        }
        public void Do_Send(string Model, string Lot, string V, string H)
        {
            int minute = DateTime.Now.Minute;
            
            string Timesend = DateTime.Now.Year.ToString()  + ZeroOr(DateTime.Now.Month.ToString())  + ZeroOr(DateTime.Now.Day.ToString())
                    + ZeroOr(DateTime.Now.Hour.ToString())  + ZeroOr(DateTime.Now.Minute.ToString());
            realf.LOTHOLD = Convert.ToInt32(Lot);
            analf.LOTProperty = Convert.ToInt32(Lot);
            realf.VerticalH_Property = Convert.ToSingle(V);
            realf.HorizontalH_Property = Convert.ToSingle(H);
            realf.ProgressMaxSet = Convert.ToInt32(Lot);
            realf.ProgressBarING = 0;
            List<String> LS = new List<String>();
            LS.Add(Model);
            LS.Add(Lot);
            LS.Add(H);
            LS.Add(V);
            LS.Add(Timesend);
            if (is_con == false)
            {
                MessageBox.Show("Not Connected Yet");
                return;
            }

            StringBuilder Dates = new StringBuilder();


            Dates.Append("TORDatesStand");
            for (int i = 0; i < LS.Count; i++)
            {
                Dates.Append(",");
                Dates.Append(LS[i]);
                Thread.Sleep(100);
            }

            // byte[] msg = Encoding.UTF8.GetBytes(Dates.ToString());
            //  int bytesSend = client_socket.Send(msg);
            BeginSend(Dates.ToString());
            realf.showMessage(realf.logBox, "send : ", Dates.ToString());
            Thread.Sleep(500);
            BeginSend("start");

            Thread.Sleep(500);

            btnRealTime.PerformClick();
            //  MessageBox.Show("Message Send Complete");
        }
        #endregion

        public void MinusGakja()
        {
            realf.CountHorizonFail--;
            realf.CountVerticalFail--;
        }
        //string Whatresult = aw
        private string WhatData(string data)
        {

            string str = data;
            //send_dp = 'TOCUnit_no'+str(count+1)+","+'Unit_horizon'+str(Result_horizon)+","+'Unit_vertical'+str(Result_vertical)+","+'Unit_hpass'+str(Result_hpass)+","
            //           +'Unit_vpass'+str(Result_vpass)+","+'TEMP'+str(temperature)
            // string Final = "TOCAQL_hpass1.8,AQL_vpass1.8,Sigmah1.8,Sigmav1.8,Meanh1.8,Meanv1.8,Cph1.8,Cpv1.8,hpassCount1.8,vpassCount1.8,hDefectrate1.8,vDefectrate1.8";
            //12개

            if (str.Contains("TOC"))
            {
                str = str.Substring(3);
                if (str.Contains("Unit_"))
                {

                    str = str.Substring(5);

                    if (str.Contains("horizon"))
                    {
                        str = str.Substring(7);
                        try
                        {
                            realf.HorizontalD_Property = Convert.ToSingle(str);

                        }
                        catch (Exception e)
                        {
                            realf.showMessage(realf.logBox, "Error : ", e.ToString());
                        }

                    }
                    else if (str.Contains("vertical"))
                    {
                        str = str.Substring(8);
                        try
                        {
                            realf.VerticalD_Property = Convert.ToSingle(str);

                        }
                        catch (Exception e)
                        {
                            realf.showMessage(realf.logBox, "Error : ", e.ToString());
                        }

                    }
                    else if (str.Contains("hpass"))
                    {
                        str = str.Substring(5);
                        try
                        {
                            int hpass = Convert.ToInt32(str);
                            if (hpass == 1)
                            {
                               // realf.IS_PassH = true;
                                realf.IS_PASSH_ProPerty = true;
                                //realf.ProcessLab = "PASS";
                            }
                            else
                            {
                                // realf.IS_PassH = false;
                                realf.IS_PASSH_ProPerty = false;
                                realf.CountHorizonFail++;
                                analf.HorizonFailCntProperty++;
                            }
                           
                            //realf.ProcessLab = "FAIL";
                        }
                        catch (Exception e)
                        {
                            realf.showMessage(realf.logBox, "Error : ", e.ToString());
                        }
                      /*  finally
                        {
                            realf.PassOrFail();
                        }*/

                    }
                    else if (str.Contains("vpass"))
                    {
                        str = str.Substring(5);
                        try
                        {
                            int vapss = Convert.ToInt32(str);
                            if (vapss == 1)
                            {
                                realf.IS_PASSV_ProPerty = true;
                                // realf.Is_Pass = true;
                            }
                            else
                            {
                                realf.IS_PASSV_ProPerty = false;
                                //realf.Is_PassV = false;
                                realf.CountVerticalFail++;
                                analf.VerticalFailCntProperty++;
                            }
                            
                        }
                        catch (Exception e)
                        {
                            realf.showMessage(realf.logBox, "Error : ", e.ToString());
                        }
                       /* finally
                        {
                            realf.PassOrFail();
                        }*/
                    }
                    else if (str.Contains("no"))
                    {
                        str = str.Substring(2);
                        try
                        {
                            int ctt = Convert.ToInt32(str);
                            realf.CountLot = ctt;
                        }
                        catch (Exception e)
                        {
                            realf.showMessage(realf.logBox, "Error : ", e.ToString());
                        }
                        realf.ProgressBarING = 1;
                    }

                    else
                    {

                        return str + " Garbage Data";
                    }





                }
                else if (str.Contains("TEMP"))
                {

                    str = str.Substring(4);
                    try
                    {
                        float temp = Convert.ToSingle(str);
                        realf.Degree_Propery = temp;
                        TestTemp = temp;
                    }
                    catch (Exception e)
                    {
                        realf.showMessage(realf.logBox, "Error : ", e.ToString());
                    }

                }


                else if (str.Contains("Pass"))
                {
                    str = str.Substring(4);
                    int a = 0;
                    try
                    {
                        a = Convert.ToInt32(str);
                    }
                    catch (Exception e)
                    {
                        realf.showMessage(realf.logBox, "Error : ", e.ToString());
                        // Application.Exit();
                    }
                    finally
                    {
                        if (a == 0)
                        {
                            //Passed = "불합격";
                        }
                        else if (a == 1)
                        {
                            // Passed = "합격";
                        }

                    }

                }
                else if (str.Contains("GO"))
                {
                    realf.ChongPass();
                    
                }
                else if (str.Contains("STOP"))
                {
                     realf.PassOrFail();
                    realf.showMessage(realf.logBox, "STOP : ", "Called");
                }
                else
                    return str + " NoChange";
            }
           
            else if (str.Contains("Last"))
            {
                str = str.Substring(4);
                analf.DoSplit(str);
              //  AnalysisBtn.PerformClick();
            }
            return str;
        }






        public void Invisible()
        {
            if (PnlFormLoader.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    this.PnlFormLoader.Controls[0].Visible = false;
                    this.PnlFormLoader.Controls[1].Visible = false;
                    this.PnlFormLoader.Controls[2].Visible = false;
                    this.PnlFormLoader.Controls[3].Visible = false;
                  //  this.PnlFormLoader.Controls[4].Visible = false;
                });
            }
            else
            {
                this.PnlFormLoader.Controls[0].Visible = false;
                this.PnlFormLoader.Controls[1].Visible = false;
                this.PnlFormLoader.Controls[2].Visible = false;
                this.PnlFormLoader.Controls[3].Visible = false;
             //   this.PnlFormLoader.Controls[4].Visible = false;
            }
        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(144, 238, 144);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);


        }
        #region 버튼제어함수들~
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(33, 37, 41);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Height = 73;
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(52, 58, 64);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);


            Invisible();
            /*  if (is_con == false)
              {
                  this.PnlFormLoader.Controls[0].Visible = true;
                  lblTitle.Text = "Login";
              }
              else
              {
                  this.PnlFormLoader.Controls[4].Visible = true;
                  lblTitle.Text = "Send Value & Start!";
              }
              //IS_Con_True_Form();*/
            this.PnlFormLoader.Controls[0].Visible = true;
        }
        private void IS_Con_True_Form()
        {
            if (is_con == false)
            {
                this.PnlFormLoader.Controls[0].Visible = true;
                lblTitle.Text = "로그인";
            }
            else
            {
                this.PnlFormLoader.Controls[4].Visible = true;
                lblTitle.Text = "Send Value & Start!";
            }
        }
        private void btnRealTime_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

            lblTitle.Text = "실시간 검사";
            Invisible();
            this.PnlFormLoader.Controls[1].Visible = true;
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

            lblTitle.Text = "결과 분석";

            Invisible();
            this.PnlFormLoader.Controls[2].Visible = true;

        }

        //private void btnData_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color1);

        //    lblTitle.Text = "Data";
        //    Invisible();
        //    this.PnlFormLoader.Controls[3].Visible = true;

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //realf.testLoad();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //is_con = false;
            Thread.Sleep(500);
            Application.Exit();
        }
        #endregion
        private void ToRealForm(bool defect, int Lot, string Log)
        {

            realf.Lot_RealForm = Lot;

        }



        private void btnLogout_Click(object sender, EventArgs e)
        {
            is_con = false;
            inputf.isconnected = false;
        }

        private void Manager_Load(object sender, EventArgs e)
        {

        }
        float TestTemp = 19.0f;
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerText.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString()
                + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();

            double b = random.NextDouble();
            int r = random.Next(0, 1);
            if (r == 0)
            {
                resultTemp = TestTemp + b;

            }
            else
            {
                resultTemp = TestTemp - b;
            }
           realf.makeTempChart(temp, resultTemp);
            temp++;

        }

        private void TimerText_Click(object sender, EventArgs e)
        {

        }

        private void btnAnalysis_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
