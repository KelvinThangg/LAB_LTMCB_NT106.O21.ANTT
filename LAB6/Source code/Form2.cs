using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.Mail;
using System.Drawing.Imaging;
using System.Runtime.InteropServices.ComTypes;

namespace LAB6
{
    public partial class Form2 : Form
    {

        private static List<TcpClient> clients = new List<TcpClient>();
        private static TcpListener listener;
        private static int sendmail = 0;
        private static bool serverRunning = true;
        private static bool serverShutdown = false;
        private int clientSavedCount = 0;
        private int clientEndCount = 0;
        private Bitmap currentSnapshot;
        private Point pasteLocation;
        private int temp = 1;
        private bool saveSignalReceived = false;
   
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            StartServer();
        }

        private void StartServer()
        {
            listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();
            UpdateStatusLabel("Server started on port 8888...");
            serverShutdown = false;
            Thread serverThread = new Thread(ServerLoop);
            serverThread.Start();
            currentSnapshot = new Bitmap(791, 345);
        }

        private void StopServer()
        {
            serverRunning = false;

            if (listener != null)
            {
                listener.Stop();
            }
            foreach (var client in clients)
            {
                client.Close();
            }
            Application.Exit();
        }

        private void UpdateClientList()
        {
            if (serverRunning && clients.Count > 0)
            {
                Invoke((MethodInvoker)delegate
                {
                    txtCount.Text = $"Số lượng Client: {clients.Count}";
                });
            }
        }

        private void ServerLoop()
        {
            while (serverRunning)
            {
                try
                {
                    if (serverShutdown) break;

                    TcpClient client = listener.AcceptTcpClient();
                    lock (clients)
                    {
                        clients.Add(client);
                    }

                    UpdateClientList();
                    UpdateClientListWithMessage("Client connected");
                    SendClientCount();

                    Thread clientThread = new Thread(HandleClient);
                    clientThread.Start(client);

                    if (clients.Count == 3)
                    {
                        sendmail = 1;
                    }
                }
                catch (SocketException)
                {
                    if (clients.Count > 0)
                    {
                        serverRunning = false;
                        Broadcast("TERMINATE", null);
                    }
                    else
                        Application.Exit();
                }
            }
        }

        private void SendClientCount()
        {
            Broadcast($"CLIENTS|{clients.Count}", null);
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                if (sendmail == 1)
                {
                    Thread mailThread = new Thread(SendMail);
                    mailThread.Start();
                    sendmail = 0;
                }

                while (serverRunning)
                {
                    if (!client.Connected)
                    {
                        break;
                    }

                    int bytesRead = 0;
                    try
                    {
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Lỗi ở IOException");
                        break;
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show("Lỗi ở SocketException");
                        break;
                    }

                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        UpdateClientListWithMessage(message);

                        if (message == "JOIN")
                        {
                            SendSnapshot(client, stream); 
                        }

                        if (message == "LEAVE")
                        {
                            DisconnectClient(client);
                            break;
                        }

                        if (message == "END")
                        {
                            clientEndCount = clients.Count;
                            Broadcast("SAVE", null);

                        }

                        if (message == "SAVED")
                        {
                            clientSavedCount++;
                            if (clientSavedCount == clientEndCount)
                            {
                                saveSignalReceived = true;
                                UpdateClientListWithMessage("Server Terminated!");
                                Broadcast("TERMINATE", null);
                            }
                            else
                            {
                                UpdateClientListWithMessage($"WAIT FOR ALL CLIENT, STILL: {clients.Count - clientSavedCount}");
                            }
                        }

                        if (message.StartsWith("IMAGE|"))
                        {
                            int imageSize = int.Parse(message.Split('|')[1]);
                            byte[] imageData = ReceiveImageData(stream, imageSize);
                            BroadcastImage(imageData, client);
                            message = "";

                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                Image receivedImage = Image.FromStream(ms);
                                using (Graphics g = Graphics.FromImage(currentSnapshot))
                                {
                                    g.DrawImage(receivedImage, pasteLocation.X, pasteLocation.Y);
                                }
                            }
                            BroadcastSnapshot();
                        }

                        if (message.StartsWith("PASTE_LOCATION|"))
                        {
                            string[] parts = message.Split('|');
                            int x = int.Parse(parts[1]);
                            int y = int.Parse(parts[2]);
                            pasteLocation = new Point(x, y);
                        }
                        
                        if (message.StartsWith("TEXT|"))
                        {
                            string text = message.Substring("TEXT|".Length);
                            text = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(text));
                            DrawTextOnSnapshot(text);
                            BroadcastSnapshot();
                        }

