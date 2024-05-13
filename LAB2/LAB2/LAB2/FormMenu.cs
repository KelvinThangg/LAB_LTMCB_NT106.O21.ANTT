using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void bai1Btn_Click(object sender, EventArgs e)
        {
            WriteNRead writeNRead = new WriteNRead();
            writeNRead.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bai2Btn_Click(object sender, EventArgs e)
        {
            FileDetail fileDetail = new FileDetail();
            fileDetail.Show();
        }

        private void bai3Btn_Click(object sender, EventArgs e)
        {
            ReadNWritepp readNWritepp = new ReadNWritepp();
            readNWritepp.Show();
        }

        private void bai4Btn_Click(object sender, EventArgs e)
        {
            BFormatter bFormatter = new BFormatter();
            bFormatter.Show();
        }

        private void bai5Btn_Click(object sender, EventArgs e)
        {
            Directory directory = new Directory();
            directory.Show();
        }
    }
}
