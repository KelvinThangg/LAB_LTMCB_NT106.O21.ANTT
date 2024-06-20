using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlTypes;
using System.IO.Ports;

namespace LAB6
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private bool isDrawing = false;
        private Point lastPoint;
        private Point endPoint; 
        private Pen pen = new Pen(Color.Black, 2);
        private bool isConnected = false;
        private Point pasteLocation;
        private float penOpacity = 1f;
        private int clickCount = 0; 
        private List<Point> trianglePoints = new List<Point>(); 
        private string currentShape = null;
        int temp = 1;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            pictureBoxWhiteboard.Image = new Bitmap(pictureBoxWhiteboard.Width, pictureBoxWhiteboard.Height);
            btnDisconnect.Enabled = false;
            pictureBoxWhiteboard.Enabled = false;
            btnEnd.Enabled = false;
            btnConnect.Enabled = true;
            buttonInsertImage.Enabled = false;
            textBoxImageURL.Enabled = false;
            btnSendText.Enabled = false;
            rbtnPen.Checked = true;
            cmbSaveFormat.SelectedIndex = 0;
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("localhost", 8888);
                stream = client.GetStream();
                isConnected = true;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                pictureBoxWhiteboard.Enabled = true;
                buttonInsertImage.Enabled = true;
                textBoxImageURL.Enabled = true;
                btnSendText.Enabled = true;
                btnEnd.Enabled = true;

                Thread receiveThread = new Thread(ReceiveData);
                receiveThread.Start();

                byte[] data = Encoding.ASCII.GetBytes("JOIN");
                stream.Write(data, 0, data.Length);
            }

            catch (Exception ex)
            {
                Application.Exit();
            }
        }

        private void Disconnect()
        {
            try
            {
                if (isConnected)
                {
                    isConnected = false;
                    byte[] data = Encoding.ASCII.GetBytes("LEAVE");
                    stream.Write(data, 0, data.Length);

                    stream?.Close();
                    client?.Close();

                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    lblClientCount.Text = string.Empty;
                    btnEnd.Enabled = false;
                }
            }
            catch (Exception ex)
            {}
        }

        private void ReceiveData()
        {

            byte[] buffer = new byte[1024];
            try
            {
                while (isConnected)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        ProcessMessage(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Disconnect();
            }
        }

        private void ProcessMessage(string message)
        {
            if (message.StartsWith("DRAW|"))
            {
                string[] parts = message.Split('|');
                Color color = Color.FromArgb(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                int width = int.Parse(parts[4]);
                float opacity = float.Parse(parts[5]);
                Point startPoint = new Point(int.Parse(parts[6]), int.Parse(parts[7]));
                Point endPoint = new Point(int.Parse(parts[8]), int.Parse(parts[9]));
                DrawOnPicturebox(color, width, startPoint, endPoint, opacity);
            }

            if (message.StartsWith("CLIENTS|"))
            {
                int clientCount = int.Parse(message.Substring("CLIENTS|".Length));
                UpdateClientCount(clientCount);
            }
       
            if (message == "SAVE")
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(SaveAndExit));
                }
                else
                {
                    SaveAndExit();
                }
                byte[] data = Encoding.ASCII.GetBytes("SAVED");
                stream.Write(data, 0, data.Length);
            }

            if (message == "TERMINATE")
            {
                Disconnect();
                Application.Exit();
            }

            if (message.StartsWith("SNAPSHOT|"))
            {
                try
                {
                    string[] parts = message.Split('|');
                    int imageSize = int.Parse(parts[1]);
                    byte[] imageData = ReceiveImageData(stream, imageSize);

                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image receivedImage = Image.FromStream(ms);

                        DrawImageOnWhiteboard(receivedImage);
                    }
                }
                catch (Exception ex)
                {}
            }
     
        }

        private void SendShapeData(string shape, Point startPoint, Point endPoint)
        {
            if (isConnected)
            {
                string message = $"SHAPE|{shape}|{startPoint.X}|{startPoint.Y}|{endPoint.X}|{endPoint.Y}|{pen.Color.R}|{pen.Color.G}|{pen.Color.B}|{pen.Width}|{penOpacity}";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }
        private void SendTriangleData(List<Point> points)
        {
            if (isConnected)
            {
                string message = $"SHAPE|Triangle";
                foreach (Point point in points)
                {
                    message += $"|{point.X}|{point.Y}";
                }
                message += $"|{pen.Color.R}|{pen.Color.G}|{pen.Color.B}|{pen.Width}|{penOpacity}";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }

        private void SaveAndExit()
        {
            string filePath;
            try
            {
                if (cmbSaveFormat.SelectedItem.ToString() == "jpeg")
                {
                    filePath = @"C:\Users\dadad\source\repos\LAB6\bin\Debug\whiteboard.jpeg";

                    using (Bitmap bmp = new Bitmap(pictureBoxWhiteboard.Width, pictureBoxWhiteboard.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.FillRectangle(Brushes.MediumSeaGreen, 0, 0, pictureBoxWhiteboard.Width, pictureBoxWhiteboard.Height);
                            g.DrawImage(pictureBoxWhiteboard.Image, 0, 0);
                        }
                        bmp.Save(filePath, ImageFormat.Jpeg);
                    }
                }
                else
                {
                    filePath = @"C:\Users\dadad\source\repos\LAB6\bin\Debug\whiteboard.png";
                    using (Bitmap bmp = new Bitmap(pictureBoxWhiteboard.Width, pictureBoxWhiteboard.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawImage(pictureBoxWhiteboard.Image, 0, 0);
                        }

                        for (int y = 0; y < bmp.Height; y++)
                        {
                            for (int x = 0; x < bmp.Width; x++)
                            {
                                Color pixelColor = bmp.GetPixel(x, y);
                                if (pixelColor.ToArgb() == Color.MediumSeaGreen.ToArgb())
                                {
                                    Color transparentColor = Color.FromArgb(0, pixelColor.R, pixelColor.G, pixelColor.B);
                                    bmp.SetPixel(x, y, transparentColor);
                                }
                            }
                        }

                        bmp.Save(filePath, ImageFormat.Png);
                    }
                }

                MessageBox.Show($"Đã lưu hình ảnh vào {filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] ReceiveImageData(NetworkStream stream, int imageSize)
        {
            byte[] imageData = new byte[imageSize];
            int bytesReceived = 0;
            while (bytesReceived < imageSize)
            {
                int bytes = stream.Read(imageData, bytesReceived, imageSize - bytesReceived);
                if (bytes == 0)
                {
                    throw new Exception("Connection closed prematurely.");
                }
                bytesReceived += bytes;
            }
            return imageData;
        }

        private void DrawImageOnWhiteboard(Image image)
        {
            if (pictureBoxWhiteboard.InvokeRequired)
            {
                pictureBoxWhiteboard.Invoke(new Action(() =>
                {
                    using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
                    {
                        g.DrawImage(image, 0, 0);
                    }
                    pictureBoxWhiteboard.Refresh();
                }));
            }
            else
            {
                using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
                {
                    g.DrawImage(image, 0, 0);
                }
                pictureBoxWhiteboard.Refresh();
            }
        }

        private void UpdateClientCount(int count)
        {
            if (lblClientCount.InvokeRequired) 
            {
                lblClientCount.Invoke(new Action(() => lblClientCount.Text = $"Số client: {count}"));
            }
            else
            {
                lblClientCount.Text = $"Số client: {count}";
            }
        }

        private void DrawOnPicturebox(Color color, int width, Point startPoint, Point endPoint, float opacity)
        {
            if (pictureBoxWhiteboard.InvokeRequired)
            {
                pictureBoxWhiteboard.Invoke(new Action(() =>
                {
                    using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
                    {
                        g.DrawLine(new Pen(Color.FromArgb((int)(color.A * opacity), color.R, color.G, color.B), width), startPoint, endPoint);
                    }
                    pictureBoxWhiteboard.Refresh();
                }));
            }
            else
            {
                using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
                {
                    g.DrawLine(new Pen(Color.FromArgb((int)(color.A * opacity), color.R, color.G, color.B), width), startPoint, endPoint);
                }
                pictureBoxWhiteboard.Refresh();
            }
        }

        private void SendDrawingData(Point startPoint, Point endPoint)
        {
            if (isDrawing)
            {
                string message = $"DRAW|{pen.Color.R}|{pen.Color.G}|{pen.Color.B}|{pen.Width}|{penOpacity}|{startPoint.X}|{startPoint.Y}|{endPoint.X}|{endPoint.Y}";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }

        private void ClearWhiteboard()
        {
            Bitmap blankBitmap = new Bitmap(pictureBoxWhiteboard.Width, pictureBoxWhiteboard.Height);
            pictureBoxWhiteboard.Image = blankBitmap;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (isConnected)
                {
                    byte[] data = Encoding.ASCII.GetBytes("END");
                    stream.Write(data, 0, data.Length);
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    buttonInsertImage.Enabled = false;
                    textBoxImageURL.Enabled = false;
                    btnSendText.Enabled = false;
                    btnEnd.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi yêu cầu kết thúc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            rbtnEraser.Checked = false;
            rbtnPen.Checked = true;
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog.Color;
            }
        }

        private void pictureBoxWhiteboard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
                clickCount++; 
            }

            if (e.Button == MouseButtons.Right) 
            {
                pasteLocation = e.Location;
                SendPasteLocation(pasteLocation);

            }

            if (cmbShape != null)
            {
                if (!rbtnEraser.Checked && !rbtnPen.Checked && cmbShape.SelectedItem.ToString() == "Triangle 🔺")
                {
                    if (clickCount <= 3)
                    {
                        trianglePoints.Add(lastPoint);
                        DrawTrianglePoints(trianglePoints);
                        if (clickCount == 3)
                        {
                            DrawTriangle(lastPoint, endPoint, penOpacity);
                            SendTriangleData(trianglePoints);
                            trianglePoints.Clear();
                            clickCount = 0;
                        }
                    }
                }
                else
                if (cmbShape.SelectedItem != null && !rbtnEraser.Checked && !rbtnPen.Checked)
                {
                    DrawCirclePoints(lastPoint, endPoint);
                    switch (cmbShape.SelectedItem.ToString())
                    {
                        case "Square ⬜":
                            if (clickCount == 2) 
                            {
                                DrawSquare(lastPoint, endPoint, penOpacity);
                                currentShape = "Square";
                                SendShapeData(currentShape, lastPoint, endPoint);
                                clickCount = 0;
                            }
                            break;
                        case "Circle 🔴":
                            if (clickCount == 2) 
                            {
                                DrawCircle(lastPoint, endPoint, penOpacity);
                                currentShape = "Circle";
                                SendShapeData(currentShape, lastPoint, endPoint);
                                clickCount = 0;
                            }
                            break;
                        case "Rectangle ▆":
                            if (clickCount == 2) 
                            {
                                DrawRectangle(lastPoint, endPoint, penOpacity);
                                currentShape = "Rectangle";
                                SendShapeData(currentShape, lastPoint, endPoint);
                                clickCount = 0;
                            }
                            break;
                    }
                }
            }

        }

        private void DrawTrianglePoints(List<Point> points)
        {

            using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
            {
                foreach (Point point in points)
                {
                    g.FillEllipse(Brushes.Black, new Rectangle(point.X, point.Y, 2, 2));
                }
            }
            pictureBoxWhiteboard.Refresh();
        }

        private void DrawCirclePoints(Point lastpoint, Point endpoint)
        {
            using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
            {
                g.FillEllipse(Brushes.Black, new Rectangle(lastpoint.X, lastpoint.Y, 2, 2));
                g.FillEllipse(Brushes.Black, new Rectangle(endpoint.X, endpoint.Y, 2, 2));
            }
            pictureBoxWhiteboard.Refresh();
        }

        private void SendPasteLocation(Point location)
        {
            if (isConnected)
            {
                string message = $"PASTE_LOCATION|{location.X}|{location.Y}";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }

        private void pictureBoxWhiteboard_MouseMove(object sender, MouseEventArgs e)
        {
            if ((isDrawing && rbtnPen.Checked) || (isDrawing && rbtnEraser.Checked))
            {
                SendDrawingData(lastPoint, e.Location);
                DrawOnPicturebox(pen.Color, (int)pen.Width, lastPoint, e.Location, penOpacity);
                lastPoint = e.Location;
            }     
        }

        private void pictureBoxWhiteboard_MouseUp(object sender, MouseEventArgs e)
        {
            endPoint = e.Location;
            isDrawing = false;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (lblClientCount.Text == "Số client: 1") temp = 0;
            pictureBoxWhiteboard.Enabled = false;
            
            Disconnect();
            ClearWhiteboard();

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            pictureBoxWhiteboard.Enabled = false;
            buttonInsertImage.Enabled = false;
            textBoxImageURL.Enabled = false;
            btnSendText.Enabled = false;
            btnEnd.Enabled = false;

            if (temp == 0) Application.Exit();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void numericUpDownPenWidth_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownPenWidth.Value > 0) pen.Width = (float)numericUpDownPenWidth.Value;
        }

        private Image ResizeImage(Image imgToResize, int percentage)
        {
            if (percentage <= 0) percentage = 10;

            int newWidth = (int)(imgToResize.Width * percentage / 10);
            int newHeight = (int)(imgToResize.Height * percentage / 10);

            Bitmap b = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, newWidth, newHeight);
            }
            return (Image)b;
        }

        private void SendImageData(Image image)
        {
            if (isConnected)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Png);
                    byte[] imageData = ms.ToArray();

                    string message = $"IMAGE|{imageData.Length}|";
                    byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                    stream.Write(messageBytes, 0, messageBytes.Length);
                    stream.Write(imageData, 0, imageData.Length);

                }
            }
        }

        private void buttonInsertImage_Click(object sender, EventArgs e)
        {
            string imageURL = textBoxImageURL.Text;
            if (string.IsNullOrWhiteSpace(imageURL))
            {
                MessageBox.Show("Vui lòng nhập URL ảnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] imageData = client.DownloadData(imageURL);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        int percentage = (trackBarResize.Value);
                        Image resizedImage = ResizeImage(image, percentage);
                        SendImageData(resizedImage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
            string text = textBoxText.Text;
            if (!string.IsNullOrEmpty(text))
            {
                SendTextToServer(text);
                textBoxText.Clear();
            }
        }

        private void SendTextToServer(string text)
        {
            if (isConnected)
            {
                string message = $"TEXT|{text}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {   
            if (isConnected)
            Disconnect();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isConnected)
                Disconnect();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\dadad\source\repos\LAB6\bin\Debug\whiteboard.";
            // Kiểm tra xem checkbox có được check hay không
            if (cmbSaveFormat.SelectedItem.ToString() == "jpeg")
            {
                filePath = @"C:\Users\dadad\source\repos\LAB6\bin\Debug\whiteboard.jpeg";
                // Lưu ảnh với background màu xanh lá cây
                using (Bitmap bmp = new Bitmap(pictureBoxWhiteboard.Width, pictureBoxWhiteboard.Height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.FillRectangle(Brushes.MediumSeaGreen, 0, 0, pictureBoxWhiteboard.Width, pictureBoxWhiteboard.Height);
                        g.DrawImage(pictureBoxWhiteboard.Image, 0, 0);
                    }
                    bmp.Save(filePath, ImageFormat.Jpeg);
                }
            }
            else
            {
                filePath = @"C:\Users\dadad\source\repos\LAB6\bin\Debug\whiteboard.png";
                using (Bitmap bmp = new Bitmap(pictureBoxWhiteboard.Width, pictureBoxWhiteboard.Height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(pictureBoxWhiteboard.Image, 0, 0);
                    }

                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color pixelColor = bmp.GetPixel(x, y);
                            if (pixelColor.ToArgb() == Color.MediumSeaGreen.ToArgb())
                            {
                                Color transparentColor = Color.FromArgb(0, pixelColor.R, pixelColor.G, pixelColor.B);
                                bmp.SetPixel(x, y, transparentColor);
                            }
                        }
                    }

                    bmp.Save(filePath, ImageFormat.Png);
                }
                }

            MessageBox.Show($"Đã lưu hình ảnh vào {filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hScrollBarOpacity_Scroll(object sender, ScrollEventArgs e)
        {
            penOpacity = hScrollBarOpacity.Value / 100f;
        }

        private void DrawSquare(Point startPoint, Point endPoint, float opacity)
        {
            int centerX = (startPoint.X + endPoint.X) / 2;
            int centerY = (startPoint.Y + endPoint.Y) / 2;

            int side = Math.Max(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));

            int x = centerX - side / 2;
            int y = centerY - side / 2;

            Rectangle rect = new Rectangle(x, y, side, side);

            using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
            {
                g.DrawRectangle(new Pen(Color.FromArgb((int)(pen.Color.A * opacity), pen.Color.R, pen.Color.G, pen.Color.B), pen.Width), rect);
            }
            pictureBoxWhiteboard.Refresh();
        }

        private void DrawCircle(Point startPoint, Point endPoint, float opacity)
        {
            int radius = (int)Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
            Rectangle rect = new Rectangle(startPoint.X - radius, startPoint.Y - radius, radius * 2, radius * 2);

            using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
            {
                g.DrawEllipse(new Pen(Color.FromArgb((int)(pen.Color.A * opacity), pen.Color.R, pen.Color.G, pen.Color.B), pen.Width), rect);
            }
            pictureBoxWhiteboard.Refresh();
        }

        private void DrawRectangle(Point startPoint, Point endPoint, float opacity)
        {
            int width = Math.Abs(endPoint.X - startPoint.X);
            int height = Math.Abs(endPoint.Y - startPoint.Y);

            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);

            Rectangle rect = new Rectangle(x, y, width, height);

            using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
            {
                g.DrawRectangle(new Pen(Color.FromArgb((int)(pen.Color.A * opacity), pen.Color.R, pen.Color.G, pen.Color.B), pen.Width), rect);
            }
            pictureBoxWhiteboard.Refresh();
        }

        private void DrawTriangle(Point startPoint, Point endPoint, float opacity)
        {
            Point[] points = trianglePoints.ToArray();
            using (Graphics g = Graphics.FromImage(pictureBoxWhiteboard.Image))
            {
                g.DrawPolygon(new Pen(Color.FromArgb((int)(pen.Color.A * opacity), pen.Color.R, pen.Color.G, pen.Color.B), pen.Width), points);
            }
            pictureBoxWhiteboard.Refresh();
        }


        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbShape.SelectedIndex != -1)
            {
                rbtnPen.Checked = false;
                rbtnEraser.Checked = false;
                if (pen.Color == Color.MediumSeaGreen)
                    pen.Color = Color.Black;
                clickCount = 0;
            }
            else clickCount = 0;
        }

        private void rbtnEraser_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEraser.Checked == true)
            {
                cmbShape.SelectedIndex = -1;
                pen.Color = Color.MediumSeaGreen;
                penOpacity = 1;

            }
        }

        private void rbtnPen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPen.Checked == true)
            {
                cmbShape.SelectedIndex = -1;
                if (pen.Color == Color.MediumSeaGreen) pen.Color = Color.Black;
            }
        }

        private void btnPlaybook_Click(object sender, EventArgs e)
        {
            string htmlFilePath = @"C:\Users\dadad\source\repos\LAB6\bin\Debug\Playbook.html";
            System.Diagnostics.Process.Start(htmlFilePath);
        }


    }
}
