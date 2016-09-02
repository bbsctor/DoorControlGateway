using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferGateway.Framework.Net;
using System.Net;
using System.Net.Sockets;

namespace TransferGateway.DoorControlTransfer.PlantFormAccess
{
    class PlantFormAccessServer:SocketServer
    {
        private IPlantFormHandler handler = null;
        public PlantFormAccessServer(IPAddress ip, int port, IPlantFormHandler handler)
            :base(ip, port)
        {
            this.handler = handler;
        }

        public override IProcessor createProcessor(TcpClient s, SocketServer srv)
        {
            return new PlantFormAccessProcessor(s, srv, handler);
        }
    }
}
