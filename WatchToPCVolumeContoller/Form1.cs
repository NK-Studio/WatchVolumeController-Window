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
        
        private readonly UdpClient _client;
        private const int _port = 9090;

        public Form1()
        {
            //WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            InitializeComponent();

            _client = new UdpClient(_port);

            StartListening();

            ipv4TextBox.Text = GetLocalIPAddress();
            portTextBox.Text = _port.ToString();
        }

        private void StartListening()
        {
            _client.BeginReceive(ReceivedData, _client);
        }

        private void ReceivedData(IAsyncResult asyncResult)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, _port);

            byte[] received = _client.EndReceive(asyncResult, ref ipEndPoint);

            string index = Encoding.UTF8.GetString(received, 0, received.Length);

            switch (index)
            {
                case "0":
                    ControlVolume(0.05f);
                    break;
                case "1":
                    ControlVolume(-0.05f);
                    break;
                case "2":
                    Audio.Mute = true;
                    break;
                case "3":
                    Audio.Mute = false;
                    break;
            }

            StartListening();
        }

        private void ControlVolume(float value)
        {
            var currentVolume = Audio.Volume;
            currentVolume += value;
            Audio.Volume = currentVolume.Clamp(0, 1);
        }
        
        // private ContextMenu SetContextMenu(NotifyIcon ni)
        // {
        //     // ContextMenu 생성합니다.
        //     ContextMenu menu = new ContextMenu();
        //
        //     // 첫번째 메뉴 "열기" MenuItem을 생성합니다.
        //     MenuItem item1 = new MenuItem();
        //
        //     // 메뉴의 Text는 "열기"로 지정합니다.
        //     item1.Text = "열기";
        //
        //     // "열기" 메뉴의 클릭이벤트를 설정합니다.
        //     item1.Click += delegate (object click, EventArgs eventArgs)
        //     {
        //         this.Show();
        //         this.WindowState = WindowState.Normal;
        //     };
        //
        //     // "열기" 메뉴를 ContextMenu에 추가합니다.
        //     menu.MenuItems.Add(item1);
        //     
        //     return menu;
        // }
        
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

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void ipv4TextBox_Click(object sender, EventArgs e)
        {
            string ipAddress = GetLocalIPAddress();

            // 클립보드에 text 저장하기
            Clipboard.SetText(ipAddress);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            WatchVolumeController.Visible = false;
        }

        private void 닥기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}