using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    class SIR : Email
    {
        public SIR(string messageIn) : base(messageIn)
        {
            MessageBox.Show(this.messageID);
        }
    }
}
