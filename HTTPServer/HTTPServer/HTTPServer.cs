using HttpValidatorApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    public class HTTPServer

    { 
        private int port;
        string path;
        TcpListener listener;
        IStatus status;

        public HTTPServer(int clientPort, string clientPath, IStatus status)
        {
            port = clientPort;
            path = clientPath;
            this.status = status;
        }

        public void Start()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);

                listener.Start();

                AcceptClient();

            }
            catch (AggregateException)
            {
            }

            catch (InvalidOperationException)
            {
            }

            catch (SocketException e)
            {
                if (e.ErrorCode == 10048)
                {
                    status.ReportError("Used port");
                }
            }
        }

        private async void AcceptClient()
        {
            try
            {
                
                var client = await listener.AcceptTcpClientAsync();
                AcceptClient();

                var requestHeaders = await ReadHeadersAsync(client.GetStream(), "");

                ProcessRequest(client, requestHeaders);
            }

            catch (ObjectDisposedException)
            {
            }
            catch (AggregateException)
            {

            }

        }

        private async void ProcessRequest(TcpClient client, string requestHeaders)
        {
            var value = new HttpRequestPattern();
            var controller = new Controller(new ExternalDisk(path));
            NetworkStream stream = client.GetStream();

            (Patterns.IMatch match, string remaining) = value.Match(requestHeaders);

            var response = match.Succes
                  ? controller.Process(((HttpRequestMatch)match).Request)
                  : new Response(ResponseTypes.BadRequest) { Body = "Bad Request" };

            if (match.Succes)
            {
                ReportClientStatus(client.Client.RemoteEndPoint.ToString(),
                                   (HttpRequestMatch)match, response.Type.ToString());
            }

            var data = response.Result;

            await stream.WriteAsync(data, 0, data.Length);

        }

        private void ReportClientStatus(string clientIP, HttpRequestMatch match, string response)
        {
            status.ClientIP(clientIP);
            status.Method(match.Request.Method.ToString());
            status.RequestUri(match.Request.Uri.ToString());
            status.ResponseType(response);
        }

        public void Stop()
        {            
            listener.Stop();
        }

        private static async Task<string> ReadHeadersAsync(NetworkStream stream, string previous)
        {
            byte[] bytes = new byte[256];

            int readBytes = await stream.ReadAsync(bytes, 0, bytes.Length);
            var text = Encoding.ASCII.GetString(bytes, 0, readBytes);

            var current = previous + text;

            if (current.Contains("\r\n\r\n") || readBytes <= 0)
            {
                return current;
            }

            return await ReadHeadersAsync(stream, current);
        }

        private void Close(TcpClient client)
        {
            client.Close();
        }

    }
}
