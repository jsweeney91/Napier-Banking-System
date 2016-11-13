using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    class Tweet : Message
    {
        public string tweetText { get; set; }

        public Tweet(string messageIn)
        {
            this.messageID = messageIn.Substring(0, 10);
            this.sender = messageIn.Substring(messageID.Length,messageIn.Length-messageID.Length).Split(' ')[1];
            this.messageBody = messageIn.Substring((messageID.Length + sender.Length+1), messageIn.Length-(messageID.Length + sender.Length+1));            
        }

        public override MessageProcessor returnData()
        {
            return new MessageProcessor(this.messageID, this.sender + " " + this.messageBody);
        }
    }
}
