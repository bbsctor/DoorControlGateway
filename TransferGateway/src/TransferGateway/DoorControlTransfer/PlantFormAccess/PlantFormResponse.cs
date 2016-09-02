using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferGateway.DoorControlTransfer.PlantFormAccess
{
    public class PlantFormResponse
    {
        private string response;
        public PlantFormResponse(string resp)
        {
            this.Value = resp;
        }

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