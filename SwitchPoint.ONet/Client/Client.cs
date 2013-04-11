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


            Host FirstConnection = InitialHosts.GetRandomHost();
            INetworkProvider Provider = new ConnectionManager();

            Provider.ConnectToHost(FirstConnection);

        }
    }
}
