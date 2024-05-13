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

namespace LAB_2
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            FileStream fs = new FileStream(open.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            richTextBox1.Text = content;
            fs.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog save = new SaveFileDialog();
       
            save.FileName = "output.txt";
            // Hiển thị hộp thoại SaveFileDialog
            save.ShowDialog();
            
            FileStream fs = new FileStream(save.FileName, FileMode.Create);
           
            StreamWriter sw = new StreamWriter(fs);
            
            sw.Write(richTextBox1.Text.ToUpper());
            sw.Close();
            fs.Close();
        }
    }
}
