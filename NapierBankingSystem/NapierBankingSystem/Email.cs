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
            messageIn= messageIn.Replace(Environment.NewLine, " ");
            Regex regex = new Regex(@"(E\d{9}) ([!#$%&'\\*\\+\\-\\/\\=\\?\\^\\_`\\{\\|\\}\\~\\+a-zA-Z0-9\\.]+@.*?[a-zA-Z0-9\\.]+) (.{20}) (.+)");
            Match match = regex.Match(messageIn);
            if (match.Success)
            {
                if(validateInput(match.Groups[2].ToString(), match.Groups[3].ToString(), match.Groups[4].ToString()))
                {
                    this.messageID = match.Groups[1].ToString();
                    this.seen = false;
                    this.sender = match.Groups[2].ToString();
                    this.subject = match.Groups[3].ToString();
                    this.messageBody = match.Groups[4].ToString();
                    bool hasChanged = true;
                    while (hasChanged)
                    {
                        regex = new Regex(@"\S+\.\S+");
                        match = regex.Match(this.messageBody);

                        if (match.Success)
                        {
                            foreach (Match g in match.Groups)
                            {
                                if (MessageHolder.quarantined.ContainsKey(g.ToString()))
                                {
                                    MessageHolder.quarantined[g.ToString()] = (Convert.ToInt32(MessageHolder.quarantined[g.ToString()]) + 1).ToString();
                                }
                                else
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
                
            }
            else
            {                
                throw new ArgumentException("Invalid input");
            }
          
        }
        public bool validateInput(string sender, string subject, string body)
        {
            if(sender.Length>0&&subject.Length==20&&body.Length<1029)
            {
                return true;
            }
            return false;
        }

        public override MessageProcessor returnData()
        {
            return new MessageProcessor(this.messageID, this.sender+ " " + this.subject+ " "+this.messageBody);
        }
    }
}
