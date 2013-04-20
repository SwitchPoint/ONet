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
    public class TCPNetworkProvider : INetworkProvider
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private List<TcpClientAdapter> clients;

        public TCPNetworkProvider(int Port)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, Port);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
            clients = new List<TcpClientAdapter>();
        }

        public List<TcpClientAdapter> ActiveConnections()
        {
            return clients;
        }

        public void Send(string Message)
        {
            foreach (var client in clients)
            {
                
            }

        }

        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClientAdapter client = new TcpClientAdapter(this.tcpListener.AcceptTcpClient());

                if (ClientConnect != null)
                {
                   
                    ClientConnect(this, null);
                }

              
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
                    
              
            }
        }

        public void Stop()
        {
            tcpListener.Stop();
        }

        private void HandleClientComm(object client)
        {
            TcpClientAdapter tcpClient = (TcpClientAdapter)client;

            clients.Add(tcpClient); 

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
