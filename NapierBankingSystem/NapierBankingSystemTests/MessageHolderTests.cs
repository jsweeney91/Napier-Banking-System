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
    public class MessageHolderTests
    {
        [TestMethod()]
        public void setCurrentIDSTest()
        {
            MessageHolder.messages.Add("S000000001", new SMS("S000000001 +447855314525 hello"));
            MessageHolder.messages.Add("E000000001", new Email("E000000001 jswee1@gmail.com test                subject"));
            MessageHolder.messages.Add("T000000003", new Tweet("T000000001 @swan hello"));

            MessageHolder.setCurrentIDS();

            if (MessageHolder.currentEmailID != 1)
            {
                Assert.Fail("Failed at email");
            }
            if (MessageHolder.currentSMSID != 1)
            {
                Assert.Fail("Failed at sms");
            }
            if (MessageHolder.currentTwitterID != 3)
            {
                Assert.Fail("Failed at tweet");
            }

        }
    }
}