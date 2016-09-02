using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TransferGateway.DoorControlTransfer.CommonDataType;

namespace TransferGateway.DoorControlTransfer.DoorControllerAccessClient
{
    public class JsonHandle
    {
        private static string pattern = "(?<=<(body)\\s*[^>]*>).*(?=</\\1\\s*>)";
        private string jsonArrayText = "";       //放入文本中？？？

        //private static string test = "<html><body>{\"result\":[{\"result\":\"0\",\"msg\":\"success\"}],\"data\":[{\"time\":\"2016-05-19 09:18:46\",\"type\":\"2\",\"flag\":\"0\",\"card\":\"3088997124\",\"person\":\"lisi\",\"para\":\"0\"},{\"time\":\"2016-05-19 20:35:21\",\"type\":\"2\",\"flag\":\"0\",\"card\":\"3088997125\",\"person\":\"huying\",\"para\":\"0\"}]}</body></html>";

        JObject outJO = null;           //最外层数据目标
        JArray resultJA = null;         //请求处理结果数组
        JObject resultJO = null;        //请求结果对象
        JArray dataJA = null;           //返回的数据数组
        JObject dataJO = null;          //返回的数据对象

        public JsonHandle()
        {

        }

        public JsonHandle(string html)
        {
            jsonArrayText = html;
        }

        public string getEventInfo(ref EventInfo[] dataInfo)
        {
            if (!String.IsNullOrEmpty(jsonArrayText))
            {
                outJO = (JObject)JsonConvert.DeserializeObject(jsonArrayText);
                resultJA = JArray.Parse(outJO["result"].ToString());
                resultJO = (JObject)resultJA[0];
                if (resultJO["result"].ToString() != "0")           //返回结果不成功
                {
                    string faileMsg = resultJO["msg"].ToString();
                    //失败信息写入日志文件
                    return faileMsg;
                }

                dataJA = JArray.Parse(outJO["data"].ToString());
                Array.Resize(ref dataInfo, dataJA.Count);
                int index = 0;
                foreach (var data in dataJA)
                {
                    dataJO = (JObject)data;
                    dataInfo[index] = new EventInfo();
                    dataInfo[index].time = dataJO["time"].ToString();
                    dataInfo[index].type = dataJO["type"].ToString();
                    dataInfo[index].flag = dataJO["flag"].ToString();
                    dataInfo[index].card = dataJO["card"].ToString();
                    dataInfo[index].person = dataJO["person"].ToString();
                    dataInfo[index].alarmPara = dataJO["para"].ToString();
                    index++;
                }
                return "success";
            }
            return "failed";
        }
    }
}