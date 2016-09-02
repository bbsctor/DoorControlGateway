using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferGateway.DoorControlTransfer.CommonDataType
{
    public class EventInfo
    {
        public string time;  //事件时间
        public string type;               //事件类型
        public string flag;               //门内外标志
        public string card;        //卡号，报警事件中可能为空
        public string person;   //刷卡人姓名
        public string alarmPara;  //报警参数，只在报警事件中有意义
    }
}