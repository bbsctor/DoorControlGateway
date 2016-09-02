using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Filters;
using TransferGateway.Framework.Message;
using TransferGateway.DoorControlTransfer.DoorControllerAccessClient;
using TransferGateway.DoorControlTransfer.CommonDataType;

namespace TransferGateway.DoorControlTransfer.Transfer
{
    public class GatewayMessageConverter
    {
        public static GatewayRequest toGatewayRequest(CommonRequest commReq)
        {
            GatewayRequest req = new GatewayRequest();
            req.Value = buildHttpStr(commReq);
            return req;
        }

        public static CommonResponse toCommonResponse(GatewayResponse gatewayResp)
        {
            CommonResponse resp = new CommonResponse();
            string jsonStr = parseJson(gatewayResp.Value);
            JsonHandle json = new JsonHandle(jsonStr);
            EventInfo[] result = new EventInfo[0];
            string isSuccess = json.getEventInfo(ref result);

            if (isSuccess.Equals("success"))
            {
                resp.Values = result;
            }
            
            return resp;
        }

        public static string parseJson(string htmlText)
        {
            string result = null;
            Lexer lexer = new Lexer(htmlText);
            Parser parser = new Parser(lexer);
            NodeFilter body = new TagNameFilter("body");
            NodeList htmlNodes = parser.Parse(body);
            for (int i = 0; i < htmlNodes.Count; i++)
            {
                if (htmlNodes[i].GetText() != null)
                {
                    Console.WriteLine(htmlNodes[i].FirstChild.ToPlainTextString());
                    result = htmlNodes[i].FirstChild.ToPlainTextString();
                    break;
                }
            }
            return result;
        }

        private static string buildHttpStr(CommonRequest req)
        {
            string result = null;
            if (!(req.ParaDict == null || req.ParaDict.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in req.ParaDict.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, req.ParaDict[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, req.ParaDict[key]);
                    }
                    i++;
                }
                result = buffer.ToString();
            }
            return result;
        }
    }
}
