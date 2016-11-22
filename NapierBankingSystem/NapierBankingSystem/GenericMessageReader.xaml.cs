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
    /// Interaction logic for GenericMessageReader.xaml
    /// </summary>
    public partial class GenericMessageReader : Page
    {
        public GenericMessageReader(Message m)
        {
            InitializeComponent();
            loadContent(m);
        }
        public void loadContent(Message m)
        {
            if (m is SIR)
            {
                SIR message = (SIR)m;
                messageLabel.Content += "Sender: ";
                messageLabel.Content += message.sender + "\n";
                messageLabel.Content += "Date reported: ";
                messageLabel.Content += message.dateReported.ToString("dd/MM/yy") + "\n";
                messageLabel.Content += "Sort code: ";
                messageLabel.Content += message.sortCode + "\n";
                messageLabel.Content += "Nature of incident: ";
                messageLabel.Content += message.natureOfIncident + "\n";
                messageLabel.Content += "Message body: " + "\n";
                messageBodyTb.Text = message.messageBody;
                
            }
            else if (m is Email)
            {
                Email message = (Email)m;
                messageLabel.Content += "Sender: ";
                messageLabel.Content += message.sender + "\n";
                messageLabel.Content += "Subject: ";
                messageLabel.Content += message.subject + "\n";
                messageLabel.Content += "Message body: " + "\n";
                messageBodyTb.Text = message.messageBody;
            }
            else if (m is SMS)
            {
                SMS message = (SMS)m;
                messageLabel.Content += "Sender: ";
                messageLabel.Content += message.sender + "\n";
                messageLabel.Content += "Message body: " + "\n";
                messageBodyTb.Text = message.messageBody;
            }
        }
       }
}