using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    public class SMS : Message
    {
        public SMS(String messageIn)
        {
            Regex re = new Regex(@"(S\d{9}) (\+[0-9]+) (.+)");
            Match m = re.Match(messageIn);
            if (m.Success)
            {
                if (m.Groups[2].ToString().Length> 11 && m.Groups[2].ToString().Length < 16 && m.Groups[3].ToString().Length<140)
                {
                    this.messageID = m.Groups[1].ToString();
                    this.sender = m.Groups[2].ToString();                   
                    this.messageBody = m.Groups[3].ToString();
                }
                else
                {
                    throw new ArgumentException("Invalid input for SMS");
                }

            }
            else
            {
                throw new ArgumentException("Invalid input for SMS");
            }
        }

        public override MessageProcessor returnData()
        {
            return new MessageProcessor(this.messageID, this.sender + " " + this.messageBody);
        }       
    }
}
