using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSVWrite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSVWrite.Tests
{
    [TestClass()]
    public class csvWriteTests
    {
        [TestMethod()]
        public void WriteToTest()
        {
            var path = "c://csvfiles//worldcities.csv";
            string writePath = csvWrite.WriteTo(path);
            Assert.IsTrue(File.Exists(writePath));
        }
    }
}