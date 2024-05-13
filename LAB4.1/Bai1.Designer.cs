namespace Lab4
{
    partial class Bai1
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
            this.Showrtb = new System.Windows.Forms.RichTextBox();
            this.button1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.URLtb = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // Showrtb
            // 
            this.Showrtb.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Showrtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Showrtb.ForeColor = System.Drawing.Color.Gold;
            this.Showrtb.Location = new System.Drawing.Point(28, 94);
            this.Showrtb.Name = "Showrtb";
            this.Showrtb.Size = new System.Drawing.Size(544, 267);
            this.Showrtb.TabIndex = 0;
            this.Showrtb.Text = "";
            // 
            // button1
            // 
            this.button1.BorderRadius = 10;
            this.button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button1.FillColor = System.Drawing.Color.Aquamarine;
            this.button1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(495, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "GET";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // URLtb
            // 
            this.URLtb.BorderRadius = 10;
            this.URLtb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.URLtb.DefaultText = "https://blogg-booster.com";
            this.URLtb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.URLtb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.URLtb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.URLtb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.URLtb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.URLtb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.URLtb.ForeColor = System.Drawing.Color.Black;
            this.URLtb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.URLtb.Location = new System.Drawing.Point(51, 12);
            this.URLtb.Name = "URLtb";
            this.URLtb.PasswordChar = '\0';
            this.URLtb.PlaceholderText = "";
            this.URLtb.SelectedText = "";
            this.URLtb.Size = new System.Drawing.Size(375, 39);
            this.URLtb.TabIndex = 3;
            // 
            // Bai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(595, 380);
            this.Controls.Add(this.URLtb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Showrtb);
            this.Name = "Bai1";
            this.Text = "Bai1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Showrtb;
        private Guna.UI2.WinForms.Guna2GradientButton button1;
        private Guna.UI2.WinForms.Guna2TextBox URLtb;
    }
}