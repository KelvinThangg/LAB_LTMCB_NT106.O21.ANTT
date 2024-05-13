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
    public partial class lab2_Bai2 : Form
    {
        public lab2_Bai2()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int charCount;
            int rowCount;
            int wordCount;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string name = ofd.SafeFileName.ToString();
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
            string filePath = fs.Name.ToString();
            StreamReader streamReader = new StreamReader(fs);
            string content = streamReader.ReadToEnd();
            streamReader.Close();
            fs.Close();

            charCount = content.Length;
            //content = content.Replace("\r\n", "\r");
            rowCount = content.Split('\n').Length;
            //rowCount = richTextBoxShow.Lines.Count();
            content = content.Replace("\r", " ");
            string[] source = content.Split(new char[] { '.', '?', '!', ' ', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            wordCount = source.Count();

            //hien thi
            richTextBoxShow.Text = content;
            tenFile.Text = name;
            duongDan.Text = filePath;
            soDong.Text = rowCount.ToString();
            soKyTu.Text = charCount.ToString();
            soTu.Text = wordCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
