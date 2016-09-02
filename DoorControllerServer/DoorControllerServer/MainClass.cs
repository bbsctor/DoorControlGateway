using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace DoorControllerServer
{
    class MainClass
    {
        private static int maxRequestHandlers = 5;
        private static int requestHandlerID = 0;
        private static HttpListener listener;
        private static void RequestHandler(IAsyncResult result)
        {
            try
            {
                HttpListenerContext context = listener.EndGetContext(result);
                StreamWriter sw = new StreamWriter(context.Response.OutputStream, Encoding.UTF8);
                //sw.WriteLine("<html><head><title>C# </title>");
                //sw.WriteLine("</head><body>" + result.AsyncState);
                //sw.WriteLine("</body></html>");

                sw.WriteLine("<html><head/><body>");
                sw.WriteLine("{ 'result':[{'result':'0','msg':'success'}],");
                sw.WriteLine("'data':[{'time':'2014-08-16 21:18:13','type':'2','flag':'0','card':'3088997124','person':'lisi','para':'0'},");
                sw.WriteLine("{ 'time':'2014-08-16 18:02:31','type':'3','flag':'0','card':'3942666036','person':'','para':'0'},");
                sw.WriteLine("{ 'time':'2014-08-06 16:58:02','type':'7','flag':'0','card':'','person':'','para':'3'}]}</body></html>");

                sw.Flush();

                context.Response.ContentType = "text/html";
                context.Response.ContentEncoding = Encoding.UTF8;

                context.Response.Close();
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine(result.AsyncState);
            }
            finally
            {
                if (listener.IsListening)
                {
                    listener.BeginGetContext(RequestHandler,
                        "RequestHandler_" + Interlocked.Increment(ref requestHandlerID));
                }
            }
        }

        public static void Main(string[] args)
        {
            using (listener = new HttpListener())
            {
                listener.Prefixes.Add("http://localhost:8080/");
                listener.Start();
                for (int count = 0; count < maxRequestHandlers; count++)
                {
                    listener.BeginGetContext(RequestHandler, "RequestHandler_" +
                        Interlocked.Increment(ref requestHandlerID));
                }
                Console.WriteLine("Press Enter to stop the HTTP Server");
                Console.ReadLine();
                listener.Stop();

                listener.Abort();
            }
        }
    }
}
