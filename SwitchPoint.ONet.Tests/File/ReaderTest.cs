using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwitchPoint.ONet.File;


namespace SwitchPoint.ONet.Tests.File
{
    [TestClass]
    public class ReaderTest
    {
        [TestMethod]
        public void ReadAllShouldReadContents()
        {
            String Contents = Reader.ReadAll("File/TestFile1.txt");
            Assert.AreEqual("test123", Contents);
            
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadAllShouldThrowFileNotFoundException()
        {
            String Contents = Reader.ReadAll("File/TestFile0.txt");
            

        }
    }
}
