using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankingSystem
{
    public abstract class Message
    {
        public string messageID { get; set; }
        public string messageBody { get; set; }
        public string sender { get; set; }

        public abstract MessageProcessor returnData();


    }
}
