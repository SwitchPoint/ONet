using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Network
{
    public class NetworkMessageEvent : EventArgs
    {
        string Message;
        public NetworkMessageEvent(string Message)
        {
            this.Message = Message;
        }

        public string ReceivedMessage()
        {
            return Message;
        }
    }
}
