using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferGateway.Framework.Message
{
    public class CommonResponse
    {
        Object[] values;

        public object[] Values
        {
            get
            {
                return values;
            }

            set
            {
                values = value;
            }
        }
    }
}
