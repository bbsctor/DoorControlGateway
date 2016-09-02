using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferGateway.DoorControlTransfer.Transfer;

namespace TransferGateway
{
    class Program
    {
        static void Main(string[] args)
        {
            MainServer mainServer = new MainServer();
            mainServer.init();
            mainServer.start();
        }
    }
}
