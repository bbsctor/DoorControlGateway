using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferGateway.DoorControlTransfer.PlantFormAccess
{
    interface IPlantFormHandler
    {
        void handle(PlantFormRequest req,ref PlantFormResponse resp);
    }
}
