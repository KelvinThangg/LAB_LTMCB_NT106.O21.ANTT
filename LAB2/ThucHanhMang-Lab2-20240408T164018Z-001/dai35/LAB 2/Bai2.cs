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
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofc = new OpenFileDialog();
            ofc.ShowDialog();
          FileStream fs = new FileStream(ofc.FileName, FileMode.OpenOrCreate);
          StreamReader sr = new StreamReader(fs);
           string content = sr.ReadToEnd();
            richTextBox1.Text = content;
            filename.Text = ofc.SafeFileName.ToString();
            url.Text = fs.Name.ToString();
            //Dem so ki tu
            int count = richTextBox1.Text.Count(c => !Char.IsWhiteSpace(c));

            letterCount.Text = count.ToString();
            // Đếm số dòng
            //string[] lines = richTextBox1.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //lineCount.Text = lines.Length.ToString();
            content = content.Replace("\r\n", "\n");
            lineCount.Text = richTextBox1.Lines.Count().ToString();
            content = content.Replace('\r',' ');
            //Dem so tu
            string[] words = content.Split(new char[] { ' ', '.', ',', ';', '?', '!' },StringSplitOptions.RemoveEmptyEntries);
            wordCount.Text = words.Count().ToString();

           
        }
    }
}
