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
    public class MessageProcessorTests
    {
        private TestContext testContextInstance;       
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void convertMessageTestInvalidIDPassedIn_returnNull()
        {
            MessageProcessor mp = new MessageProcessor();
            Message m = mp.convertMessage("P00000001");
            Assert.AreEqual<Message>(null,m);
        }

        [TestMethod()]
        public void GetEmailTypeWithSIREmail()
        {
            MessageProcessor mp = new MessageProcessor();
            Message m = mp.convertMessage("E000000001 jsweeney91@gmail.com SIR 24/10/16       Sort Code: 80-45-32 Nature of Incident: Theft wat");
            if (m is SIR)
            {
                return;
            }
            else
            {
                Assert.Fail("expected: SIR, actual: " + m.GetType());
                
            }
            
           
        }

        [TestMethod()]
        public void GetEmailTypeWithStandardEmail()
        {
            MessageProcessor mp = new MessageProcessor();
            Message m = mp.convertMessage("E000000001 jsweeney91@gmail.com wassup 24/10/16       Sort Code: 80-45-32 Nature of Incident: Theft wat");
            if (m is Email)
            {
                return;
            }
            else
            {
                Assert.Fail("Expected:Email, Actual: " + m.GetType());
            }
        }


        [TestMethod()]
        public void GetSMStypewithValidSMS()
        {
            MessageProcessor mp = new MessageProcessor();
            Message m = mp.convertMessage("S000000001 +447991088919 hi");
            if (m is SMS)
            {
                return;
            }
            else
            {
                Assert.Fail("Expected:SMS Actual: " + m.GetType());
            }
        }


        [TestMethod()]
        public void GetTweettypewithValidTweet()
        {
            MessageProcessor mp = new MessageProcessor();
            Message m = mp.convertMessage("T000000001 @Swan hi");
            if (m is Tweet)
            {
                return;
            }
            else
            {
                Assert.Fail("Expected:Tweet Actual: "+m.GetType());
            }
        }

        [TestMethod()]
        public void addedNewTweetWithHashTags()
        {
            MessageHolder.mentions.Clear();
            MessageProcessor mp = new MessageProcessor();
            Message m = mp.convertMessage("T000000001 @Swan #hi #there");
            if (MessageHolder.mentions.Count==2)
            {
                return;
            }
            else
            {
                Assert.Fail("Expected:2 Actual: "+ MessageHolder.mentions.Count.ToString());
            }
        }


        [TestMethod()]
        public void addedNewTweetWithMentions()
        {
            MessageHolder.mentions.Clear();
            MessageProcessor mp = new MessageProcessor();
            Message m = mp.convertMessage("T000000001 @Swan @myself");
            if (MessageHolder.mentions.Count == 1)
            {
                return;
            }
            else
            {
                Assert.Fail("Expected:1 Actual: " + MessageHolder.mentions.Count.ToString());
            }
        }
    }
}