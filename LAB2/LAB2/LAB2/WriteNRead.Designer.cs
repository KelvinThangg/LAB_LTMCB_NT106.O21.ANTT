namespace LAB2
{
    partial class WriteNRead
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
            this.components = new System.ComponentModel.Container();
            this.Show = new System.Windows.Forms.TextBox();
            this.readBtn = new Guna.UI2.WinForms.Guna2Button();
            this.writeBtn = new Guna.UI2.WinForms.Guna2Button();
            this.exitBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.titleTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Show
            // 
            this.Show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.Show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Show.Font = new System.Drawing.Font("Mulish Light", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Show.Location = new System.Drawing.Point(318, 34);
            this.Show.Multiline = true;
            this.Show.Name = "Show";
            this.Show.ReadOnly = true;
            this.Show.Size = new System.Drawing.Size(418, 382);
            this.Show.TabIndex = 5;
            this.Show.TextChanged += new System.EventHandler(this.Show_TextChanged);
            // 
            // readBtn
            // 
            this.readBtn.BackColor = System.Drawing.Color.Transparent;
            this.readBtn.BorderColor = System.Drawing.Color.White;
            this.readBtn.BorderRadius = 23;
            this.readBtn.BorderThickness = 1;
            this.readBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.readBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.readBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.readBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.readBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(62)))));
            this.readBtn.Font = new System.Drawing.Font("Shopee Display ExtBd", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.readBtn.ForeColor = System.Drawing.Color.White;
            this.readBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(62)))));
            this.readBtn.HoverState.Font = new System.Drawing.Font("Shopee Display Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.readBtn.Location = new System.Drawing.Point(46, 62);
            this.readBtn.Name = "readBtn";
            this.readBtn.Size = new System.Drawing.Size(180, 45);
            this.readBtn.TabIndex = 7;
            this.readBtn.Text = "Đọc File";
            this.readBtn.UseTransparentBackground = true;
            this.readBtn.Click += new System.EventHandler(this.readBtn_Click);
            // 
            // writeBtn
            // 
            this.writeBtn.BackColor = System.Drawing.Color.Transparent;
            this.writeBtn.BorderColor = System.Drawing.Color.White;
            this.writeBtn.BorderRadius = 23;
            this.writeBtn.BorderThickness = 1;
            this.writeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.writeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.writeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.writeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.writeBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.writeBtn.Font = new System.Drawing.Font("Shopee Display ExtBd", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.writeBtn.ForeColor = System.Drawing.Color.White;
            this.writeBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(72)))), ((int)(((byte)(103)))));
            this.writeBtn.HoverState.Font = new System.Drawing.Font("Shopee Display Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.writeBtn.Location = new System.Drawing.Point(46, 130);
            this.writeBtn.Name = "writeBtn";
            this.writeBtn.Size = new System.Drawing.Size(180, 45);
            this.writeBtn.TabIndex = 8;
            this.writeBtn.Text = "Ghi File";
            this.writeBtn.UseTransparentBackground = true;
            this.writeBtn.Click += new System.EventHandler(this.writeBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.BorderColor = System.Drawing.Color.White;
            this.exitBtn.BorderRadius = 23;
            this.exitBtn.BorderThickness = 1;
            this.exitBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exitBtn.Font = new System.Drawing.Font("Shopee Display ExtBd", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exitBtn.HoverState.Font = new System.Drawing.Font("Shopee Display Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.exitBtn.Location = new System.Drawing.Point(46, 195);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(180, 45);
            this.exitBtn.TabIndex = 9;
            this.exitBtn.Text = "Thoát";
            this.exitBtn.UseTransparentBackground = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(62)))));
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.exitBtn);
            this.guna2Panel1.Controls.Add(this.writeBtn);
            this.guna2Panel1.Controls.Add(this.readBtn);
            this.guna2Panel1.Location = new System.Drawing.Point(-7, 121);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(260, 330);
            this.guna2Panel1.TabIndex = 10;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.guna2Panel2.Location = new System.Drawing.Point(251, -2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(550, 453);
            this.guna2Panel2.TabIndex = 11;
            this.guna2Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel2_Paint);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 30;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(37)))));
            this.guna2Panel3.Controls.Add(this.titleTxt);
            this.guna2Panel3.Location = new System.Drawing.Point(-4, -2);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(257, 127);
            this.guna2Panel3.TabIndex = 12;
            this.guna2Panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel3_Paint);
            // 
            // titleTxt
            // 
            this.titleTxt.BorderThickness = 0;
            this.titleTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.titleTxt.DefaultText = "WRITE AND READ FILE";
            this.titleTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.titleTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.titleTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.titleTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.titleTxt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(37)))));
            this.titleTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.titleTxt.Font = new System.Drawing.Font("Shopee Display Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.titleTxt.ForeColor = System.Drawing.Color.White;
            this.titleTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.titleTxt.Location = new System.Drawing.Point(11, 29);
            this.titleTxt.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.PasswordChar = '\0';
            this.titleTxt.PlaceholderText = "";
            this.titleTxt.SelectedText = "";
            this.titleTxt.Size = new System.Drawing.Size(234, 74);
            this.titleTxt.TabIndex = 0;
            this.titleTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.titleTxt.TextChanged += new System.EventHandler(this.titleTxt_TextChanged);
            // 
            // WriteNRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WriteNRead";
            this.Text = "Write and Read File";
            this.Load += new System.EventHandler(this.WriteNRead_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Show;
        private Guna.UI2.WinForms.Guna2Button readBtn;
        private Guna.UI2.WinForms.Guna2Button writeBtn;
        private Guna.UI2.WinForms.Guna2Button exitBtn;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2TextBox titleTxt;
    }
}