using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace Batterty2
{
    public partial class frmLogin : Form
    {
        //ErrorForm ef = new ErrorForm();

        string ipaddress = "";
        int port = 0;



        public bool isconnected;
        byte[] bytes = new byte[1024];




        public frmLogin()
        {
            InitializeComponent();
            isconnected = false;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }


        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (isconnected == true)
                return;

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
