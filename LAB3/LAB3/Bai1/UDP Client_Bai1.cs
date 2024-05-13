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

namespace LAB3
{
    public partial class UDP_Client : Form
    {
        public UDP_Client()
        {
            InitializeComponent();
        }

        private void UDP_Client_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                
                    UdpClient udpClient = new UdpClient();
                    //Lấy địa chỉ IP từ textbox và chuyển thành kiểu 

                    IPAddress ipadd = IPAddress.Parse(textBox1.Text);
                    if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("missing Port");
                        }
                    int port = Convert.ToInt32(textBox2.Text);
                    IPEndPoint ipend = new IPEndPoint(ipadd, port);
                    //Chuyển chuỗi dữ liệu nhập sang kiểu byte
                    Byte[] sendBytes =
                   Encoding.UTF8.GetBytes(richTextBox1.Text);
                    //Gởi dữ liệu đến IPEndPoint đã định nghĩa địa chỉ IP và 

                    udpClient.Send(sendBytes, sendBytes.Length, ipend);
                    //Xóa dữ liệu vừa gửi ở ô nhập
                    richTextBox1.Text = "";
                
            
       
        }
    }
}
