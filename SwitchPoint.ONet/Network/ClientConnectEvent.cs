using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Network
{
    class ClientConnectEvent : EventArgs
    {
        ITCPClient ConnectedClient;
        public ClientConnectEvent(ITCPClient Client)
        {
            ConnectedClient = Client;

        }
    }
}
