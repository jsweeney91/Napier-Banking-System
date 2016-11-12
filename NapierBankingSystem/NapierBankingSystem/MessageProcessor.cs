using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankingSystem
{
    class MessageProcessor
    {
        public string header { get; set; }
        public string body { get; set; }

        public MessageProcessor()
        {
            
        }

        public MessageProcessor(string h, string b)
        {
            this.header = h;
            this.body = b;
        }

        public Message returnMessage()
        {
            Message msg;
            if (this.header.StartsWith("E"))
            {
                msg = new Email(this);               
            }
            else if (this.header.StartsWith("S"))
            {
                msg = new SMS(this);
            }
            else
            {
                msg = new Tweet(this);
            }

            return msg;
        }
    }
}
