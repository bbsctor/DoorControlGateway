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
    class PlantFormAccessProcessor:SocketProcessor
    {
        private static byte[] result = new byte[1024];
        private IPlantFormHandler handler = null;
        //public event EventHandler<PlantFormEventArgs> HandlePlantFormEvent;
        public PlantFormAccessProcessor(TcpClient s, SocketServer srv, IPlantFormHandler handler)
            :base(s, srv)
        {
            this.handler = handler;
        }

        public override void handleRequest()
        {
            //String response = streamReadLine(inputStream);
            int receiveNumber = inputStream.Read(result, 0, result.Length);
            string recvStr = Encoding.Unicode.GetString(result, 0, receiveNumber);
            PlantFormRequest req = new PlantFormRequest(recvStr);
            //OnRaisePlantFormEvent(new PlantFormEventArgs(req));
            PlantFormResponse resp = null;
            handler.handle(req, ref resp);
            if (resp.Value != null)
            {
                outputStream.Write(resp.Value);
            }

            Console.WriteLine(recvStr);
        }
    }
}
