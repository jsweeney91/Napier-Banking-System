using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankingSystem
{
    //used with the message refresher for new message notifications
    public interface Observer
    {
        void receiveNotification();
    }
    
}
