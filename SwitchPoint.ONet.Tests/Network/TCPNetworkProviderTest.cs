using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using SwitchPoint.ONet.Network;
using System.Net.Sockets;
using System.Net;
using System.Threading; 


namespace SwitchPoint.ONet.Tests.Network
{
    [TestClass]
    public class TCPNetworkProviderTest
    {
        [TestMethod]
        public void SouldRaiseConnectEvent()
        {
            int Port = new Random().Next(5000, 7000);
            bool EventRaised = false;
            AutoResetEvent mutex = new AutoResetEvent(false);

            TCPNetworkProvider Provider = new TCPNetworkProvider(Port);

            Provider.ClientConnect += (object sender, EventArgs e) => { 
                EventRaised = true;
                mutex.Set(); 
            };



            TcpClient client = new TcpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            client.Connect(serverEndPoint);
            mutex.WaitOne();
            client.Close();


            Assert.IsTrue(EventRaised);



            

        }


        [TestMethod]
        public void SouldRaiseMessageEvent()
        {
            AutoResetEvent mutex = new AutoResetEvent(false);
            int Port = new Random().Next(5000, 7000);
            bool EventRaised = false;
            string Message = "Hello";
            string ReceivedMessage = "";

            TCPNetworkProvider Provider = new TCPNetworkProvider(Port);

            Provider.MessageReceived += (object sender, EventArgs e) =>
            {
                Assert.IsInstanceOfType(e, typeof(NetworkMessageEvent));

                EventRaised = true;
                ReceivedMessage = ((NetworkMessageEvent)e).ReceivedMessage();
                mutex.Set(); 
            };



            TcpClient client = new TcpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            client.Connect(serverEndPoint);


            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(Message);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            mutex.WaitOne();
            client.Close();

            Assert.IsTrue(EventRaised);



      


        }

        
    }
}
