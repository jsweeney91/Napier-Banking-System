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
    public class SIRTests
    {
        [TestMethod()]
        public void SIRTestValidInput()
        {
            try
            {
                SIR sir = new SIR("E000000001 jsweeney91@gmail.com SIR 23/12/16         Sort Code: 32-32-12 Nature of Incident: Suspicious Incident \r\n suspicious activity");

                if (sir.dateReported.ToString("ddMMyy") != "231216")
                {
                    Assert.Fail("wrong date in SIR");
                }
                if (sir.sender!="jsweeney91@gmail.com")
                {
                    Assert.Fail("wrong sender in SIR");
                }
                if (sir.sortCode != "32-32-12")
                {
                    Assert.Fail("wrong Sort code in SIR");
                }
                if (sir.natureOfIncident != "Suspicious Incident") 
                {
                    Assert.Fail("wrong incident type in SIR");
                }
                return;
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }         
        }
        [TestMethod()]
        public void SIRTestInvalidID()
        {
            try
            {
                SIR sir = new SIR("E00000000 jsweeney91@gmail.com SIR 23/12/16         Sort Code: 32-32-12 Nature of Incident: Suspicious Incident \r\n suspicious activity");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                return;
            }
            
        }

        [TestMethod()]
        public void SIRTestInvalidEmail()
        {
            try
            {
                SIR sir = new SIR("E000000001 jsweeney9gmail.com SIR 23/12/16         Sort Code: 32-32-12 Nature of Incident: Suspicious Incident \r\n suspicious activity");

                Assert.Fail("invalid email added");
            }
            catch (Exception ex)
            {
                return;
            }
        }

        [TestMethod()]
        public void SIRTestInvalidDate()
        {
            try
            {
                SIR sir = new SIR("E000000001 jsweeney91@gmail.com SIR wa/sads/ad6         Sort Code: 32-32-12 Nature of Incident: Suspicious Incident \r\n suspicious activity");
                Assert.Fail("invalid sort code added");

            }
            catch (Exception ex)
            {
                return;
            }
            Assert.Fail("invalid date added");
        }

        [TestMethod()]
        public void SIRTestInvalidSortCode()
        {
            try
            {
                SIR sir = new SIR("E000000001 jsweeney91@gmail.com SIR 23/12/16         Sort Code: 3d-32-12 Nature of Incident: Suspicious Incident \r\n suspicious activity");
                Assert.Fail("invalid sort code added");
            }
            catch (Exception ex)
            {
                return;
            }
      
            
        }

        [TestMethod()]
        public void SIRTestInvalidIncidentType()
        {
            try
            {
                SIR sir = new SIR("E000000001 jsweeney91@gmail.com SIR 23/12/16         Sort Code: 32-32-12 Nature of Incident: Suspicious Incident \r\n suspicious activity");
                return;
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }


    }
}