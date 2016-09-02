using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using TransferGateway.DoorControlTransfer.PlantFormAccess;
using TransferGateway.Framework.Message;

namespace TransferGateway.DoorControlTransfer.Transfer
{
    class MainServer:IPlantFormHandler
    {
        private PlantFormAccessServer plantServer;
        private LogicProcessor logicProcessor;

        public void init()
        {
            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            plantServer = new PlantFormAccessServer(ip, 8500, this);
            logicProcessor = new LogicProcessor();
        }

        public void start()
        {
            plantServer.listen();
        }

        public void handle(PlantFormRequest req, ref PlantFormResponse resp)
        {
            CommonRequest commomReq = PlantFormMessageConverter.toCommonRequest(req);
            CommonResponse commResp = null;

            logicProcessor.process(commomReq, ref commResp);
            resp = PlantFormMessageConverter.toPlantFormResponse(commResp);

            Console.WriteLine(" received this message: {0}", resp.Value);
        }
    }
}
