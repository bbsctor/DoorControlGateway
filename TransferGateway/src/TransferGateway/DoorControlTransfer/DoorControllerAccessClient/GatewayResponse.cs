using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferGateway.DoorControlTransfer.DoorControllerAccessClient
{
    public class GatewayResponse
    {
        private string response;

        public string Value
        {
            get
            {
                return response;
            }

            set
            {
                response = value;
            }
        }
    }
}
