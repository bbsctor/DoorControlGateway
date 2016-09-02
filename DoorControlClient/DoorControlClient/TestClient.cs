using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace DoorControl
{
    class TestClient
    {
        private static byte[] result = new byte[1024];
        static void Main(string[] args)
        {

            //Console.WriteLine("Client Running ...");
            //TcpClient client;

            //try
            //{
            //    client = new TcpClient();
            //    client.Connect("localhost", 8500);      // 与服务器连接
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
            //// 打印连接到的服务端信息
            //Console.WriteLine("Server Connected！{0} --> {1}",
            //    client.Client.LocalEndPoint, client.Client.RemoteEndPoint);

            //string msg = "\"Welcome To TraceFact.Net\"";
            //NetworkStream streamToServer = client.GetStream();

            //byte[] buffer = Encoding.Unicode.GetBytes(msg);     // 获得缓存
            //streamToServer.Write(buffer, 0, buffer.Length);     // 发往服务器
            //Console.WriteLine("Sent: {0}", msg);

            //IPAddress ipAddress = IPAddress.Any;
            //TcpListener tcpListener = new TcpListener(ipAddress, 9999);
            //tcpListener.Start();

            //TcpClient tcpClient = tcpListener.AcceptTcpClient();


            //NetworkStream ns = tcpClient.GetStream();

            //StreamReader sr = new StreamReader(ns);

            //string result = sr.ReadToEnd();
            //Console.WriteLine("Receive: {0}", result);

            //// 按Q退出
            //Console.ReadLine();

            //设定服务器IP地址
            
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 8500)); //配置服务器IP与端口
                Console.WriteLine("连接服务器成功");
            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                return;
            }
            

            string sendMessage = "client send Message Hellp" + DateTime.Now;
            clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
            Console.WriteLine("向服务器发送消息：{0}" + sendMessage);
               
            int receiveLength = clientSocket.Receive(result);
            Console.WriteLine("接收服务器消息：{0}", Encoding.ASCII.GetString(result, 0, receiveLength));
            Console.ReadLine();
        }
    }
}
