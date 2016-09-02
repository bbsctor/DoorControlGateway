using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferGateway.Framework.Message;

namespace TransferGateway.Framework
{
    interface ILogicProcessor
    {
        void process(CommonRequest request, ref CommonResponse response);
    }
}
