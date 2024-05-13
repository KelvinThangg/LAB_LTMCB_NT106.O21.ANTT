namespace LAB_2
{
    partial class Form1
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
            this.bai1btn = new System.Windows.Forms.Button();
            this.bai2btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bai1btn
            // 
            this.bai1btn.Location = new System.Drawing.Point(50, 128);
            this.bai1btn.Name = "bai1btn";
            this.bai1btn.Size = new System.Drawing.Size(129, 46);
            this.bai1btn.TabIndex = 0;
            this.bai1btn.Text = "Bài 1";
            this.bai1btn.UseVisualStyleBackColor = true;
            this.bai1btn.Click += new System.EventHandler(this.bai1btn_Click);
            // 
            // bai2btn
            // 
            this.bai2btn.Location = new System.Drawing.Point(50, 231);
            this.bai2btn.Name = "bai2btn";
            this.bai2btn.Size = new System.Drawing.Size(129, 50);
            this.bai2btn.TabIndex = 1;
            this.bai2btn.Text = "Bài 2";
            this.bai2btn.UseVisualStyleBackColor = true;
            this.bai2btn.Click += new System.EventHandler(this.bai2btn_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bai2btn);
            this.Controls.Add(this.bai1btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bai1btn;
        private System.Windows.Forms.Button bai2btn;
    }
}

