using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WebDownloader
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            string filePath = txtPath.Text;

            try
            {
                // Tạo WebClient
                WebClient myClient = new WebClient();

                // Download nội dung trang web
                Stream response = myClient.OpenRead(url);
                StreamReader reader = new StreamReader(response);
                string htmlContent = reader.ReadToEnd();

                // Lưu nội dung vào file HTML
                File.WriteAllText(filePath, htmlContent);
             
                // Hiển thị nội dung lên textbox
                richTextBox1.Text = htmlContent;

                MessageBox.Show("Download thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}