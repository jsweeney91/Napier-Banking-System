using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    class Email : Message
    {
        public string subject { get; set; }

        public Email(string messageIn)
        {
            this.messageID = messageIn.Substring(0, 10);
            messageIn = messageIn.Substring(10, messageIn.Length-10);
            this.sender = messageIn.Split(' ')[1];
            this.subject = messageIn.Substring(sender.Length+2, 20);
            //MessageBox.Show(subject);
            int size = subject.Length + sender.Length;
            this.messageBody = messageIn.Substring(size,messageIn.Length-size);
        }

        public override MessageProcessor returnData()
        {
            return new MessageProcessor(this.messageID, this.sender+ " " + this.subject+ " "+this.messageBody);
        }
    }
}
