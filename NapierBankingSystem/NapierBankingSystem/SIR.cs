using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    class SIR : Email
    {
        DateTime reportDate;
        string natureOfIncident;
        string sortCode;
        public SIR(string messageIn) : base(messageIn)
        {
            DateTime.TryParse(this.subject.Substring(4, 8),out this.reportDate);
            Regex regex = new Regex(@"Sort Code: ([0-9-]+)");
            Match match = regex.Match(messageIn);
            MessageBox.Show(messageIn);
            if (match.Success)
            {
                this.sortCode = match.Groups[1].Value;
            }

            regex = new Regex(@"Nature of Incident: (.+)");
            match = regex.Match(messageIn);
            if (match.Success)
            {
                string nature = match.Groups[1].ToString();
                foreach(string n in MessageHolder.incidentTypes)
                {
                    if (nature.StartsWith(n))
                    {
                        this.natureOfIncident = n;
                        break;
                    }
                }
            }
        }
    }
}
