﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NapierBankingSystem
{
    /// <summary>
    /// Interaction logic for SendTweet.xaml
    /// </summary>
    public partial class SendTweet : Page
    {
        public SendTweet()
        {
            InitializeComponent();
        }

        //used to add new Tweet messages
        //NOTE: this will use the same string format for receiving messages as decribed in initial specification
        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput())
            {
                string currentID = (MessageHolder.currentTwitterID + 1).ToString();
                if (currentID.Length < 9)
                {
                    string zeros = String.Concat(Enumerable.Repeat("0", 9 - currentID.Length));
                    currentID = zeros + currentID;
                    
                }
                currentID = "T" + currentID;

                Tweet tweet = new Tweet(currentID +" "+twitterHandleTextbox.Text+" "+messageTextbox.Text);
                MessageHolder.currentTwitterID++;
                MessageHolder.addMessage(currentID, tweet);
                
            }
        }

        //validates the textboxes to ensure format meets the specification described in the
        //initial documentation
        private bool validateInput()
        {
            errorLbl.Content = "";
            bool canAdd = true;
            if (twitterHandleTextbox.Text.StartsWith("@")) //all twitter handles start with "@"
            {
                if (twitterHandleTextbox.Text.Length > 15 || String.IsNullOrEmpty(twitterHandleTextbox.Text))
                {
                    errorLbl.Content += "Twitter handle be between 0 and 15 characters "+Environment.NewLine;
                    canAdd = false;
                }
            }
            else
            {
                errorLbl.Content += "Twitter handles must start with @ "+Environment.NewLine;
                canAdd = false;
            }
            if (messageTextbox.Text.Length > 140 || String.IsNullOrEmpty(messageTextbox.Text)) 
            {
                errorLbl.Content += "Message cant be more than 140 characters "+Environment.NewLine;
                canAdd = false;
            }
            return canAdd;
            
        }
    }
}
