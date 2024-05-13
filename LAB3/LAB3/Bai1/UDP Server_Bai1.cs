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

namespace LAB3
{
    public partial class UDP_Server_Bai1 : Form
    {
        public UDP_Server_Bai1()
        {
            InitializeComponent();
        }
        public void InfoMessage(string message)
        {
            // Kiểm tra xem code có đang chạy trên thread UI không
            if (this.InvokeRequired)
            {
                // Nếu không, chúng ta cần gọi Invoke để cập nhật control UI trên thread UI
                this.Invoke((MethodInvoker)delegate
                {
                    // Thêm thông điệp vào RichTextBox
                    ListViewItem item = new ListViewItem(message + "\n");
                    listView1.Items.Add(item);
                });
            }
            else
            {
                // Nếu đang ở trên thread UI, cập nhật trực tiếp
                ListViewItem item = new ListViewItem(message + "\n");
                listView1.Items.Add(item);
            }
        }

        public void serverThread()
        {
            int port = Convert.ToInt32(textBox1.Text);
            UdpClient udpClient = new UdpClient(port);
            while (true)
            {
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Any, 0);
                //Đón nhận và đẩy dữ liệu nhận được vào mảng Byte
                Byte[] recvBytes = udpClient.Receive(ref IpEnd);
                string Data = Encoding.UTF8.GetString(recvBytes);
                string mess = IpEnd.Address.ToString() + ": " + Data.ToString() + "\n";
                // Gọi hàm hiển thị thông điệp nhận được lên màn hình
                InfoMessage(mess);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            // Khởi tạo một thread mới để chạy hàm serverThread
            Thread serverThread = new Thread(new ThreadStart(this.serverThread));

            // Bắt đầu chạy thread
            serverThread.Start();
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UDP_Server_Bai1_Load(object sender, EventArgs e)
        {


        }
    }
}
