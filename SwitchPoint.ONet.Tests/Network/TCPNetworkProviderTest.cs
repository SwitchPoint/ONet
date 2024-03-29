﻿using System;
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
        
        public void ShouldRaiseConnectEvent()
        {
            int Port = new Random().Next(5000, 50000);
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



            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("hi");

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();



            mutex.WaitOne();
            client.Close();

            Provider.Stop();

            Assert.IsTrue(EventRaised);



            

        }

        public void ShouldAddClientToList()
        {
            int Port = new Random().Next(5000, 50000);
            AutoResetEvent mutex = new AutoResetEvent(false);

            TCPNetworkProvider Provider = new TCPNetworkProvider(Port);

            Provider.ClientConnect += (object sender, EventArgs e) =>
            {
               
                mutex.Set();
            };



            TcpClient client = new TcpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            client.Connect(serverEndPoint);



            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("hi");

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();



            mutex.WaitOne();
            client.Close();

            Provider.Stop();

            Assert.AreEqual(1, Provider.ActiveConnections().Count);




        }


        [TestMethod]
        
        public void ShouldRaiseMessageEvent()
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


            Provider.Stop();
            Assert.IsTrue(EventRaised);



      


        }


        [TestMethod]
        
        public void ShouldRaiseReceiveLongMessage()
        {
            AutoResetEvent mutex = new AutoResetEvent(false);
            int Port = new Random().Next(5000, 7000);
            bool EventRaised = false;
            string Message = "";
            string ReceivedMessage = "";


            for (int i = 0; i < 100000; i++)
            {
                Message = Message + "a";
            }



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
            Provider.Stop();
            Assert.IsTrue(EventRaised);






        }

        
    }
}
