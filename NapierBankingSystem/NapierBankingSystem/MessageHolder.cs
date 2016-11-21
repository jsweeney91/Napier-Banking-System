﻿using System;
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
        private static JSON js = new JSON();
        public static Dictionary<string, Message> messages = new Dictionary<string, Message>();
        public static int currentEmailID;
        public static int currentTwitterID;
        public static int currentSMSID;
        public static string[] incidentTypes = { "Theft","Staff Attack","ATM Theft","Raid","Customer Attack","Staff Abuse","Bomb Threat","Terrorism","Suspicious Incident","Intelligence","Cash Loss"};
        public static MessageRefresher refresher = MessageRefresher.getInstance();
        public static Dictionary<string, string> textspeak = new Dictionary<string, string>();
        public static Dictionary<string, List<string>> mentions = new Dictionary<string, List<String>>();

        public static void readMessages()
        {
            getTextspeak();            
            js.fileName = @"C:\Users\admin\desktop\messages.json";
            messages = js.readJSON();
            setCurrentIDS();
            refresher.numberOfMessages = messages.Count;
        }

        public static void getTextspeak()
        {
            CSVReader r = new CSVReader();
            string path = @"../../Resources/textwords.csv";
            r.fileName = path;
            textspeak = r.readFile();
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
