using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using TransferGateway.Framework.Message;

namespace TransferGateway.DoorControlTransfer.DoorControllerAccessClient
{
    public class DoorControllerClient
    {
        private static readonly string DefaultUserAgent = 
            @" Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2; Alexa Toolbar; mxie; .NET CLR 1.1.4322)";
        Encoding encoding = Encoding.GetEncoding("utf-8");


        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受   
        }

        //private string doorControllerServerAddr = "127.0.0.1";


        public GatewayResponse QueryEventInfo(GatewayRequest req)
        {
            HttpWebRequest request = createRequest("/goform/ACEventLoad");

            
            byte[] data = encoding.GetBytes(req.Value);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string temp = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            GatewayResponse resp = new GatewayResponse();
            resp.Value = temp;
            return resp;
        }

        private HttpWebRequest createRequest(string target)
        {
            string url = "http://" + /*doorControllerServerAddr*/"localhost" + ":8080" + target;

            HttpWebRequest request = null;
            //HTTPSQ请求
            ServicePointManager.ServerCertificateValidationCallback = null;//new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = DefaultUserAgent;
            request.KeepAlive = false;
            request.UseDefaultCredentials = false;
            request.ServicePoint.Expect100Continue = false;
            ServicePointManager.MaxServicePointIdleTime = 2000;

            return request;
        }
    }
}

