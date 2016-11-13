using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankingSystem
{
    class SMS : Message
    {
        public string messageText;

        public SMS(MessageProcessor m)
        {
            this.sender = m.header.Substring(1, m.header.Length-1);
            this.messageBody = m.body;
            this.messageID = m.header;
            this.messageText = m.body;
        }
        public override MessageProcessor returnData()
        {
            return new MessageProcessor(this.messageID, this.messageBody);
        }       
    }
}
