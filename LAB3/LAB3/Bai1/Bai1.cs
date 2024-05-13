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
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UDP_Server_Bai1 server = new UDP_Server_Bai1();
            server.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UDP_Client client = new UDP_Client();
            client.Show();
        }
    }
}
