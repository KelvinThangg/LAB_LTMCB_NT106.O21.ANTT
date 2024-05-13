using LAB3.Bai3;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai1 bai1 = new Bai1();
            bai1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TCPServer server = new TCPServer();
            server.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TCP_Telnet telnet = new TCP_Telnet();
            telnet.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          Bai4_Form bai4 = new Bai4_Form();
            bai4.Show();
        }
    }
}
