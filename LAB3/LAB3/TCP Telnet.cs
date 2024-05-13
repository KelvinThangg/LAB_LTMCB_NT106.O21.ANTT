using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;


namespace LAB3
{
    public partial class TCP_Telnet : Form
    {
     
        public TCP_Telnet()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        void StartUnsafeThread()
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1];
            Socket clientSocket;
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipepServer);
            listenerSocket.Listen(-1);
            clientSocket = listenerSocket.Accept();
            listView1.Items.Add(new ListViewItem("Client connected"));
           
            while (true)
            {

                string text = "";
                try
                {
                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        text += Encoding.ASCII.GetString(recv);
                        if (bytesReceived == 0)
                        {
                            listView1.Items.Add(new ListViewItem("Client disconnected"));
                            clientSocket.Shutdown(SocketShutdown.Both);
                            listenerSocket.Close();
                            return;
                        }
                    }
                    while (text[text.Length - 1] != '\n');
                    listView1.Items.Add(new ListViewItem(text));
                }
                catch (SocketException)
                {
                    // Đóng kết nối socket một cách an toàn
                    clientSocket.Shutdown(SocketShutdown.Both);
                    listenerSocket.Close();

                    listView1.Items.Add(new ListViewItem("Client disconnected"));
                    break;
                }
            }
        }

        private void TCP_Telnet_FormClosed(object sender, FormClosedEventArgs e)
        {
            listView1.Items.Add(new ListViewItem("Client disconnected"));
        }
      
    }
}
