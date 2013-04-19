using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Network
{
    class TCPNetworkProvider : INetworkProvider
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        public TCPNetworkProvider()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 3000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();

                if (ClientConnect != null)
                {
                   
                    ClientConnect(this, null);
                }
                
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();

                if (MessageReceived != null)
                {
                    MessageReceived(this, new NetworkMessageEvent(encoder.GetString(message, 0, bytesRead)));
                }
            }

            tcpClient.Close();
        }

        public void ConnectToHost(Host Host)
        {
            
        }

        public event EventHandler ClientConnect;

        public event EventHandler ClientDisconnect;

        public event EventHandler MessageReceived;
    }
}
