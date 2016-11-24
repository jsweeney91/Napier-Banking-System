using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    public class Tweet : Message
    {
        public string tweetText { get; set; }

        public Tweet(string messageIn)
        {
            Regex re = new Regex(@"(T\d{9}) (@.*?) (.+)");
            Match m = re.Match(messageIn);
            if (m.Success)
            {
                if (validateInput(m.Groups[2].ToString(), m.Groups[3].ToString()))
                {
                    this.messageID = m.Groups[1].ToString();
                    this.sender = m.Groups[2].ToString();
                    this.messageBody = m.Groups[3].ToString();
                }
                else
                {
                    throw new ArgumentException("Invalid tweet message");
                }
            }
            else
            {
                throw new ArgumentException("Invalid Tweet data");
            }
            string[] hashtags = this.messageBody.Split(' ');
            foreach(string h in hashtags)
            {
                if (h.StartsWith("#") || h.StartsWith("@"))
                {
                   string tag = h;
                   if (MessageHolder.mentions.ContainsKey(tag))
                   {
                        if (!MessageHolder.mentions[tag].Contains(this.messageID))
                        {
                            MessageHolder.mentions[tag].Add(this.messageID);
                        }
                   }
                    else
                    {
                        MessageHolder.mentions.Add(tag, new List<String>());
                        MessageHolder.mentions[tag].Add(this.messageID);
                    }                   
                }
            }
        }

        public bool validateInput(string se, string mb)
        {
            if(se.Length<=15 && mb.Length <= 140)
            {
                if (se.StartsWith("@"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override MessageProcessor returnData()
        {
            return new MessageProcessor(this.messageID, this.sender + " " + this.messageBody);
        }
    }
}
