using System;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WebDownloader
{
    public partial class Bai3 : Form
    {
        private FolderBrowserDialog folderBrowserDialog;

        public Bai3()
        {
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            string savePath = txtPath.Text.Trim(); // Loại bỏ khoảng trắng thừa
            string fileName = GetSafeFileNameFromUrl(url);
            string fullPath = Path.Combine(savePath, fileName);

            if (string.IsNullOrEmpty(savePath))
            {
                MessageBox.Show("Khong tim thay!");
                savePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";
            }

            // Thêm dấu ngoặc kép nếu đường dẫn chứa khoảng trắng
            if (savePath.Contains(" "))
            {
                savePath = "\"" + savePath + "\"";
            }

            //string fileName = Path.Combine(savePath, GetFileNameFromUrl(url)); // Sử dụng Path.Combine để kết hợp đường dẫn và tên file một cách an toàn


            try
            {
                WebClient client = new WebClient();
                string htmlContent = client.DownloadString(url);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument(); // Use the fully qualified name
                doc.LoadHtml(htmlContent);

                // Xử lý đặc biệt (nếu cần)
                // Ví dụ: loại bỏ các thẻ script, style, ...

                // Thay đổi cách ghi nội dung vào tệp
                File.WriteAllText(fullPath, doc.DocumentNode.OuterHtml); // Ghi vào đường dẫn đầy đủ
                richTextBox1.Text = File.ReadAllText(fullPath); // Đọc lại từ đường dẫn đầy đủ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private string GetSafeFileNameFromUrl(string url)
        {
            Uri uri = new Uri(url);
            string host = uri.Host.Replace(".", "_");

            // Loại bỏ ký tự không hợp lệ khỏi tên tệp
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                host = host.Replace(c.ToString(), "");
            }

            return $"{host}.html";
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại chọn thư mục
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Nếu người dùng chọn OK, lấy đường dẫn đã chọn và hiển thị trong TextBox
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}