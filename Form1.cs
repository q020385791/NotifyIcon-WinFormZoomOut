using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace winformZoomOut
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        public Form1()
        {
            InitializeComponent();
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            Zoom();
        }
        private void Zoom()
        {
            if (notifyIcon == null)
            {
                notifyIcon = new NotifyIcon();
                // 初始化
            }
            notifyIcon.BalloonTipText = "滑鼠移動到Icon上要顯示的文字";
            notifyIcon.Text = "縮小視窗的標題";

            try
            {
                notifyIcon.Icon = new Icon("nhi_logo.ico");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Icon file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            notifyIcon.Click -= MyNotifyIcon_Click;
            notifyIcon.Click += MyNotifyIcon_Click;
            ContextMenu contextMenu = new ContextMenu();
            MenuItem notifyIconMenuItem1 = new MenuItem
            {
                //可以設定是否可勾選
                Checked = false,
                Text = "復原"
            };
            notifyIconMenuItem1.Click -= NotifyIconMenuItem1_Click;
            notifyIconMenuItem1.Click += NotifyIconMenuItem1_Click;
            contextMenu.MenuItems.Add(notifyIconMenuItem1);
            notifyIcon.ContextMenu = contextMenu;
            //讓程式在工具列中隱藏
            ShowInTaskbar = false;
            //隱藏程式本身的視窗
            Hide();
            //通知欄顯示Icon
            notifyIcon.Visible = true;

            //通知欄提示 (顯示時間毫秒，標題，內文，類型)
            notifyIcon.ShowBalloonTip(1000, "Program still Running", "Your program now listening......", ToolTipIcon.Info);
        }
        public string Console
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            SomeClass test = new SomeClass(this);
            test.testReturnstring();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notifyIcon != null && notifyIcon.Visible)
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
                notifyIcon = null;
            }
        }

        private void MyNotifyIcon_Click(object sender, EventArgs e)
        {
            RestoreWindow();
        }

        private void NotifyIconMenuItem1_Click(object sender, EventArgs e)
        {
            RestoreWindow();
        }
        private void RestoreWindow()
        {
            notifyIcon.Visible = false;
            ShowInTaskbar = true;
            Show();
        }
    }
}

