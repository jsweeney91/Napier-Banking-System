using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    public static class MessageHolder
    {
        private static JSON js = new JSON();
        public static Dictionary<string, Message> messages;
        public static int currentEmailID;
        public static int currentTwitterID;
        public static int currentSMSID;
        public static string[] incidentTypes = { "Theft","Staff Attack","ATM Theft","Raid","Customer Attack","Staff Abuse","Bomb Threat","Terrorism","Suspicious Incident","Intelligence","Cash Loss"};

        public static void readMessages()
        {
            js.fileName = @"C:\Users\admin\desktop\messages.json";
            messages = js.readJSON();
            setCurrentIDS();
        }

        public static void addMessage(string id, Message m)
        {
            messages.Add(id, m);
            js.writeData();
            setCurrentIDS();
        }

        public static void setCurrentIDS()
        {
            foreach (string s in messages.Keys)
            {
                int tempVal;
                Int32.TryParse(s.Substring(1, 9), out tempVal);
                if (s.StartsWith("E"))
                {
                    if (tempVal > currentEmailID)
                    {
                        currentEmailID = tempVal;
                    }
                }
                else if (s.StartsWith("S"))
                {
                    if (tempVal > currentSMSID)
                    {
                        currentSMSID = tempVal;
                    }
                }
                else if (s.StartsWith("T"))
                {
                    if (tempVal > currentTwitterID)
                    {
                        currentTwitterID = tempVal;
                    }
                }
            }
        }
    }
}
