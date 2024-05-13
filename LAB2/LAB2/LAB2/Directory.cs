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
    public partial class Directory : Form
    {
        public Directory()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void load_Listview()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            listView.Items.Clear();

            if (result == DialogResult.OK)
            {
                string selectedFolder = folderBrowserDialog.SelectedPath;
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(selectedFolder);
                    FileInfo[] files = dir.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        ListViewItem item = new ListViewItem(file.Name);
                        item.SubItems.Add(file.Length.ToString());
                        item.SubItems.Add(file.Extension);
                        item.SubItems.Add(file.CreationTime.ToString());
                        listView.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Refresh the ListView
                    listView.Refresh();
                }
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            load_Listview();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    } 
}
