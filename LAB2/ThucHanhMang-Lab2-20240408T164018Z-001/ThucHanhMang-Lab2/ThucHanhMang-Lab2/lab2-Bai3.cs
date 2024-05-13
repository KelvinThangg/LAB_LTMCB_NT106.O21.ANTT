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
    public partial class lab2_Bai3 : Form
    {
        public lab2_Bai3()
        {
            InitializeComponent();
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string contents = sr.ReadToEnd();
            textBox1.Text = contents;
            fs.Close();
            sr.Close();
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            FileStream wr = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
            StreamWriter sr = new StreamWriter(wr);
            sr.Write(textBox1.Text);
            sr.Close();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            string inputFilePath = "..\\Debug\\New folder\\input.txt";
            string outputFilePath = "..\\Debug\\New folder\\output.txt";

            // Create StreamReader to read from input file
            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                // Create StreamWriter to write to output file
                using (StreamWriter swr = new StreamWriter(outputFilePath))
                {
                    // Read lines from input file and write them to output file
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        string result = Cal(line);
                        string output = $"{line}={result}";
                        swr.WriteLine(output);
                    }
                }
            }
        }

        static string Cal(string str)
        {
            if (str.Contains('+'))
            {
                string[] parts = str.Split('+');
                double a = double.Parse(parts[0]);
                double b = double.Parse(parts[1]);
                double result = a + b;
                return result.ToString();
            }
            else if (str.Contains('-'))
            {
                string[] parts = str.Split('-');
                double a = double.Parse(parts[0]);
                double b = double.Parse(parts[1]);
                double result = a - b;
                return result.ToString();
            }
            else if (str.Contains('*'))
            {
                string[] parts = str.Split('*');
                double a = double.Parse(parts[0]);
                double b = double.Parse(parts[1]);
                double result = a * b;
                return result.ToString();
            }
            else if (str.Contains("/"))
            {
                string[] parts = str.Split('/');
                double a;
                if (!double.TryParse(parts[0], out a))
                {
                    throw new ArgumentException("Invalid number: " + parts[0]);
                }

                double b;
                if (!double.TryParse(parts[1], out b))
                {
                    throw new ArgumentException("Invalid number: " + parts[1]);
                }

                if (b == 0)
                {
                    return "Division by zero.";
                }

                double result = a / b;
                return result.ToString();
            }

            return str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Truncate, FileAccess.Write);
                fs.SetLength(0);
                fs.Close();
                MessageBox.Show("Data in file deleted successfully.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
