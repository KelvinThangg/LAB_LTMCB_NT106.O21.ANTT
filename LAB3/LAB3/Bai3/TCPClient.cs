using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3.Bai3
{
    public partial class TCPClient : Form
    {
        public TCPClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient tcpclnt = new TcpClient();
            IPAddress ipadd = IPAddress.Parse("127.0.0.1");
            int port = Convert.ToInt32("8080");
            // Gọi hàm kết nối đến server
            tcpclnt.Connect(ipadd, port);

            // Khởi tạo một stream để gửi dữ liệu đến server
            NetworkStream stream = tcpclnt.GetStream();

            // Chuyển dữ liệu từ textBox3 sang dạng byte
            Byte[] sendBytes = Encoding.UTF8.GetBytes(richTextBox1.Text);

            // Gửi dữ liệu đến server
            stream.Write(sendBytes, 0, sendBytes.Length);
            richTextBox1.Text = "";
            // Đóng kết nối
            tcpclnt.Close();
            tcpclnt.Dispose();

        }

    }
}
