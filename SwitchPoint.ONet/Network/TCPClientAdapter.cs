using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Network
{
    public class TcpClientAdapter: ITCPClient
    {
       private TcpClient wrappedClient;
       public TcpClientAdapter(TcpClient client)
       {
        wrappedClient = client;
       }

       public Stream GetStream()
       {
         return wrappedClient.GetStream();
       }
    }
}
