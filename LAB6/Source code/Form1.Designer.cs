namespace LAB6
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
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.pictureBoxWhiteboard = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.numericUpDownPenWidth = new System.Windows.Forms.NumericUpDown();
            this.lblClientCount = new System.Windows.Forms.Label();
            this.textBoxImageURL = new System.Windows.Forms.TextBox();
            this.buttonInsertImage = new System.Windows.Forms.Button();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.btnSendText = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnPen = new System.Windows.Forms.RadioButton();
            this.rbtnEraser = new System.Windows.Forms.RadioButton();
            this.trackBarResize = new System.Windows.Forms.TrackBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.hScrollBarOpacity = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbShape = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPlaybook = new System.Windows.Forms.Button();
            this.cmbSaveFormat = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWhiteboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarResize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(100, 431);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(109, 44);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(674, 354);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(64, 57);
            this.btnColor.TabIndex = 1;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(213, 431);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(67, 44);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // pictureBoxWhiteboard
            // 
            this.pictureBoxWhiteboard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxWhiteboard.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxWhiteboard.Name = "pictureBoxWhiteboard";
            this.pictureBoxWhiteboard.Size = new System.Drawing.Size(791, 345);
            this.pictureBoxWhiteboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWhiteboard.TabIndex = 3;
            this.pictureBoxWhiteboard.TabStop = false;
            this.pictureBoxWhiteboard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWhiteboard_MouseDown);
            this.pictureBoxWhiteboard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWhiteboard_MouseMove);
            this.pictureBoxWhiteboard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWhiteboard_MouseUp);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 431);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(82, 44);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // numericUpDownPenWidth
            // 
            this.numericUpDownPenWidth.Location = new System.Drawing.Point(609, 385);
            this.numericUpDownPenWidth.Name = "numericUpDownPenWidth";
            this.numericUpDownPenWidth.Size = new System.Drawing.Size(59, 26);
            this.numericUpDownPenWidth.TabIndex = 5;
            this.numericUpDownPenWidth.ValueChanged += new System.EventHandler(this.numericUpDownPenWidth_ValueChanged);
            // 
            // lblClientCount
            // 
            this.lblClientCount.AutoSize = true;
            this.lblClientCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblClientCount.Location = new System.Drawing.Point(383, 357);
            this.lblClientCount.Name = "lblClientCount";
            this.lblClientCount.Size = new System.Drawing.Size(74, 25);
            this.lblClientCount.TabIndex = 6;
            this.lblClientCount.Text = "Status";
            // 
            // textBoxImageURL
            // 
            this.textBoxImageURL.Location = new System.Drawing.Point(76, 388);
            this.textBoxImageURL.Name = "textBoxImageURL";
            this.textBoxImageURL.Size = new System.Drawing.Size(301, 26);
            this.textBoxImageURL.TabIndex = 7;
            this.textBoxImageURL.Text = "https://th.bing.com/th/id/OIP.rowaWV1TafRWwSubdYNZswAAAA?rs=1&pid=ImgDetMain";
            // 
            // buttonInsertImage
            // 
            this.buttonInsertImage.Location = new System.Drawing.Point(282, 431);
            this.buttonInsertImage.Name = "buttonInsertImage";
            this.buttonInsertImage.Size = new System.Drawing.Size(67, 44);
            this.buttonInsertImage.TabIndex = 8;
            this.buttonInsertImage.Text = "Image";
            this.buttonInsertImage.UseVisualStyleBackColor = true;
            this.buttonInsertImage.Click += new System.EventHandler(this.buttonInsertImage_Click);
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(76, 356);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(226, 26);
            this.textBoxText.TabIndex = 11;
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(352, 431);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(67, 44);
            this.btnSendText.TabIndex = 12;
            this.btnSendText.Text = "Text";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "TEXT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "URL:";
            // 
            // rbtnPen
            // 
            this.rbtnPen.AutoSize = true;
            this.rbtnPen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rbtnPen.Location = new System.Drawing.Point(516, 388);
            this.rbtnPen.Name = "rbtnPen";
            this.rbtnPen.Size = new System.Drawing.Size(65, 24);
            this.rbtnPen.TabIndex = 16;
            this.rbtnPen.TabStop = true;
            this.rbtnPen.Text = "Pen";
            this.rbtnPen.UseVisualStyleBackColor = true;
            this.rbtnPen.CheckedChanged += new System.EventHandler(this.rbtnPen_CheckedChanged);
            // 
            // rbtnEraser
            // 
            this.rbtnEraser.AutoSize = true;
            this.rbtnEraser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnEraser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rbtnEraser.Location = new System.Drawing.Point(516, 356);
            this.rbtnEraser.Name = "rbtnEraser";
            this.rbtnEraser.Size = new System.Drawing.Size(87, 24);
            this.rbtnEraser.TabIndex = 17;
            this.rbtnEraser.TabStop = true;
            this.rbtnEraser.Text = "Eraser";
            this.rbtnEraser.UseVisualStyleBackColor = true;
            this.rbtnEraser.CheckedChanged += new System.EventHandler(this.rbtnEraser_CheckedChanged);
            // 
            // trackBarResize
            // 
            this.trackBarResize.LargeChange = 2;
            this.trackBarResize.Location = new System.Drawing.Point(377, 385);
            this.trackBarResize.Name = "trackBarResize";
            this.trackBarResize.Size = new System.Drawing.Size(127, 69);
            this.trackBarResize.TabIndex = 18;
            this.trackBarResize.TickFrequency = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(421, 431);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 44);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // hScrollBarOpacity
            // 
            this.hScrollBarOpacity.Location = new System.Drawing.Point(566, 424);
            this.hScrollBarOpacity.MaximumSize = new System.Drawing.Size(228, 20);
            this.hScrollBarOpacity.MinimumSize = new System.Drawing.Size(228, 20);
            this.hScrollBarOpacity.Name = "hScrollBarOpacity";
            this.hScrollBarOpacity.Size = new System.Drawing.Size(228, 20);
            this.hScrollBarOpacity.TabIndex = 20;
            this.hScrollBarOpacity.Value = 100;
            this.hScrollBarOpacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarOpacity_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(494, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Opacity";
            // 
            // cmbShape
            // 
            this.cmbShape.FormattingEnabled = true;
            this.cmbShape.Items.AddRange(new object[] {
            "Triangle 🔺",
            "Rectangle ▆",
            "Square ⬜",
            "Circle 🔴"});
            this.cmbShape.Location = new System.Drawing.Point(566, 451);
            this.cmbShape.Name = "cmbShape";
            this.cmbShape.Size = new System.Drawing.Size(228, 28);
            this.cmbShape.TabIndex = 22;
            this.cmbShape.SelectedIndexChanged += new System.EventHandler(this.cmbShape_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(502, 454);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Shape";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(614, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Size";
            // 
            // btnPlaybook
            // 
            this.btnPlaybook.Location = new System.Drawing.Point(741, 354);
            this.btnPlaybook.Name = "btnPlaybook";
            this.btnPlaybook.Size = new System.Drawing.Size(53, 57);
            this.btnPlaybook.TabIndex = 25;
            this.btnPlaybook.Text = "HD";
            this.btnPlaybook.UseVisualStyleBackColor = true;
            this.btnPlaybook.Click += new System.EventHandler(this.btnPlaybook_Click);
            // 
            // cmbSaveFormat
            // 
            this.cmbSaveFormat.FormattingEnabled = true;
            this.cmbSaveFormat.Items.AddRange(new object[] {
            "png",
            "jpeg"});
            this.cmbSaveFormat.Location = new System.Drawing.Point(308, 354);
            this.cmbSaveFormat.Name = "cmbSaveFormat";
            this.cmbSaveFormat.Size = new System.Drawing.Size(69, 28);
            this.cmbSaveFormat.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(796, 471);
            this.Controls.Add(this.cmbSaveFormat);
            this.Controls.Add(this.btnPlaybook);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbShape);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hScrollBarOpacity);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSendText);
            this.Controls.Add(this.rbtnEraser);
            this.Controls.Add(this.rbtnPen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.buttonInsertImage);
            this.Controls.Add(this.textBoxImageURL);
            this.Controls.Add(this.lblClientCount);
            this.Controls.Add(this.numericUpDownPenWidth);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.pictureBoxWhiteboard);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.trackBarResize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(818, 527);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(818, 527);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Whitebroad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWhiteboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarResize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.PictureBox pictureBoxWhiteboard;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.NumericUpDown numericUpDownPenWidth;
        private System.Windows.Forms.Label lblClientCount;
        private System.Windows.Forms.TextBox textBoxImageURL;
        private System.Windows.Forms.Button buttonInsertImage;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnPen;
        private System.Windows.Forms.RadioButton rbtnEraser;
        private System.Windows.Forms.TrackBar trackBarResize;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.HScrollBar hScrollBarOpacity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbShape;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPlaybook;
        private System.Windows.Forms.ComboBox cmbSaveFormat;
    }
}

