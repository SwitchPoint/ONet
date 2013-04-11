using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Network
{
    public interface INetworkProvider
    {
        void ConnectToHost(String IP, int Port);
    }
}
