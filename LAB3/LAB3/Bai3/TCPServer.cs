using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3.Bai3
{
    public partial class TCPServer : Form
    {
        public TCPServer()
        {
            TCPClient tcpclnt = new TCPClient();
            tcpclnt.Show();
            InitializeComponent();
        }

        private void InfoMessage(string mess)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(InfoMessage), new object[] { mess });
                return;
            }
            richTextBox1.Text += mess + "\r\n";
        }
        public void serverThread()
        {
            int port = Convert.ToInt32("8080");
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int data = stream.Read(buffer, 0, client.ReceiveBufferSize);
                string message = IPAddress.Loopback.ToString() + ": " + port.ToString() + ": " + Encoding.UTF8.GetString(buffer, 0, data);

                InfoMessage(message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo một thread mới để chạy hàm serverThread
            Thread serverThread = new Thread(new ThreadStart(this.serverThread));

            // Bắt đầu chạy thread
            serverThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


