using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferGateway.DoorControlTransfer.PlantFormAccess
{
    public class PlantFormRequest
    {
        private string request;
        public PlantFormRequest(string req)
        {
            this.Value = req;
        }

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
