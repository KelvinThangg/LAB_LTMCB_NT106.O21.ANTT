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
    public partial class lab2_Bai5 : Form
    {
        public lab2_Bai5()
        {
            InitializeComponent();
        }


        public void DSFile(string path)
        {

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                // Tạo một ListViewItem mới
                ListViewItem item = new ListViewItem(Path.GetFileName(file));

                // Thêm các subitem cho ListViewItem
                item.SubItems.Add(new FileInfo(file).Length.ToString()); // Kích thước của tệp
                item.SubItems.Add(Path.GetExtension(file)); // Phần mở rộng của tệp
                item.SubItems.Add(File.GetLastWriteTime(file).ToString()); // Ngày sửa đổi cuối cùng của tệp

                // Thêm ListViewItem vào ListView
                listView1.Items.Add(item);
            }
        }
        private void btnRead_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string folderPath = fbd.SelectedPath;
            DSFile(folderPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
