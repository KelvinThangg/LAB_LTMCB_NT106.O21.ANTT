namespace ThucHanhMang_Lab2
{
    partial class lab2_Bai5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRead = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tenFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kichThuoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duoiMoRong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngayTao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(28, 337);
            this.btnRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(144, 76);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Chọn";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click_1);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tenFile,
            this.kichThuoc,
            this.duoiMoRong,
            this.ngayTao});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 55);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(734, 253);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tenFile
            // 
            this.tenFile.Text = "Tên File";
            this.tenFile.Width = 250;
            // 
            // kichThuoc
            // 
            this.kichThuoc.Text = "Kích Thước";
            this.kichThuoc.Width = 100;
            // 
            // duoiMoRong
            // 
            this.duoiMoRong.Text = "Đuôi mở rộng";
            this.duoiMoRong.Width = 100;
            // 
            // ngayTao
            // 
            this.ngayTao.Text = "Ngày tạo";
            this.ngayTao.Width = 188;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(620, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 76);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lab2_Bai5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ThucHanhMang_Lab2.Properties.Resources.hinh_nen_dang_yeu_cute_cho_may_tinh_115833037;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.listView1);
            this.Name = "lab2_Bai5";
            this.Text = "lab2_Bai5";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader tenFile;
        private System.Windows.Forms.ColumnHeader kichThuoc;
        private System.Windows.Forms.ColumnHeader duoiMoRong;
        private System.Windows.Forms.ColumnHeader ngayTao;
        private System.Windows.Forms.Button button1;
    }
}