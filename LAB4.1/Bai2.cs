using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string url = txturl.Text;
            string data = txtdata.Text;

            try
            {
                // Tạo WebRequest
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";

                // Chuyển đổi dữ liệu sang mảng byte
                byte[] byteArray = Encoding.UTF8.GetBytes(data);

                // Thiết lập ContentType và ContentLength
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                // Tạo request stream và ghi dữ liệu
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                // Lấy response
                WebResponse response = request.GetResponse();

                // Đọc dữ liệu trả về
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                // Hiển thị kết quả
               richTextBox1.Text = responseFromServer;

                // Đóng stream
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
    
}
