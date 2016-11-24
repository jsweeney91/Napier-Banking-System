using Microsoft.VisualStudio.TestTools.UnitTesting;
using NapierBankingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankingSystem.Tests
{
    [TestClass()]
    public class CSVReaderTests
    {
        [TestMethod()]
        public void readFileTestwithInvalidData()
        {
            CSVReader c = new CSVReader();
            c.isTesting = true;
            Dictionary<string,string> output = c.readFile("../../../testData/CSVInvalid.txt");
            Assert.AreEqual(0, output.Count);
        }

        [TestMethod()]
        public void readFileTestwithValidData()
        {
            CSVReader c = new CSVReader();
            c.isTesting = true;
            Dictionary<string, string> output = c.readFile("../../../testData/validDataTestCSV.csv");
            bool pass = true;
            if (output.Count  != 2)
            {
                pass = false;
            }else if (output["test1"] == "value1")
            {
                Assert.AreEqual("value2", output["test2"]);
            }
        }
    }
}