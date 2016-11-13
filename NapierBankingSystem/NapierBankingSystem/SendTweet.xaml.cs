using System;
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

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput())
            {
             
            }
        }

        private bool validateInput()
        {
            errorLbl.Content = "";
            bool canAdd = true;
            if (twitterHandleTextbox.Text.Length > 15 || String.IsNullOrEmpty(twitterHandleTextbox.Text))  
            {
                errorLbl.Content += "Twitter handle must be less than 15 characters \n";
                canAdd = false;
            }
            if (messageTextbox.Text.Length > 140 || String.IsNullOrEmpty(messageTextbox.Text)) 
            {
                errorLbl.Content += "Message cant be more than 140 characters \n";
                canAdd = false;
            }
            return canAdd;
            
        }
    }
}
