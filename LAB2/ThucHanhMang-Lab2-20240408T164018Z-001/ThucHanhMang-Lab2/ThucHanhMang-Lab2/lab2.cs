using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanhMang_Lab2
{
    public partial class lab2 : Form
    {
        public lab2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lab2_bai4 form4 = new lab2_bai4();
            form4.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lab2_Bai3 form3 = new lab2_Bai3();
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lab2_bai1 form1 = new lab2_bai1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab2_Bai2 form2 = new lab2_Bai2();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lab2_Bai5 form5 = new lab2_Bai5();
            form5.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lab2_Load(object sender, EventArgs e)
        {

        }
    }
}
