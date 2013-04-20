using System;
using System.Collections.Generic;

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

        public NetworkStream GetStream()
        {
            return wrappedClient.GetStream();
        }

        public void Close()
        {
            wrappedClient.Close();
        }


        public void Send(string Message)
        {
            NetworkStream clientStream = wrappedClient.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(Message);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }
    }
}
