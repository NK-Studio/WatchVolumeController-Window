using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WatchToPCVolumeController
{
    public partial class Form1 : Form
    {
        private const string VolumeUp = "nircmd.exe changesysvolume 1000";
        private const string VolumeDown = "nircmd.exe changesysvolume -1000";
        private const string Mute = "nircmd.exe mutesysvolume 1";
        private const string NoMute = "nircmd.exe mutesysvolume 0";
        
        private readonly UdpClient _client;
        
        public Form1()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            InitializeComponent();

            _client = new UdpClient(9090);
            
            StartListening();
        }

        private void StartListening()
        {
            _client.BeginReceive(ReceivedData, _client);
        }
        
        private void ReceivedData(IAsyncResult asyncResult)
        {

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("IPv4 주소를 입력하세요."), 9090);

            byte[] received = _client.EndReceive(asyncResult, ref ipEndPoint);
            
            string index = Encoding.UTF8.GetString(received, 0, received.Length);
            
            switch (index)
            {
                case "0":
                    ExecuteCmd(VolumeUp);
                    break;
                case "1":
                    ExecuteCmd(VolumeDown);
                    break;
                case "2":
                    ExecuteCmd(Mute);
                    break;
                case "3":
                    ExecuteCmd(NoMute);
                    break;
            }

            StartListening();
        }

        /// <summary>
        /// 인자로 들어온 명령어를 CMD에 명령합니다.
        /// </summary>
        /// <param name="textKey"></param>
        /// <returns></returns>
        private static void ExecuteCmd(string textKey)
        {
            ProcessStartInfo proStartInfo = new ProcessStartInfo();
            Process process = new Process();

            proStartInfo.FileName = @"cmd.exe";
            proStartInfo.CreateNoWindow = true;
            proStartInfo.UseShellExecute = false;

            proStartInfo.RedirectStandardInput = true; //표준 출력을 리다이렉트
            proStartInfo.RedirectStandardOutput = true;
            proStartInfo.RedirectStandardError = true;

            process.StartInfo = proStartInfo;
            process.Start(); //어플리케이션 실행

            process.StandardInput.Write(textKey + Environment.NewLine);
            process.StandardInput.Close();

            process.WaitForExit();
            process.Close();
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
