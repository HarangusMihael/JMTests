using HttpServer;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace HttpWPFApplication
{
    public class HttpViewModel : IStatus, INotifyPropertyChanged
    {
        private string path;
        private int port;
        private Thread startServer;
        private HTTPServer server;
        private string status = "Server not started";
        private string clientMessage = "";

        public string PathText
        {
            get => path;

            set
            {
                path = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PathText)));
            }
        }

        public int Port
        {
            get => port;

            set
            {
                port = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Port)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand start;
        private DelegateCommand stop;

        public ICommand StartServer
        {
            get
            {
                if (start == null)
                    start = new DelegateCommand(ServerStart);
                return start;
            }            
        }

        public ICommand StopServer
        {
            get
            {
                if (stop == null)
                    stop = new DelegateCommand(ServerStop);
                return stop;
            }
        }

        private void ServerStop()
        {
            server.Stop();
            startServer.Join();
            ServerStatus = "Server stopped";
        }

        public void ServerStart()
        {
            
            startServer = new Thread(new ThreadStart(Server));
            startServer.Start();
            ServerStatus = "Server started";
  
        }

        public void Server()
        {
            server = new HTTPServer(port, path, this);
            server.Start();
        }

        public string ServerStatus
        {
            get => status;
            private set
            {
                status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ServerStatus)));
            }
        }
        
        public string ClientMessage
        {
            get => clientMessage;

            private set
            {
                clientMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClientMessage)));
            }
        }

        public void ReportError(string message)
        {
            MessageBox.Show(message);

        }

        public void ClientIP(string client)
        {
            Dispatcher.CurrentDispatcher.Invoke(() => ClientMessage += "IP:" + client + "\r\n");
        }

        public void Method(string method)
        {
            Dispatcher.CurrentDispatcher.Invoke(() => ClientMessage += method + "\r\n");
        }

        public void RequestUri(string uri)
        {
            Dispatcher.CurrentDispatcher.Invoke(() => ClientMessage += uri + "\r\n");
        }

        public void ResponseType(string responseType)
        {
            Dispatcher.CurrentDispatcher.Invoke(() => ClientMessage += responseType + "\r\n");
        }

    }
}
