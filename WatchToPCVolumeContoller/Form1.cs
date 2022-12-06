using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2WatchController
{
    public partial class Form1 : Form
    {
        private UdpClient client;
        public Form1()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            InitializeComponent();

            client = new UdpClient(9090);
            
            StartListening();
        }

        private void StartListening()
        {
            client.BeginReceive(ReceivedData, client);
        }
        
        private void ReceivedData(IAsyncResult asyncResult)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("172.30.1.97"), 9090);
            byte[] received = client.EndReceive(asyncResult, ref ipEndPoint);
            
            string index = Encoding.UTF8.GetString(received, 0, received.Length);
            
            switch (index)
            {
                case "0":
                    ExecuteCmd("nircmd.exe changesysvolume 2000");
                    break;
                case "1":
                    ExecuteCmd("nircmd.exe changesysvolume -2000");
                    break;
            }

            StartListening();
        }

        /// <summary>
        /// textKey : 실행할 명령어 
        /// </summary>
        /// <param name="textKey"></param>
        /// <returns></returns>
        private static void ExecuteCmd(string textKey)
        {
            ProcessStartInfo pri = new ProcessStartInfo();
            Process pro = new Process();

            pri.FileName = @"cmd.exe";
            pri.CreateNoWindow = true;
            pri.UseShellExecute = false;

            pri.RedirectStandardInput = true; //표준 출력을 리다이렉트
            pri.RedirectStandardOutput = true;
            pri.RedirectStandardError = true;

            pro.StartInfo = pri;
            pro.Start(); //어플리케이션 실

            pro.StandardInput.Write(textKey + Environment.NewLine);
            pro.StandardInput.Close();

            pro.WaitForExit();
            pro.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            WatchVolumeController.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                WatchVolumeController.Visible = true;
            }
        }
        
    }
}