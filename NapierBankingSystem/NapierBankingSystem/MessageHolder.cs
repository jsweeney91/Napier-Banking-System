using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankingSystem
{
    public static class MessageHolder
    {
        private static JSON js = new JSON();
        public static List<Message> messages;

        public static void readMessages()
        {
            js.fileName = @"C:\Users\admin\desktop\messages.json";
            messages = js.readJSON();
        }
    }
}
