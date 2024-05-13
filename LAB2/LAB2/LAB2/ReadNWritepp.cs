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
    public partial class ReadNWritepp : Form
    {
        public ReadNWritepp()
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
            Show.Text = content;
            fs.Close();

            //thuc hien phep tinh
            string[] lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] results = PerformOperations(lines);
            string resultString = string.Join("\r\n", results);
        }

        private string[] PerformOperations(string[] lines)
        {
            string[] results = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                StringBuilder currentNumber = new StringBuilder();
                List<string> parts = new List<string>();

                foreach (char c in line)
                {
                    if (char.IsDigit(c) || c == ',' || c == '.')
                    {
                        currentNumber.Append(c);
                    }
                    else if (c == '+' || c == '-' || c == '*' || c == '/')
                    {
                        parts.Add(currentNumber.ToString());
                        parts.Add(c.ToString());
                        currentNumber.Clear();
                    }
                }
                parts.Add(currentNumber.ToString());

                double result = double.NaN;

                if (parts.Count != 3)
                {
                    MessageBox.Show("Dữ liệu nhập không hợp lệ");
                }
                else
                {
                    try
                    {
                        double number1 = double.Parse(parts[0].Replace(',', '.')); // Chuyển dấu phẩy thành dấu chấm
                        double number2 = double.Parse(parts[2].Replace(',', '.')); // Chuyển dấu phẩy thành dấu chấm
                        string operation = parts[1];

                        switch (operation)
                        {
                            case "+":
                                result = number1 + number2;
                                break;
                            case "-":
                                result = number1 - number2;
                                break;
                            case "*":
                                result = number1 * number2;
                                break;
                            case "/":
                                if (number2 == 0)
                                {
                                    MessageBox.Show("Vui lòng nhập số thứ hai khác 0");
                                    continue;
                                }
                                else
                                {
                                    result = number1 / number2;
                                    break;
                                }
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Dữ liệu nhập không hợp lệ");
                    }
                }

                results[i] = line + " = " + result.ToString().Replace('.', ','); // Chuyển dấu chấm thành dấu phẩy cho phù hợp với định dạng số thực
            }
            return results;
        }



        private void writeBtn_Click(object sender, EventArgs e)
        {
            string[] lines = Show.Lines; // Lấy nội dung từ TextBox
            string[] results = PerformOperations(lines); // Thực hiện phép tính

            string filepath = "D:\\UIT\\Nam_2\\LTMCB\\TH\\LAB_02\\output_bai3.txt";
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                foreach (string result in results)
                {
                    sw.WriteLine(result); // Ghi từng kết quả vào tệp tin
                }
            }

            MessageBox.Show("Đã ghi kết quả vào tệp tin!");
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Show_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
