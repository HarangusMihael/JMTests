using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    public interface IStatus
    {
        void ReportError(string message);
        void ClientIP(string client);
        void Method(string client);
        void RequestUri(string client);
        void ResponseType(string responseType);
    }
}
