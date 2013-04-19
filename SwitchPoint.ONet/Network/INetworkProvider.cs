using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Network
{
    public interface INetworkProvider
    {
        event EventHandler ClientConnect;
        event EventHandler ClientDisconnect;
        event EventHandler MessageReceived;

        void ConnectToHost(Host Host);
    }
}
