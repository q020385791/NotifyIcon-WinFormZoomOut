using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformZoomOut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            Zoom();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Zoom();
        }

        private void EventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {
        }


        private void Zoom()
        {
            NotifyIcon MyNotifyIcon = new NotifyIcon();

            MyNotifyIcon.BalloonTipText = "滑鼠移動到Icon上藥顯示的文字";
            MyNotifyIcon.Text = "縮小視窗的標題";

            MyNotifyIcon.Icon = new Icon("nhi_logo.ico");
            MyNotifyIcon.Click += (Mysender, Mye) =>
            {
                //取消在通知欄顯示Icon
                MyNotifyIcon.Visible = false;
                //顯示在工具列
                this.ShowInTaskbar = true;
                //顯示程式的視窗
                this.Show();
            };
            ContextMenu contextMenu = new ContextMenu();
            MenuItem notifyIconMenuItem1 = new MenuItem();
            //可以設定是否可勾選
            notifyIconMenuItem1.Checked = false;
            notifyIconMenuItem1.Index = 1;
            notifyIconMenuItem1.Text = "復原";
            notifyIconMenuItem1.Click += (ItemSender, Iteme) =>
            {
                //取消在通知欄顯示Icon
                MyNotifyIcon.Visible = false;
                //顯示在工具列
                this.ShowInTaskbar = true;
                //顯示程式的視窗
                this.Show();
            };
            contextMenu.MenuItems.Add(notifyIconMenuItem1);
            MyNotifyIcon.ContextMenu = contextMenu;
            //讓程式在工具列中隱藏
            this.ShowInTaskbar = false;
            //隱藏程式本身的視窗
            this.Hide();
            //通知欄顯示Icon
            MyNotifyIcon.Visible = true;

            //通知欄提示 (顯示時間毫秒，標題，內文，類型)
            MyNotifyIcon.ShowBalloonTip(1000, "Program still Running", "Your program now listening......", ToolTipIcon.Info);
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
    }


}

