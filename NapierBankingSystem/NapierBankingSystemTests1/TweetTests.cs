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
    public class TweetTests
    {
        [TestMethod()]
        public void TweetTestValidInput()
        {
            Tweet t = new Tweet("T000000001 @swan hello");
            if (t.messageID == "T000000001" && t.sender == "@swan" && t.messageBody == "hello")
            {
                return;
            }
            else
            {
                Assert.Fail("Data doesn't match input data");
            }
        }

        [TestMethod()]
        public void tweetTestInvalidHandle()
        {
            try
            {
                Tweet t = new Tweet("T000000001 swan hello");
                Assert.Fail("Invalid handle added");
            }
            catch(ArgumentException ex)
            {
                return;
            }
        }

        [TestMethod()]
        public void tweetTestInvalidHandleTooLong()
        {
            try
            {
                Tweet t = new Tweet("T000000001 @aaaaaaaaaaaaaaaaa hello");
                Assert.Fail("Invalid handle added");
            }
            catch (ArgumentException ex)
            {
                return;
            }
        }

        [TestMethod()]
        public void tweetTestInvalidID()
        {
            try
            {
                Tweet t = new Tweet("T00000000 @aaaaaa hello");
                Assert.Fail("Invalid id added");
            }
            catch (ArgumentException ex)
            {
                return;
            }
        }

        [TestMethod()]
        public void tweetTestHashtagAdded()
        {
            MessageHolder.mentions.Clear();
            Tweet t = new Tweet("T000000001 @aaaaaa #hello #there");
            Assert.AreEqual(2, MessageHolder.mentions.Count);
        }

        [TestMethod()]
        public void tweetDuplicateHashtagAdded()
        {
            MessageHolder.mentions.Clear();
            Tweet t = new Tweet("T000000001 @aaaaaa #hello");
            Tweet t2 = new Tweet("T000000002 @aaaaaa #hello");
            Assert.AreEqual(2, MessageHolder.mentions["#hello"].Count);            
        }

        [TestMethod()]
        public void userMentionAddedinTweet()
        {
            MessageHolder.mentions.Clear();
            Tweet t = new Tweet("T000000001 @aaaaaa @swan");
            Assert.AreEqual(true, MessageHolder.mentions.ContainsKey("@swan"));
        }
    }
}

