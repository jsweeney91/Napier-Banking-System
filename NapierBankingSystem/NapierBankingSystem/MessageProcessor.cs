using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    public class MessageProcessor
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

        private Message convertMessage(String messageIn)
        {
            if (messageIn.StartsWith("E"))
            {
                return new Email(messageIn);
            }
            else if (messageIn.StartsWith("S"))
            {
                return new SMS(messageIn);
            }
            else if (messageIn.StartsWith("T"))
            {
                return new Tweet(messageIn);
            }else
            {
                MessageBox.Show("Invalid input "+messageIn);
                return null;
            }            
        }


        public Message loadMessage()
        {
            Message msg=convertMessage(this.header + " " + this.body);
            return msg;
        }
    }
}
