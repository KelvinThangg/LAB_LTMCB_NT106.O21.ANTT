using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private string getHTML(string szURL)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(szURL);
            // Get the response. 
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server. 
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access. 
            StreamReader reader = new StreamReader(dataStream);
            // Read the content. 
            string responseFromServer = reader.ReadToEnd();
            Showrtb.Text = responseFromServer;
            // Close the response. 
            response.Close();
            return responseFromServer;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                getHTML(URLtb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nội dung trang web: " + ex.Message);
            }
        }
    }
}
