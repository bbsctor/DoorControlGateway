using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferGateway.Framework.Message
{
    public class CommonRequest
    {
        public CommonRequest()
        {
            paraDict = new Dictionary<string, string>();
        }
        private string target;
        private Dictionary<string, string> paraDict;

        public string Target
        {
            get
            {
                return target;
            }

            set
            {
                target = value;
            }
        }

        public Dictionary<string, string> ParaDict
        {
            get
            {
                return paraDict;
            }

            set
            {
                paraDict = value;
            }
        }
    }
}