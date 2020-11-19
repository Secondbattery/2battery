using System;
using System.Windows.Forms;

namespace Batterty2
{
    public partial class frmInput : Form
    {
        //private string Date;
        private string LOT;
        private string HorizontalLocal;
        private string VerticalLocal;
        private string DayInfo;
        private string ModelName;

        string ipaddress = "";
        int port =0; 
        public bool isconnected;

        public void Init()
        {
            //InitializeComponent();
            LotInputBox.Text="";
            HorizontalInputBox.Text = "";
             VerticalInputBox.Text = "";
             ModelNameBox.Text = "";
        }
        public frmInput()
        {
            isconnected = false;
            if (DateTime.Now.Day < 10)
            {
                DayInfo = "0" + DateTime.Now.Day.ToString();
            }
            InitializeComponent();

        }
        //private void DateInput()
        //{
        //    if (Dateinputbox.InvokeRequired)
        //    {
        //        Invoke((MethodInvoker)delegate ()
        //        {
        //            DateInput();
        //        });
        //    }
        //    else
        //    {
        //        Dateinputbox.Text = DateTime.Now.Year.ToString() + DateTime.Today.Month.ToString() + DayInfo;
        //    }
        //}
        private void LOTBTN_Click(object sender, EventArgs e)
        {
            //Date = Dateinputbox.Text;
            LOT = LotInputBox.Text;
            HorizontalLocal = HorizontalInputBox.Text;
            VerticalLocal = VerticalInputBox.Text;
            ModelName = ModelNameBox.Text;

            try
            {
                Manager.Instance.Do_Send(ModelName, LOT, VerticalLocal, HorizontalLocal);


            }
            catch (Exception se)
            {
                MessageBox.Show(se.ToString());
            }
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            LOTBTN.Enabled = true;
            ConnectBtn.Enabled = false;
            IPBox.ReadOnly = true;
            PortBox.ReadOnly = true;
            if (isconnected == true)
            {
                return;
 
            }
                

            try
            {
                port = Convert.ToInt32(PortBox.Text);
                ipaddress = IPBox.Text;
                Manager.Instance.DoCon(ipaddress, port);
            }
            catch (Exception se)
            {
                //MessageBox.Show(se.ToString());
                //   ef.Show();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           
            Init();
           Manager.Instance.AllInit();
        }
    }
}
