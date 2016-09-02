using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferGateway.Framework.Message;
using TransferGateway.DoorControlTransfer.PlantFormAccess;
using TransferGateway.DoorControlTransfer.CommonDataType;

namespace TransferGateway.DoorControlTransfer.Transfer
{
    public class PlantFormMessageConverter
    {
        public static CommonRequest toCommonRequest(PlantFormRequest platFormReq)
        {
            CommonRequest req = new CommonRequest();
            req.Target = "ACEventLoad";
            req.ParaDict.Add("doorID", "5");
            req.ParaDict.Add("num", "20");
            return req;
        }

        public static PlantFormResponse toPlantFormResponse(CommonResponse commResp)
        {
            StringBuilder sb = new StringBuilder();
            EventInfo temp = null;
            for (int i = 0; i < commResp.Values.Length; i++)
            {
                temp = (EventInfo)commResp.Values[i];
                sb.AppendLine(temp.alarmPara + " " + temp.card + " " + temp.flag + " " + temp.person + " " + temp.time + " " + temp.type);
            }

            return new PlantFormResponse(sb.ToString());
        }
    }
}
