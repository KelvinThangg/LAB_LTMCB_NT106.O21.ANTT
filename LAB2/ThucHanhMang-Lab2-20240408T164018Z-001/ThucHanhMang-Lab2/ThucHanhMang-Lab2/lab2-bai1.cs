using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanhMang_Lab2
{
    public partial class lab2_bai1 : Form
    {
        public lab2_bai1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fs);
            string s = streamReader.ReadToEnd();
            richTextBoxShow.Text = s;
            fs.Close();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fs);
            streamWriter.WriteLine(richTextBoxShow.Text.ToUpper());
            streamWriter.Flush();
            fs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
