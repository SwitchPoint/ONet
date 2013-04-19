using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Network
{
    class ConnectionManager : INetworkProvider
    {
        public void ConnectToHost(Host Host)
        {
            throw new NotImplementedException();
        }

        public event EventHandler ClientConnect;

        public event EventHandler ClientDisconnect;

        public event EventHandler MessageReceived;
    }
}
