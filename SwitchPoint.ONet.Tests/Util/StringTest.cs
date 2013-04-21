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

        [TestMethod]
        public void ShouldNotSplitWhenNoLineEndings()
        {
            String input = "a";
            Assert.AreEqual(1, StringUtils.SplitNewLines(input).Length);
            Assert.AreEqual("a", StringUtils.SplitNewLines(input)[0]);
            
        }

        [TestMethod]
        public void ShouldStillSplitBlankLines()
        {
            String input = "a\n";
            Assert.AreEqual(2, StringUtils.SplitNewLines(input).Length);
            Assert.AreEqual("a", StringUtils.SplitNewLines(input)[0]);
            Assert.AreEqual("", StringUtils.SplitNewLines(input)[1]);
        }

        [TestMethod]
        public void ShouldExtractRandomValueFromStringArray()
        {
            Random rand = new Random();
            String[] input = new String[] { "a", "b", "c" };
            int randomNumber = rand.Next(input.Length-1);

            IRandomGenerator generator = new SimpleRandomGeneratorMock(randomNumber);


            Assert.AreEqual(input[randomNumber], StringUtils.PickRandom(input));

        }

    }
}
