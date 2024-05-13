using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cau5ne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Thiết lập chế độ xem chi tiết cho ListView
            listView1.View = View.Details;

            // Thêm các cột
            listView1.Columns.Add("Tên file", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("Kích thước", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Đuôi mở rộng", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Ngày tạo", 300, HorizontalAlignment.Left);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mở cửa sổ duyệt thư mục
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Xoá danh sách cũ
                listView1.Items.Clear();

                // Lấy tất cả file
                string[] files = Directory.GetFiles(folderDialog.SelectedPath);

                foreach (string file in files)
                {
                    // Lấy thông tin file
                    FileInfo fileInfo = new FileInfo(file);
                    string filename = fileInfo.Name;
                    long size = fileInfo.Length;
                    string extension = fileInfo.Extension;
                    DateTime createdDate = fileInfo.CreationTime;

                    // Tạo ListView
                    ListViewItem item = new ListViewItem(filename);
                    item.SubItems.Add(Convert.ToString(size) + " bytes"); // Convert size to string
                    item.SubItems.Add(extension);
                    item.SubItems.Add(createdDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    listView1.Items.Add(item);
                }
            }
        }
    }
}