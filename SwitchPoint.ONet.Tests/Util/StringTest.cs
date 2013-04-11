using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwitchPoint.ONet.Util;
namespace SwitchPoint.ONet.Tests.Util
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void ShouldSplitUnixEndings()
        {
            String input = "a\nb";
            Assert.AreEqual(2, StringUtils.SplitNewLines(input).Length);
            Assert.AreEqual("a", StringUtils.SplitNewLines(input)[0]);
            Assert.AreEqual("b", StringUtils.SplitNewLines(input)[1]);
        }

        [TestMethod]
        public void ShouldSplitWindowsEndings()
        {
            String input = "a\r\nb";
            Assert.AreEqual(2, StringUtils.SplitNewLines(input).Length);
            Assert.AreEqual("a", StringUtils.SplitNewLines(input)[0]);
            Assert.AreEqual("b", StringUtils.SplitNewLines(input)[1]);
        }
    }
}
