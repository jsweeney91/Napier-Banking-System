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
    public class EmailTests
    {

        [TestMethod()]
        public void EmailTestwithValidInput()
        {
            try
            {
                Email em = new Email("E000000020 jsweeney91@gmail.com hi                   hello");
                if(em.messageID == "E000000020"&&em.sender== "jsweeney91@gmail.com"&&em.subject== "hi                  "&& em.messageBody == "hello")
                {
                    return;
                }
            }catch(ArgumentException ex)
            {
                Assert.Fail("Input appears to be invalid");
            }
        }

        [TestMethod()]
        public void EmailTestwithInvalidMessageID()
        {
            try
            {
                Email em = new Email("E00000000 jsweeney91@gmail.com hi                   hello");
                Assert.Fail("Input should be invalid");
            }
            catch (ArgumentException ex)
            {
                return;
            }
        }

        [TestMethod()]
        public void EmailTestwithInvalidEmail()
        {
            try
            {
                Email em = new Email("E000000001 jsweeney91gmail.com hi                   hello");
                Assert.Fail("Input should be invalid");
            }
            catch (ArgumentException ex)
            {
                return;
            }
        }

        [TestMethod()]
        public void EmailTestwithInvalidsubject()
        {
            try
            {
                Email em = new Email("E000000001 jsweeney91@gmail.com ");
                Assert.Fail("Input should be invalid");
            }
            catch (ArgumentException ex)
            {
                return;
            }
        }

        [TestMethod()]
        public void emailValidateInputwithinvalidEmailLength()
        {
            try
            {
                Email em = new Email("E000000001 jsweeney91@gmail.com hi                   hello");
                Assert.AreEqual(false, em.validateInput("","                   ","test"));
                
            }
            catch (ArgumentException ex)
            {
                Assert.Fail(ex.ToString());
                return;
            }
        }

        [TestMethod()]
        public void emailValidateInputwithinvalidSubjectLength()
        {
            try
            {
                Email em = new Email("E000000001 jsweeney91@gmail.com hi                   hello");
                Assert.AreEqual(false, em.validateInput("js@js.com", "                 ", "test"));

            }
            catch (ArgumentException ex)
            {
                Assert.Fail(ex.ToString());
                return;
            }
        }

        [TestMethod()]
        public void emailValidateInputwithbodyBodyLength()
        {
            try
            {
                Email em = new Email("E000000001 jsweeney91@gmail.com hi                   hello");
                Assert.AreEqual(false, em.validateInput("jsweeney91@gmail.com", "                    ", string.Concat(Enumerable.Repeat(" ", 1030))));

            }
            catch (ArgumentException ex)
            {
                Assert.Fail(ex.ToString());
                return;
            }
        }

        [TestMethod()]
        public void emailValidateInputwithValidValues()
        {
            try
            {
                Email em = new Email("E000000001 jsweeney91@gmail.com hi                   hello");
                Assert.AreEqual(true, em.validateInput("jsweeney91@gmail.com", "                    ", string.Concat(Enumerable.Repeat(" ", 1028))));

            }
            catch (ArgumentException ex)
            {
                Assert.Fail(ex.ToString());
                return;
            }
        }

    }
}