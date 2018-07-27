using HttpServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace HttpUIApplication
{
    public partial class HttpUI : Form, IStatus
    {
        private Thread startServer;
        private string path;
        private int port;
        private HTTPServer server;

        public HttpUI()
        {
            InitializeComponent();
            StopButton.Enabled = false;
        }

        public void StartServer()
        {
            server = new HTTPServer(port, path, this);
            server.Start();
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(PathText.Text))
            {
                Color color = Color.Red;
                ClientAddress.SelectionColor = color;
                ClientAddress.AppendText("Path does not exist");
                ClientAddress.SelectionColor = ClientAddress.ForeColor;
                return;
            }

            if (!int.TryParse(PortText.Text, out int n) || n < 0 || n > ushort.MaxValue)
            {
                Color color = Color.Red;
                ClientAddress.SelectionColor = color;
                ClientAddress.AppendText("Port must be a number between 0 and 65535");
                ClientAddress.SelectionColor = ClientAddress.ForeColor;
                return;
            }
            
            path = PathText.Text;
            port = n;
            startServer = new Thread(new ThreadStart(StartServer));
            startServer.Start();
            UpdateStatus(true);
            ServerStatus.Text = "Server started succesfully!";
            ClientAddress.Text = "No connection";
        }

        private void Path_TextChanged(object sender, EventArgs e)
        {
            path = PathText.Text;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            server.Stop();
            startServer.Join();
            UpdateStatus(false);
            ServerStatus.Text = "Server was stopped.";
        }

        private void Port_TextChanged(object sender, EventArgs e)
        {
            if (PortText.Text != null && int.TryParse(PortText.Text, out int n))
            {
                port = Convert.ToInt32(PortText.Text);
            }
        }

        public void ReportError(string message)
        {
            MessageBox.Show(message);

            Invoke(new MethodInvoker(() => UpdateStatus(false)));
        }

        public void UpdateStatus(bool state)
        {
            StartButton.Enabled = !state;
            StopButton.Enabled = state;
        }

        private void ServerStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClientAddress_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void ClientIP(string client)
        {
           Invoke(new MethodInvoker(() => ClientAddress.Text += "IP: " + client + "\r\n"));

        }

        public void Method(string method)
        {
            Invoke(new MethodInvoker(() => ClientAddress.Text += method + "\r\n"));
        }

        public void RequestUri(string uri)
        {
            Invoke(new MethodInvoker(() => ClientAddress.Text += uri + "\r\n"));

        }

        public void ResponseType(string responseType)
        {
            Invoke(new MethodInvoker(() => ClientAddress.Text += responseType + "\r\n"));

        }

        private void HttpUI_Load(object sender, EventArgs e)
        {
            PathText.Text = Properties.Settings.Default.RootFolder;
        }
    }
}
