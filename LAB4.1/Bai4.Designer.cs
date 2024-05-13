namespace Lab4
{
    partial class Bai4
    {/// <summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bai4));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtUrl = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGo = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnDownload = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnViewSource = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(10, 49);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(17, 17);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(729, 373);
            this.webBrowser1.TabIndex = 0;
            // 
            // txtUrl
            // 
            this.txtUrl.BorderColor = System.Drawing.Color.Cyan;
            this.txtUrl.BorderRadius = 5;
            this.txtUrl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUrl.DefaultText = "google.com";
            this.txtUrl.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUrl.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUrl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUrl.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUrl.FillColor = System.Drawing.Color.Black;
            this.txtUrl.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUrl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUrl.ForeColor = System.Drawing.Color.White;
            this.txtUrl.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUrl.Location = new System.Drawing.Point(12, 7);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.PasswordChar = '\0';
            this.txtUrl.PlaceholderText = "";
            this.txtUrl.SelectedText = "";
            this.txtUrl.Size = new System.Drawing.Size(491, 36);
            this.txtUrl.TabIndex = 5;
            // 
            // btnGo
            // 
            this.btnGo.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnGo.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnGo.ImageRotate = 0F;
            this.btnGo.ImageSize = new System.Drawing.Size(30, 30);
            this.btnGo.Location = new System.Drawing.Point(509, 7);
            this.btnGo.Name = "btnGo";
            this.btnGo.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnGo.Size = new System.Drawing.Size(49, 36);
            this.btnGo.TabIndex = 6;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click_2);
            // 
            // btnDownload
            // 
            this.btnDownload.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDownload.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnDownload.Image")));
            this.btnDownload.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDownload.ImageRotate = 0F;
            this.btnDownload.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDownload.Location = new System.Drawing.Point(555, 7);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDownload.Size = new System.Drawing.Size(49, 36);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click_1);
            // 
            // btnViewSource
            // 
            this.btnViewSource.BorderRadius = 15;
            this.btnViewSource.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewSource.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewSource.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewSource.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewSource.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewSource.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnViewSource.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnViewSource.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewSource.ForeColor = System.Drawing.Color.White;
            this.btnViewSource.Location = new System.Drawing.Point(610, 10);
            this.btnViewSource.Name = "btnViewSource";
            this.btnViewSource.Size = new System.Drawing.Size(127, 30);
            this.btnViewSource.TabIndex = 7;
            this.btnViewSource.Text = "View Source";
            this.btnViewSource.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // Bai4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(750, 444);
            this.Controls.Add(this.btnViewSource);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Bai4";
            this.Text = "Web Browser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Guna.UI2.WinForms.Guna2TextBox txtUrl;
        private Guna.UI2.WinForms.Guna2ImageButton btnGo;
        private Guna.UI2.WinForms.Guna2ImageButton btnDownload;
        private Guna.UI2.WinForms.Guna2GradientButton btnViewSource;
        // (Tùy chọn)
        // private System.Windows.Forms.ProgressBar progressBar1;
    }
}