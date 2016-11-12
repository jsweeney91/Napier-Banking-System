using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankingSystem
{
    abstract class Message
    {
        public String messageID { get; set; }
        public String messageBody { get; set; }


    }
}
