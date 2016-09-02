using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferGateway.DoorControlTransfer.PlantFormAccess
{
    public class PlantFormEventArgs : EventArgs
    {
        public PlantFormEventArgs(PlantFormRequest req)
        {
            this.request = req;
        }
        private PlantFormRequest request;

        internal PlantFormRequest Request
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
