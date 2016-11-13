using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankingSystem
{
    class Email : Message
    {
        public string messageText { get; set; }

        public Email(MessageProcessor m)
        {
            this.messageID = m.header;
            this.messageBody = m.body;
            this.messageText = m.body;
        }
        public override MessageProcessor returnData()
        {
            return new MessageProcessor(this.messageID, this.messageBody);
        }
    }
}
