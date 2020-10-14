namespace Batterty2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnAnalysis = new System.Windows.Forms.Panel();
            this.PnlFormLoader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLogout = new FontAwesome.Sharp.IconButton();
            this.btnData = new FontAwesome.Sharp.IconButton();
            this.chart = new FontAwesome.Sharp.IconButton();
            this.btnRealTime = new FontAwesome.Sharp.IconButton();
            this.btnLogin = new FontAwesome.Sharp.IconButton();
            this.Home = new System.Windows.Forms.PictureBox();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.btnAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Home)).BeginInit();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnData);
            this.panelMenu.Controls.Add(this.chart);
            this.panelMenu.Controls.Add(this.btnRealTime);
            this.panelMenu.Controls.Add(this.btnLogin);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(204, 700);
            this.panelMenu.TabIndex = 0;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnAnalysis.Controls.Add(this.lblTitle);
            this.btnAnalysis.Controls.Add(this.PnlFormLoader);
            this.btnAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAnalysis.Location = new System.Drawing.Point(204, 0);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(1096, 700);
            this.btnAnalysis.TabIndex = 3;
            // 
            // PnlFormLoader
            // 
            this.PnlFormLoader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlFormLoader.Location = new System.Drawing.Point(0, 74);
            this.PnlFormLoader.Name = "PnlFormLoader";
            this.PnlFormLoader.Size = new System.Drawing.Size(1096, 626);
            this.PnlFormLoader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(15, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 38);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "label1";
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogout.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnLogout.IconColor = System.Drawing.Color.LightGreen;
            this.btnLogout.IconSize = 30;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 640);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogout.Rotation = 0D;
            this.btnLogout.Size = new System.Drawing.Size(204, 60);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnData
            // 
            this.btnData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnData.FlatAppearance.BorderSize = 0;
            this.btnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnData.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnData.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnData.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
            this.btnData.IconColor = System.Drawing.Color.Gainsboro;
            this.btnData.IconSize = 35;
            this.btnData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnData.Location = new System.Drawing.Point(0, 335);
            this.btnData.Name = "btnData";
            this.btnData.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnData.Rotation = 0D;
            this.btnData.Size = new System.Drawing.Size(204, 60);
            this.btnData.TabIndex = 5;
            this.btnData.Text = "Data";
            this.btnData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // chart
            // 
            this.chart.AllowDrop = true;
            this.chart.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart.FlatAppearance.BorderSize = 0;
            this.chart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chart.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.chart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chart.ForeColor = System.Drawing.Color.Gainsboro;
            this.chart.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
            this.chart.IconColor = System.Drawing.Color.Gainsboro;
            this.chart.IconSize = 35;
            this.chart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chart.Location = new System.Drawing.Point(0, 275);
            this.chart.Name = "chart";
            this.chart.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.chart.Rotation = 0D;
            this.chart.Size = new System.Drawing.Size(204, 60);
            this.chart.TabIndex = 4;
            this.chart.Text = "Analysis";
            this.chart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chart.UseVisualStyleBackColor = true;
            this.chart.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnRealTime
            // 
            this.btnRealTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRealTime.FlatAppearance.BorderSize = 0;
            this.btnRealTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealTime.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnRealTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRealTime.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRealTime.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
            this.btnRealTime.IconColor = System.Drawing.Color.Gainsboro;
            this.btnRealTime.IconSize = 35;
            this.btnRealTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRealTime.Location = new System.Drawing.Point(0, 215);
            this.btnRealTime.Name = "btnRealTime";
            this.btnRealTime.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRealTime.Rotation = 0D;
            this.btnRealTime.Size = new System.Drawing.Size(204, 60);
            this.btnRealTime.TabIndex = 3;
            this.btnRealTime.Text = "RealTime";
            this.btnRealTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRealTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRealTime.UseVisualStyleBackColor = true;
            this.btnRealTime.Click += new System.EventHandler(this.btnRealTime_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
            this.btnLogin.IconColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.IconSize = 35;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(0, 155);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogin.Rotation = 0D;
            this.btnLogin.Size = new System.Drawing.Size(204, 60);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Home
            // 
            this.Home.Image = ((System.Drawing.Image)(resources.GetObject("Home.Image")));
            this.Home.Location = new System.Drawing.Point(35, 28);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(120, 95);
            this.Home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Home.TabIndex = 0;
            this.Home.TabStop = false;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.Home);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(204, 155);
            this.panelLogo.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "60";
            this.panelMenu.ResumeLayout(false);
            this.btnAnalysis.ResumeLayout(false);
            this.btnAnalysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Home)).EndInit();
            this.panelLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnData;
        private System.Windows.Forms.PictureBox Home;
        private System.Windows.Forms.Panel btnAnalysis;
        private FontAwesome.Sharp.IconButton chart;
        private FontAwesome.Sharp.IconButton btnRealTime;
        private FontAwesome.Sharp.IconButton btnLogin;
        private FontAwesome.Sharp.IconButton btnLogout;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel PnlFormLoader;
        private System.Windows.Forms.Panel panelLogo;
    }
}

