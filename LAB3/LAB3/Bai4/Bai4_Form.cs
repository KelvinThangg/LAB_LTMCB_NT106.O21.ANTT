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
    public partial class Bai4_Form : Form
    {
        public Bai4_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai4 bai4 = new Bai4();
            bai4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai4_Client bai4_client = new Bai4_Client();
            bai4_client.Show();
        }
    }
}
