using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TransferGateway.Framework.Net
{
    public abstract class SocketServer
    {
        protected int port;
        protected IPAddress ip;
        TcpListener listener;
        public IProcessor processor;
        bool is_active = true;

        public SocketServer(IPAddress ip, int port)
        {
            this.port = port;
            this.ip = ip;

        }

        public void listen()
        {
            listener = new TcpListener(ip, port);
            listener.Start();
            while (is_active)
            {
                TcpClient s = listener.AcceptTcpClient();
                processor = createProcessor(s, this);
                Thread thread = new Thread(new ThreadStart(processor.process));
                thread.Start();
                Thread.Sleep(1);
            }
        }

        public virtual IProcessor createProcessor(TcpClient s, SocketServer srv)
        {
            return new SocketProcessor(s, srv);
        }
    }
}
