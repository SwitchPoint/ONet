using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwitchPoint.ONet.Network;
namespace SwitchPoint.ONet.Tests.Network
{
    [TestClass]
    public class NetworkTest
    {
        [TestMethod]
        public void ShouldSplitHostName()
        {
            string Vector = "switchpoint.co.uk:1234";
            Host Host = new Host(Vector);

            Assert.AreEqual("switchpoint.co.uk", Host.HostName);
            Assert.AreEqual(1234, Host.Port);
        }

        [TestMethod]
        public void ShouldSplitIPv4Address()
        {
            string Vector = "172.16.1.1:1234";
            Host Host = new Host(Vector);

            Assert.AreEqual("172.16.1.1", Host.HostName);
            Assert.AreEqual(1234, Host.Port);
        }

        [TestMethod]
        public void ShouldSplitRFC3986IPv6Address()
        {
            string Vector = "[2001:db8::1]:1234";
            Host Host = new Host(Vector);

            Assert.AreEqual("[2001:db8::1]", Host.HostName);
            Assert.AreEqual(1234, Host.Port);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldErrorWithNoPort()
        {
            string Vector = "switchpoint.co.uk";
            Host Host = new Host(Vector);

        }


    }
}
