using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.IO;

namespace Lab4
{
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        // (Tùy chọn) Xử lý sự kiện tiến trình download
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        // (Tùy chọn) Xử lý sự kiện download hoàn thành
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download hoàn tất!");
        }

        private void btnGo_Click_1(object sender, EventArgs e)
        {

        }


        private void btnGo_Click_2(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtUrl.Text);
        }

        private void btnDownload_Click_1(object sender, EventArgs e)
        {
            string url = webBrowser1.Url.ToString();

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;
                    DownloadWebsite(url, folderPath);
                }
            }
        }

        private void DownloadWebsite(string url, string folderPath)
        {
            try
            {
                HashSet<string> downloadedUrls = new HashSet<string>();

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                downloadedUrls.Add(url); // Thêm URL gốc vào danh sách đã tải

                string htmlFilePath = Path.Combine(folderPath, "index.html");
                doc.Save(htmlFilePath);

                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//img[@src]")) // Chỉ xét thẻ img
                {
                    string fileUrl = link.Attributes["src"].Value;
                    if (!fileUrl.StartsWith("http"))
                    {
                        fileUrl = new Uri(new Uri(url), fileUrl).AbsoluteUri;
                    }

                    if (!downloadedUrls.Contains(fileUrl)) // Kiểm tra trước khi tải
                    {
                        string fileName = Path.GetFileName(fileUrl);
                        string filePath = Path.Combine(folderPath, fileName);
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(fileUrl, filePath);
                        }
                        downloadedUrls.Add(fileUrl); // Đánh dấu đã tải
                    }
                }

                MessageBox.Show("Download hoàn tất!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;

                    // Tạo form mới để hiển thị source
                    Form sourceForm = new Form();
                    sourceForm.Text = "HTML Source";
                    sourceForm.Size = new Size(800, 600);

                    // Tạo TreeView để hiển thị cấu trúc thư mục
                    TreeView treeView = new TreeView();
                    treeView.Dock = DockStyle.Left;
                    treeView.Width = 200;
                    sourceForm.Controls.Add(treeView);

                    // Tạo RichTextBox để hiển thị nội dung file
                    RichTextBox rtbSource = new RichTextBox();
                    rtbSource.Dock = DockStyle.Fill;
                    sourceForm.Controls.Add(rtbSource);

                    // Tạo nút để hiển thị hình ảnh
                    Button btnShowImage = new Button();
                    btnShowImage.Text = "Hiển thị hình ảnh";
                    btnShowImage.Visible = false;
                    btnShowImage.Dock = DockStyle.Bottom;
                    sourceForm.Controls.Add(btnShowImage);

                    // Thêm các node vào TreeView
                    TreeNode rootNode = new TreeNode(folderPath);
                    treeView.Nodes.Add(rootNode);
                    AddNodes(rootNode, folderPath);

                    TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                    tableLayoutPanel.Dock = DockStyle.Fill;
                    tableLayoutPanel.ColumnCount = 2;
                    tableLayoutPanel.RowCount = 1;
                    sourceForm.Controls.Add(tableLayoutPanel);
                    // Thêm TreeView vào cột đầu tiên
                    tableLayoutPanel.Controls.Add(treeView, 0, 0);
                    treeView.Dock = DockStyle.Fill;

                    // Thêm RichTextBox vào cột thứ hai
                    tableLayoutPanel.Controls.Add(rtbSource, 1, 0);
                    rtbSource.Dock = DockStyle.Fill;
                    // Xử lý sự kiện khi chọn node trong TreeView
                    treeView.AfterSelect += (object Sender, TreeViewEventArgs treeArgs) =>
                    {
                        string selectedPath = treeArgs.Node.FullPath;

                        if (File.Exists(selectedPath))
                        {
                            string extension = Path.GetExtension(selectedPath).ToLower();

                            if (extension == ".html" || extension == ".htm" || extension == ".txt" || extension == ".css" || extension == ".js")
                            {
                                rtbSource.Text = File.ReadAllText(selectedPath);
                                rtbSource.ScrollToCaret();
                             
                                btnShowImage.Visible = false;
                            }
                            else if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                            {
                                rtbSource.Text = ""; // Xóa nội dung RichTextBox
                                btnShowImage.Visible = true;

                         
                                btnShowImage.Click += (btnSender, eventArgs) => 
                                {
                                    Form imageForm = new Form();
                                    imageForm.Text = "Hình ảnh";
                                    PictureBox pictureBox = new PictureBox();
                                    pictureBox.Image = Image.FromFile(selectedPath);
                                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                    pictureBox.Dock = DockStyle.Fill;
                                    imageForm.Controls.Add(pictureBox);
                                    imageForm.ShowDialog();
                                };
                            }
                            else
                            {
                                rtbSource.Text = "Không thể hiển thị file.";
                                btnShowImage.Visible = false;
                            }
                        }
                    };

                    sourceForm.ShowDialog();
                }
            }
        }

        // Hàm đệ quy để thêm các node vào TreeView
        private void AddNodes(TreeNode parentNode, string directoryPath)
        {
            string[] directories = Directory.GetDirectories(directoryPath);
            foreach (string directory in directories)
            {
                TreeNode node = new TreeNode(Path.GetFileName(directory));
                parentNode.Nodes.Add(node);
                AddNodes(node, directory);
            }

            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                TreeNode node = new TreeNode(Path.GetFileName(file));
                parentNode.Nodes.Add(node);
            }
        }
    }

}