using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    public class SMS : Message
    {
        public SMS(String messageIn)
        {
            this.messageID = messageIn.Substring(0, 10);
            this.sender = messageIn.Substring(messageID.Length+1, 13);
            this.messageBody = messageIn.Substring(25,messageIn.Length-25);
            this.seen = false;
        }

        public override MessageProcessor returnData()
        {
            return new MessageProcessor(this.messageID, this.sender + " " + this.messageBody);
        }       
    }
}
