using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferGateway.DoorControlTransfer.DoorControllerAccessClient
{
    public class GatewayRequest
    {
        private string request;

        public string Value
        {
            get
            {
                return request;
            }

            set
            {
                request = value;
            }
        }
    }
}
