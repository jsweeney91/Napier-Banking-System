using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace NapierBankingSystem
{
    public static class MessageHolder
    {
        private static JSON js = new JSON(); //json reader object
        public static Dictionary<string, Message> messages = new Dictionary<string, Message>(); //holds all the messages for the application, messageID is the key
        public static int currentEmailID; //current highest email id, used for incrementing on new messages being input
        public static int currentTwitterID; //current highest twitter id, used for incrementing on new messages being input
        public static int currentSMSID; //current highest SMS id, used for incrementing on new messages being input

        //different incident types for SIR emails(may require updating if new incident types arise)
        public static string[] incidentTypes = { "Theft","Staff Attack","ATM Theft","Raid","Customer Attack","Staff Abuse","Bomb Threat","Terrorism","Suspicious Incident","Intelligence","Cash Loss"}; 
        public static MessageRefresher refresher = MessageRefresher.getInstance(); //loop checks for new messages
        public static Dictionary<string, string> textspeak = new Dictionary<string, string>(); //abbreviation dictionary
        public static Dictionary<string, string> quarantined = new Dictionary<string, string>(); //quarantined URLs
        public static Dictionary<string, List<string>> mentions = new Dictionary<string, List<String>>(); //mentions is tweets
        public static CSVReader r = new CSVReader();

        //populates the variables in this class when the application starts
        public static void readMessages()
        {
            getTextspeak();
            getQuarantinedItems();
            js.fileName = Properties.Settings.Default.JSONFile;
            messages = js.readJSON();
            setCurrentIDS();
            refresher.numberOfMessages = messages.Count;
        }

        public static void getTextspeak()
        {
            string path = Properties.Settings.Default.Textwords;
            textspeak = r.readFile(path);
        }

        public static void updateTextspeak()
        {
            string path = Properties.Settings.Default.Textwords;
            r.overwriteFile(path,textspeak);
        }

        public static void getQuarantinedItems()
        {
            string path = Properties.Settings.Default.Quarantined;
            quarantined = r.readFile(path);
        }

        public static void updateQuarantinedItems()
        {
            string path = Properties.Settings.Default.Quarantined;
            r.overwriteFile(path,quarantined);
        }

        //when new messages are added use this method
        /// <param name="id">new message id to add to the dictionary</param>
        /// <param name="m">message data to be added</param>
        public static void addMessage(string id, Message m)
        {
            messages.Add(id, m);
            js.writeData();
            setCurrentIDS(); //increments the ids
        }

        //gets the current highest id used for emails, sms and tweets 
        //used to maintain unique references for messages
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
