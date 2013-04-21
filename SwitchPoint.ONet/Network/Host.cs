using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Network
{
    public class Host
    {
        public String HostName { get; set; }
        public int Port { get; set; }


        public Host(String HostName)
        {
            int colonIndex = HostName.LastIndexOf(':');
            if (colonIndex == -1)
            {
                throw new ArgumentException("Invalid host:port format");
            }
            this.HostName = HostName.Substring(0, colonIndex);
            Port = int.Parse(HostName.Substring(colonIndex + 1));
        }

        public IPAddress Resolve()
        {
            IPHostEntry hostEntry;

            hostEntry = Dns.GetHostEntry(HostName);

            if (hostEntry.AddressList.Length > 0)
            {
                return hostEntry.AddressList[0];
            }

            throw new ArgumentException("Cannot Resolve Host");

            
        }

        public IPEndPoint Endpoint()
        {
            try
            {
                return new IPEndPoint(IPAddress.Parse(HostName), Port);
            }
            catch (FormatException ex)
            {
                return new IPEndPoint(Resolve(), Port);
            }
        }
    }
}
