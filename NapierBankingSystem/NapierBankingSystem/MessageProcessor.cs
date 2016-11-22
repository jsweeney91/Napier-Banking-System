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

        public Message convertMessage(String messageIn)
        {
            if (messageIn.StartsWith("E"))
            {
                if (getEmailType(messageIn) == "SIR")
                {
                    return new SIR(messageIn);
                }
                else
                {
                    return new Email(messageIn);
                }
            }
            else if (messageIn.StartsWith("S"))
            {
                return new SMS(messageIn);
            }
            else if (messageIn.StartsWith("T"))
            {
                return new Tweet(messageIn);
            }
            else
            {
                MessageBox.Show("Invalid input " + messageIn);
                return null;
            }            
        }


        public Message loadMessage()
        {
            Message msg=convertMessage(this.header + " " + this.body);
            return msg;
        }

        private string getEmailType(string messageIn)
        {
            string messageID = messageIn.Substring(0, 10);
            messageIn = messageIn.Substring(11);
            string sender = messageIn.Split(' ')[0];
            string subject = messageIn.Substring(sender.Length + 1, 20);
            int size = subject.Length + sender.Length;
            if (subject.StartsWith("SIR"))
            {
                return "SIR";
            }
            else
            {
                return "Email";
            }
        }
    }
}
