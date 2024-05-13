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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB2
{
    public partial class WriteNRead : Form
    {
        public WriteNRead()
        {
            InitializeComponent();
        }

        private void WriteNRead_Load(object sender, EventArgs e)
        {

        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                string content = sr.ReadToEnd();
                Show.Text = content;
                fs.Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đọc file: " + ex.Message);
            }
        }

        private void writeBtn_Click(object sender, EventArgs e)
        {
            string duLieu = Show.Text;
            string filepath = "D:\\UIT\\Nam_2\\LTMCB\\TH\\LAB_02\\output_bai1.txt";
            FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            string duLieuUpperCase = duLieu.ToUpper();
            sw.WriteLine(duLieuUpperCase);
            sw.Flush();
            fs.Close();
            MessageBox.Show("Đã ghi dữ liệu thành công!");
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Show_TextChanged(object sender, EventArgs e)
        {

        }

        private void titleTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
