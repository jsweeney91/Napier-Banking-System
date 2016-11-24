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
    public class SMSTests
    {
        [TestMethod()]
        public void SMSTestInvalidID()
        {
            try
            {
                SMS sm = new SMS("S00000021 +447955489198 hello");
                Assert.Fail("MessageID is invalid but was accepted");
            }
            catch (ArgumentException ex)
            {
                return;
            }
        }

        [TestMethod()]
        public void SMSTestInvalidPhoneNo()
        {
            try
            {
                SMS sm = new SMS("S000000021 +44795hj08919 hello");
                Assert.Fail("MessageID is invalid but was accepted");
            }
            catch (ArgumentException ex)
            {
                return;
            }
        }

        [TestMethod()]
        public void SMSTestInvalidCharacterLength()
        {
            try
            {
                SMS sm = new SMS("S000000021 +447950788919 " + string.Concat(Enumerable.Repeat("a", 141)));
                Assert.Fail("Message body is invalid but was accepted");
            }
            catch (ArgumentException ex)
            {
                return;
            }
        }
        [TestMethod()]
        public void SMSTestValid()
        {
            try
            {
                SMS sm = new SMS("S000000021 +447950788919 test data");
                if(sm.sender == "+447950788919"&&sm.messageBody== "test data"&& sm.messageID== "S000000021")
                {
                    return;
                }
                else
                {
                    Assert.Fail("Message data wrong with valid input");
                }
            }
            catch (ArgumentException ex)
            {
                return;
            }
        }
    }
}