                        if (message.StartsWith("SHAPE|"))
                        {
                                
                            string[] parts = message.Split('|');
                            string shape = parts[1];
                            if (shape == "Triangle")
                            {
                                List<Point> trianglePoints = new List<Point>();
                                for (int i = 2; i < parts.Length - 5; i += 2)
                                {
                                    trianglePoints.Add(new Point(int.Parse(parts[i]), int.Parse(parts[i + 1])));
                                }
                                Color color = Color.FromArgb(int.Parse(parts[parts.Length - 5]), int.Parse(parts[parts.Length - 4]), int.Parse(parts[parts.Length - 3]));
                                int width = int.Parse(parts[parts.Length - 2]);
                                float opacity = float.Parse(parts[parts.Length - 1]);

                                DrawTriangleOnSnapshot(trianglePoints, color, width, opacity);
                            }
                            else
                            {
                                Point startPoint = new Point(int.Parse(parts[2]), int.Parse(parts[3]));
                                Point endPoint = new Point(int.Parse(parts[4]), int.Parse(parts[5]));
                                Color color = Color.FromArgb(int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]));
                                int width = int.Parse(parts[9]);
                                float opacity = float.Parse(parts[10]);

                                DrawShapeOnSnapshot(shape, startPoint, endPoint, color, width, opacity);
                            }
                            BroadcastSnapshot();
                        }

                        if (message.StartsWith("DRAW|"))
                        {
                            string[] parts = message.Split('|');
                            Color color = Color.FromArgb(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                            int width = int.Parse(parts[4]);
                            float opacity = float.Parse(parts[5]); 
                            Point startPoint = new Point(int.Parse(parts[6]), int.Parse(parts[7]));
                            Point endPoint = new Point(int.Parse(parts[8]), int.Parse(parts[9]));

                            using (Graphics g = Graphics.FromImage(currentSnapshot))
                            {
                                g.DrawLine(new Pen(Color.FromArgb((int)(color.A * opacity), color.R, color.G, color.B), width), startPoint, endPoint);
                            }
                            Broadcast(message, client);
                        }
                        else
                        {
                            Broadcast(message, client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateClientListWithMessage("Client disconnected");
                DisconnectClient(client);
                SendClientCount();
                if (clients.Count == 0)
                {
                    UpdateStatusLabel("No more clients. Shutting down server.");
                    Broadcast("TERMINATE", client);
                    StopServer();
                }
            }
            finally
            {
                lock (clients)
                {
                    clients.Remove(client);
                }
                client.Close();
                UpdateClientListWithMessage("Client disconnected");
                UpdateClientList();
                SendClientCount();

                if (clients.Count == 0)
                {
                    UpdateStatusLabel("No more clients. Shutting down server.");
                    Broadcast("TERMINATE", client);
                    StopServer();
                }
            }
        }

        private void DrawShapeOnSnapshot(string shape, Point startPoint, Point endPoint, Color color, int width, float opacity)
        {
            using (Graphics g = Graphics.FromImage(currentSnapshot))
            {
                Pen pen = new Pen(Color.FromArgb((int)(color.A * opacity), color.R, color.G, color.B), width);

                switch (shape)
                {
                    case "Square":
                        DrawSquare(g, pen, startPoint, endPoint);
                        break;
                    case "Circle":
                        DrawCircle(g, pen, startPoint, endPoint);
                        break;
                    case "Rectangle":
                        DrawRectangle(g, pen, startPoint, endPoint);
                        break;
                    default:
                        break;
                }
            }
        }

        private void DrawSquare(Graphics g, Pen pen, Point startPoint, Point endPoint)
        {
            int centerX = (startPoint.X + endPoint.X) / 2;
            int centerY = (startPoint.Y + endPoint.Y) / 2;

            int side = Math.Max(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));

            int x = centerX - side / 2;
            int y = centerY - side / 2;

            Rectangle rect = new Rectangle(x, y, side, side);

            g.DrawRectangle(pen, rect);
        }

        private void DrawCircle(Graphics g, Pen pen, Point startPoint, Point endPoint)
        {
            int radius = (int)Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
            Rectangle rect = new Rectangle(startPoint.X - radius, startPoint.Y - radius, radius * 2, radius * 2);

            g.DrawEllipse(pen, rect);
        }

        private void DrawRectangle(Graphics g, Pen pen, Point startPoint, Point endPoint)
        {
            int width = Math.Abs(endPoint.X - startPoint.X);
            int height = Math.Abs(endPoint.Y - startPoint.Y);

            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);

            Rectangle rect = new Rectangle(x, y, width, height);

            g.DrawRectangle(pen, rect);
        }

        private void DrawTriangleOnSnapshot(List<Point> trianglePoints, Color color, int width, float opacity)
        {
            using (Graphics g = Graphics.FromImage(currentSnapshot))
            {
                Pen pen = new Pen(Color.FromArgb((int)(color.A * opacity), color.R, color.G, color.B), width);
                g.DrawPolygon(pen, trianglePoints.ToArray());
            }
        }

        private void DrawTextOnSnapshot(string text)
        {
            using (Graphics g = Graphics.FromImage(currentSnapshot))
            {
                Font font = new Font("Arial", 16);
                Brush brush = new SolidBrush(Color.Black);
                g.DrawString(text, font, brush, new PointF(pasteLocation.X, pasteLocation.Y));
            }
        }

        private void SendSnapshot(TcpClient client, NetworkStream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                currentSnapshot.Save(ms, ImageFormat.Png);
                byte[] imageData = ms.ToArray();
                string message = $"SNAPSHOT|{imageData.Length}|";
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                UpdateClientListWithMessage("SEND SNAPSHOT");
                stream.Write(messageBytes, 0, messageBytes.Length);
                stream.Write(imageData, 0, imageData.Length);
            }
        }

        private byte[] ReceiveImageData(NetworkStream stream, int imageSize)
        {
            byte[] imageData = new byte[imageSize];
            int bytesReceived = 0;
            while (bytesReceived < imageSize)
            {
                int bytes = stream.Read(imageData, bytesReceived, imageSize - bytesReceived);
                bytesReceived += bytes;
            }
            return imageData;
        }

        private void BroadcastImage(byte[] imageData, TcpClient excludeClient)
        {
            foreach (TcpClient c in clients)
            {
                if (true)
                {
                    try
                    {
                        NetworkStream clientStream = c.GetStream();
                        string message = $"IMAGE|{imageData.Length}|";
                        byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                        clientStream.Write(messageBytes, 0, messageBytes.Length);
                        clientStream.Write(imageData, 0, imageData.Length);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ở BroadcastImage");
                    }
                }
            }
        }

        private void DisconnectClient(TcpClient client)
        {
            lock (clients)
            {
                clients.Remove(client);
                client.Close();
                UpdateClientList();
                SendClientCount();

                if (clients.Count == 0)
                {
                    UpdateStatusLabel("No more clients. Shutting down server.");
                    Broadcast("TERMINATE", null);
                    StopServer();
                }
            }
        }

        private async void SendMail()
        {
            string from = "khabanhpro135@gmail.com";
            string pass = "oyys skbr wueu spka";
            string to = "khabanhpro135@gmail.com";
            string body = "User >= 3 ! Server chuan bi sap :)) ! Check the server !!!";

            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = body;
            message.Subject = "LAB6: Whiteboard Server Warning";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass)
            };

            try
            {
                await smtp.SendMailAsync(message);
                UpdateClientListWithMessage("Warning has been sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ở SendMail");
            }
        }

        private void Broadcast(string message, TcpClient excludeClient)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            
            foreach (TcpClient c in clients)
            {
                if (message == "END" || message == "TERMINATE")
                {
                    NetworkStream clientStream = c.GetStream();
                    clientStream.Write(data, 0, data.Length);
                }
                else
                {
                    if (c != excludeClient && c.Connected)
                    {
                        try
                        {
                            NetworkStream clientStream = c.GetStream();
                            clientStream.Write(data, 0, data.Length);

                            if (message.StartsWith("DRAW|") && !saveSignalReceived)
                            {
                                string[] parts = message.Split('|');
                                Color color = Color.FromArgb(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                                int width = int.Parse(parts[4]);
                                float opacity = float.Parse(parts[5]); 
                                Point startPoint = new Point(int.Parse(parts[6]), int.Parse(parts[7]));
                                Point endPoint = new Point(int.Parse(parts[8]), int.Parse(parts[9]));

                                using (Graphics g = Graphics.FromImage(currentSnapshot))
                                {
                                    g.DrawLine(new Pen(Color.FromArgb((int)(color.A * opacity), color.R, color.G, color.B), width), startPoint, endPoint);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Tất cả client đã lưu! Server dừng!");
                        }
                   }
                }
            }
        }

        private void BroadcastSnapshot()
        {
            // Gửi snapshot đến tất cả các client
            foreach (TcpClient client in clients)
            {
                if (client.Connected)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        SendSnapshot(client, stream);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ở BroadcastSnapshot");
                    }
                }
            }
        }

        private void UpdateStatusLabel(string message)
        {
            if (serverRunning && clients.Count > 0 && !saveSignalReceived)
            {
                Invoke((MethodInvoker)delegate
                {
                    txtLabel.Text = message;
                });
            }
        }

        private void UpdateClientListWithMessage(string message)
        {
            try
            {
                if (serverRunning && clients.Count > 0 && !saveSignalReceived)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        lstClients.Items.Add(new ListViewItem(message));
                    });
                }
            }
            catch (Exception ex) { };
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverShutdown = true;
            if (clients.Count > 0)
            {
                serverRunning = false;
                Broadcast("TERMINATE", null);
            }
            else
            {
                StopServer();
                Application.Exit();
            }
        }
    }
}
