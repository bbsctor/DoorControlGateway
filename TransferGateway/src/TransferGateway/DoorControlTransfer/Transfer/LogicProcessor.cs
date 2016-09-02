using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferGateway.Framework.Message;
using TransferGateway.Framework;
using TransferGateway.DoorControlTransfer.CommonDataType;
using TransferGateway.DoorControlTransfer.DoorControllerAccessClient;

namespace TransferGateway.DoorControlTransfer.Transfer
{
    class LogicProcessor:ILogicProcessor
    {
        DoorControllerClient controllerClient;

        internal DoorControllerClient ControllerClient
        {
            get
            {
                return controllerClient;
            }

            set
            {
                controllerClient = value;
            }
        }

        public LogicProcessor()
        {
            controllerClient = new DoorControllerClient();
        }

        public void process(CommonRequest request, ref CommonResponse response)
        {
            if(request.Target.Equals("ACEventLoad"))
            {
                GatewayRequest gReq = GatewayMessageConverter.toGatewayRequest(request);
                GatewayResponse gResp = controllerClient.QueryEventInfo(gReq);

                response = GatewayMessageConverter.toCommonResponse(gResp);
            }
        }
    }
}
