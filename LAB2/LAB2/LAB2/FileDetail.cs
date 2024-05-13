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

namespace LAB2
{
    public partial class FileDetail : Form
    {
        public FileDetail()
        {
            InitializeComponent();
        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            showTxt.Text = content;
            fs.Close();

            //file name
            string name = ofd.SafeFileName.ToString();
            nameTxt.Text = name;

            //url
            string url = fs.Name.ToString();
            urlTxt.Text = url;

            //word count
            string[] source = content.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = source.Count();
            wordsTxt.Text = wordCount.ToString();

            //character count
            // dem dau cach, dau xuong dong va dau ve dong moi
            int charCount = content.Count();
            lettersTxt.Text = charCount.ToString();

            //row count
            content = content.Replace("\r\n", "\r");
            int lineCount = showTxt.Lines.Count();
            content = content.Replace("\r", "");
            linesTxt.Text = lineCount.ToString();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
