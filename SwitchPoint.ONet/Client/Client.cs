using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwitchPoint.ONet.Network;

namespace SwitchPoint.ONet.Client
{
    class Client
    {
        public Client()
        {
            String HostsFileLocation = "";
            IHostProvider InitialHosts = new InitialHosts(HostsFileLocation);
            INetworkProvider Provider = new ConnectionManager();

            MakeFirstConnection(InitialHosts,Provider);

        }

        private void MakeFirstConnection(IHostProvider InitialHosts, INetworkProvider Provider)
        {
            Host FirstConnection = InitialHosts.GetRandomHost();
            Provider.ConnectToHost(FirstConnection);
        }
    }
}
