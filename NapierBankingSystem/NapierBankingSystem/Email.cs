using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    public class Email : Message
    {
        public string subject { get; set; }

        public Email(string messageIn)
        {
            this.messageID = messageIn.Substring(0, 10);
            messageIn = messageIn.Substring(11);
            this.sender = messageIn.Split(' ')[0];
           // MessageBox.Show(sender);
            this.subject = messageIn.Substring(sender.Length+1,20);
            int size = subject.Length + sender.Length;
            this.messageBody = messageIn.Substring(messageIn.IndexOf(subject)+subject.Length);
            this.seen = false;
            bool hasChanged = true;

            while (hasChanged)
            {
                Regex regex = new Regex(@"\S+\.\S+");
                Match match = regex.Match(this.messageBody);

                if (match.Success)
                {
                    foreach (Match g in match.Groups)
                    {
                        if (MessageHolder.quarantined.ContainsKey(g.ToString())){
                            MessageHolder.quarantined[g.ToString()] = (Convert.ToInt32(MessageHolder.quarantined[g.ToString()]) + 1).ToString();
                        }else
                        {
                            MessageHolder.quarantined.Add(g.ToString(), "1");
                        }
                        MessageHolder.updateQuarantinedItems();
                        this.messageBody = this.messageBody.Replace(g.ToString(), "<<Quarantined Link>>");
                    }
                }
                else
                {
                    hasChanged = false;
                }
            }
          
        }

        public override MessageProcessor returnData()
        {
            return new MessageProcessor(this.messageID, this.sender+ " " + this.subject+ " "+this.messageBody);
        }
    }
}
