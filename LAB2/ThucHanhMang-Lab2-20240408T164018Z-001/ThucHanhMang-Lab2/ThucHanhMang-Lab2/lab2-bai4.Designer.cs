namespace ThucHanhMang_Lab2
{
    partial class lab2_bai4
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
            this.btn_write = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_copy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_write
            // 
            this.btn_write.Location = new System.Drawing.Point(79, 88);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(110, 38);
            this.btn_write.TabIndex = 15;
            this.btn_write.Text = "Ghi file";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(244, 9);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(477, 432);
            this.textBox1.TabIndex = 14;
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(79, 9);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(110, 38);
            this.btn_read.TabIndex = 13;
            this.btn_read.Text = "Lưu file";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(79, 178);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(110, 38);
            this.btn_copy.TabIndex = 16;
            this.btn_copy.Text = "Đọc File";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // lab2_bai4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ThucHanhMang_Lab2.Properties.Resources.hinh_nen_dang_yeu_cute_cho_may_tinh_115833037;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_copy);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_read);
            this.Name = "lab2_bai4";
            this.Text = "lab2_bai4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_copy;
    }
}